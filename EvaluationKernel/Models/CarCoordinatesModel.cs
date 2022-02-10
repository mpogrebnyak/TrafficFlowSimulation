namespace EvaluationKernel
{
	public class Coordinates
	{
		public double X { get; set; }
		public double Y { get; set; }
	}
	public class CarCoordinatesModel
	{
		public int CarNumber { get; set; }
		public Coordinates CurrentCarCoordinates { get; set; }
		public Coordinates PreviousСarCoordinates { get; set; }
	}
}