using EvaluationKernel.Models;
using System;
using System.Linq;

namespace EvaluationKernel.Equations
{
	public class MainEquation : Equation
	{
		public MainEquation(ModelParameters modelParameters)
		{
			_m = modelParameters;
		}

		public override double GetEquation(CarCoordinatesModel carCoordinatesModel)
		{
			var n = carCoordinatesModel.CarNumber;
			var x_n = carCoordinatesModel.CurrentCarCoordinates;
			var x_n_1 = carCoordinatesModel.PreviousСarCoordinates;

			return (n == 0)
				? GetFirstCarEquation(n, x_n)
				: GetAllCarEquation(n, x_n, x_n_1);
		}

		private double GetFirstCarEquation(int n, Coordinates x_n)
		{
			return ReleFunction(x_n)
				? _m.a * (_m.Vmax[n] - x_n.Y)
				: _m.q * (x_n.Y * (_m.Vmin - x_n.Y) / (_m.L - x_n.X));
		}

		private double GetAllCarEquation(int n, Coordinates x_n, Coordinates x_n_1)
		{
			return ReleFunction(x_n, x_n_1)
				? _m.a * ((_m.Vmax[n] - x_n_1.Y) / (1 + Math.Exp(_m.p * (x_n.X - x_n_1.X + _m.s))) + x_n_1.Y - x_n.Y)
				: _m.q * (x_n.Y * (x_n_1.Y - x_n.Y)) / (x_n_1.X - x_n.X - _m.l + _m.k);		   
		}
	}
}