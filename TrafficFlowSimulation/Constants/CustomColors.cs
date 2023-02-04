﻿using System.Collections.Generic;
using System.Drawing;

namespace TrafficFlowSimulation.Constants;

public static class CustomColors
{
	public static Color Red = Color.FromArgb(0xe0, 0x40, 10);

	public static Color Blue = Color.FromArgb(0x41, 140, 240);

	public static Color BrightRed = Color.FromArgb(255, 0, 0);

	public static Color LightRed = Color.FromArgb(255, 102, 102);

	public static Color Orange = Color.FromArgb(255, 153, 102);

	public static Color LightOrange = Color.FromArgb(255, 204, 153);

	public static Color LightGreen = Color.FromArgb(204, 255, 153);

	public static Color Green = Color.FromArgb(0, 255, 0);

	public static Color Black = Color.FromArgb(0, 0, 0);

	public static List<Color> GetColorsForInliningDistanceEstimation()
	{
		return new List<Color>
		{
			BrightRed,
			LightRed,
			Orange,
			LightOrange,
			LightGreen,
			Green,
			Black
		};
	}

	public static List<Color> GetColorsForAccelerationCoefficientEstimation()
	{
		return new List<Color>
		{
			BrightRed,
			Green
		};
	}
}