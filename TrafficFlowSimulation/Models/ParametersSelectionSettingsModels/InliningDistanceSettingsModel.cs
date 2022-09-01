using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EvaluationKernel.Models;
using Localization.Localization;
using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Models.ParametersSelectionSettingsModels;

public class InliningDistanceSettingsModel : BaseSettingsModels
{
	[Hidden] 
	public override double L { get; set; }

	[Translation(Locales.ru, "Скорость второго автомобиля")]
	[Translation(Locales.en, "Follower car speed")]
	[CustomDisplay(1)]
	public double FollowerCarSpeed { get; set; }

	[Translation(Locales.ru, "Положение второго автомобиля")]
	[Translation(Locales.en, "Follower car position")]
	[CustomDisplay(1)]
	public double FollowerCarDistance { get; set; }

	public override void MapTo(ModelParameters mp)
	{
		mp.L = L;
		mp.Vn = new List<double> {0, FollowerCarSpeed};
		mp.lambda = new List<double> {0, -FollowerCarDistance};
	}

	public override object GetDefault()
	{
		return new InliningDistanceSettingsModel
		{
			L = 1000,
			FollowerCarSpeed = 16.7,
			FollowerCarDistance = 20
		};
	}
}