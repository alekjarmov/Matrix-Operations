using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MatrixOperations
{
    public partial class MatrixMultiplicationInput : Form
    {
        //decimal XFirstMatrix;
        //decimal YFirstMatrix;
        //decimal XSecondMatrix;  
        //decimal YSecondMatrix;
        private void SetWidthAndHeight(int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix)
        {
            Width = (XFirstMatrix + XSecondMatrix) * (100 + GeneratorMethods.FieldsPaddingX) + GeneratorMethods.MatrixDistance*2 + 100;
            Height = Math.Max(YFirstMatrix,YSecondMatrix) * (40 + GeneratorMethods.FieldsPaddingY) + 100;

        }
        public MatrixMultiplicationInput(decimal XFirstMatrix, decimal YFirstMatrix, decimal XSecondMatrix, decimal YSecondMatrix)
        {
            InitializeComponent();
            SetWidthAndHeight((int)XFirstMatrix, (int)YFirstMatrix, (int)XSecondMatrix, (int)YSecondMatrix);

            this.GenerateMatrices(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix);

        }
    }
}
