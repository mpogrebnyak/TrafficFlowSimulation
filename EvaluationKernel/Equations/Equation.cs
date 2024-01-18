using System;
using EvaluationKernel.Models;
// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Equations
{
	public class Equation : IEquation
	{
		protected readonly ModelParameters _m;

		private const double _eps = 0.01;

		public Equation(ModelParameters modelParameters)
		{
			_m = modelParameters;
		}

		public virtual double GetEquation(CarCoordinatesModel carCoordinatesModel)
		{
			var n = carCoordinatesModel.CarNumber;
			var x_0 = new Coordinates {X = _m.L, DotX = 0};
			var x_n = carCoordinatesModel.CurrentCarCoordinates;
			var x_n_1 = carCoordinatesModel.PreviousСarCoordinates;

			return n == 0
				? GetFirstCarEquation(n, x_n, x_0)
				: GetAllCarEquation(n, x_n, x_n_1);
		}

		protected double GetFirstCarEquation(int n, Coordinates x_n, Coordinates x_0)
		{
			return RelayFunction(n, x_n, x_0)
				? _m.a[n] * (Vmax(n) - x_n.DotX)
				: -H(n, x_n, x_0);
		}

		protected double GetAllCarEquation(int n, Coordinates x_n, Coordinates x_n_1)
		{
			return RelayFunction(n, x_n, x_n_1)
				? _m.a[n] * (P(n, x_n, x_n_1) - x_n.DotX)
				: -H(n, x_n, x_n_1);
		}

		protected bool RelayFunction(int n, Coordinates x_n, Coordinates x_n_1)
		{
			return Math.Round(DeltaX(x_n, x_n_1), 5) > Math.Round(S(n, x_n.DotX), 5);
		}

		protected double P(int n, Coordinates x_n, Coordinates x_n_1)
		{
			var s = S(n, x_n.DotX) + _m.tau * DeltaDotX(x_n, x_n_1);
			return (Vmax(n) - V(n, x_n_1.DotX)) / (1 + Math.Exp(_m.k[n] * (-DeltaX(x_n, x_n_1) + s))) + V(n, x_n_1.DotX);
		}

		protected double H(int n, Coordinates x_n, Coordinates x_n_1)
		{
			var deceleration = _m.q[n] * Math.Pow(x_n.DotX * DeltaDotX(x_n, x_n_1), 2) / Math.Pow(DeltaX(x_n, x_n_1) - L_safe(n), 2);

			if (x_n.DotX < _eps && x_n.DotX > 0)
			{
				return _m.mu * _m.g;
			}

			if (deceleration <= _m.mu * _m.g)
			{
				return deceleration;
			}

			return _m.mu * _m.g;
		}

		protected double S(int n, double v)
		{
			return (_m.tau + _m.tau_b) * v + Math.Pow(v, 2) / (2 * _m.g * _m.mu) + L_safe(n);
		}

		public static double S(ModelParameters m, int n, double v)
		{
			return (m.tau + m.tau_b) * v + Math.Pow(v, 2) / (2 * m.g * m.mu) + L_safe(m, n);
		}

		protected virtual double V(int n, double v)
		{
			return Math.Min(_m.Vmax[n], v);
		}

		protected virtual double Vmax(int n)
		{
			return _m.Vmax[n];
		}

		protected virtual double L_safe(int n)
		{
			return L_safe(_m, n);
		}

		public static double L_safe(ModelParameters m, int n)
		{
			return n == 0
				? m.lSafe[n]
				: m.lSafe[n] + m.lCar[n - 1];
		}

		protected virtual double DeltaX(Coordinates x_n, Coordinates x_n_1)
		{
			return Math.Abs(x_n_1.X - x_n.X);
		}

		protected virtual double DeltaDotX(Coordinates x_n, Coordinates x_n_1)
		{
			return x_n_1.DotX - x_n.DotX;
		}
	}
}
