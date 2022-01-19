using EvaluationKernel.Models;
using System;

namespace EvaluationKernel.Equations
{
    public class MainEquation : Equation
    {
        public MainEquation(ModelParameters modelParameters)
        {
            _m = modelParameters;
        }

        public override double GetEquation(CarCoordinatesModel carCoordinatesModel)
        {
            var x_n = carCoordinatesModel.currentCarCoordinates;
            var x_n_1 = carCoordinatesModel.previousСarCoordinates;

            return (carCoordinatesModel.carNumber == 1)
                ? GetFirstCarEquation(x_n)
                : GetAllCarEquation(x_n, x_n_1);
        }

        private double GetFirstCarEquation(Coordinates x_n)
        {
            return ReleFunction(x_n)
                ? _m.a * (_m.Vmax - x_n.Y)
                : _m.q * (x_n.Y * (_m.Vmin - x_n.Y) / (_m.L - x_n.X));
        }

        private double GetAllCarEquation(Coordinates x_n, Coordinates x_n_1)
        {
            return ReleFunction(x_n, x_n_1)
                ? _m.a * ((_m.Vmax - x_n_1.Y) / (1 + Math.Exp(_m.p * (x_n.X - x_n_1.X + _m.s))) + x_n_1.Y - x_n.Y)
                : _m.q * (x_n.Y * (x_n_1.Y - x_n.Y)) / (x_n_1.X - x_n.X - _m.l + _m.k);           
        }
    }
}