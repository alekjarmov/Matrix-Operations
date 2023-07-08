using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixOperations.Forms
{
    public partial class GraphVisualization : Form
    {
        int NumberPoints;
        int[,] Relations;
        public GraphVisualization(int NumberPoints, int[,] Relations)
        {
            InitializeComponent();
            this.NumberPoints = NumberPoints;
            this.Relations = Relations;
            GenerateVerticlesOnRandomLocations();

        }
        public void GenerateVerticlesOnRandomLocations()
        {
            Random random = new Random();
            List<Point> centersVerticles = new List<Point>();
            for(int i=0;i<NumberPoints; i++)
            {
                centersVerticles.Add(new Point());
            }
        }

    }
}
