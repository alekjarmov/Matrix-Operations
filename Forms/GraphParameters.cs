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
    public partial class GraphParameters : Form
    {
        public GraphParameters()
        {
            InitializeComponent();
        }
        public void ContinueBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
        }

        private void VerticlesInputBtn_Click(object sender, EventArgs e)
        {
            GraphVisualizationInput form = new GraphVisualizationInput((int)NumVerticles.Value);
            this.Close();
            form.ShowDialog();
        }
    }
}
