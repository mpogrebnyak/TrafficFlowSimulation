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
		public double Vmax { get; set; }

		public string Vmax_multiple { get; set; }

		[Required]
		public double tau { get; set; }

		public string tau_multiple { get; set; }

		[Required]
		public double a { get; set; }

		public string a_multiple { get; set; }

		[Required]
		public double q { get; set; }

		public string q_multiple { get; set; }

		[Required]
		public double l { get; set; }

		public string l_multiple { get; set; }

		[Required]
		public double k { get; set; }

		public string k_multiple { get; set; }

		[Required]
		public double s { get; set; }

		public string s_multiple { get; set; }

		[Required]
		public double Vmin { get; set; }

		public double[] lambda { get; set; }

		public double mu { get; set; }

		public double g { get; set; }

		public double Lenght { get; set; }
	}
}