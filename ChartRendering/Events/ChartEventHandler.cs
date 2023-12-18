using System;
using System.Collections.Generic;
using ChartRendering.Constants;
using ChartRendering.Models;

namespace ChartRendering.Events;

public delegate void ChartEventHandler(List<ChartEventActions> actions, ChartEventHandlerArgs e);

public class ChartEventHandlerArgs : EventArgs
{
	public CoordinatesArgs Coordinates { get; set; }

	public EnvironmentArgsBase EnvironmentArgs { get; set; }

	public ChartEventHandlerArgs(CoordinatesArgs coordinates, EnvironmentArgsBase environment = null)
	{
		Coordinates = coordinates;
		EnvironmentArgs = environment;
	}
}