using ChartRendering.ChartRenderModels.SettingsModels;

namespace ChartRendering.EvaluationHandlers.MovementSimulationEvaluationHandlers;

public class RoadHoleEvaluationHandler : SpeedLimitChangingEvaluationHandler
{
	protected override void Evaluate(object parameters)
	{
		var p = (Parameters) parameters;
		var modeSettings = (RoadHoleModeSettingsModel) p.ModeSettings;

		modeSettings.SegmentBeginning = "1:0" + " 2:" + modeSettings.SegmentLenght + " 3:" + modeSettings.L;
		modeSettings.SpeedInSegment = "1:" + modeSettings.SegmentSpeed + " 2:" + modeSettings.InitialSpeed + " 3:" + modeSettings.InitialSpeed;

		base.Evaluate(parameters);
	}
}