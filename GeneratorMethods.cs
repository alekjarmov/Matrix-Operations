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
        // This is default fields height - both NumbericUpDown and TextBox
        public static readonly int FieldsHeight = 23;
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
                    form.Controls.Add(numericUpDowns[i, j]);
                }
            }

            return numericUpDowns;
        }
        private static TextBox[,] GenerateResultingMatrix(Form form, int X, int Y,
                                    int MarginX, int MarginY,
                                    int TextBoxWidth)
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
                    labels[i, j].Enabled = false;
                    form.Controls.Add(labels[i, j]);

                }
            }

            return labels;
        }
        private static (int,int,int) CenterMatrix(int XFirstMatrix, int XSecondMatrix)
        {
            int MarginFirstMatrix, MarginSecondMatrix,MarginResultMatrix;
            if (XFirstMatrix > XSecondMatrix)
            {
                MarginFirstMatrix = 0;
                MarginSecondMatrix = ((XFirstMatrix-XSecondMatrix) * (FieldsHeight+FieldsPaddingX))/2;

            }
            else
            {
                MarginFirstMatrix = ((XSecondMatrix - XFirstMatrix) * (FieldsHeight + FieldsPaddingX)) / 2;// (float)YFirstMatrix / (float)(YSecondMatrix);
                MarginSecondMatrix = 0;
            }
            MarginResultMatrix = MarginFirstMatrix;
            return (MarginFirstMatrix, MarginSecondMatrix, MarginResultMatrix);

        }

       
        public static void GenerateMatrices(this Form form, decimal XFirstMatrix, decimal YFirstMatrix, decimal XSecondMatrix, decimal YSecondMatrix)
        {
            
            (int XResultantMatrix, int YResultantMatrix) = ((int)XFirstMatrix, (int)YSecondMatrix);

            int Width = form.ClientSize.Width - 2*FixedMarginX - 2*MatrixDistance;
            int NumericUpDownsTotalWidth = Width / (int)(XFirstMatrix + XSecondMatrix + XResultantMatrix);


            if (FieldsPaddingX>NumericUpDownsTotalWidth)
            {
                throw new InvalidPaddingException();
            }


            int NumericUpDownsWidth = NumericUpDownsTotalWidth - FieldsPaddingX;

            (int CenterMarginYFirstMatrix, int CenterMarginYSecondMatrix, int CenterMarginYResultMatrix) = CenterMatrix((int)XFirstMatrix, (int)XSecondMatrix);

            int MarginXForFirstMatrix = FixedMarginX;
            int MarginYForFirstMatrix = FixedMarginY + CenterMarginYFirstMatrix;


            NumericUpDown[,] FirstMatrix = GenerateMatrix(form, (int)XFirstMatrix, (int)YFirstMatrix, MarginXForFirstMatrix,
                MarginYForFirstMatrix, NumericUpDownsWidth);

            int MarginXForSecondMatrix = MarginXForFirstMatrix + MatrixDistance + (int)YFirstMatrix*NumericUpDownsTotalWidth;
            int MarginYForSecondMatrix = FixedMarginY + CenterMarginYSecondMatrix;


            NumericUpDown[,] SecondMatrix = GenerateMatrix(form, (int)XSecondMatrix, (int)YSecondMatrix, MarginXForSecondMatrix,
                MarginYForSecondMatrix, NumericUpDownsWidth); 

            int MarginXForResultMatrix = MarginXForSecondMatrix + MatrixDistance  + (int)YSecondMatrix * NumericUpDownsTotalWidth;
            int MarginYForResultMatrix = FixedMarginY + CenterMarginYResultMatrix;


            TextBox[,] ResultMatrix = GenerateResultingMatrix(form, (int)XResultantMatrix, (int)YResultantMatrix, MarginXForResultMatrix,
                MarginYForResultMatrix, NumericUpDownsWidth); // NumericUpDownsHeight, NumericUpDownsWidth);



        }
    }
}
