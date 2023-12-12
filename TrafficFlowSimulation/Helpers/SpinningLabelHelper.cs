using System.Linq;
using System.Windows.Forms;
using TrafficFlowSimulation.Constants;
using TrafficFlowSimulation.Properties;

namespace TrafficFlowSimulation.Windows.Helpers;

public class SpinningLabelHelper
{
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

	public void StartSpinning()
	{
		if (_label == null)
			return;

		MethodInvoker action = delegate
		{
			_label.Image = Resources.gear;
		};

		if (_form.InvokeRequired)
			_form.Invoke(action);
	}

	public void StopSpinning()
	{
		if (_label == null)
			return;

		MethodInvoker action = delegate
		{
			_label.Image = Resources.gear_static;
			_label.ToolTipText = null;
		};

		if (_form.InvokeRequired)
			_form.Invoke(action);
	}

	public void UpdateSpinningToolTip(int value)
	{
		if (_label == null)
			return;

		MethodInvoker action = delegate
		{
			_label.ToolTipText = value.ToString();
		};

		if (_form.InvokeRequired)
			_form.Invoke(action);
	}
}