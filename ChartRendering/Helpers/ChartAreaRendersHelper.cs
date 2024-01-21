using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartRendering.Helpers;

// ReSharper disable ConstantConditionalAccessQualifier

public static class ChartAreaRendersHelper
{
	private const int MinimumSingleSegmentInPixels = 18;

	private const double ZoomShift = 48;

	private static readonly ChartAreaCreationModel ChartAreaBaseModel = new()
	{
		Name = string.Empty,
		AxisX = new Axis
		{
			Minimum = -30,
			Maximum = 10,
			Interval = 10,
		},
		AxisY = new Axis
		{
			Minimum = 0,
			Maximum = 1,
			Interval = 1,
			LabelStyle = new LabelStyle
				{
					Enabled = false
				}
		}
	};

	private static readonly AxisScaleView GetScaleView = new()
	{
		Zoomable = true,
		SizeType = DateTimeIntervalType.Number,
		MinSize = 30
	};

	private static readonly AxisScrollBar GetScrollBar = new()
	{
		Enabled = true,
		ButtonStyle = ScrollBarButtonStyles.SmallScroll,
		IsPositionedInside = true,
		BackColor = Color.White,
		ButtonColor = Color.FromArgb(249, 246, 247)
	};

	public static ChartArea CreateChartArea(ChartAreaCreationModel model)
	{
		var chartArea = new ChartArea
		{
			Name = model.Name ?? ChartAreaBaseModel.Name,
			AxisX = new Axis
			{
				Maximum  = model.AxisX?.Maximum ?? ChartAreaBaseModel.AxisX.Maximum,
				Minimum = model.AxisX?.Minimum ?? ChartAreaBaseModel.AxisX.Minimum,
				Interval = model.AxisX?.Interval ?? ChartAreaBaseModel.AxisX.Interval,
				Title = model.AxisX?.Title ?? ChartAreaBaseModel.AxisX.Title,
				TitleAlignment = StringAlignment.Far,
				LineWidth = model.AxisX?.LineWidth ?? ChartAreaBaseModel.AxisX.LineWidth,
				MajorGrid = model.AxisX?.MajorGrid ?? ChartAreaBaseModel.AxisX.MajorGrid,
				LabelAutoFitMinFontSize = model.AxisX?.LabelAutoFitMinFontSize ?? ChartAreaBaseModel.AxisX.LabelAutoFitMinFontSize,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				LabelAutoFitStyle = LabelAutoFitStyles.IncreaseFont
			},
			AxisY = new Axis
			{
				Maximum = model.AxisY?.Maximum ?? ChartAreaBaseModel.AxisY.Maximum,
				Minimum = model.AxisY?.Minimum ?? ChartAreaBaseModel.AxisY.Minimum,
				Interval = model.AxisY?.Interval ?? ChartAreaBaseModel.AxisY.Interval,
				Title = model.AxisY?.Title ?? ChartAreaBaseModel.AxisY.Title,
				LabelStyle = model.AxisY?.LabelStyle ?? ChartAreaBaseModel.AxisY.LabelStyle,
				TitleAlignment = StringAlignment.Far,
				LineWidth = model.AxisY?.LineWidth ?? ChartAreaBaseModel.AxisY.LineWidth,
				MajorGrid = model.AxisY?.MajorGrid ?? ChartAreaBaseModel.AxisY.MajorGrid,
				LabelAutoFitMinFontSize = model.AxisY?.LabelAutoFitMinFontSize ?? ChartAreaBaseModel.AxisY.LabelAutoFitMinFontSize,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
				LabelAutoFitStyle = LabelAutoFitStyles.IncreaseFont
			}
		};

		if (model.IsZoomAvailable)
		{
			chartArea.AxisX.ScaleView = GetScaleView;
			chartArea.AxisX.ScrollBar = GetScrollBar;
			chartArea.AxisX.ScaleView.Zoom(-30, -30 + ZoomShift);
		}

		if (model.AxisX != null && model.AxisX.CustomLabels.Any())
		{
			foreach (var customLabels in model.AxisX.CustomLabels)
			{
				chartArea.AxisX.CustomLabels.Add(customLabels);
			}
		}

		if (model.AxisY != null && model.AxisY.CustomLabels.Any())
		{
			foreach (var customLabels in model.AxisY.CustomLabels)
			{
				chartArea.AxisY.CustomLabels.Add(customLabels);
			}
		}

		return chartArea;
	}

	public static void CreateCustomLabels(Axis axis, double singleSegmentInPixels, int minimumSingleSegmentInPixels = MinimumSingleSegmentInPixels)
	{
		if (axis.CustomLabels.Any() == false)
		{
			return;
		}

		var requiredCustomLabels = new CustomLabel[axis.CustomLabels.Count];
		axis.CustomLabels
			.Where(x => x.Tag is null)
			.ToArray()
			.CopyTo(requiredCustomLabels, 0);
		axis.CustomLabels.Clear();

		foreach (var requiredCustomLabel in requiredCustomLabels.Where(x => x is not null))
		{
			var isLabelAvailable = true;
			foreach (var customLabel in axis.CustomLabels)
			{
				if (Math.Abs(CalculateInitialPosition(customLabel.FromPosition) - CalculateInitialPosition(requiredCustomLabel.FromPosition)) * singleSegmentInPixels < minimumSingleSegmentInPixels)
				{
					isLabelAvailable = false;
					break;
				}
			}

			if (isLabelAvailable)
			{
				axis.CustomLabels.Add(requiredCustomLabel);
			}
		}

		if (axis.Interval != 0)
		{
			for (var i = axis.Minimum; i <= axis.Maximum; i += axis.Interval)
			{
				var isLabelAvailable = true;
				foreach (var customLabel in axis.CustomLabels)
				{
					if (Math.Abs(CalculateInitialPosition(customLabel.FromPosition) - i) * singleSegmentInPixels < minimumSingleSegmentInPixels)
					{
						isLabelAvailable = false;
						break;
					}
				}

				if (isLabelAvailable)
				{
					axis.CustomLabels.Add(CreateCustomLabel(i, null, i.ToString(CultureInfo.InvariantCulture)));
				}
			}
		}
	}

	public static CustomLabel CreateCustomLabel(double value, string? text = null, string tag = null)
	{
		return new CustomLabel
		{
			Text = text ?? Math.Round(value, 2).ToString(CultureInfo.InvariantCulture),
			FromPosition = CalculateFromPosition(value),
			ToPosition = CalculateToPosition(value),
			GridTicks = GridTickTypes.None,
			Tag = tag
		};
	}

	private static double CalculateFromPosition(double position, double step = 50)
	{
		return position - step;
	}

	private static double CalculateToPosition(double position, double step = 50)
	{
		return position + step;
	}

	private static double CalculateInitialPosition(double position, double step = 50)
	{
		return position + step;
	}
}

public class ChartAreaCreationModel
{
	public string? Name { get; set; }

	public Axis AxisX { get; set; }

	public Axis AxisY { get; set; }

	public bool IsZoomAvailable { get; set; }

	public bool IsOnlyCustomGridAvailable { get; set; }
}