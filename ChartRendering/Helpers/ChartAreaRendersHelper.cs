using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartRendering.Helpers;

// ReSharper disable ConstantConditionalAccessQualifier

public static class ChartAreaRendersHelper
{
	private static readonly double ZoomShift = 48;
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
		},
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
				TitleFont = new Font("Microsoft Sans Serif", 10F)
			},
			AxisY = new Axis
			{
				Maximum = model.AxisY?.Maximum ?? ChartAreaBaseModel.AxisY.Maximum,
				Minimum = model.AxisY?.Minimum ?? ChartAreaBaseModel.AxisY.Minimum,
				Interval = model.AxisY?.Interval ?? ChartAreaBaseModel.AxisY.Interval,
				Title = model.AxisY?.Title ?? ChartAreaBaseModel.AxisY.Title,
				TitleAlignment = StringAlignment.Far,
				TitleFont = new Font("Microsoft Sans Serif", 10F),
			}
		};

		if (model.IsZoomAvailable)
		{
			chartArea.AxisX.ScaleView = GetScaleView;
			chartArea.AxisX.ScrollBar = GetScrollBar;
			chartArea.AxisX.ScaleView.Zoom(-30, -30 + ZoomShift);
		}

		return chartArea;
	}
}

public class ChartAreaCreationModel
{
	public string? Name { get; set; }

	public Axis AxisX { get; set; }

	public Axis AxisY { get; set; }

	public bool IsZoomAvailable { get; set; }
}