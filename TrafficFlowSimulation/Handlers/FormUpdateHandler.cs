using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartRendering.Constants;
using ChartRendering.Events;
using Microsoft.Practices.ServiceLocation;

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

	private void Form_ChartEventHandler(List<ChartEventActions> actions, ChartEventHandlerArgs e)
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

	private void ChartEventHandlerInternal(ChartEventActions action, ChartEventHandlerArgs e)
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
				ServiceLocator.Current.GetInstance<ChartRenderingHandler>(_key).UpdateScale(e.Coordinates);
				return;
			}

			default:
			{
				return;
			}
		}
	}

	private void ChartEventHandlerExternal(ChartEventActions action, ChartEventHandlerArgs e)
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