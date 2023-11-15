using System.Collections.Generic;
using EvaluationKernel.Models;

// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Equations.SpecializedEquations;

public class EquationWithStop : Equation
{
	private List<int> carNumberToStop;

	public EquationWithStop(ModelParameters modelParameters) : base(modelParameters) { }

	public override double GetEquation(CarCoordinatesModel carCoordinatesModel)
	{
		var n = carCoordinatesModel.CarNumber;

		carNumberToStop = carCoordinatesModel.CarNumberToStop;
		var x_0 = new Coordinates {X = L(n), DotX = 0};

		var x_n = carCoordinatesModel.CurrentCarCoordinates;
		var x_n_1 = carCoordinatesModel.PreviousСarCoordinates;

		return n == 0 || carNumberToStop.Contains(n)
			? GetFirstCarEquation(n, x_n, x_0)
			: GetAllCarEquation(n, x_n, x_n_1);
	}

	protected override double L_safe(int n)
	{
		return n == 0 || carNumberToStop.Contains(n)
			? 0 //_m.lSafe[n]
			: _m.lSafe[n] + _m.lCar[n - 1];
	}

	private double L(int n)
	{
		if (carNumberToStop.Contains(n))
			return 0;

		return _m.L;
	}
}