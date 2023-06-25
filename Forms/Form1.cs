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
                var mbox = MessageBox.Show("Please select an operation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedOption = listBoxOptions.SelectedItem.ToString().ToLower();
            switch (selectedOption)
            {
                case "addition":
                    AdditionParameters additionParameters = new AdditionParameters(selectedOption);
                    additionParameters.Show();
                    break;
                case "subtraction":
                    AdditionParameters subtractionParameters = new AdditionParameters(selectedOption);
                    subtractionParameters.Show();
                    break;
                case "multiplication":
                    MultiplicationParameters multiplicationParameters = new MultiplicationParameters();
                    multiplicationParameters.Show();
                    break;
            }

        }
    }
}