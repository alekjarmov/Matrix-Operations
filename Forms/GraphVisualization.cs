﻿using MatrixOperations.Graph_Elements;
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
        public static int LeftMargin = 20;
        public static int RightMargin = 20;
        public static int TopMargin = 20;
        public static int BottomMargin = 20;

        public bool dragStarted = false;
        public Verticle draggingVerticle = null;
        public GraphVisualization(int NumberPoints, int[,] Relations)
        {

            InitializeComponent();
            DoubleBuffered = true;
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
                centersVerticles.Add(new Point(random.Next(0 + 2 * Verticle.RADIUS + LeftMargin, ClientSize.Width - 2 * Verticle.RADIUS - RightMargin),
                                                random.Next(0 + 2 * Verticle.RADIUS + TopMargin, ClientSize.Height - 2 * Verticle.RADIUS - BottomMargin)));
            }
            GenerateVerticles(centersVerticles);
        }

        private void GenerateEdges()
        {
            Edges = new List<IEdge>();
            for (int i = 0; i < Relations.GetLength(0); i++)
            {
                for (int j = 0; j < Relations.GetLength(1); j++)
                {
                    if (i > j && Relations[i, j] == 1)
                    {
                        Verticle v1 = Verticles[i];
                        Verticle v2 = Verticles[j];
                        Edges.Add(new Edge(v1.Position, v2.Position, v1, v2));
                    }
                    else if (i == j && Relations[i, j] == 1)
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
            for (int index = 0; index < centersVerticles.Count; index++)
            {
                Point point = centersVerticles[index];
                Verticle verticle = new Verticle(point, Color.FromArgb(255, random.Next(30, 255), random.Next(30, 255), random.Next(30, 255)), $"{index + 1}");
                Verticles.Add(verticle);
            }
        }

        private void GraphVisualization_Paint(object sender, PaintEventArgs e)
        {
            DrawEdges(e.Graphics);
            DrawVerticles(e.Graphics);
        }

        private void GraphVisualization_MouseDown(object sender, MouseEventArgs e)
        {
            if (!dragStarted)
            {
                Point MouseLocation = e.Location;

                foreach (Verticle vert in Verticles)
                {
                    if ((MouseLocation.X - vert.Position.X) * (MouseLocation.X - vert.Position.X) + (MouseLocation.Y - vert.Position.Y) * (MouseLocation.Y - vert.Position.Y)
                    <= Verticle.RADIUS * Verticle.RADIUS)
                    {
                        draggingVerticle = vert;
                        dragStarted = true;

                        break;
                    }
                }
            }
        }

        private void GraphVisualization_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragStarted)
            {
                draggingVerticle.Position = e.Location;
                GenerateEdges();
                Invalidate();
            }
        }

        private void GraphVisualization_MouseUp(object sender, MouseEventArgs e)
        {
            if (dragStarted)
            {
                dragStarted = false;
                draggingVerticle.Position = e.Location;
                GenerateEdges();
                Invalidate();
            }
        }
    }
}
