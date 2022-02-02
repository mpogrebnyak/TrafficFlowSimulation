using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrafficFlowSimulation.Commands.Rendering
{
    public static class CarsRenderingHelper
    {
        public static void CreatePaintedCars()
        {
            var carsFolder = Resources.Settings.PaintedCarsFolder;
            if (!Directory.Exists(carsFolder)) Directory.CreateDirectory(carsFolder);

            var bmp = Properties.Resources.white_car;

            var colors = GetColors(ChartColorPalette.BrightPastel);

            foreach (var newColor in colors)
            {
                Color actualColor;
                Bitmap newBitmap = new Bitmap(bmp.Width, bmp.Height);
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        actualColor = bmp.GetPixel(i, j);
                        if (actualColor.R == 255)
                            newBitmap.SetPixel(i, j, newColor);
                        else
                            newBitmap.SetPixel(i, j, actualColor);
                    }
                }

                newBitmap.SetResolution(200, 200);

                newBitmap.Save(carsFolder + "\\" + newColor.Name + ".png");
            }
        }

        private static List<Color> GetColors(ChartColorPalette chartColorPalette)
        {
            switch (chartColorPalette)
            {
                case ChartColorPalette.BrightPastel:
                    return new List<Color>
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

                    };

                default:
                    return new List<Color> { Color.White };

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
    }
}
