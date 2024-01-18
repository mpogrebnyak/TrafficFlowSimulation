using ChartRendering.Attribute;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace ChartRendering.ChartRenderModels.ParametersModels;

public class SpeedLimitChangingInitialConditionsParametersModel : InitialConditionsParametersModel
{
	[Hidden]
	public double Vn { get; set; }

	[Hidden]
	public string Vn_multiple { get; set; }

	[Hidden]
	public double lambda { get; set; }

	[Hidden]
	public string lambda_multiple { get; set; }
}