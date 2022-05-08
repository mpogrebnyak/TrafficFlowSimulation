using EvaluationKernel.Models;

namespace EvaluationKernel.Equations
{
	public abstract class Equation
	{
		public ModelParameters _m;

		public Equation(ModelParameters modelParameters)
		{
			_m = modelParameters;
		}

		public abstract double GetEquation(CarCoordinatesModel carCoordinatesModel);

		public virtual bool ReleFunction(int n, Coordinates x_n, double L)
		{
			return L - x_n.X > S(n, x_n.Y)
				? true
				: false;
		}

		protected double V(double v, double Vmax)
		{
			return Vmax >= v
				? v
				: Vmax;
		}

		protected double S(int n, double v)
		{
			return System.Math.Pow(v, 2) / (2 * _m.g * _m.mu) + _m.l[n];
		}
	}
}
