using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Constants;
using ChartRendering.Events;
using Microsoft.Practices.ServiceLocation;

namespace TrafficFlowSimulation.Handlers;

public static class FormUpdateHandler
{
	private static Form _form;

	private static string _key;

	public static event ChartEventHandler ChartEventHandler;

	public static void Initialize(Form form, string key)
	{
		_form = form;
		_key = key;
		ChartEventHandler += Form_ChartEventHandler;
	}

	public static ChartEventHandler GetEvent()
	{
		return ChartEventHandler;
	}

	private static void Form_ChartEventHandler(List<ChartEventActions> actions, ChartEventHandlerArgs e)
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

	private static void ChartEventHandlerInternal(ChartEventActions action, ChartEventHandlerArgs e)
	{
		switch (action)
		{
			case ChartEventActions.UpdateCharts:
			{
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(_key).UpdateCharts(e.Coordinates);
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(_key).UpdateScale(e.Coordinates);
				return;
			}

			case ChartEventActions.UpdateChartEnvironments:
			{
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(_key).UpdateChartEnvironments(e.EnvironmentArgs);
				return;
			}

			default:
			{
				return;
			}
		}
	}

	private static void ChartEventHandlerExternal(ChartEventActions action, ChartEventHandlerArgs e)
	{
		switch (action)
		{
			case ChartEventActions.SaveChart:
			{
				var charts = _form.Controls.OfType<Chart>().ToList();
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(_key).SaveCharts(charts);
				return;
			}

			default:
			{
				return;
			}
		}
	}
}