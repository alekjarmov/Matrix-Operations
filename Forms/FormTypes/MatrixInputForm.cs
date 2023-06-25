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

        protected int[,] FirstMatrixValues;
        protected int[,] SecondMatrixValues;
        public MatrixInputForm()
        {

        }

        public void InitializeInputEnvironment(int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix, string Sign)
        {
            this.SetWidthAndHeight(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix);
            CalculateButton = this.GenerateAnimationButton(XFirstMatrix, XSecondMatrix);
            (FirstMatrix, SecondMatrix, ResultantMatrix) = this.GenerateMatrices(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix, Sign);

            FirstMatrixValues = TransformNumericalUpDownToIntegerMatrix(FirstMatrix);
            SecondMatrixValues = TransformNumericalUpDownToIntegerMatrix(SecondMatrix);


        }

        private int[,] TransformNumericalUpDownToIntegerMatrix(NumericUpDown[,] Matrix)
        {
            int[,] Values = new int[Matrix.GetLength(0), Matrix.GetLength(1)];
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Values[i, j] = (int)Matrix[i, j].Value;
                }
            }
            return Values;
        }

        public abstract void StartAnimation(object? sender, EventArgs e);
    }
}
