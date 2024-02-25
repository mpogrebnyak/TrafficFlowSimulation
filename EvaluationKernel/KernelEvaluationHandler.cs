using System.Collections.Generic;
using System.Linq;
using EvaluationKernel.Equations;
using EvaluationKernel.Models;

namespace EvaluationKernel;

public class KernelEvaluationHandler
{
	private readonly RungeKuttaMethod _rungeKuttaMethod;

	private readonly int _n;

	private double _t;

	private readonly double[] _x;

	private readonly double[] _y;

	private readonly double[] _previousX;

	private readonly double[] _previousY;

	public double GetT()
	{
		return _t;
	}

	public List<double> GetX()
	{
		return _x.ToList();
	}

	public List<double> GetY()
	{
		return _y.ToList();
	}

	public KernelEvaluationHandler(ModelParameters modelParameters, Equation equation)
	{
		_rungeKuttaMethod = new RungeKuttaMethod(modelParameters, equation);

		_n = modelParameters.n;
		_t = _rungeKuttaMethod.T.Last();
		_previousX = new double[_n];
		_previousY = new double[_n];
		_x = new double[_n];
		_y = new double[_n];

		for (var i = 0; i < _n; i++)
		{
			_x[i] = _rungeKuttaMethod.X(i).Last();
			_y[i] = _rungeKuttaMethod.Y(i).Last();
		}
	}

	public void Next()
	{
		for (var i = 0; i < _n; i++)
		{
			_previousX[i] = _x[i];
			_previousY[i] = _y[i];
		}

		_rungeKuttaMethod.Solve();

		_t = _rungeKuttaMethod.T.Last();

		for (var i = 0; i < _n; i++)
		{
			_x[i] = _rungeKuttaMethod.X(i).Last();
			_y[i] = _rungeKuttaMethod.Y(i).Last();
		}
	}
}