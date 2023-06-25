using MatrixOperations.Forms.FormTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MatrixOperations
{
    public partial class MultiplicationAnimation : MatrixInputForm
    {
        
        public MultiplicationAnimation(decimal XFirstMatrix, decimal YFirstMatrix, decimal XSecondMatrix, decimal YSecondMatrix)
            : base()
        {
            InitializeComponent();
            InitializeInputEnvironment((int)XFirstMatrix, (int)YFirstMatrix, (int)XSecondMatrix, (int)YSecondMatrix, "*");
            
        }

        private void DisableAllNumericUpDowns()
        {
            for (int i = 0; i < FirstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < FirstMatrix.GetLength(1); j++)
                {
                    FirstMatrix[i, j].Enabled = false;
                }
            }
            for (int i = 0; i < SecondMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < SecondMatrix.GetLength(1); j++)
                {
                    SecondMatrix[i, j].Enabled = false;
                }
            }
        }
        public override async void StartAnimation(object? sender, EventArgs e)
        {
            DisableAllNumericUpDowns();
            for (int i = 0; i < FirstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < SecondMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < SecondMatrix.GetLength(0); k++)
                    {
                        FirstMatrix[i, k].BackColor = Color.LightGreen;
                        SecondMatrix[k, j].BackColor = Color.LightGreen;
                        await Task.Delay(1000);
                        FirstMatrix[i, k].BackColor = Color.White;
                        SecondMatrix[k, j].BackColor = Color.White;
                    }
                }
            }
        }

    }
}
