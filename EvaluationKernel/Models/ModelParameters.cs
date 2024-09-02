using System;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Models
{
	public class ModelParameters : ICloneable
	{
		/*
		Если потока 2, 
		то n - количество всего авто 
		n1 - в первом потоке,
		n2 - во втором,
		все остальные параметры лежат вместе в списках,
		сначала то, что отнисится к n, а затем к m 
		*/
		public int n { get; set; }

		public int n1 { get; set; }

		public int n2 { get; set; }

		public List<double> tau { get; set; }

		public List<double> tau_b { get; set; }

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
			tau = new List<double>();
			tau_b = new List<double>();
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
				n1 = n1,
				n2 = n2,
				tau = tau,
				tau_b = tau_b,
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
