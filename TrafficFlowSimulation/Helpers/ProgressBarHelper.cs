using System;
using System.Linq;
using System.Windows.Forms;
using TrafficFlowSimulation.Constants;

namespace TrafficFlowSimulation.Windows.Helpers;

public class ProgressBarHelper
{
	private readonly ToolStripProgressBar? _progressBar;
	private readonly Control _form;

	private double currentValue = 0;
	public ProgressBarHelper(Control form)
	{
		_form = form;
		_progressBar = (form.Controls
				.Find(ControlName.ParametersSelectionWindowControlName.ControlMenuStrip, true)
				.Single() as ToolStrip
			)?.Items
			.Find(ControlName.ParametersSelectionWindowControlName.ToolStripProgressBar, true)
			.Single() as ToolStripProgressBar;

		if (_progressBar == null)
			return;

		MethodInvoker action = delegate
		{
			_progressBar.Minimum = 0;
			_progressBar.Maximum = 0;
			_progressBar.Value = 0; 
		};

		if (_form.InvokeRequired)
			_form.Invoke(action);
	}

	public void SetMaximum(int max)
	{
		if (_progressBar == null)
			return;

		MethodInvoker action = delegate
		{
			_progressBar.Maximum = max;
		};

		if (_form.InvokeRequired)
			_form.Invoke(action);
	}

	public void Update(double value)
	{
		if (_progressBar == null)
			return;

		currentValue += value;
		var newValue = currentValue < _progressBar.Maximum
			? (int) currentValue
			: _progressBar.Maximum;

		var percent = 100 * Math.Round(currentValue / _progressBar.Maximum, 4);
		var toolTipText = percent <= 100
			? percent + "%"
			: "100%";
		MethodInvoker action = delegate
		{
			_progressBar.Value = newValue;
			_progressBar.ToolTipText = toolTipText;
		};

		if (_form.InvokeRequired)
			_form.Invoke(action);
	}
}