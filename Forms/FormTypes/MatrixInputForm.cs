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
        public MatrixInputForm()
        {

        }

        public (NumericUpDown[,], NumericUpDown[,], TextBox[,]) InitializeInputEnvironment(int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix, string Sign)
        {
            this.SetWidthAndHeight(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix);
            this.GenerateAnimationButton(XFirstMatrix, XSecondMatrix);
            return this.GenerateMatrices(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix, Sign);
        }
    }
}
