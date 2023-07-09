using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations.Shapes
{
    public abstract class GraphElement
    {
        public Point Position { get; set; }
        public Color Color { get; set; }

        public GraphElement(Point p, Color c)
        {
            Position = p;
            Color = c;
        }

        public abstract void Draw(Graphics g);


    }
}
