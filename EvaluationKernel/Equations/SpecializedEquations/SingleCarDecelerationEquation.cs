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

		return -H(n, x_n, x_0);
	}
}