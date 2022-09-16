using System;
using System.Linq;
using System.Windows.Forms;
using TrafficFlowSimulation.Constants;

namespace TrafficFlowSimulation.Windows.Components;

public class SlamPanelComponent : IComponent
{
	private readonly Control.ControlCollection _controls;

	public SlamPanelComponent(Control.ControlCollection controls)
	{
		_controls = controls;
	}

	public void Initialize()
	{
		if (_controls.Find(ControlName.CommonControlName.SlamPanelName, true).Single() is Panel slamPanel) 
			slamPanel.MouseClick += SlamPanel_MouseClick;
	}

	private void SlamPanel_MouseClick(object sender, EventArgs e)
	{
		if (_controls.Find(ControlName.CommonControlName.ParametersPanelName, true).Single() is not Panel parametersPanel)
			return;

		if (parametersPanel.Visible)
			parametersPanel.Hide();
		else
			parametersPanel.Show();
	}
}