using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace MatrixOperations.Shapes
{
    public class Verticle : GraphElement
    {
        public static readonly int RADIUS = 25;
        float radius;
        public string Text;
        public Verticle(Point p, Color c, string Text)
            : base(p, c)
        {
            radius = RADIUS;
            this.Text = Text;
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Position.X - radius, Position.Y - radius, radius * 2, radius * 2);
            TextRenderer.DrawText(g, Text, null, new Rectangle((int)(Position.X - radius), (int)(Position.Y - radius), (int)(radius * 2), (int)(radius * 2)), Color.White,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            b.Dispose();
        }

       
    }
}
