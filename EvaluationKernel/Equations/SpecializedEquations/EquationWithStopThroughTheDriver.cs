using System.Collections.Generic;
using EvaluationKernel.Models;

// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Equations.SpecializedEquations;

public class EquationWithStopThroughTheDriver : Equation
{
	private const double _eps = 0.01;

	public readonly HashSet<int> StopCar = new() {0};

	public readonly Dictionary<int, bool> VirtualCars = new();

	public EquationWithStopThroughTheDriver(ModelParameters modelParameters) : base(modelParameters)
	{
	}

	public override double GetEquation(int i, List<List<double>> x, List<List<double>> y, List<int> N)
	{
		var x_n = new Coordinates { N = i, X = x[i][x[i].Count - 1], DotX = y[i][y[i].Count - 1] };

		if (i == 0 || FirstCarNumbers.Contains(i))
		{
			var x_0 = new Coordinates { N = i == 0 ? -1 : i, X = L(i), DotX = 0 };

			return GetFirstCarEquation(i, x_n, x_0);
		}

		if (i == 1 || FirstCarNumbers.Contains(i - 2))
		{
			if (i == 1)
			{
				var x_1 = new Coordinates {N = i, X = x[i - 1][x[i - 1].Count - 1], DotX = y[i - 1][y[i - 1].Count - 1]};
				return GetAllCarEquation(i, x_n, x_1);
			}

			var x_n_2 = new Coordinates {N = i, X = x[i - 2][x[i - 2].Count - 2], DotX = y[i - 2][y[i - 2].Count - 1]};

			return GetAllCarEquation(i, x_n, x_n_2);
		}

		if (IsVirtual(i))
		{
			if (i == 2)
			{
				var y_0 = new Coordinates {N = i, X = x[i - 2][x[i - 2].Count - N[i - 2]], DotX = y[i - 2][y[i - 2].Count - N[i - 2]]};
				return GetAllCarEquation(i, x_n, y_0);
			}

			var y_n_3 = new Coordinates {N = i, X = x[i - 3][x[i - 3].Count - N[i - 3]], DotX = y[i - 3][y[i - 3].Count - N[i - 3]]};

			return GetAllCarEquation(i, x_n, y_n_3);
		}

		var x_n_1 = new Coordinates {N = i, X = x[i - 1][x[i - 1].Count - 1], DotX = y[i - 1][y[i - 1].Count - 1]};

		return GetAllCarEquation(i, x_n, x_n_1);
	}

	public bool IsVirtual(int i)
	{
		return VirtualCars[i];
	}

	protected override double L_safe(int n)
	{
		if (n == 0 || FirstCarNumbers.Contains(n))
		{
			return _eps;
		}

		if (n == 1)
		{
			return _m.lSafe[n] + _m.lCar[n - 1];
		}

		if (IsVirtual(n))
		{
			return _m.lSafe[n] + _m.lCar[n - 2];
		}

		return _m.lSafe[n] + _m.lCar[n - 1];
	}

	private double L(int n)
	{
		return StopCar.Contains(n)
			? 0
			: _m.L;
	}
}