using MatrixOperations.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixOperations
{
    public static class GeneratorMethods
    {
        static int FixedMargin = 5;
        static int FieldsPaddingX = 20;
        static int FieldsPaddingY = 20;
        static int MatrixDistance = 0;
        private static NumericUpDown[,] GenerateMatrix(Form form, int X, int Y, 
                                    int MarginX,int MarginY,
                                    int NumericUpDownsHeight, int NumericUpDownsWidth)
        {
            NumericUpDown[,] numericUpDowns = new NumericUpDown[X, Y];

            for (var i = 0; i < X; i++)
            {
                for (var j = 0; j < Y; j++)
                {
                    numericUpDowns[i, j] = new NumericUpDown();
                    numericUpDowns[i, j].Top = MarginY + i * (NumericUpDownsHeight + FieldsPaddingY);
                    numericUpDowns[i, j].Left = MarginX + j * (NumericUpDownsWidth + FieldsPaddingX);
                    numericUpDowns[i, j].Width = NumericUpDownsWidth;
                    numericUpDowns[i, j].Height = NumericUpDownsHeight;
                    form.Controls.Add(numericUpDowns[i, j]);
                }
            }

            return numericUpDowns;
        }
        private static (float, float, float) CalculateHeightPercentages(int YFirstMatrix, int YSecondMatrix)
        {
            float PercentsForFirstMatrixHeight, PercentsForSecondMatrixHeight, PercentsForResultingMatrixHeight;
            if (YFirstMatrix > YSecondMatrix)
            {
                PercentsForFirstMatrixHeight = 1;
                PercentsForSecondMatrixHeight = (float)YSecondMatrix / (float)(YFirstMatrix);

            }
            else
            {
                PercentsForFirstMatrixHeight = (float)YFirstMatrix / (float)(YSecondMatrix);
                PercentsForSecondMatrixHeight = 1;
            }
            PercentsForResultingMatrixHeight = PercentsForSecondMatrixHeight;
            return (PercentsForFirstMatrixHeight, PercentsForSecondMatrixHeight, PercentsForResultingMatrixHeight);

        }

       
        public static void GenerateTwoMatrices(this Form form, decimal XFirstMatrix, decimal YFirstMatrix, decimal XSecondMatrix, decimal YSecondMatrix)
        {
            
            (int XResultantMatrix, int YResultantMatrix) = ((int)XFirstMatrix, (int)YSecondMatrix);


            int Width = form.ClientSize.Width - 2*FixedMargin - 2*MatrixDistance;
            int Height = form.ClientSize.Height - 2*FixedMargin;

            (int NumericUpDownsTotalWidth, int NumericUpDownsTotalHeight) =
                (Width / (int)(XFirstMatrix + XSecondMatrix + XResultantMatrix), Height / (int)Math.Max(YFirstMatrix, YSecondMatrix));

            
            
            if(FieldsPaddingX>NumericUpDownsTotalWidth | FieldsPaddingY>NumericUpDownsTotalHeight)
            {
                throw new InvalidPaddingException();
            }

            (int NumericUpDownsWidth, int NumericUpDownsHeight) =
                (NumericUpDownsTotalWidth-FieldsPaddingX, NumericUpDownsTotalWidth - FieldsPaddingY);

            (float PercentsForFirstMatrixHeight, float PercentsForSecondMatrixHeight, float PercentsForResultingMatrixHeight) = CalculateHeightPercentages((int)YFirstMatrix, (int)YSecondMatrix);


            int MarginXForFirstMatrix = FixedMargin;
            int MarginYForFirstMatrix = (int)(Height - (int)(PercentsForFirstMatrixHeight * Height)) / 2 + FixedMargin;


            NumericUpDown[,] FirstMatrix = GenerateMatrix(form, (int)XFirstMatrix, (int)YFirstMatrix, MarginXForFirstMatrix,
                MarginYForFirstMatrix, NumericUpDownsHeight, NumericUpDownsWidth);

            int MarginXForSecondMatrix = FixedMargin + (int)XFirstMatrix*NumericUpDownsTotalWidth + MatrixDistance*2;
            int MarginYForSecondMatrix = (int)(Height - (int)(PercentsForSecondMatrixHeight * Height)) / 2 + FixedMargin;


            NumericUpDown[,] SecondMatrix = GenerateMatrix(form, (int)XSecondMatrix, (int)YSecondMatrix, MarginXForSecondMatrix,
                MarginYForSecondMatrix, NumericUpDownsHeight, NumericUpDownsWidth);

            //NumericUpDown numericUpDown = new NumericUpDown();

            //TextBox textBox = new TextBox();
            //textBox.Text = "Hello";
            //textBox.Top = 3 + 5; textBox.Left = 80;
            //textBox.Width = 115;
            //textBox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            //form.Controls.Add(textBox);

        }
    }
}
