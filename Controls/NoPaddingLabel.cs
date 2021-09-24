using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntryPhoneSystem
{
    public partial class NoPaddingLabel : Label
    {
        private TextFormatFlags flags = TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding;

        public bool RightAlignment
        {
            get
            {
                return (flags & TextFormatFlags.Right) == TextFormatFlags.Right;
            }
            set
            {
                if (value)
                {
                    flags = flags |= TextFormatFlags.Right;
                }
                else
                {
                    flags = flags &= ~TextFormatFlags.Right;
                }
                Invalidate();
            }
        }


        //public NoPaddingLabel()
        //{
        // /   InitializeComponent();
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //      TextRenderer.DrawText(e.Graphics, this.Text, this.Font, ClientRectangle, this.ForeColor, Color.Transparent, flags);

        //}

        protected override void OnPaint(PaintEventArgs e)
        {
            Point drawPoint = new Point(0, 0);

            //string[] ary = Text.Split(new char[] { '|' });
            //if (ary.Length == 2)
            //{
            //    Font normalFont = this.Font;

            //    Font boldFont = new Font(normalFont, FontStyle.Bold);

            //    Size normalSize = TextRenderer.MeasureText(ary[0].Trim(), normalFont);
            //    Size boldSize = TextRenderer.MeasureText(ary[1].Trim(), boldFont);

            //    Rectangle normalRect = new Rectangle(drawPoint, normalSize);
            //    Rectangle boldRect = new Rectangle(normalRect.Right - 5, normalRect.Top, boldSize.Width, boldSize.Height);

            //    TextRenderer.DrawText(e.Graphics, ary[0], normalFont, normalRect, ForeColor);
            //    TextRenderer.DrawText(e.Graphics, ary[1], boldFont, boldRect, ForeColor);
            //}
            //else
            //{

            //    TextRenderer.DrawText(e.Graphics, Text, Font, drawPoint, ForeColor);
            //}
            Font normalFont = this.Font;
            Size normalSize = TextRenderer.MeasureText(Text, normalFont);
            Rectangle normalRect = new Rectangle(drawPoint, normalSize);
            TextRenderer.DrawText(e.Graphics, Text, normalFont, normalRect, ForeColor);


        }
    }
}
