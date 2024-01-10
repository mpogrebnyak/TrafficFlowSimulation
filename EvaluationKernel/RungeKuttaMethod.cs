using System.Collections.Generic;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;
// ReSharper disable InconsistentNaming

namespace EvaluationKernel
{
	public class RungeKuttaMethod
	{
		const double _h = 0.001;

		private int _N, _n;

		private Equation _equation;

		List<List<double>> x;
		List<List<double>> y;
		List<double> t;

		List<int> CarNumberToStop = new List<int>(); 

		public RungeKuttaMethod(ModelParameters modelParameters, Equation equation)
		{
			_n = modelParameters.n;
			_N = (int) modelParameters.tau != 0
				? (int) (modelParameters.tau / _h)
				: 1;
			_equation = equation;

			t = new List<double>();
			x = new List<List<double>>();
			y = new List<List<double>>();

			SetInitialConditions(modelParameters);
		}

		private void SetInitialConditions(ModelParameters modelParameters)
		{
			for (var i = 0; i < _n; i++)
			{
				x.Add(new List<double>());
				y.Add(new List<double>());
			}

			for (var i = 0; i < _N; i++)
			{
				t.Add((i - _N) * _h);
				for (var j = 0; j < _n; j++)
				{
					x[j].Add(modelParameters.lambda[j]);
					y[j].Add(modelParameters.Vn[j]);
				}
			}
		}

		public void SetInitialConditions(List<double> Vn, List<double> lambda)
		{
			for (int i = 0; i < _N; i++)
			{
				for (int j = 0; j < _n; j++)
				{
					x[j].Add(lambda[j]);
					y[j].Add(Vn[j]);
				}
			}
		}

		public Equation Equation
		{
			set => _equation = value;
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

		public void SetCarNumberToStop(List<int> carsNumber)
		{
			CarNumberToStop = carsNumber;
		}

		double f(int i)
		{
			return y[i][y[i].Count - 1];
		}

		double g(int i)
		{
			return _equation.GetEquation(
				new CarCoordinatesModel
				{
					CarNumber = i,
					CarNumberToStop = CarNumberToStop,
					CurrentCarCoordinates = new Coordinates
					{
						n = i,
						X = x[i][x[i].Count - 1],
						DotX = y[i][y[i].Count - 1]
					},
					PreviousСarCoordinates = new Coordinates
					{
						n = i != 0 ? i - 1 : 0,
						X = i != 0 ? x[i - 1][x[i].Count - _N] : 0,
						DotX = i != 0 ? y[i - 1][y[i].Count - _N] : 0
					}	
				});
		}

		public void Solve()
		{
			double[] k1 = new double[_n];
			double[] k2 = new double[_n];
			double[] k3 = new double[_n];
			double[] k4 = new double[_n];
			double[] q1 = new double[_n];
			double[] q2 = new double[_n];
			double[] q3 = new double[_n];
			double[] q4 = new double[_n];
			for (int i = 0; i < _n; i++)
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
