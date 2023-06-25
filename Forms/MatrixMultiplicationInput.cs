using MatrixOperations.Forms.FormTypes;
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
    public partial class MatrixMultiplicationInput : MatrixInputForm
    {

        public MatrixMultiplicationInput(decimal XFirstMatrix, decimal YFirstMatrix, decimal XSecondMatrix, decimal YSecondMatrix)
            : base()
        {
            InitializeComponent();
            (NumericUpDown[,] FirstMatrix, NumericUpDown[,] SecondMatrix, TextBox[,] ResultantMatrix) =
                InitializeInputEnvironment((int)XFirstMatrix, (int)YFirstMatrix, (int)XSecondMatrix, (int)YSecondMatrix, "*");


        }
    }
}
