using System.Drawing;
using System.Windows.Forms;

namespace TrafficFlowSimulation.Windows
{
	internal class ControlToolStripCustomRender : ToolStripProfessionalRenderer
	{
		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if (!e.Item.Selected)
			{
				base.OnRenderButtonBackground(e);
			}
			else
			{
				Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
				e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), rectangle);
				e.Graphics.DrawRectangle(Pens.Black, rectangle);
			}
		}

		protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if (!e.Item.Selected)
			{
				base.OnRenderDropDownButtonBackground(e);
			}
			else
			{
				Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
				e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), rectangle);
				e.Graphics.DrawRectangle(Pens.Black, rectangle);
			}
		}

		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
			if (!e.Item.Selected)
			{
				base.OnRenderDropDownButtonBackground(e);
			}
			else
			{
				Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
				e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), rectangle);
				e.Graphics.DrawRectangle(Pens.Black, rectangle);
			}
		}
	}
}