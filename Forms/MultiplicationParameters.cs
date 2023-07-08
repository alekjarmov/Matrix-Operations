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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            var inputs = new NumericUpDown[] { XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix };

            foreach (var input in inputs)
            {
                input.Minimum = 1;
                input.Maximum = 6;
                input.Value = 1;
            }

        }
        private void MatrixInput_Click(object sender, EventArgs e)
        {
            MatrixMultiplicationInput form = new MatrixMultiplicationInput(XFirstMatrix.Value, YFirstMatrix.Value, XSecondMatrix.Value, YSecondMatrix.Value);
            this.Close();
            form.ShowDialog();


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelMultiplictationDimensions_Click(object sender, EventArgs e)
        {

        }

        private void XFirstMatrix_ValueChanged(object sender, EventArgs e)
        {

        }

        private void YFirstMatrix_ValueChanged(object sender, EventArgs e)
        {
            XSecondMatrix.Value = YFirstMatrix.Value;

        }

        private void XSecondMatrix_ValueChanged(object sender, EventArgs e)
        {
            YFirstMatrix.Value = XSecondMatrix.Value;
        }
    }
}
