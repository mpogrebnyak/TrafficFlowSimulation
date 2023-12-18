using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using ChartRendering.Constants;
using ChartRendering.Events;
using Microsoft.Practices.ServiceLocation;
using TrafficFlowSimulation.Windows;

namespace TrafficFlowSimulation.Handlers;

public static class FormUpdateHandler
{
	private static MainWindow _form;

	public static event ChartEventHandler ChartEventHandler;

	public static void Initialize(MainWindow form)
	{
		_form = form;
		ChartEventHandler += MainForm_ChartEventHandler;
	}

	public static ChartEventHandler GetEvent()
	{
		return ChartEventHandler;
	}

	private static void MainForm_ChartEventHandler(List<ChartEventActions> actions, ChartEventHandlerArgs e)
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
	}

	private static void ChartEventHandlerInternal(ChartEventActions action, ChartEventHandlerArgs e)
	{
		switch (action)
		{
			case ChartEventActions.UpdateCharts:
			{
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>().UpdateCharts(e.Coordinates);
				return;
			}

			case ChartEventActions.UpdateChartEnvironments:
			{
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>().UpdateChartEnvironments(e.EnvironmentArgs);
				return;
			}

			default:
			{
				return;
			}
		}
	}
}