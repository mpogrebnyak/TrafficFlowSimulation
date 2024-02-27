using System.Collections.Generic;
using System.Linq;
using EvaluationKernel.Models;

// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Equations.SpecializedEquations;

public class EquationWithStopThroughTheDriver : Equation
{
	public EquationWithStopThroughTheDriver(ModelParameters modelParameters) : base(modelParameters)
	{
	}

	public HashSet<int> CarToSTOP = new HashSet<int>();
	
	
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

		if (i % 2 == 0)
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

	protected override double L_safe(int n)
	{
		return n == 0 || CarToSTOP.Contains(n)
		//return n == 0 || FirstCarNumbers.Contains(n)
			? 0.000000000001
			: _m.lSafe[n] + _m.lCar[n - 1];
	}

	private double L(int n)
	{
		return CarToSTOP.Contains(n)
			? 0
			: _m.L;
	}
}