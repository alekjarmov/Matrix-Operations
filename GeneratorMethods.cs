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
        public static int FixedMarginX = 5;
        public static int FixedMarginY = 5;
        public static int FieldsPaddingX = 20;
        public static int FieldsPaddingY = 20;
        public static int MatrixDistance = 20;
        private static NumericUpDown[,] GenerateMatrix(Form form, int X, int Y, 
                                    int MarginX,int MarginY,
                                    int NumericUpDownsWidth)
                                    //int NumericUpDownsHeight, int NumericUpDownsWidth)
        {
            NumericUpDown[,] numericUpDowns = new NumericUpDown[X, Y];

            for (var i = 0; i < X; i++)
            {
                for (var j = 0; j < Y; j++)
                {
                    numericUpDowns[i, j] = new NumericUpDown();
                    numericUpDowns[i, j].Top = MarginY + i * (numericUpDowns[i,j].Height + FieldsPaddingY);
                    numericUpDowns[i, j].Left = MarginX + j * (NumericUpDownsWidth + FieldsPaddingX);
                    numericUpDowns[i, j].Width = NumericUpDownsWidth;
                    //numericUpDowns[i, j].Height =  NumericUpDownsHeight;
                    form.Controls.Add(numericUpDowns[i, j]);
                }
            }

            return numericUpDowns;
        }
        private static TextBox[,] GenerateResultingMatrix(Form form, int X, int Y,
                                    int MarginX, int MarginY,
                                    int TextBoxWidth)
        //int NumericUpDownsHeight, int NumericUpDownsWidth)
        {

            TextBox[,] labels = new TextBox[X, Y];

            for (var i = 0; i < X; i++)
            {
                for (var j = 0; j < Y; j++)
                {
                    labels[i, j] = new TextBox();
                    labels[i, j].Top = MarginY + i * (labels[i, j].Height + FieldsPaddingY);
                    labels[i, j].Left = MarginX + j * (TextBoxWidth + FieldsPaddingX);
                    labels[i, j].Width = TextBoxWidth;
                    //numericUpDowns[i, j].Height =  NumericUpDownsHeight;
                    form.Controls.Add(labels[i, j]);
                }
            }

            return labels;
        }
        private static (float, float, float) CalculateHeightPercentages(int YFirstMatrix, int YSecondMatrix)
        {
            float PercentsForFirstMatrixHeight, PercentsForSecondMatrixHeight, PercentsForResultingMatrixHeight;
            if (YFirstMatrix > YSecondMatrix)
            {
                PercentsForFirstMatrixHeight = 1;
                PercentsForSecondMatrixHeight = 1;//(float)YSecondMatrix / (float)(YFirstMatrix);

            }
            else
            {
                PercentsForFirstMatrixHeight = 1;// (float)YFirstMatrix / (float)(YSecondMatrix);
                PercentsForSecondMatrixHeight = 1;
            }
            PercentsForResultingMatrixHeight = PercentsForSecondMatrixHeight;
            return (PercentsForFirstMatrixHeight, PercentsForSecondMatrixHeight, PercentsForResultingMatrixHeight);

        }

       
        public static void GenerateMatrices(this Form form, decimal XFirstMatrix, decimal YFirstMatrix, decimal XSecondMatrix, decimal YSecondMatrix)
        {
            
            (int XResultantMatrix, int YResultantMatrix) = ((int)XFirstMatrix, (int)YSecondMatrix);

            System.Diagnostics.Debug.WriteLine($"{form.ClientSize.Width}");
            int Width = form.ClientSize.Width - 2*FixedMarginX - 2*MatrixDistance;
            int Height = form.ClientSize.Height - 2*FixedMarginY;

            //(int NumericUpDownsTotalWidth, int NumericUpDownsTotalHeight) =
            //    (Width / (int)(XFirstMatrix + XSecondMatrix + XResultantMatrix), Height / (int)Math.Max(YFirstMatrix, YSecondMatrix));

            int NumericUpDownsTotalWidth = Width / (int)(XFirstMatrix + XSecondMatrix + XResultantMatrix);


            if (FieldsPaddingX>NumericUpDownsTotalWidth)// | FieldsPaddingY>NumericUpDownsTotalHeight)
            {
                throw new InvalidPaddingException();
            }

            //(int NumericUpDownsWidth, int NumericUpDownsHeight) =
            //    (NumericUpDownsTotalWidth-FieldsPaddingX, NumericUpDownsTotalHeight - FieldsPaddingY);

            int NumericUpDownsWidth = NumericUpDownsTotalWidth - FieldsPaddingX;
            //(float PercentsForFirstMatrixHeight, float PercentsForSecondMatrixHeight, float PkercentsForResultingMatrixHeight) = CalculateHeightPercentages((int)YFirstMatrix, (int)YSecondMatrix);


            int MarginXForFirstMatrix = FixedMarginX;
            int MarginYForFirstMatrix = FixedMarginY;
            //(Height - (int)(PercentsForFirstMatrixHeight * Height)) / 2 + FixedMarginY;


            NumericUpDown[,] FirstMatrix = GenerateMatrix(form, (int)XFirstMatrix, (int)YFirstMatrix, MarginXForFirstMatrix,
                MarginYForFirstMatrix, NumericUpDownsWidth);//NumericUpDownsHeight, NumericUpDownsWidth);

            int MarginXForSecondMatrix = MarginXForFirstMatrix + MatrixDistance + (int)XFirstMatrix*NumericUpDownsTotalWidth;
            int MarginYForSecondMatrix = FixedMarginY;
            //(Height - (int)(PercentsForSecondMatrixHeight * Height)) / 2 + FixedMarginY;


            NumericUpDown[,] SecondMatrix = GenerateMatrix(form, (int)XSecondMatrix, (int)YSecondMatrix, MarginXForSecondMatrix,
                MarginYForSecondMatrix, NumericUpDownsWidth); //NumericUpDownsHeight, NumericUpDownsWidth);

            int MarginXForResultMatrix = MarginXForSecondMatrix + MatrixDistance  + (int)XSecondMatrix * NumericUpDownsTotalWidth;
            int MarginYForResultMatrix = FixedMarginY;
            //(Height - (int)(PercentsForResultingMatrixHeight * Height)) / 2 + FixedMarginY;


            NumericUpDown[,] ResultMatrix = GenerateMatrix(form, (int)XResultantMatrix, (int)YResultantMatrix, MarginXForResultMatrix,
                MarginYForResultMatrix, NumericUpDownsWidth); // NumericUpDownsHeight, NumericUpDownsWidth);


            //form.Width = MarginXForResultMatrix + XResultantMatrix*NumericUpDownsTotalWidth + YResultantMatrix*NumericUpDownsTotalWidth;
            //form.Height = Math.Max((int)(YFirstMatrix*NumericUpDownsTotalHeight), (int)(YSecondMatrix *NumericUpDownsTotalHeight));

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
