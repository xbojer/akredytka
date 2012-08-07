using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Akredytka.Classes
{
    public class NamedDescriptionDecoration : BrightIdeasSoftware.AbstractDecoration
    {
        public ImageList ImageList;
        public string ImageName;
        public string Title;
        public string Description;

        public Font TitleFont = new Font("Segoe UI", 15, FontStyle.Bold);
        public Color TitleColor = Color.FromArgb(255, 32, 32, 32);
        public Font DescripionFont = new Font("Segoe UI", 14);
        public Color DescriptionColor = Color.FromArgb(255, 96, 96, 96);
        public Size CellPadding = new Size(2, 2);

        public override void Draw(BrightIdeasSoftware.ObjectListView olv, Graphics g, Rectangle r)
        {
            Rectangle cellBounds = this.CellBounds;
            cellBounds.Inflate(-this.CellPadding.Width, -this.CellPadding.Height);
            Rectangle textBounds = cellBounds;

            if (this.ImageList != null && !String.IsNullOrEmpty(this.ImageName))
            {
                g.DrawImage(this.ImageList.Images[this.ImageName], cellBounds.Location);
                textBounds.X += this.ImageList.ImageSize.Width;
                textBounds.Width -= this.ImageList.ImageSize.Width;
            }

            //g.DrawRectangle(Pens.Red, textBounds);

            // Draw the title
            using (StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap))
            {
                fmt.Trimming = StringTrimming.EllipsisCharacter;
                fmt.Alignment = StringAlignment.Near;
                fmt.LineAlignment = StringAlignment.Near;
                using (SolidBrush b = new SolidBrush(this.TitleColor))
                {
                    g.DrawString(this.Title, this.TitleFont, b, textBounds, fmt);
                }
                // Draw the description
                SizeF size = g.MeasureString(this.Title, this.TitleFont, (int)textBounds.Width, fmt);
                textBounds.Y += (int)size.Height;
                textBounds.Height -= (int)size.Height;
            }

            // Draw the description
            using (StringFormat fmt2 = new StringFormat())
            {
                fmt2.Trimming = StringTrimming.EllipsisCharacter;
                using (SolidBrush b = new SolidBrush(this.DescriptionColor))
                {
                    g.DrawString(this.Description, this.DescripionFont, b, textBounds, fmt2);
                }
            }
        }
    }
}
