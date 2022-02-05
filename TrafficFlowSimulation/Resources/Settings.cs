using System.ComponentModel;

namespace TrafficFlowSimulation.Resources
{
	public class Settings
	{
		[DefaultValue("ColorCars")]
		public string PaintedCarsFolder { get; set; }
		
		[DefaultValue("true")]
		public bool Test1 { get; set; }
		
		[DefaultValue(1)]
		public int Test2 { get; set; }
		
		[DefaultValue("1,2,3,4")]
		public string[] Test3 { get; set; }

		public int? Test4 { get; set; }
	}
}
