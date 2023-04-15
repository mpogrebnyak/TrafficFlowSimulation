﻿using System;
using EvaluationKernel.Models;
// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Equations;

public class MainEquation : Equation
{
	public MainEquation(ModelParameters modelParameters) : base(modelParameters)
	{
	}

	public override double GetEquation(CarCoordinatesModel carCoordinatesModel)
	{
		var n = carCoordinatesModel.CarNumber;
		var x_n = carCoordinatesModel.CurrentCarCoordinates;
		var x_n_1 = carCoordinatesModel.PreviousСarCoordinates;

		return n == 0
			? GetFirstCarEquation(n, x_n)
			: GetAllCarEquation(n, x_n, x_n_1);
	}

	private double GetFirstCarEquation(int n, Coordinates x_n)
	{
		var x_0 = new Coordinates {X = _m.L, Y = 0};

		return RelayFunction(n, x_n, _m.L)
			? _m.a[n] * (_m.Vmax[n] - x_n.Y)
			: H(n, x_n, x_0, 0) * x_n.Y;
	}

	private double GetAllCarEquation(int n, Coordinates x_n, Coordinates x_n_1)
	{
		var s = S(n, x_n.Y) + 2 * Math.Exp(1 / Math.Pow(_m.k[n], 0.5));
		return RelayFunction(n, x_n, x_n_1.X)
			? _m.a[n] * ((_m.Vmax[n] - V(x_n_1.Y, _m.Vmax[n])) / (1 + Math.Exp(_m.k[n] * (x_n.X - x_n_1.X + s))) + V(x_n_1.Y, _m.Vmax[n]) - x_n.Y)
			: H(n, x_n, x_n_1, _m.lCar[n - 1]) * x_n.Y;
	}
}