using System.Linq;
using System.Windows.Forms;
using TrafficFlowSimulation.Constants;

namespace TrafficFlowSimulation.Windows.Helpers;

public class ProgressBarHelper
{
	private readonly ToolStripProgressBar? _progressBar;
	private readonly Control _form;

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

	public void Update(int value)
	{
		if (_progressBar == null)
			return;

		MethodInvoker action = delegate
		{
			_progressBar.Value = value;
		};

		if (_form.InvokeRequired)
			_form.Invoke(action);
	}
}