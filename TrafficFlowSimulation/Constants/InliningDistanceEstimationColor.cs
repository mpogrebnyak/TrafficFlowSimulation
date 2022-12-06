using System.Collections.Generic;
using System.Drawing;

namespace TrafficFlowSimulation.Constants;

public static class InliningDistanceEstimationColor
{
	public static Color Red = Color.FromArgb(255, 0, 0);
	public static Color LightRed = Color.FromArgb(255, 102, 102);
	public static Color Orange = Color.FromArgb(255, 153, 102);
	public static Color LightOrange = Color.FromArgb(255, 204, 153);
	public static Color LightGreen = Color.FromArgb(204, 255, 153);
	public static Color Green = Color.FromArgb(0, 255, 0);

	public static Color Black = Color.FromArgb(0, 0, 0);

	public static List<Color> GetAllColors()
	{
		return new List<Color>()
		{
			Red,
			LightRed,
			Orange,
			LightOrange,
			LightGreen,
			Green,
			Black
		};
	}
	//Color.Red, Color.Chartreuse, Color.Blue, Color.Coral, Color.Fuchsia, Color.DarkViolet};

}