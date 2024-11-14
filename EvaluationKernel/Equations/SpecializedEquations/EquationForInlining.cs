using System.Collections.Generic;
using EvaluationKernel.Models;

namespace EvaluationKernel.Equations.SpecializedEquations;

public class EquationForInlining : Equation
{
	// Номер первой машины второго потока
	private readonly int _number;

	private readonly double _l;

	public EquationForInlining(ModelParameters modelParameters, int number = -1, double l = 100) : base(modelParameters)
	{
		_number = number;
		_l = l;
	}

	public override double GetEquation(int i, List<List<double>> x, List<List<double>> y, List<int> N)
	{
		if (FirstCarNumbers.Contains(i))
		{
			return GetEquation(
				i,
				x[i][x[i].Count - 1],
				y[i][y[i].Count - 1]);
		}

		return GetEquation(
			i,
			x[i][x[i].Count - 1],
			y[i][y[i].Count - 1],
			x[i - 1][x[i - 1].Count - N[i - 1]],
			y[i - 1][y[i - 1].Count - N[i - 1]]);
	}

	protected virtual double GetEquation(int n, double x, double dotX, double prevX = default, double prevDotX = default)
	{
		var x_n = new Coordinates { N = n, X = x, DotX = dotX };

		if (FirstCarNumbers.Contains(n))
		{
			var x_0 = n == _number
				? new Coordinates { N = -1, X = _l, DotX = 0 }
				: new Coordinates { N = -1, X = _m.L, DotX = 0 };

			return GetFirstCarEquation(n, x_n, x_0);
		}

		if (n == _number && prevX > _l)
		{
			var l = _l + L_safe(n);
			var x_0 = new Coordinates { N = -1, X = l, DotX = 0 };

			return GetFirstCarEquation(n, x_n, x_0);
		}

		var x_n_1 = new Coordinates { N = n, X = prevX, DotX = prevDotX };

		return GetAllCarEquation(n, x_n, x_n_1);
	}


	protected override double L_safe(int n)
	{
		if (n == 0 || FirstCarNumbers.Contains(n))
		{
			return 0;
		}

		return _m.lSafe[n] + _m.lCar[n - 1];
	}
}