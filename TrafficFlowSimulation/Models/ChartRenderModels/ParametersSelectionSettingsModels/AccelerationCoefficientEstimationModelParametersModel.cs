using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;
using TrafficFlowSimulation.Models.ChartRenderModels.ParametersModels;
using TrafficFlowSimulation.Models.ChartRenderModels.ParametersModels.Constants;
using TrafficFlowSimulation.Windows.CustomControls;

namespace TrafficFlowSimulation.Models.ChartRenderModels.ParametersSelectionSettingsModels;

public class AccelerationCoefficientEstimationModelParametersModel : BasicParametersModel
{
	[Translation(Locales.ru, "Количество автомобилей")]
	[Translation(Locales.en, "Vehicles number")]
	[CustomDisplay(1, isReadOnly: true)]
	[Required, Range(1, 10000)]
	public override int n { get; set; }

	[Translation(Locales.ru, "Максимальная скорость")]
	[Translation(Locales.en, "Maximum speed")]
	[CustomDisplay(2, isReadOnly: true)]
	[Required]
	public override double Vmax { get; set; }

	[Hidden]
	public override object IsCarsIdentical { get; set; }

	[Hidden]
	public override string Vmax_multiple { get; set; }

	[Hidden]
	public override double tau { get; set; }

	[Hidden]
	public override string tau_multiple { get; set; }

	[Hidden]
	public override double a { get; set; }

	[Hidden]
	public override string a_multiple { get; set; }

	[Hidden]
	public override double q { get; set; }

	[Hidden]
	public override string q_multiple { get; set; }

	[Hidden]
	public override double l_safe { get; set; }

	[Hidden]
	public override string l_safe_multiple { get; set; }

	[Hidden]
	public override double l_car { get; set; }

	[Hidden] 
	public override string l_car_multiple { get; set; }

	[Hidden]
	public override double k { get; set; }

	[Hidden]
	public override string k_multiple { get; set; }

	public new void MapTo(ModelParameters mp)
	{
		base.MapTo(mp);
		mp.Vn = new List<double> { 0 };
		mp.lambda = new List<double> { 0 };
	}

	public override object GetDefault()
	{
		return new AccelerationCoefficientEstimationModelParametersModel
		{
			IsCarsIdentical = new ComboBoxItem
			{
				Text = IdenticalCars.Yes.GetDescription(),
				Value = IdenticalCars.Yes
			},
			n = 1,
			Vmax = 100 / 3.6
		};
	}
}