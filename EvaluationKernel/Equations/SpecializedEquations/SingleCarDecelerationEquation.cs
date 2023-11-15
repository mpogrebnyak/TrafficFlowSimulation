using System;
using EvaluationKernel.Models;
// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Equations.SpecializedEquations;

public class SingleCarDecelerationEquation : Equation
{
	public SingleCarDecelerationEquation(ModelParameters modelParameters) : base(modelParameters)
	{
	}

	public override double GetEquation(CarCoordinatesModel carCoordinatesModel)
	{
		var n = carCoordinatesModel.CarNumber;
		var x_n = carCoordinatesModel.CurrentCarCoordinates;
		var x_0 = new Coordinates {X = _m.L, DotX = 0};

		//return -H(n, x_n, x_0, 0) * x_n.DotX;
		return -H(n, x_n, x_0);
	}
	
	//Старое
	/*	protected double H(int n, Coordinates x_n, Coordinates x_n_1, double lCar)
		{
			var deceleration = _m.q[n] * Math.Pow(x_n_1.DotX - x_n.DotX, 2) / Math.Pow(x_n_1.X - x_n.X - _m.lSafe[n] - lCar, 2);

			if (x_n.DotX < 0.01 && x_n_1.X - x_n.X - _m.lSafe[n] - lCar < 0.01)
			{
				return 0;
			}

			if (deceleration <= _m.mu * _m.g)
			{
				return deceleration;
			}

			return _m.mu * _m.g;
		}
		*/
}