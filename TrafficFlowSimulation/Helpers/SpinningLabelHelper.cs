using System.Linq;
using System.Windows.Forms;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Properties;

namespace TrafficFlowSimulation.Helpers;

public class SpinningLabelHelper
{
	private bool _enabled;

	private readonly ToolStripLabel? _label;

	private readonly Control _form;

	public SpinningLabelHelper(Form form)
	{
		_form = form;
		_label = (form.Controls
				.Find(ControlName.ParametersSelectionWindowControlName.ControlMenuStrip, true)
				.Single() as ToolStrip
			)?.Items
			.Find(ControlName.ParametersSelectionWindowControlName.ToolStripLoadingLabel, true)
			.Single() as ToolStripLabel;
	}

	public void Switch()
	{
		if (_enabled)
		{
			StopSpinning();
			_enabled = false;
		}
		else
		{
			StartSpinning();
			_enabled = true;
		}
	}

	private void StartSpinning()
	{
		if (_label == null)
			return;

		void Action()
		{
			_label.Image = Resources.gear;
		}

		if (_form.InvokeRequired)
			_form.Invoke((MethodInvoker) Action);
	}

	private void StopSpinning()
	{
		if (_label == null)
			return;

		void Action()
		{
			_label.Image = Resources.gear_static;
			_label.ToolTipText = null;
		}

		if (_form.InvokeRequired)
			_form.Invoke((MethodInvoker) Action);
	}
}