using System;
using EvaluationKernel.Models;

namespace EvaluationKernel.Equations;

public class SingleCarDecelerationEquation : Equation
{
	public SingleCarDecelerationEquation(ModelParameters modelParameters) : base(modelParameters)
	{
	}

	public override double GetEquation(CarCoordinatesModel carCoordinatesModel)
	{
		var n = carCoordinatesModel.CarNumber;
		var x_n = carCoordinatesModel.CurrentCarCoordinates;
//-_m.q[n] *2* _m.mu * _m.g

		if (x_n.Y < 0.01)
		{
			return -_m.mu * _m.g * x_n.Y;
		}

		return -_m.q[n] * (x_n.Y * x_n.Y) / (_m.L - x_n.X - _m.lSafe[n]); 
	}
}