using System;
using System.Collections.Generic;
using EvaluationKernel.Helpers;
using EvaluationKernel.Models;

namespace EvaluationKernel.Equations.SpecializedEquations;

public class EquationWithSpeedLimitChanging : Equation
{
	private readonly SortedDictionary<int, int> _position = new();

	private readonly SortedDictionary<int, SegmentModel> _segmentSpeeds;

	private int _currentSegment;

	public EquationWithSpeedLimitChanging(ModelParameters modelParameters, SortedDictionary<int, SegmentModel> segmentSpeeds) : base(modelParameters)
	{
		_segmentSpeeds = segmentSpeeds;
		for (var i = 0; i < modelParameters.n; i++)
		{
			_position.Add(i, 0);
		}
	}

	public override double GetEquation(CarCoordinatesModel carCoordinatesModel)
	{
		var n = carCoordinatesModel.CarNumber;
		var x_0 = new Coordinates {X = _m.L, DotX = 100};
		var x_n = carCoordinatesModel.CurrentCarCoordinates;
		var x_n_1 = carCoordinatesModel.PreviousСarCoordinates;

		_currentSegment = GetSegmentNumber(x_n.X);
		_position[n] = _currentSegment;

		return n == 0
			? GetFirstCarEquation(n, x_n, x_0)
			: GetAllCarEquation(n, x_n, x_n_1);
	}

	protected override double Vmax(int n)
	{
		return _segmentSpeeds[_currentSegment].Speed;
	}

	protected override double V(int n, double v)
	{
		return Math.Min(_segmentSpeeds[_currentSegment].Speed, v);
	}

	protected override double DeltaX(Coordinates x_n, Coordinates x_n_1)
	{
		return Phi(x_n, x_n_1) - x_n.X;
	}

	protected override double DeltaDotX(Coordinates x_n, Coordinates x_n_1)
	{
		return Vmin(x_n_1.DotX) - x_n.DotX;
	}

	private double Vmin(double v)
	{
		return Math.Min(v, _segmentSpeeds[_currentSegment + 1].Speed);
	}

	private double Phi(Coordinates x_n, Coordinates x_n_1)
	{
		if (x_n.DotX > _segmentSpeeds[_currentSegment + 1].Speed)
		{
			return Math.Min(_segmentSpeeds[_currentSegment + 1].SegmentBeginning, x_n_1.X);
		}

		return x_n_1.X;
	}

	private int GetSegmentNumber(double x)
	{
		return EquationHelper.BinarySearchInDictionary(_segmentSpeeds, x);
	}
}