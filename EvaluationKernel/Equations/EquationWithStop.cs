using System;
using System.Collections.Generic;
using EvaluationKernel.Models;
// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Equations;

public class EquationWithStop : Equation
{
	public EquationWithStop(ModelParameters modelParameters) : base(modelParameters) { }

	public override double GetEquation(CarCoordinatesModel carCoordinatesModel)
	{
		var n = carCoordinatesModel.CarNumber;
		var carNumberToStop = carCoordinatesModel.CarNumberToStop;
		var x_n = carCoordinatesModel.CurrentCarCoordinates;
		var x_n_1 = carCoordinatesModel.PreviousСarCoordinates;

		return n == 0 || carNumberToStop.Contains(n)
			? GetFirstCarEquation(n, x_n, carNumberToStop)
			: GetAllCarEquation(n, x_n, x_n_1);
	}

	private double GetFirstCarEquation(int n, Coordinates x_n, List<int> carNumberToStop)
	{
		var l = L(n, carNumberToStop);
		return RelayFunction(n, x_n, l)
			? _m.a[n] * (_m.Vmax[n] - x_n.Y)
			: _m.q[n] * (x_n.Y * (_m.Vmin - x_n.Y) / (l - x_n.X));
	}

	private double GetAllCarEquation(int n, Coordinates x_n, Coordinates x_n_1)
	{
		var s = S(n, x_n.Y) + 2 * Math.Exp(1 / Math.Pow(_m.k[n], 0.5));
		return RelayFunction(n, x_n, x_n_1.X)
			? _m.a[n] * ((_m.Vmax[n] - V(x_n_1.Y, _m.Vmax[n])) / (1 + Math.Exp(_m.k[n] * (x_n.X - x_n_1.X + s))) + V(x_n_1.Y, _m.Vmax[n]) - x_n.Y)
			: _m.q[n] * (x_n.Y * (x_n_1.Y - x_n.Y)) / (x_n_1.X - x_n.X - _m.lSafe[n] - _m.lCar[n - 1] + _m.eps);  
	}

	private double L(int n, List<int> carsToStop)
	{
		if (carsToStop.Contains(n))
			return 0;

		return _m.L;
	}
}