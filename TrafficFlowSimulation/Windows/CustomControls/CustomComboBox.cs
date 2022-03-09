using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TrafficFlowSimulation.Windows.CustomControls;

public partial class CustomComboBox : ComboBox
{
    static Color borderColor = Color.Black;
    public Color BorderColor
    {
        get { return borderColor; }
        set { borderColor = value; Invalidate(); }
    }
    public enum PenStyles
    {
        PS_SOLID = 0,
        PS_DASH = 1,
        PS_DOT = 2,
        PS_DASHDOT = 3,
        PS_DASHDOTDOT = 4
    }

    public enum ComboBoxButtonState
    {
        STATE_SYSTEM_NONE = 0,
        STATE_SYSTEM_INVISIBLE = 0x00008000,
        STATE_SYSTEM_PRESSED = 0x00000008
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct COMBOBOXINFO
    {
        public Int32 cbSize;
        public RECT rcItem;
        public RECT rcButton;
        public ComboBoxButtonState buttonState;
        public IntPtr hwndCombo;
        public IntPtr hwndEdit;
        public IntPtr hwndList;
    }

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public RECT(int left_, int top_, int right_, int bottom_)
        {
            Left = left_;
            Top = top_;
            Right = right_;
            Bottom = bottom_;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is RECT))
            {
                return false;
            }

