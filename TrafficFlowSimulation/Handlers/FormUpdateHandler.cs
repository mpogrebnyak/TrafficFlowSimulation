using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Constants;
using ChartRendering.Events;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Helpers;

namespace TrafficFlowSimulation.Handlers;

public class FormUpdateHandler
{
	private readonly Form _form;

	private readonly string _key;

	public event ChartEventHandler ChartEventHandler;

	public FormUpdateHandler(Form form, string key)
	{
		_form = form;
		_key = key;
		ChartEventHandler += Form_ChartEventHandler;
	}

	public ChartEventHandler GetEvent()
	{
		return ChartEventHandler;
	}

	private void Form_ChartEventHandler(List<ChartEventActions> actions, EventHandlerArgs e)
	{
		void Method()
		{
			foreach (var action in actions)
			{
				ChartEventHandlerInternal(action, e);
			}

			Thread.Sleep(20);
			Application.DoEvents();
		}

		_form.Invoke((MethodInvoker) Method);

		foreach (var action in actions)
		{
			ChartEventHandlerExternal(action, e);
		}
	}

	private void ChartEventHandlerInternal(ChartEventActions action, EventHandlerArgs e)
	{
		switch (action)
		{
			case ChartEventActions.UpdateCharts:
			{
				var args = (ChartEventHandlerArgs) e;
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(_key).UpdateCharts(args.Coordinates);
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(_key).UpdateScale(args.Coordinates);
				return;
			}

			case ChartEventActions.UpdateChartEnvironments:
			{
				var args = (ChartEventHandlerArgs) e;
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(_key).UpdateChartEnvironments(args.EnvironmentArgs);
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(_key).UpdateScale(args.Coordinates);
				return;
			}

			default:
			{
				return;
			}
		}
	}

	private void ChartEventHandlerExternal(ChartEventActions action, EventHandlerArgs e)
	{
		switch (action)
		{
			case ChartEventActions.SaveChart:
			{
				var args = (SaveChartEventHandlerArgs) e;
				var charts = _form.Controls.OfType<Chart>().ToList();
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(_key).SaveCharts(charts, args.FileName);
				return;
			}

			case ChartEventActions.SaveChartPoints:
			{
				var args = (ChartEventHandlerWithSavingArgs) e;
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(_key).SaveCoordinates(args.SerializerData, args.FileName);
				return;
			}

			case ChartEventActions.DisplayExecution:
			{
				ServiceLocator.Current.GetInstance<SpinningLabelHelper>(_key).Switch();
				return;
			}

			default:
			{
				return;
			}
		}
	}
}