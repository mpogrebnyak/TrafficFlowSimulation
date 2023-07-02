using System;
using EvaluationKernel.Models;
// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Equations
{
	public abstract class Equation
	{
		protected ModelParameters _m;

		private const double _eps = 0.0001;

		protected Equation(ModelParameters modelParameters)
		{
			_m = modelParameters;
		}

		public abstract double GetEquation(CarCoordinatesModel carCoordinatesModel);

		protected bool RelayFunction(int n, Coordinates x_n, double L)
		{
			return L - x_n.X > S(n, x_n.Y);
		}

		protected double H(int n, Coordinates x_n, Coordinates x_n_1, double lCar)
		{
			var deceleration = _m.q[n] * Math.Pow(x_n_1.Y - x_n.Y, 2) / Math.Pow(x_n_1.X - x_n.X - _m.lSafe[n] - lCar, 2);

			if (x_n.Y < _eps)// && x_n_1.X - x_n.X - _m.lSafe[n] - lCar < _eps)
			{
				return 0;
			}

			if (deceleration <= _m.mu * _m.g)
			{
				return deceleration;
			}

			return _m.mu * _m.g;
		}

		protected double V(double v, double Vmax)
		{
			return Vmax >= v ? v : Vmax;
		}

		protected double S(int n, double v)
		{
			var l = n == 0
				? _m.lSafe[n]
				: _m.lSafe[n] + _m.lCar[n - 1];
			return (1 + 0.1) * v + Math.Pow(v, 2) / (2 * _m.g * _m.mu) + l;
		}
	}
}
