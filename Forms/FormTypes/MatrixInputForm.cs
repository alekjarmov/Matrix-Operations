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


        public MatrixInputForm()
        {

        }

        public void InitializeInputEnvironment(int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix, string Sign)
        {
            this.SetWidthAndHeight(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix);
            CalculateButton = this.GenerateAnimationButton(XFirstMatrix, XSecondMatrix);
            (FirstMatrix, SecondMatrix, ResultantMatrix) = this.GenerateMatrices(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix, Sign);
            this.GenerateLabels(YFirstMatrix,YSecondMatrix);


        }


        public abstract void StartAnimation(object? sender, EventArgs e);
    }
}
