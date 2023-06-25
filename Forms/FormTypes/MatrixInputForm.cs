using MatrixOperations.Initialization_files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixOperations.Forms.FormTypes
{
    public partial class MatrixInputForm : Form
    {
        protected NumericUpDown[,] FirstMatrix;
        protected NumericUpDown[,] SecondMatrix;
        protected TextBox[,] ResultantMatrix;
        protected Button CalculateButton;
        protected Button RandomizeButton;
        protected Button ClearButton;

        public MatrixInputForm()
        {

        }
        protected void EnableAllNumericUpDowns(bool Enable = true)
        {
            for (int i = 0; i < FirstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < FirstMatrix.GetLength(1); j++)
                {
                    FirstMatrix[i, j].Enabled = Enable;
                }
            }
            for (int i = 0; i < SecondMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < SecondMatrix.GetLength(1); j++)
                {
                    SecondMatrix[i, j].Enabled = Enable;
                }
            }
        }
        public void InitializeInputEnvironment(int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix, string Sign)
        {
            Text = "Calculation Visualization";
            this.SetWidthAndHeight(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix);
            
            (FirstMatrix, SecondMatrix, ResultantMatrix) = this.GenerateMatrices(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix, Sign);

            CalculateButton = this.GenerateButton(XFirstMatrix, XSecondMatrix, "Calculate", StartAnimation, Variables.LeftOffset);
            RandomizeButton = this.GenerateButton(XFirstMatrix, XSecondMatrix, "Randomize", RandomizeInputs,
                Variables.LeftOffset + Variables.ButtonsMarginLeft + CalculateButton.Width);
            ClearButton = this.GenerateButton(XFirstMatrix, XSecondMatrix, "Clear", ClearInputs,
                Variables.LeftOffset + 2*Variables.ButtonsMarginLeft + 2*CalculateButton.Width);

            this.GenerateLabels(YFirstMatrix,YSecondMatrix);


        }
        public void RandomizeInputs(object? sender, EventArgs e)
        {
            Random random = new Random();
            for (int k = 0; k < FirstMatrix.GetLength(0); k++)
                for (int l = 0; l < FirstMatrix.GetLength(1); l++)
                    FirstMatrix[k, l].Value = random.Next(100)*(random.Next(2)%2==0 ? -1 : 1);
            for (int k = 0; k < SecondMatrix.GetLength(0); k++)
                for (int l = 0; l < SecondMatrix.GetLength(1); l++)
                    SecondMatrix[k, l].Value = random.Next(100) * (random.Next(2) % 2 == 0 ? -1 : 1);
        }
        public void ClearInputs(object? sender, EventArgs e)
        {
            for (int k = 0; k < FirstMatrix.GetLength(0); k++)
                for (int l = 0; l < FirstMatrix.GetLength(1); l++)
                    FirstMatrix[k, l].Value = 0;
            for (int k = 0; k < SecondMatrix.GetLength(0); k++)
                for (int l = 0; l < SecondMatrix.GetLength(1); l++)
                    SecondMatrix[k, l].Value = 0;
            for (int k = 0; k < ResultantMatrix.GetLength(0); k++)
                for (int l = 0; l < ResultantMatrix.GetLength(1); l++)
                    ResultantMatrix[k, l].Text = "";
        }
        public virtual void StartAnimation(object? sender, EventArgs e)
        {
            CalculateButton.Enabled = false;
            RandomizeButton.Enabled = false;
            ClearButton.Enabled = false;
            EnableAllNumericUpDowns(false);

        }
        public void EndAnimation()
        {
            CalculateButton.Enabled = true;
            RandomizeButton.Enabled = true;
            ClearButton.Enabled = true;
            EnableAllNumericUpDowns();
            

        }
    }
}
