using MatrixOperations.Graph_Elements;
using MatrixOperations.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MatrixOperations.Forms
{
    public partial class GraphVisualization : Form
    {
        int NumberPoints;
        int[,] Relations;
        List<Verticle> Verticles;
        List<IEdge> Edges;

        public GraphVisualization(int NumberPoints, int[,] Relations)
        {
            InitializeComponent();
            this.NumberPoints = NumberPoints;
            this.Relations = Relations;
            InitializeGraph();

        }

        private void InitializeGraph()
        {
            Verticles = new List<Verticle>();
            Edges = new List<IEdge>();

            GenerateVerticlesOnRandomLocations();
            GenerateEdges();
            Invalidate(true);
        }

        public void GenerateVerticlesOnRandomLocations()
        {
            Random random = new Random();
            List<Point> centersVerticles = new List<Point>();
            for (int i = 0; i < NumberPoints; i++)
            {
                centersVerticles.Add(new Point(random.Next(0 + Verticle.RADIUS, ClientSize.Width - Verticle.RADIUS), random.Next(0 + Verticle.RADIUS, ClientSize.Height - Verticle.RADIUS)));
            }
            GenerateVerticles(centersVerticles);
        }

        private void GenerateEdges()
        {
            for(int i=0; i<Relations.GetLength(0); i++)
            {
                for (int j = 0; j < Relations.GetLength(1); j++)
                {
                    if (i>j && Relations[i, j] == 1)
                    {
                        Verticle v1 = Verticles[i];
                        Verticle v2 = Verticles[j];
                        Edges.Add(new Edge(v1.Position,v2.Position,v1, v2));
                    }
                    else if (i==j && Relations[i, j] == 1)
                    {
                        Edges.Add(new ReccurentEdge(Verticles[i]));
                    }
                }
            }
            
        }

        private void DrawVerticles(Graphics g)
        {
            foreach (Verticle circle in Verticles)
            {
                circle.Draw(g);
            }
        }
        private void DrawEdges(Graphics g)
        {
            foreach (IEdge edge in Edges)
            {
                edge.Draw(g);
            }
        }

        private void GenerateVerticles(List<Point> centersVerticles)
        {
            Random random = new Random();
            for(int index = 0; index<centersVerticles.Count;index++) 
            {
                Point point = centersVerticles[index];
                Verticle verticle = new Verticle(point, Color.FromArgb(255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), $"{index+1}");
                Verticles.Add(verticle);
            }
        }

        private void GraphVisualization_Paint(object sender, PaintEventArgs e)
        {
            DrawEdges(e.Graphics);
            DrawVerticles(e.Graphics);
        }

        
    }
}
