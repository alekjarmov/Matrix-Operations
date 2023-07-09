using MatrixOperations.Graph_Elements;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations.Shapes
{
    public class Edge:IEdge
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public static float Thickness = 5;

        public Verticle Verticle1 { get; set; }
        public Verticle Verticle2 { get; set; }
        public Edge(Point s, Point e,  Verticle v1, Verticle v2)
        {
            Start = s;
            End = e;
            Verticle1 = v1;
            Verticle2 = v2;
        }

        public void Draw(Graphics g)
        {
            using (Brush brush = new LinearGradientBrush(Verticle1.Position, Verticle2.Position, Verticle1.Color, Verticle2.Color))
            {
                using (Pen pen = new Pen(brush, Thickness))
                {
                    g.DrawLine(pen, Start, End);
                }
               
            }
            GC.Collect();
            
        }
    }
}
