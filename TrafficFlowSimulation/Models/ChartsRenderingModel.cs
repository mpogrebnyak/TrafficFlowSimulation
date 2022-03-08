using EvaluationKernel.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrafficFlowSimulation.Models
{
    public class ChartsRenderingModel
    {
        public ModelParameters ModelParameters { get; set; }
        public Chart SpeedChart { get; set; }
        public Chart DistanceChart { get; set; }
    }
}
