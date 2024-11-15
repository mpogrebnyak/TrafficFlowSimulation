﻿using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Constants;
using Settings;

namespace ChartRendering.Renders
{
	public static class CarsRenderingHelper
	{
		public static readonly Dictionary<BitmapName, Bitmap> BitmapResources = new()
		{
			{new BitmapName {Name = "white_car", Value = 4}, Properties.Resources.white_car},
			{new BitmapName {Name = "white_truck", Value = 8}, Properties.Resources.white_truck}
		};

		private static readonly string CarsFolder = SettingsHelper.Get<Properties.ChartRenderingSettings>().PaintedCarsFolder;

		public static void CreatePaintedCars()
		{
			DeleteFolder();
			Directory.CreateDirectory(CarsFolder);
			var directory = new DirectoryInfo(CarsFolder);

			foreach (var bitmapResource in BitmapResources)
			{
				var bmp = bitmapResource.Value;

				var colorPalettes = GetColors();

				foreach (var colorPalette in colorPalettes)
				{
					directory.CreateSubdirectory(colorPalette.PaletteName);

					foreach (var newColor in colorPalette.Colors)
					{
						var coloredBmp = new Bitmap(bmp.Width, bmp.Height);
						for (var i = 0; i < bmp.Width; i++)
						{
							for (var j = 0; j < bmp.Height; j++)
							{
								var actualColor = bmp.GetPixel(i, j);
								if (actualColor.R == 255)
									coloredBmp.SetPixel(i, j, newColor);
								else
									coloredBmp.SetPixel(i, j, actualColor);
							}
						}

						var subDirectory = directory.GetDirectories().Single(x => x.Name == colorPalette.PaletteName);
						var outputFileName = subDirectory.FullName + "\\" + bitmapResource.Key.Name + "_" + newColor.Name + ".png";
						using (MemoryStream memory = new MemoryStream())
						{
							using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
							{
								coloredBmp.Save(memory, ImageFormat.Png);
								var bytes = memory.ToArray();
								fs.Write(bytes, 0, bytes.Length);
							}
						}
					}
				}
			}
		}

		public static void DeleteFolder()
		{
			if (Directory.Exists(CarsFolder))
				Directory.Delete(CarsFolder, true);
		}

