using System;
using EvaluationKernel.Models;

namespace EvaluationKernel.Equations;

public class BaseEquation : Equation
{
	public BaseEquation(ModelParameters modelParameters) : base(modelParameters)
	{
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
		return ReleFunction(n, x_n, _m.L)
			? _m.a[n] * (_m.Vmax[n] - x_n.Y)
			: _m.q[n] * (x_n.Y * (_m.Vmin - x_n.Y) / (_m.L - x_n.X));
	}

	private double GetAllCarEquation(int n, Coordinates x_n, Coordinates x_n_1)
	{
		return ReleFunction(n, x_n, x_n_1.X)
			? _m.a[n] * ((_m.Vmax[n] - V(x_n_1.Y, _m.Vmax[n])) / (1 + Math.Exp(_m.k[n] * (x_n.X - x_n_1.X + _m.s[n]))) + V(x_n_1.Y, _m.Vmax[n]) - x_n.Y)
			: _m.q[n] * (x_n.Y * (x_n_1.Y - x_n.Y)) / (x_n_1.X - x_n.X - _m.l[n] + _m.eps);  
	}
}