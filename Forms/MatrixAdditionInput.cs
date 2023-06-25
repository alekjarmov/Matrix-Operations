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

namespace MatrixOperations.Forms
{
    public partial class MatrixAdditionInput : MatrixInputForm
    {
        public MatrixAdditionInput(decimal X, decimal Y)
        {
            InitializeComponent();
            (NumericUpDown[,] FirstMatrix, NumericUpDown[,] SecondMatrix, TextBox[,] ResultantMatrix) =
                InitializeInputEnvironment((int)X,(int)Y, (int)X, (int)Y, "+");



        }
    }
}
