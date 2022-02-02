namespace EvaluationKernel
{
	public class Coordinates
	{
		public double X { get; set; }
		public double Y { get; set; }
	}
	public class CarCoordinatesModel
	{
		public int carNumber { get; set; }
		public Coordinates currentCarCoordinates { get; set; }
		public Coordinates previousСarCoordinates { get; set; }
	}
}