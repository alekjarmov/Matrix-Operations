using MatrixOperations.Forms.FormTypes;
using MatrixOperations.Initialization_files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MatrixOperations
{
    public partial class MatrixMultiplicationInput : MatrixInputForm
    {
        
        public MatrixMultiplicationInput(decimal XFirstMatrix, decimal YFirstMatrix, decimal XSecondMatrix, decimal YSecondMatrix)
            : base()
        {
            InitializeComponent();

            InitializeInputEnvironment((int)XFirstMatrix, (int)YFirstMatrix, (int)XSecondMatrix, (int)YSecondMatrix, "*");
            
        }

        
        

        protected override async Task Animate(CancellationToken token)
        {
            CalculateButton.Enabled = false;
            RandomizeButton.Enabled = false;
            this.ResetResultantMatrix();
            for (int i = 0; i < FirstMatrix.GetLength(0); i++)
            {
                for (int x = 0; x < FirstMatrix.GetLength(1); x++)
                {
                    FirstMatrix[i, x].BackColor = Color.LightGreen;
                }

                for (int j = 0; j < SecondMatrix.GetLength(1); j++)
                {
                    for (int x = 0; x < SecondMatrix.GetLength(0); x++)
                    {
                        SecondMatrix[x, j].BackColor = Color.LightGreen;
                    }
                    for (int k = 0; k < SecondMatrix.GetLength(0); k++)
                    {
                        
                        FirstMatrix[i, k].BackColor = Color.LightPink;
                        SecondMatrix[k, j].BackColor = Color.LightPink;
                        ResultantMatrix[i, j].BackColor = Color.LightPink;
                        ResultantMatrix[i, j].ForeColor = Color.Black;
                        int ParsedResultantMatrixText = 0;

                        if (!ResultantMatrix[i, j].Text.Equals(""))
                            ParsedResultantMatrixText = Int32.Parse(ResultantMatrix[i, j].Text);
                        ResultantMatrix[i, j].Text = $"{ParsedResultantMatrixText + (FirstMatrix[i, k].Value * SecondMatrix[k, j].Value)}";
                        try
                        {
                            token.ThrowIfCancellationRequested();
                            await Task.Delay(Variables.IterationTime);
                        }
                        catch (OperationCanceledException ex)
                        {
                            ResetColorNumericUpDowns();
                            ResetResultantMatrix();
                            return;
                        }
                        FirstMatrix[i, k].BackColor = Color.LightGreen;
                        SecondMatrix[k, j].BackColor = Color.LightGreen;
                    }
                    for (int x = 0; x < SecondMatrix.GetLength(0); x++)
                    {
                        SecondMatrix[x, j].BackColor = Color.White;
                    }
                    ResultantMatrix[i, j].BackColor = Color.White;

                }
                for (int x = 0; x < FirstMatrix.GetLength(1); x++)
                {
                    FirstMatrix[i, x].BackColor = Color.White;
                }

            }

        }
    }
}
