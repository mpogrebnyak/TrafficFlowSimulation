using System.ComponentModel.DataAnnotations;

namespace EvaluationKernel.Models
{
    public class ModelParameters : ValidationModel
    {
        [Required]
        [Range(1, 100)]
        public int n { get; set; }
        public double tau { get; set; }
        public double a { get; set; }

        public double q { get; set; }
        public double Vmax { get; set; }

        public double Vmin { get; set; }
        public double[] lambda { get; set; }
        public double k { get; set; }
        public double mu { get; set; }

        public double g { get; set; }

        public double l { get; set; }

        public double L { get; set; }

        public double p { get; set; }

        public double s { get; set; }
    }
}
