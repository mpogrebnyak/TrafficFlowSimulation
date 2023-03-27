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
		var x_0 = new Coordinates {X = _m.L, Y = 0};

		return H(n, x_n, x_0, 0) * x_n.Y;
	}
}