using System;
using System.Collections.Generic;
using ChartRendering.Constants;
using ChartRendering.Models;
using EvaluationKernel.Models;

namespace ChartRendering.Events;

public delegate void ChartEventHandler(List<ChartEventActions> actions, EventHandlerArgs e);

public abstract class EventHandlerArgs : EventArgs
{
}

public class SaveChartEventHandlerArgs : EventHandlerArgs
{
	public string FileName { get; set; }

	public SaveChartEventHandlerArgs(string fileName)
	{
		FileName = fileName;
	}
}

public class ChartEventHandlerArgs : EventHandlerArgs
{
	public CoordinatesArgs Coordinates { get; set; }

	public EnvironmentArgsBase EnvironmentArgs { get; set; }

	public ChartEventHandlerArgs(CoordinatesArgs coordinates, EnvironmentArgsBase environment = null)
	{
		Coordinates = coordinates;
		EnvironmentArgs = environment;
	}
}

public class AddChartEventHandlerArgs : EventHandlerArgs
{
	public ModelParameters ModelParameters { get; set; }
	public int Index { get; set; }

	public AddChartEventHandlerArgs(ModelParameters modelParameters, int index)
	{
		ModelParameters = modelParameters;
		Index = index;
	}
}


public class ChartEventHandlerWithSavingArgs : SaveChartEventHandlerArgs
{
	public SerializerPointsModel SerializerData { get; set; }

	public ChartEventHandlerWithSavingArgs(string fileName, SerializerPointsModel serializerData) : base(fileName)
	{
		SerializerData = serializerData;
	}
}