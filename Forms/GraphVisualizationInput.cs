using MatrixOperations.Forms.FormTypes;
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

namespace MatrixOperations.Forms
{
    public partial class GraphVisualizationInput : MatrixInputForm
    {
        public GraphVisualizationInput(int NumberVerticles)
        {
            InitializeComponent();
            InitializeInputEnvironment(NumberVerticles,NumberVerticles,0,0,0,1, null, false);
            SetNumericalUpDownsOnChange();
            this.GenerateButton(XFirstMatrix, 0, "Generate Graph", StartCalculation, Variables.LeftOffset, Variables.FieldsTotalHeight);
        }

        public void SetNumericalUpDownsOnChange()
        {
            Dictionary<NumericUpDown, NumericUpDown> mappings = new Dictionary<NumericUpDown, NumericUpDown>();

            for (int i = 0; i< FirstMatrix.GetLength(0); i++)
            {
                for(int j=0;j< FirstMatrix.GetLength(1); j++)
                {
                    
                     mappings[FirstMatrix[i, j]] = FirstMatrix[j, i];

                }
            }
            foreach (NumericUpDown key in mappings.Keys)
            {
                key.ValueChanged += (sender, e) => { mappings[key].Value = key.Value; };
            }

        }
        public override void StartCalculation(object? sender, EventArgs e)
        {
            int[,] relations = ConvertNumericUpDownToIntegerMatrix(FirstMatrix);
            GraphVisualization form = new GraphVisualization(FirstMatrix.GetLength(0), relations);

            form.ShowDialog();
        }

        private int[,] ConvertNumericUpDownToIntegerMatrix(NumericUpDown[,] firstMatrix)
        {
            int[,] result = new int[firstMatrix.GetLength(0),firstMatrix.GetLength(1)];

            for(int i=0; i< result.GetLength(0);i++)
            {
                for(int j=0; j<result.GetLength(1); j++)
                {
                    result[i, j] = (int)firstMatrix[i, j].Value;
                }
            }
            return result;
        }

        protected override Task ShowCalculation(CancellationToken token)
        {

            throw new NotImplementedException();
        }


    }
}
