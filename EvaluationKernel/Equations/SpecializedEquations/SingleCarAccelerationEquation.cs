using EvaluationKernel.Models;
// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Equations.SpecializedEquations;

public class SingleCarAccelerationEquation : Equation
{
	public SingleCarAccelerationEquation(ModelParameters modelParameters) : base(modelParameters)
	{
	}

	protected override double GetEquation(int n, double x, double dotX, double prevX = default, double prevDotX = default)
	{
		var x_n = new Coordinates { N = n, X = x, DotX = dotX };

		return _m.a[n] * (_m.Vmax[n] - x_n.DotX);
	}
}