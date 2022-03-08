using System.Collections.Generic;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;

namespace EvaluationKernel
{
	public class RungeKuttaMethod
	{
		const double _h = 0.001; // 0.001

		private int _N, _n;
		private MainEquation _mainEquation;

		List<List<double>> x;
		List<List<double>> y;
		List<double> t;

		public RungeKuttaMethod(ModelParameters modelParameters)
		{
			_n = modelParameters.n;
			_N = (int) (modelParameters.tau / _h);
			_mainEquation = new MainEquation(modelParameters);

			t = new List<double>();
			x = new List<List<double>>();
			y = new List<List<double>>();

			SetInitialConditions(modelParameters);
		}

		private void SetInitialConditions(ModelParameters modelParameters)
		{
			for (int i = 0; i < _n; i++)
			{
				x.Add(new List<double>());
				y.Add(new List<double>());
			}

			for (int i = 0; i < _N; i++)
			{
				t.Add((i - _N) * _h);
				for (int j = 0; j < _n; j++)
				{
					x[j].Add(modelParameters.lambda[j]);
					y[j].Add(modelParameters.Vn[j]);
				}
			}
		}

		public List<double> T
		{
			get { return t; }
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
			return _mainEquation.GetEquation(
				new CarCoordinatesModel
				{
					CarNumber = i,
					CurrentCarCoordinates = new Coordinates
					{
						X = x[i][x[i].Count - 1],
						Y = y[i][y[i].Count - 1]
					},
					PreviousСarCoordinates = new Coordinates
					{
						X = i != 0 ? x[i - 1][x[i].Count - _N] : 0,
						Y = i != 0 ? y[i - 1][y[i].Count - _N] : 0
					}
				});
				// if (i == 0)
				//	return 16.7 - y[i][y[i].Count - 1];
				// else
				//	return y[i - 1][y[i].Count - _N]- y[i][y[i].Count - 1];
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
			}

			t.Add(t[t.Count - 1] + _h);

			//double k1 = h * f(x[x.Count - 1], x[x.Count - N]);
			//double k2 = h * f(x[x.Count - 1] + k1 / 2, x[x.Count - N] + k1 / 2);
			//double k3 = h * f(x[x.Count - 1] + k2 / 2, x[x.Count - N] + k2 / 2);
			//double k4 = h * f(x[x.Count - 1] + k3, x[x.Count - N] + k3);
			//x.Add(x[x.Count - 1] + (k1 + 2 * k2 + 2 * k3 + k4) / 6);
		}
	}
}
