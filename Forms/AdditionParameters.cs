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
    public partial class AdditionParameters : ParameterForm
    {
        public AdditionParameters() : base() 
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void x_Click(object sender, EventArgs e)
        {
        }

        private void YFirstMatrix_ValueChanged(object sender, EventArgs e)
        {
        }

        private void XFirstMatrix_ValueChanged(object sender, EventArgs e)
        {
        }

        private void MatrixInput_Click(object sender, EventArgs e)
        {
            MatrixAdditionInput form = new MatrixAdditionInput(NumericalUpDownRows.Value, NumericalUpDownColumns.Value);
            form.ShowDialog();
        }
    }
}
