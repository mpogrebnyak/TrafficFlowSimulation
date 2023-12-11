using TrafficFlowSimulation.Models.Attribute;

namespace TrafficFlowSimulation.Models.ChartRenderModels.ParametersModels;

public class SpeedLimitChangingModeParametersModel : BasicParametersModel
{
	[Hidden]
	public override double Vmax { get; set; }

	[Hidden]
	public override string Vmax_multiple { get; set; }
}