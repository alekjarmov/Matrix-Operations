using MatrixOperations.Forms.FormTypes;
using MatrixOperations.Initialization_files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixOperations.Forms
{
    public partial class MatrixAdditionInput
    {
        string Mode { get; set; }
        public MatrixAdditionInput(decimal X, decimal Y, string mode) : base()
        {
            InitializeComponent();
            
            Mode = mode.ToLower();
            string sign = mode == "addition" ? "+" : "-";
            InitializeInputEnvironment((int)X, (int)Y, (int)X, (int)Y, sign);


        }

        protected override async Task Animate(CancellationToken token)
        {
            CalculateButton.Enabled = false;
            RandomizeButton.Enabled = false;
            for (int i = 0; i < FirstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < FirstMatrix.GetLength(1); j++)
                {
                    
                    FirstMatrix[i, j].BackColor = Color.LightGreen;
                    SecondMatrix[i, j].BackColor = Color.LightGreen;
                    ResultantMatrix[i, j].BackColor = Color.LightGreen;
                    switch (Mode)
                    {
                        case "addition":
                            ResultantMatrix[i, j].Text = $"{FirstMatrix[i, j].Value + SecondMatrix[i, j].Value}";
                            break;
                        case "subtraction":
                            ResultantMatrix[i, j].Text = $"{FirstMatrix[i, j].Value - SecondMatrix[i, j].Value}";
                            break;
                    }
                    try
                    {
                        token.ThrowIfCancellationRequested();
                        await Task.Delay(Variables.IterationTime);
                    }
                    catch (OperationCanceledException ex)
                    {
                        ResetColorNumericUpDowns();
                        ResetResultantMatrix();
                        return;
                    }



                    FirstMatrix[i, j].BackColor = Color.White;
                SecondMatrix[i, j].BackColor = Color.White;
                ResultantMatrix[i, j].BackColor = Color.White;
                }
            }
            
        }
    

    }
}
