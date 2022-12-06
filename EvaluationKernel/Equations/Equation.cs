using EvaluationKernel.Models;

namespace EvaluationKernel.Equations
{
	public abstract class Equation
	{
		protected ModelParameters _m;

		protected Equation(ModelParameters modelParameters)
		{
			_m = modelParameters;
		}

		public abstract double GetEquation(CarCoordinatesModel carCoordinatesModel);

		protected bool RelayFunction(int n, Coordinates x_n, double L)
		{
			return L - x_n.X > S(n, x_n.Y);
		}

		protected double V(double v, double Vmax)
		{
			return Vmax >= v ? v : Vmax;
		}

		public double S(int n, double v)
		{
			var l = n == 0
				? _m.lSafe[n]
				: _m.lSafe[n] + _m.lCar[n - 1];
			return System.Math.Pow(v, 2) / (2 * _m.g * _m.mu) + l;
		}
	}
}
