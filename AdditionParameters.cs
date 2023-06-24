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
    public partial class AdditionParameters : Form
    {
        public string Mode { get; set; }
        public AdditionParameters(string mode)
        {
            InitializeComponent();
            Mode = mode.ToLower();
            switch (Mode)
            {
                case "addition":
                    MatrixInput.Text = "Go to A+B calculator";
                    break;
                case "subtraction":
                    MatrixInput.Text = "Go to A-B calculator";
                    break;
            }
        }

        private void MatrixInput_Click(object sender, EventArgs e)
        {

        }
    }
}
