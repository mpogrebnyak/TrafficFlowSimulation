using System.Collections.Generic;
using EvaluationKernel.Models;

// ReSharper disable InconsistentNaming

namespace EvaluationKernel.Equations.SpecializedEquations;

public class EquationThroughTheDriver : Equation
{
	public EquationThroughTheDriver(ModelParameters modelParameters) : base(modelParameters)
	{
	}

	public override double GetEquation(int i, List<List<double>> x, List<List<double>> y, List<int> N)
	{
		var x_n = new Coordinates { N = i, X = x[i][x[i].Count - 1], DotX = y[i][y[i].Count - 1] };

		if (FirstCarNumbers.Contains(i))
		{
			var x_n_0 = new Coordinates {N = -1, X = _m.L, DotX = 0};

			return GetFirstCarEquation(i, x_n, x_n_0);
		}

		if (i % 2 == 0)
		{
			if (i == 2)
			{
				var y_0 = new Coordinates {N = i, X = x[i - 2][x[i - 2].Count - N[i - 2]], DotX = y[i - 2][y[i - 2].Count - N[i - 2]]};
				return GetAllCarEquation(i, x_n, y_0);
			}

			var y_n_1 = new Coordinates {N = i, X = x[i - 3][x[i - 3].Count - N[i - 3]], DotX = y[i - 3][y[i - 3].Count - N[i - 3]]};

			return GetAllCarEquation(i, x_n, y_n_1);
		}

		var x_n_1 = new Coordinates {N = i, X = x[i - 1][x[i - 1].Count - 1], DotX = y[i - 1][y[i - 1].Count - 1] };

		return GetAllCarEquation(i, x_n, x_n_1);
	}
}