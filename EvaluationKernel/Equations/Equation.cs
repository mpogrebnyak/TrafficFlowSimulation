using EvaluationKernel.Models;

namespace EvaluationKernel.Equations
{
	public abstract class Equation
	{
		public ModelParameters _m;

		public abstract double GetEquation(CarCoordinatesModel carCoordinatesMode);

		public bool ReleFunction(Coordinates x_n, Coordinates x_n_1)
		{
			return x_n_1.X - x_n.X > S(x_n.Y)
				? true
				: false;
		}

		public bool ReleFunction(Coordinates x_n)
		{
			return _m.L - x_n.X > S(x_n.Y)
				? true
				: false;
		}

		private double S(double v)
		{
			return System.Math.Pow(v, 2) / (2 * _m.g * _m.mu) + _m.l;
		}
	}
}
