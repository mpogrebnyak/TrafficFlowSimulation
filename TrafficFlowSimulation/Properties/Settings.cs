using System.ComponentModel;
using TrafficFlowSimulation.Constants;

namespace TrafficFlowSimulation.Properties
{
	public class Settings
	{
		public DrivingMode CurrentDrivingMode { get; set; }

		[DefaultValue("StartAndStopMovement, TrafficThroughOneTrafficLight, InliningInFlow")]
		public DrivingMode[] AvailableDrivingModes { get; set; }

		public ParametersSelectionMode CurrentParametersSelectionMode { get; set; }

		[DefaultValue("InliningDistance")]
		public ParametersSelectionMode[] AvailableParametersSelectionModes { get; set; }

		[DefaultValue("ColorCars")]
		public string PaintedCarsFolder { get; set; }
		
		[DefaultValue("*.bmp|*.bmp;|*.png|*.png;|*.jpg|*.jpg|*.emf|*.emf")]
		public string AvailableFileTypes { get; set; }

		[DefaultValue(4)]
		public int CarLength { get; set; }

		[DefaultValue("true")]
		public bool Test1 { get; set; }
		
		[DefaultValue(1)]
		public int Test2 { get; set; }
		
		[DefaultValue("1,2,3,4")]
		public string[] Test3 { get; set; }

		public int? Test4 { get; set; }
	}
}
