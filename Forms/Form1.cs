using MatrixOperations.Forms;

namespace MatrixOperations
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBoxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonShowOperation_Click(object sender, EventArgs e)
        {
            if (listBoxOptions.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an option");
                return;
            }

            string selectedOption = listBoxOptions.SelectedItem.ToString();
            switch (selectedOption)
            {
                case "Addition":
                    AdditionParameters additionParameters = new AdditionParameters();
                    additionParameters.Show();
                    break;
                case "Multiplication":
                    MultiplicationParameters multiplicationParameters = new MultiplicationParameters();
                    multiplicationParameters.Show();
                    break;
            }

        }
    }
}