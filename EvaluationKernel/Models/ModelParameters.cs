using System.Collections.Generic;

namespace EvaluationKernel.Models
{
	public class ModelParameters
	{
		public int n { get; set; }

		public double tau { get; set; }

		public List<double> a { get; set; }

		public List<double> q { get; set; }

		public List<double> Vmax { get; set; }

		public double Vmin { get; set; }

		public List<double> k { get; set; }

		public double mu { get; set; }

		public double g { get; set; }

		public List<double> l { get; set; }

		public double L { get; set; }

		public List<double> s { get; set; }

		public double eps { get; set; }

		public List<double> lambda { get; set; }

		public List<double> Vn { get; set; }

		public ModelParameters()
		{
			Vmax = new List<double>();
			a = new List<double>();
			q = new List<double>();
			l = new List<double>();
			k = new List<double>();
			s = new List<double>();
			Vn = new List<double>();
			lambda = new List<double>();
		}
	}
}