		private static List<ColorPalette> GetColors()
		{
			return new List<ColorPalette>
			{
				new ColorPalette
				{
					PaletteName = ChartColorPalette.BrightPastel.ToString(),
					Colors = new List<Color>
					{
						Color.FromArgb(0x41, 140, 240),
						Color.FromArgb(0xfc, 180, 0x41),
						Color.FromArgb(0xe0, 0x40, 10),
						Color.FromArgb(5, 100, 0x92),
						Color.FromArgb(0xbf, 0xbf, 0xbf),
						Color.FromArgb(0x1a, 0x3b, 0x69),
						Color.FromArgb(0xff, 0xe3, 130),
						Color.FromArgb(0x12, 0x9c, 0xdd),
						Color.FromArgb(0xca, 0x6b, 0x4b),
						Color.FromArgb(0, 0x5c, 0xdb),
						Color.FromArgb(0xf3, 210, 0x88),
						Color.FromArgb(80, 0x63, 0x81),
						Color.FromArgb(0xf1, 0xb9, 0xa8),
						Color.FromArgb(0xe0, 0x83, 10),
						Color.FromArgb(120, 0x93, 190)
					}
				},
				new ColorPalette
				{
					PaletteName = "RedAndBlue",
					Colors = new List<Color>
					{
						CustomColors.Red,
						CustomColors.Blue,
						CustomColors.DarkGreen
					}
				}
			};
			//var Berry = { Color.BlueViolet, MediumOrchid, RoyalBlue, MediumVioletRed, Blue, BlueViolet, Orchid, MediumSlateBlue, ARGB(0xc0, 0, 0xc0), MediumBlue, Purple }
			//BrightPastel = { ARGB(0x41, 140, 240), ARGB(0xfc, 180, 0x41), ARGB(0xe0, 0x40, 10), ARGB(5, 100, 0x92), ARGB(0xbf, 0xbf, 0xbf), ARGB(0x1a, 0x3b, 0x69), ARGB(0xff, 0xe3, 130), ARGB(0x12, 0x9c, 0xdd), ARGB(0xca, 0x6b, 0x4b), ARGB(0, 0x5c, 0xdb), ARGB(0xf3, 210, 0x88), ARGB(80, 0x63, 0x81), ARGB(0xf1, 0xb9, 0xa8), ARGB(0xe0, 0x83, 10), ARGB(120, 0x93, 190) }
			//Chocolate = { Sienna, Chocolate, DarkRed, Peru, Brown, SandyBrown, SaddleBrown, ARGB(0xc0, 0x40, 0), Firebrick, ARGB(0xb6, 0x5c, 0x3a) }
			//Default = { Green, Blue, Purple, Lime, Fuchsia, Teal, Yellow, Gray, Aqua, Navy, Maroon, Red, Olive, Silver, Tomato, Moccasin }
			//Earth = { ARGB(0xff, 0x80, 0), DarkGoldenrod, ARGB(0xc0, 0x40, 0), OliveDrab, Peru, ARGB(0xc0, 0xc0, 0), ForestGreen, Chocolate, Olive, LightSeaGreen, SandyBrown, ARGB(0, 0xc0, 0), DarkSeaGreen, Firebrick, SaddleBrown, ARGB(0xc0, 0, 0) }
			//Excel = { ARGB(0x99, 0x99, 0xff), ARGB(0x99, 0x33, 0x66), ARGB(0xff, 0xff, 0xcc), ARGB(0xcc, 0xff, 0xff), ARGB(0x66, 0, 0x66), ARGB(0xff, 0x80, 0x80), ARGB(0, 0x66, 0xcc), ARGB(0xcc, 0xcc, 0xff), ARGB(0, 0, 0x80), ARGB(0xff, 0, 0xff), ARGB(0xff, 0xff, 0), ARGB(0, 0xff, 0xff), ARGB(0x80, 0, 0x80), ARGB(0x80, 0, 0), ARGB(0, 0x80, 0x80), ARGB(0, 0, 0xff) }
			//Fire = { Gold, Red, DeepPink, Crimson, DarkOrange, Magenta, Yellow, OrangeRed, MediumVioletRed, ARGB(0xdd, 0xe2, 0x21) }
			//Light = { Lavender, LavenderBlush, PeachPuff, LemonChiffon, MistyRose, Honeydew, AliceBlue, WhiteSmoke, AntiqueWhite, LightCyan }
			//Pastel = { SkyBlue, LimeGreen, MediumOrchid, LightCoral, SteelBlue, YellowGreen, Turquoise, HotPink, Khaki, Tan, DarkSeaGreen, CornflowerBlue, Plum, CadetBlue, PeachPuff, LightSalmon }
			//SeaGreen = { SeaGreen, MediumAquamarine, SteelBlue, DarkCyan, CadetBlue, MediumSeaGreen, MediumTurquoise, LightSteelBlue, DarkSeaGreen, SkyBlue }
			//SemiTransparent = { ARGB(150, 0xff, 0, 0), ARGB(150, 0, 0xff, 0), ARGB(150, 0, 0, 0xff), ARGB(150, 0xff, 0xff, 0), ARGB(150, 0, 0xff, 0xff), ARGB(150, 0xff, 0, 0xff), ARGB(150, 170, 120, 20), ARGB(80, 0xff, 0, 0), ARGB(80, 0, 0xff, 0), ARGB(80, 0, 0, 0xff), ARGB(80, 0xff, 0xff, 0), ARGB(80, 0, 0xff, 0xff), ARGB(80, 0xff, 0, 0xff), ARGB(80, 170, 120, 20), ARGB(150, 100, 120, 50), ARGB(150, 40, 90, 150) }
			//Палитра оттенков серого определяется: gray value = 200 - (
		}

		private class ColorPalette
		{
			public string PaletteName { get; set; }

			public List<Color> Colors { get; set; }
		}

		public class BitmapName
		{
			public string Name { get; set; }

			public int Value { get; set; }
		}
	}
}
