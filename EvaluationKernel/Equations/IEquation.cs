using System.Collections.Generic;

namespace EvaluationKernel.Equations;

public interface IEquation
{
	public double GetEquation(int i, List<List<double>> x, List<List<double>> y, List<int> N);
}