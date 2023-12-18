namespace ChartRendering.Models;

public class InliningDistanceEstimationCoordinatesModel : CoefficientEstimationCoordinatesModel
{
	public double Intensity { get; set; }

	public bool IsIntensityChangedToZero { get; set; }
}