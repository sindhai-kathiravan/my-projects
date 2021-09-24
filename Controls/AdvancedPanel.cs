using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntryPhoneSystem
{
    public class AdvancedPanel : Panel
    {
        #region Variables

        ///// <summary>Panel border style.</summary>
        //public enum BevelStyle
        //{
        //    /// <summary>Lowered border.</summary>
        //    Lowered,
        //    /// <summary>Raised border.</summary>
        //    Raised,
        //    /// <summary>Thin border.</summary>
        //    Flat
        //}

        public enum ShadowMode
        {
            /// <summary>Specifies a shodow from upper left to lower right.</summary>
            ForwardDiagonal = 0,

            /// <summary>Specifies a surrounded shadow.</summary>
            Surrounded = 1,

            /// <summary>Specifies a dropped shadow.</summary>
            Dropped = 2

        }

        //public enum PanelGradientMode
        //{
        //    /// <summary>Specifies a gradient from upper right to lower left.</summary>
        //    BackwardDiagonal = 3,

        //    /// <summary>Specifies a gradient from upper left to lower right.</summary>
        //    ForwardDiagonal = 2,

        //    /// <summary>Specifies a gradient from left to right.</summary>
        //    Horizontal = 0,

        //    /// <summary>Specifies a gradient from top to bottom.</summary>
        //    Vertical = 1
        //}



        Color _startColor = Color.FromArgb(232, 238, 249);
        Color _endColor = Color.FromArgb(168, 192, 234);
        private Color _borderColor = Color.FromArgb(102, 102, 102);
        private Color mainColor;


        private int _rectRadius = 0;
        // private PanelGradientMode _backgroundGradientMode = PanelGradientMode.Vertical;
        private int _shadowShift = 0;
        private Color _shadowColor = Color.DimGray;
        private const int sh = 10;
        private int _edgeWidth = 2;

        private Color edgeColor1;
        private Color edgeColor2;
        //    private BevelStyle _style = BevelStyle.Flat;
        private ShadowMode _shadowStyle = ShadowMode.ForwardDiagonal;



        /// <summary>
        /// Gets or sets the style of the shadow.
        /// </summary>
        [Browsable(true), Category("AdvancedPanel"), Description("Style of the shadow.")]
        public ShadowMode ShadowStyle
        {
            get
            {
                return _shadowStyle;
            }
            set
            {
                _shadowStyle = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The width of an edge
        /// </summary>
        [Browsable(true), Category("AdvancedPanel"), Description("The width of an edge.")]
        public int EdgeWidth
        {
            get
            {
                return _edgeWidth;
            }
            set
            {
                _edgeWidth = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the style of the bevel
        /// </summary>
        /// [Browsable(true), Category("AdvancedPanel"), Description("The style of the bevel.")]
        //public BevelStyle Style
        //{
        //    get
        //    {
        //        return _style;
        //    }
        //    set
        //    {
        //        _style = value;
        //        Invalidate();
        //    }
        //}

        ///// <summary>
        ///// Gets or sets begin gradient color
        ///// </summary>
        //[Browsable(true), Category("AdvancedPanel"), Description("The begin gradient color.")]
        //public Color StartColor
        //{
        //    get { return _startColor; }
        //    set
        //    {
        //        _startColor = value;
        //        Invalidate();
        //    }
        //}

        /// <summary>
        /// Gets or sets end gradient color
        /// </summary>
        [Browsable(true), Category("AdvancedPanel"), Description("The end Panel Color.")]
        public Color PanelColor
        {
            get { return _endColor; }
            set
            {
                _endColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shadow shift
        /// </summary>
        [Browsable(true), Category("AdvancedPanel"), Description("The shadow shift.")]
        public int ShadowShift
        {
            get { return _shadowShift; }
            set
            {
                _shadowShift = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the shadow color
        /// </summary>
        [Browsable(true), Category("AdvancedPanel"), Description("The shadow color.")]
        public Color ShadowColor
        {
            get { return _shadowColor; }
            set
            {
                _shadowColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Border color in flat mode
        /// </summary>
        [Browsable(true), Category("AdvancedPanel"), Description("The flat border color.")]
        public Color FlatBorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }


        ///// <summary>
        ///// Gets or sets the background gradient mode
        ///// </summary>
        //[Browsable(true), Category("AdvancedPanel"), Description("The gradient type.")]
        //public PanelGradientMode BackgroundGradientMode
        //{
        //    get { return _backgroundGradientMode; }
        //    set
        //    {
        //        _backgroundGradientMode = value;
        //        Invalidate();
        //    }
        //}

        /// <summary>
        /// Gets or sets the corner round radius
        /// </summary>
        [Browsable(true), Category("AdvancedPanel"), Description("The corner round radius.")]
        public int RectRadius
        {
            get { return _rectRadius; }
            set
            {
                _rectRadius = value;
                Invalidate();
            }
        }

        #endregion

        public AdvancedPanel()
        {
            this.Size = new Size(200, 50);
            this.Paint += this.AdvancedPanel_Paint;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #region Paint

        private void AdvancedPanel_Paint(object sender, PaintEventArgs e)
        {
            var panelRect = new Rectangle();

            if (_shadowShift > 0)
            {
                DrawShadow(e.Graphics);
            }

            switch (_shadowStyle)
            {
                case ShadowMode.ForwardDiagonal:

                    panelRect = new Rectangle(
                        0,
                        0,
                        Width - _shadowShift - 1,
                        Height - _shadowShift - 1);

                    break;
                case ShadowMode.Surrounded:
                    panelRect = new Rectangle(ShadowShift,
                    _shadowShift + _edgeWidth,
                    Width - (2 * ShadowShift) - 1,
                    Height - (2 * ShadowShift) - 1);
                    break;
                case ShadowMode.Dropped:
                    panelRect = new Rectangle(0,
                    0,
                    Width - 1,
                    Height - (2 * ShadowShift) - 1);
                    break;
            }
            DrawRect(e.Graphics, panelRect);

        }

        private void DrawRectLowered(Graphics graphics, Rectangle rect)
        {
            var darknessEnd = _endColor.GetSaturation();
            var darknessBegin = _startColor.GetSaturation();
            mainColor = darknessEnd <= darknessBegin ? _endColor : _startColor;

            edgeColor1 = ControlPaint.Dark(mainColor);
            edgeColor2 = ControlPaint.Light(mainColor);

            DrawEdges(graphics, ref rect);
            rect.Inflate(-_edgeWidth, -_edgeWidth);
            DrawPanelStyled(graphics, rect);
        }



        private void DrawRect(Graphics graphics, Rectangle rect)
        {

            // Border rectangle
            using (Brush backgroundGradientBrush = new SolidBrush(_borderColor))
            {
                RoundedRectangle.DrawFilledRoundedRectangle(graphics, backgroundGradientBrush,
                    rect, _rectRadius);
            }

            rect.Inflate(-_edgeWidth, -_edgeWidth);

            // Panel main rectangle
            //using (Brush backgroundGradientBrush = new LinearGradientBrush(
            //    rect, _startColor, _endColor, (LinearGradientMode)this.BackgroundGradientMode))
            //{
            SolidBrush redBrush = new SolidBrush(_endColor);
            RoundedRectangle.DrawFilledRoundedRectangle(graphics, redBrush,
                rect, _rectRadius);
            // }

        }


        private void DrawRectRaised(Graphics graphics, Rectangle rect)
        {

            var darknessEnd = _endColor.GetSaturation();
            var darknessBegin = _startColor.GetSaturation();
            mainColor = darknessEnd >= darknessBegin ? _endColor : _startColor;

            edgeColor1 = ControlPaint.Light(_startColor);
            edgeColor2 = ControlPaint.Dark(_endColor);

            DrawEdges(graphics, ref rect);
            rect.Inflate(-_edgeWidth, -_edgeWidth);
            DrawPanelStyled(graphics, rect);

        }


        /// <summary>
        /// Fill in the panel edges
        /// </summary>
        /// <param name="g">Graphics Object</param>
        /// <param name="edgeRect">Rectangle defining the panel edge</param>
        protected virtual void DrawEdges(Graphics g, ref Rectangle edgeRect)
        {

            Rectangle lgbRect = edgeRect;
            lgbRect.Inflate(1, 1);

            // Blend colors 
            var edgeBlend = new Blend();
            if (RectRadius >= 150)
            {
                edgeBlend.Positions = new float[] { 0.0f, .2f, .4f, .6f, .8f, 1.0f };
                edgeBlend.Factors = new float[] { .0f, .0f, .2f, .4f, 1f, 1f };
            }
            else
            {
                //switch (Style)
                //{
                //    case BevelStyle.Lowered:
                //        edgeBlend.Positions = new float[] { 0.0f, .49f, .52f, 1.0f };
                //        edgeBlend.Factors = new float[] { .0f, .6f, .99f, 1f };


                //        break;
                //    case BevelStyle.Raised:
                //        edgeBlend.Positions = new float[] { 0.0f, .45f, .51f, 1.0f };
                //        edgeBlend.Factors = new float[] { .0f, .0f, .2f, 1f };
                //        break;
                //}
            }


            using (var edgeBrush = new LinearGradientBrush(lgbRect,
                                                edgeColor1,
                                                edgeColor2,
                                                LinearGradientMode.ForwardDiagonal))
            {
                edgeBrush.Blend = edgeBlend;
                RoundedRectangle.DrawFilledRoundedRectangle(g, edgeBrush, edgeRect, _rectRadius);
            }
        }

        /// <summary>
        /// Fill in the main panel with gradient
        /// </summary>
        /// <param name="g">Graphics Object</param>
        /// <param name="rect">Rectangle defining the panel top</param>
        protected virtual void DrawPanelStyled(Graphics g, Rectangle rect)
        {
            //using (Brush pgb = new LinearGradientBrush(rect, _startColor, _endColor,
            //    (LinearGradientMode)this.BackgroundGradientMode))
            //{
            SolidBrush redBrush = new SolidBrush(_endColor);
            RoundedRectangle.DrawFilledRoundedRectangle(g, redBrush, rect, _rectRadius);
            //}

        }

        private void DrawShadow(Graphics graphics)
        {
            Rectangle rect = new Rectangle();
            GraphicsPath path;
            switch (_shadowStyle)
            {
                case ShadowMode.ForwardDiagonal:
                    rect = new Rectangle(ShadowShift + sh, ShadowShift + sh,
                                    Width - ShadowShift - sh, Height - ShadowShift - sh);
                    break;
                case ShadowMode.Surrounded:
                    rect = new Rectangle(0, 0, Width, Height);
                    break;
                case ShadowMode.Dropped:
                    rect = new Rectangle(_shadowShift, 0, Width - 2 * _shadowShift, Height);
                    break;
            }

            if (_shadowStyle != ShadowMode.Dropped)
            {
                path = RoundedRectangle.DrawRoundedRectanglePath(rect, _rectRadius);
            }
            else
            {
                path = RoundedRectangle.DrawRoundedRectanglePath(rect, _rectRadius, true);
            }

            using (PathGradientBrush shadowBrush = new PathGradientBrush(path))
            {
                shadowBrush.CenterPoint = new PointF(rect.Width / 2,
                    rect.Height / 2);

                // Set the color along the entire boundary 
                Color[] color = { Color.Transparent };
                shadowBrush.SurroundColors = color;

                // Set the center color 
                shadowBrush.CenterColor = _shadowColor;
                graphics.FillPath(shadowBrush, path);

                shadowBrush.FocusScales = new PointF(0.95f, 0.85f);
                graphics.FillPath(shadowBrush, path);

            }

        }


        #endregion

    }

    public class RoundedRectangle
    {

        public static GraphicsPath DrawRoundedRectanglePath(Rectangle rect,
                                          int radius)
        {
            return DrawRoundedRectanglePath(rect, radius, false);
        }

        public static GraphicsPath DrawRoundedRectanglePath(Rectangle rect,
            int radius, bool dropStyle)
        {
            int x = rect.X;
            int y = rect.Y;
            int width = rect.Width;
            int height = rect.Height;

            int xw = x + width;
            int yh = y + height;
            int xwr = xw - radius;
            int yhr = yh - radius;
            int xr = x + radius;
            int yr = y + radius;
            int r2 = radius * 2;
            int xwr2 = xw - r2;
            int yhr2 = yh - r2;
            int xw2 = x + width / 2;
            int yh10 = yh - height / 20;

            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            //Top Left Corner
            if (r2 > 0)
            {
                p.AddArc(x, y, r2, r2, 180, 90);
            }

            //Top Edge
            p.AddLine(xr, y, xwr, y);

            //Top Right Corner
            if (r2 > 0)
            {
                p.AddArc(xwr2, y, r2, r2, 270, 90);
            }

            //Right Edge
            p.AddLine(xw, yr, xw, yhr);

            //Bottom Right Corner
            if (r2 > 0)
            {
                p.AddArc(xwr2, yhr2, r2, r2, 0, 90);
            }

            //Bottom Edge
            if (dropStyle)
            {
                p.AddBezier(
                    new Point(xwr, yh),
                    new Point(xw2, yh10),
                    new Point(xw2, yh10),
                    new Point(xr, yh));
            }
            else
            {
                p.AddLine(xwr, yh, xr, yh);
            }


            //Bottom Left Corner
            if (r2 > 0)
            {
                p.AddArc(x, yhr2, r2, r2, 90, 90);
            }

            //Left Edge
            p.AddLine(x, yhr, x, yr);


            p.CloseFigure();
            return p;
        }





        public static GraphicsPath DrawFilledRoundedRectangle(Graphics graphics, Brush rectBrush, Rectangle rect,
                                  int radius)
        {
            GraphicsPath path = DrawRoundedRectanglePath(rect, radius);
            SmoothingMode mode = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(rectBrush, path);
            graphics.SmoothingMode = mode;
            return path;
        }


        public static GraphicsPath DrawRoundedRectangle(Graphics graphics, Pen pen, Rectangle rect,
                          int radius)
        {
            GraphicsPath path = DrawRoundedRectanglePath(rect, radius);
            SmoothingMode mode = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = mode;
            return path;
        }



    }
}