            return this.Equals((RECT) obj);
        }

        public bool Equals(RECT value)
        {
            return this.Left == value.Left &&
                   this.Top == value.Top &&
                   this.Right == value.Right &&
                   this.Bottom == value.Bottom;
        }

        public int Height
        {
            get { return Bottom - Top + 1; }
        }

        public int Width
        {
            get { return Right - Left + 1; }
        }

        public Size Size
        {
            get { return new Size(Width, Height); }
        }

        public Point Location
        {
            get { return new Point(Left, Top); }
        }

        // Handy method for converting to a System.Drawing.Rectangle
        public System.Drawing.Rectangle ToRectangle()
        {
            return System.Drawing.Rectangle.FromLTRB(Left, Top, Right, Bottom);
        }

        public static RECT FromRectangle(Rectangle rectangle)
        {
            return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
        }

        public void Inflate(int width, int height)
        {
            this.Left -= width;
            this.Top -= height;
            this.Right += width;
            this.Bottom += height;
        }

        public override int GetHashCode()
        {
            return Left ^ ((Top << 13) | (Top >> 0x13))
                        ^ ((Width << 0x1a) | (Width >> 6))
                        ^ ((Height << 7) | (Height >> 0x19));
        }

        public static implicit operator Rectangle(RECT rect)
        {
            return System.Drawing.Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        public static implicit operator RECT(Rectangle rect)
        {
            return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }
    }

    public CustomComboBox()
    {
        InitializeComponent();

        // Timer to check when the dropdown is fully visible
        _dropDownCheck.Interval = 100;
        _dropDownCheck.Tick += new EventHandler(dropDownCheck_Tick);
    }

    /// <summary>
    /// Override window messages
    /// </summary>
    protected override void WndProc(ref Message m)
    {
        
        // Filter window messages
        switch (m.Msg)
        {
            case WM_CTLCOLORLISTBOX:
                base.WndProc(ref m);
                DrawNativeBorder(m.LParam);
                break;
            case WM_PAINT:
                base.WndProc(ref m);
                using (var g = Graphics.FromHwnd(Handle))
                {
                    using (var p = new Pen(BorderColor))
                    {
                        g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);

                        var d = FlatStyle == FlatStyle.Popup ? 1 : 0;
                        g.DrawLine(p, Width - buttonWidth - d,
                            0, Width - buttonWidth - d, Height);
                    }
                }
                break;
            default:
                base.WndProc(ref m);
                break;
        }
    }

    public const int WM_CTLCOLORLISTBOX = 0x0134;
    private const int WM_PAINT = 0xF;
    private int buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
    private Timer _dropDownCheck = new Timer(); // Timer that checks when the drop down is fully visible

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("user32.dll")]
    public static extern IntPtr SetFocus(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi);

    [DllImport("gdi32.dll")]
    public static extern int ExcludeClipRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreatePen(PenStyles enPenStyle, int nWidth, int crColor);

    [DllImport("gdi32.dll")]
    public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

    [DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);

    [DllImport("gdi32.dll")]
    public static extern void Rectangle(IntPtr hdc, int X1, int Y1, int X2, int Y2);

    public static int RGB(int R, int G, int B)
    {
        return (R | (G << 8) | (B << 16));
    }

    /// <summary>
    /// On drop down
    /// </summary>
    protected override void OnDropDown(EventArgs e)
    {
        base.OnDropDown(e);

        // Start checking for the dropdown visibility
        _dropDownCheck.Start();
    }

    /// <summary>
    /// Checks when the drop down is fully visible
    /// </summary>
    private void dropDownCheck_Tick(object sender, EventArgs e)
    {
        // If the drop down has been fully dropped
        if (DroppedDown)
        {
            // Stop the time, send a listbox update
            _dropDownCheck.Stop();
            Message m = GetControlListBoxMessage(this.Handle);
            WndProc(ref m);
        }
    }

    /// <summary>
    /// Non client area border drawing
    /// </summary>
    /// <param name="m">The window message to process</param>
    /// <param name="handle">The handle to the control</param>
    public void DrawNativeBorder(IntPtr handle)
    {
        // Define the windows frame rectangle of the control
        RECT controlRect;
        GetWindowRect(handle, out controlRect);
        controlRect.Right -= controlRect.Left;
        controlRect.Bottom -= controlRect.Top;
        controlRect.Top = controlRect.Left = 0;

        // Get the device context of the control
        IntPtr dc = GetWindowDC(handle);

        // Define the client area inside the control rect
        RECT clientRect = controlRect;
        clientRect.Left += 1;
        clientRect.Top += 1;
        clientRect.Right -= 1;
        clientRect.Bottom -= 1;
        ExcludeClipRect(dc, clientRect.Left, clientRect.Top, clientRect.Right, clientRect.Bottom);

        // Create a pen and select it
        Color borderColor = BorderColor;
        IntPtr border = CreatePen(PenStyles.PS_SOLID, 1, RGB(borderColor.R, borderColor.G, borderColor.B));

        // Draw the border rectangle
        IntPtr borderPen = SelectObject(dc, border);
        Rectangle(dc, controlRect.Left, controlRect.Top, controlRect.Right, controlRect.Bottom);
        SelectObject(dc, borderPen);
        DeleteObject(border);

        // Release the device context
        ReleaseDC(handle, dc);
        SetFocus(handle);
    }

    /// <summary>
    /// Creates a default WM_CTLCOLORLISTBOX message
    /// </summary>
    /// <param name="handle">The drop down handle</param>
    /// <returns>A WM_CTLCOLORLISTBOX message</returns>
    public Message GetControlListBoxMessage(IntPtr handle)
    {
        // Force non-client redraw for focus border
        Message m = new Message();
        m.HWnd = handle;
        m.LParam = GetListHandle(handle);
        m.WParam = IntPtr.Zero;
        m.Msg = WM_CTLCOLORLISTBOX;
        m.Result = IntPtr.Zero;
        return m;
    }

    /// <summary>
    /// Gets the list control of a combo box
    /// </summary>
    /// <param name="handle"></param>
    /// <returns></returns>
    public static IntPtr GetListHandle(IntPtr handle)
    {
        COMBOBOXINFO info;
        info = new COMBOBOXINFO();
        info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
        return GetComboBoxInfo(handle, ref info) ? info.hwndList : IntPtr.Zero;
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        base.OnPaintBackground(e);
        using (var brush = new SolidBrush(BackColor))
        {
            e.Graphics.FillRectangle(brush, ClientRectangle);
            e.Graphics.DrawRectangle(Pens.DarkGray, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }
    }
}
