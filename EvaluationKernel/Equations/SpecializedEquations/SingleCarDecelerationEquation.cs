using EvaluationKernel.Models;
// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Equations.SpecializedEquations;

public class SingleCarDecelerationEquation : Equation
{
	public SingleCarDecelerationEquation(ModelParameters modelParameters) : base(modelParameters)
	{
	}

	protected override double GetEquation(int n, double x, double dotX, double prevX = default, double prevDotX = default)
	{
		var x_n = new Coordinates { N = n, X = x, DotX = dotX };
		var x_0 = new Coordinates { X = _m.L, DotX = 0 };

		return -H(n, x_n, x_0);
	}
}