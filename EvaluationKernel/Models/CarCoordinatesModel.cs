using System.Collections.Generic;

namespace EvaluationKernel.Models
{
	public class Coordinates
	{
		public int n { get; set; }
		public double X { get; set; }
		public double DotX { get; set; }
	}

	public class CarCoordinatesModel
	{
		public int CarNumber { get; set; }

		public List<int> CarNumberToStop { get; set; }
		public Coordinates CurrentCarCoordinates { get; set; }
		public Coordinates PreviousСarCoordinates { get; set; }
	}
}