using EvaluationKernel.Models;

namespace EvaluationKernel.Equations;

public interface IEquation
{
	public double GetEquation(CarCoordinatesModel carCoordinatesModel);
}