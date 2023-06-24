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
    public partial class MultiplicationParameters : Form
    {
        public MultiplicationParameters()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MatrixInput_Click(object sender, EventArgs e)
        {
            (decimal FirstMatrixX, decimal FirstMatrixY, decimal SecondMatrixX, decimal SecondMatrixY) =
                (XFirstMatrix.Value, YFirstMatrix.Value, XSecondMatrix.Value, YSecondMatrix.Value);

            MatrixMultiplicationInput form = new MatrixMultiplicationInput(FirstMatrixX,FirstMatrixY, SecondMatrixX, SecondMatrixY);
            form.ShowDialog();

        }
    }
}
