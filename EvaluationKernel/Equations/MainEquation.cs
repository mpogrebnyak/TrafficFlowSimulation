using EvaluationKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
			var n = carCoordinatesModel.CarNumber;
			var stop = carCoordinatesModel.CarNumberToStop;
			var x_n = carCoordinatesModel.CurrentCarCoordinates;
			var x_n_1 = carCoordinatesModel.PreviousСarCoordinates;

			return (n == 0 || stop.Contains(n))
				? GetFirstCarEquation(n, x_n, stop)
				: GetAllCarEquation(n, x_n, x_n_1, stop);
		}

		private double GetFirstCarEquation(int n, Coordinates x_n, List<int> carsToStop)
		{
			return ReleFunction2(n, x_n, carsToStop)
				? _m.a[n] * (_m.Vmax[n] - x_n.Y)
				: _m.q[n] * (x_n.Y * (_m.Vmin - x_n.Y) / (Stop(n, carsToStop) - x_n.X));
		}
		
		public bool ReleFunction2(int n, Coordinates x_n, List<int> carsToStop)
		{
			var ee = _m.L;
			if (carsToStop.Contains(n))
				ee =  0;
			
			return ee - x_n.X > S(n, x_n.Y)
				? true
				: false;
		}
		
		private double S(int n, double v)
		{
			return System.Math.Pow(v, 2) / (2 * _m.g * _m.mu) + _m.l[n];
		}

		private double GetAllCarEquation(int n, Coordinates x_n, Coordinates x_n_1, List<int> carsToStop)
		{
			return ReleFunction(n, x_n, x_n_1)
				? _m.a[n] * ((_m.Vmax[n] - V(x_n_1.Y, _m.Vmax[n])) / (1 + Math.Exp(_m.k[n] * (x_n.X - x_n_1.X + _m.s[n]))) + V(x_n_1.Y, _m.Vmax[n]) - x_n.Y)
				: _m.q[n] * (x_n.Y * (x_n_1.Y - x_n.Y)) / (x_n_1.X - x_n.X - _m.l[n] + _m.eps);		   
		}

		private double V(double v, double Vmax)
        {
			return Vmax >= v
				? v
				: Vmax;
		}
		
		private double Stop(int n, List<int> carsToStop)
		{
			if (carsToStop.Contains(n))
				return 0;

			return _m.L;
		}
	}
}