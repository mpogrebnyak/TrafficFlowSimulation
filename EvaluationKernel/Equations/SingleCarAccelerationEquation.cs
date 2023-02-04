using EvaluationKernel.Models;

namespace EvaluationKernel.Equations;

public class SingleCarAccelerationEquation : Equation
{
	public SingleCarAccelerationEquation(ModelParameters modelParameters) : base(modelParameters)
	{
	}

	public override double GetEquation(CarCoordinatesModel carCoordinatesModel)
	{
		var n = carCoordinatesModel.CarNumber;
		var x_n = carCoordinatesModel.CurrentCarCoordinates;

		return _m.a[n] * (_m.Vmax[n] - x_n.Y);
	}
}