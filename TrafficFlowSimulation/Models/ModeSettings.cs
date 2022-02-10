using TrafficFlowSimulation.Сonstants;

namespace TrafficFlowSimulation.Models
{
	public class ModeSettings
	{
		public AutoScroll AutoScroll { get; set; }
		public int ScrollFor { get; set; }

		public void MapTo(int scroll, decimal scrollFor)
		{
			AutoScroll = GetScroll(scroll);
			ScrollFor = (int)scrollFor;
		}

		private AutoScroll GetScroll(int scroll)
		{
			return scroll == 0 ? AutoScroll.Yes : AutoScroll.No;
		}
	}
}