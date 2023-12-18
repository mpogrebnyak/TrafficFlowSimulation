using ChartRendering.Attribute;

// ReSharper disable InconsistentNaming

namespace ChartRendering.ChartRenderModels.ParametersModels;

public class SpeedLimitChangingModeParametersModel : BaseParametersModel
{
	[Hidden]
	public override double Vmax { get; set; }

	[Hidden]
	public override string Vmax_multiple { get; set; }
}