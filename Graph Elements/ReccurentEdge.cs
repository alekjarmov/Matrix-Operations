using MatrixOperations.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations.Graph_Elements
{
    internal class ReccurentEdge:IEdge
    {
        public Verticle Verticle { get; set; }
        public static float Thickness = 5;

        public ReccurentEdge(Verticle verticle)
        {
            Verticle = verticle;
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Verticle.Color, Thickness);
            g.DrawEllipse(pen, Verticle.Position.X, Verticle.Position.Y, 2*Verticle.RADIUS, 2*Verticle.RADIUS);
            pen.Dispose();


            
        }
    }
}
