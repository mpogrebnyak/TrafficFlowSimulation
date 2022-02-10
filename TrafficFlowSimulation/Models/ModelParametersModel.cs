using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TrafficFlowSimulation.Commands;

namespace TrafficFlowSimulation.Models
{
	public class ModelParametersModel : ValidationModel
	{
		[Required]
		[Range(1, 10000)]
		public int n { get; set; }

		[Required]
		public double single_Vmax { get; set; }

		public string multiple_Vmax { get; set; }

		[Required]
		public double tau { get; set; }

		[Required]
		public double a { get; set; }

		[Required]
		public double q { get; set; }

		[Required]
		public double Vmin { get; set; }

		public double[] lambda { get; set; }
		public double k { get; set; }
		public double mu { get; set; }

		public double g { get; set; }

		public double l { get; set; }

		public double L { get; set; }

		public double p { get; set; }

		public double s { get; set; }
	}
}