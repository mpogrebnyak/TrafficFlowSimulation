using EvaluationKernel.Models;

// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Equations.SpecializedEquations;

public class EquationWithStop : Equation
{
	public EquationWithStop(ModelParameters modelParameters) : base(modelParameters) { }

	protected override double GetEquation(int n, double x, double dotX, double prevX = default, double prevDotX = default)
	{
		var x_n = new Coordinates { N = n, X = x, DotX = dotX };

		if (FirstCarNumbers.Contains(n))
		{
			var x_0 = new Coordinates { N = -1, X = L(n, x), DotX = 0 };

			return GetFirstCarEquation(n, x_n, x_0);
		}

		var x_n_1 = new Coordinates { N = n, X = prevX, DotX = prevDotX };

		return GetAllCarEquation(n, x_n, x_n_1);
	}

	protected override double L_safe(int n)
	{
		return FirstCarNumbers.Contains(n)
			? 0 //_m.lSafe[n]
			: _m.lSafe[n] + _m.lCar[n - 1];
	}

	private double L(int n, double x)
	{
		if (FirstCarNumbers.Contains(n))
			return x > 0
				? _m.L
				: 0;

		return _m.L;
	}
}