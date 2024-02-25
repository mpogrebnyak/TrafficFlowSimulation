using System.Collections.Generic;
using System.Linq;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
// ReSharper disable InconsistentNaming

namespace EvaluationKernel
{
	public class RungeKuttaMethod
	{
		private const double _h = 0.001;

		private readonly int _n;

		private readonly Equation _equation;

		private readonly List<List<double>> x;
		private readonly List<List<double>> y;
		private List<double> t;
		private readonly List<int> N;

		public RungeKuttaMethod(ModelParameters modelParameters, Equation equation)
		{
			_equation = equation;

			_n = modelParameters.n;
			t = new List<double>();
			x = new List<List<double>>();
			y = new List<List<double>>();
			N = new List<int>();

			SetInitialConditions(modelParameters);
		}


		private void SetInitialConditions(ModelParameters modelParameters)
		{
			for (var i = 0; i < _n; i++)
			{
				x.Add(new List<double>());
				y.Add(new List<double>());
			}

			foreach (var tau in modelParameters.tau)
			{
				N.Add((int)(tau / _h));
			}

			for (var i = 0; i < N.Max(); i++)
			{
				t.Add((i - N.Max()) * _h);
				for (var j = 0; j < _n; j++)
				{
					x[j].Add(modelParameters.lambda[j]);
					y[j].Add(modelParameters.Vn[j]);
				}
			}
		}

		public void SetInitialConditions(List<double> Vn, List<double> lambda)
		{
			for (var i = 0; i < N.Max(); i++)
			{
				for (var j = 0; j < _n; j++)
				{
					x[j].Add(lambda[j]);
					y[j].Add(Vn[j]);
				}
			}
		}

		public List<double> T
		{
			get { return t; }
			set => t = value;
		}

		public List<double> X(int i)
		{
			return x[i];
		}

		public List<double> Y(int i)
		{
			return y[i];
		}

		double f(int i)
		{
			return y[i][y[i].Count - 1];
		}

		double g(int i)
		{
			return _equation.GetEquation(i, x, y, N);
		}

		public void Solve()
		{
			var k1 = new double[_n];
			var k2 = new double[_n];
			var k3 = new double[_n];
			var k4 = new double[_n];
			var q1 = new double[_n];
			var q2 = new double[_n];
			var q3 = new double[_n];
			var q4 = new double[_n];
			for (var i = 0; i < _n; i++)
			{
				k1[i] = _h * f(i);
				k2[i] = _h * (f(i)+k1[i] / 2);
				k3[i] = _h * (f(i)+k2[i] / 2);
				k4[i] = _h * (f(i)+k3[i]);
				q1[i] = _h * g(i);
				if (i == 0)
				{
					q2[i] = _h * (g(i)-q1[i] / 2);
					q3[i] = _h * (g(i)-q2[i] / 2);
					q4[i] = _h * (g(i)-q3[i]);
				}
				else
				{
					q2[i] = _h * (g(i)+q1[i - 1] / 2 - q1[i] / 2);
					q3[i] = _h * (g(i)+q2[i - 1] / 2- q2[i] / 2);
					q4[i] = _h * (g(i)+q3[i - 1]- q3[i]);
				}

				x[i].Add(x[i][x[i].Count - 1] + (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]) / 6);
				y[i].Add(y[i][y[i].Count - 1] + (q1[i] + 2 * q2[i] + 2 * q3[i] + q4[i]) / 6);

				x[i].RemoveAt(0);
				y[i].RemoveAt(0);
			}

			t.Add(t[t.Count - 1] + _h);
			t.RemoveAt(0);
		}
	}
}
