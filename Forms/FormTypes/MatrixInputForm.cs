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
    public abstract partial class MatrixInputForm : Form
    {
        protected NumericUpDown[,] FirstMatrix;
        protected NumericUpDown[,] SecondMatrix;
        protected TextBox[,] ResultantMatrix;
        protected Button CalculateButton;
        protected Button RandomizeButton;
        protected Button ClearButton;
        protected int XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix;
        protected string Sign;
        protected CancellationTokenSource IterationToken;
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
        protected void ResetColorNumericUpDowns()
        {
            for (int i = 0; i < FirstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < FirstMatrix.GetLength(1); j++)
                {
                    FirstMatrix[i, j].BackColor = Color.White;
                }
            }
            for (int i = 0; i < SecondMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < SecondMatrix.GetLength(1); j++)
                {
                    SecondMatrix[i, j].BackColor = Color.White;
                }
            }
        }
        protected void ResetResultantMatrix()
        {
            for (int i = 0; i < ResultantMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < ResultantMatrix.GetLength(1); j++)
                {
                    ResultantMatrix[i, j].BackColor = Color.White;
                    ResultantMatrix[i, j].Text = "";
                }
            }
            
        }
        protected abstract Task Animate(CancellationToken token);
        public void InitializeInputEnvironment(int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix, string Sign)
        {
            (this.XFirstMatrix, this.YFirstMatrix, this.XSecondMatrix, this.YSecondMatrix) = (XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix);
            this.Sign = Sign;
            Text = "Calculation Visualization";
            this.SetWidthAndHeight(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix);
            
            (FirstMatrix, SecondMatrix, ResultantMatrix) = this.GenerateMatrices(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix, Sign);
            ResetColorNumericUpDowns();
            ResetResultantMatrix();
            CalculateButton = this.GenerateButton(XFirstMatrix, XSecondMatrix, "Calculate", StartAnimation, Variables.LeftOffset);
            RandomizeButton = this.GenerateButton(XFirstMatrix, XSecondMatrix, "Randomize", RandomizeInputs,
                Variables.LeftOffset + Variables.ButtonsMarginLeft + CalculateButton.Width);
            ClearButton = this.GenerateButton(XFirstMatrix, XSecondMatrix, "Clear", GenerateAllInputs,
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

        public void GenerateAllInputs(object? sender, EventArgs e)
        {
            if(IterationToken!=null)
                IterationToken.Cancel();
            IterationToken = null;
            Controls.Clear();
            (FirstMatrix, SecondMatrix, ResultantMatrix) = this.GenerateMatrices(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix, Sign);

            CalculateButton = this.GenerateButton(XFirstMatrix, XSecondMatrix, "Calculate", StartAnimation, Variables.LeftOffset);
            RandomizeButton = this.GenerateButton(XFirstMatrix, XSecondMatrix, "Randomize", RandomizeInputs,
                Variables.LeftOffset + Variables.ButtonsMarginLeft + CalculateButton.Width);
            ClearButton = this.GenerateButton(XFirstMatrix, XSecondMatrix, "Clear", GenerateAllInputs,
                Variables.LeftOffset + 2 * Variables.ButtonsMarginLeft + 2 * CalculateButton.Width);

            ResetColorNumericUpDowns();
            ResetResultantMatrix();
            this.GenerateLabels(YFirstMatrix, YSecondMatrix);

        }
        public async void StartAnimation(object? sender, EventArgs e)
        {
            CalculateButton.Enabled = false;
            RandomizeButton.Enabled = false;
            EnableAllNumericUpDowns(false);
            IterationToken = new CancellationTokenSource();
            
            await Animate(IterationToken.Token);
            
            EndAnimation();
            
            

        }
        public void EndAnimation()
        {
            CalculateButton.Enabled = true;
            RandomizeButton.Enabled = true;
            EnableAllNumericUpDowns();
            

        }
    }
}
