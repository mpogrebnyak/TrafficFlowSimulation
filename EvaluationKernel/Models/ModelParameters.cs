using System;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Models
{
	public class ModelParameters : ICloneable
	{
		public int n { get; set; }

		public double tau { get; set; }

		public double tau_b { get; set; }

		public List<double> a { get; set; }

		public List<double> q { get; set; }

		public List<double> Vmax { get; set; }

		public List<double> k { get; set; }

		public double mu { get; set; }

		public double g { get; set; }

		public List<double> lSafe { get; set; }

		public List<double> lCar { get; set; }

		public double L { get; set; }

		public List<double> lambda { get; set; }

		public List<double> Vn { get; set; }

		public ModelParameters()
		{
			Vmax = new List<double>();
			a = new List<double>();
			q = new List<double>();
			lSafe = new List<double>();
			lCar = new List<double>();
			k = new List<double>();
			Vn = new List<double>();
			lambda = new List<double>();
		}

		public object Clone()
		{
			return new ModelParameters
			{  
				n = n, 
				tau = tau,
				a = a,
				q = q,
				Vmax = Vmax,
				k = k,
				mu = mu,
				g = g,
				lSafe = lSafe,
				lCar = lCar,
				L = L,
				lambda = lambda,
				Vn = Vn
			};
		}
	}
}
