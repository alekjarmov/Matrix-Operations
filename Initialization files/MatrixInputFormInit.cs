using MatrixOperations.Exceptions;
using MatrixOperations.Forms.FormTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixOperations
{
    public static class MatrixInputFormInit 
    {
        

        // Properites per field
        public static readonly int FieldsWidth = 30;
        //Default height per textBox and numericalUpDown
        public static readonly int FieldsHeight = 23;
        public static readonly int FieldsPaddingLeft = 20;
        public static readonly int FieldsPaddingTop = 20;
        public static readonly int FieldsTotalHeight = FieldsHeight + FieldsPaddingTop;
        public static readonly int FieldsTotalWidth = FieldsWidth + FieldsPaddingLeft;

        // Distance between matrices
        public static readonly int MatrixDistance = 50;

        // Offset from the matrices block
        public static readonly int TopOffset = 50;
        public static readonly int BottomOffset = 250;
        public static readonly int LeftOffset = 50;
        public static readonly int RightOffset = 200;


        //Operators Text Size
        public static readonly int FontEqualsHeight = 11;
        public static readonly int FontEqualsWidth = 8;
        public static readonly int FontOperationHeight = 8;
        public static readonly int FontOperationWidth = 8;

        public static NumericUpDown[,] GenerateMatrix(MatrixInputForm form, int X, int Y, 
                                    int MarginX,int MarginY)
        {
            NumericUpDown[,] numericUpDowns = new NumericUpDown[X, Y];

            for (var i = 0; i < X; i++)
            {
                for (var j = 0; j < Y; j++)
                {
                    numericUpDowns[i, j] = new NumericUpDown();
                    numericUpDowns[i, j].Top = MarginY + i * FieldsTotalHeight;
                    numericUpDowns[i, j].Left = MarginX + j * FieldsTotalWidth;
                    numericUpDowns[i, j].Width = FieldsWidth;
                    form.Controls.Add(numericUpDowns[i, j]);
                }
            }

            return numericUpDowns;
        }
        public static TextBox[,] GenerateDisabledTextBoxMatrix(MatrixInputForm form, int X, int Y,
                                    int MarginX, int MarginY)
        {

            TextBox[,] labels = new TextBox[X, Y];

            for (var i = 0; i < X; i++)
            {
                for (var j = 0; j < Y; j++)
                {
                    labels[i, j] = new TextBox();
                    labels[i, j].Top = MarginY + i * FieldsTotalHeight;
                    labels[i, j].Left = MarginX + j * FieldsTotalWidth;
                    labels[i, j].Width = FieldsWidth;
                    labels[i, j].Enabled = false;
                    form.Controls.Add(labels[i, j]);

                }
            }

            return labels;
        }
        private static (int,int,int) GetCenteringMargins(int XFirstMatrix, int XSecondMatrix)
        {
            int MarginFirstMatrix, MarginSecondMatrix,MarginResultMatrix;
            if (XFirstMatrix > XSecondMatrix)
            {
                MarginFirstMatrix = 0;
                MarginSecondMatrix = ((XFirstMatrix - XSecondMatrix) * FieldsTotalHeight) /2;

            }
            else
            {
                MarginFirstMatrix = ((XSecondMatrix - XFirstMatrix) * FieldsTotalHeight) / 2;
                MarginSecondMatrix = 0;
            }
            MarginResultMatrix = MarginFirstMatrix;
            return (MarginFirstMatrix, MarginSecondMatrix, MarginResultMatrix);

        }

       
        private static NumericUpDown[,] GenerateFirstMatrix(this MatrixInputForm form, int XFirstMatrix, int YFirstMatrix, int CenterMarginYFirstMatrix)
        {
            // <summary>
            // Generates the first matrix
            //</summary>
            int MarginXForFirstMatrix = LeftOffset;
            int MarginYForFirstMatrix = TopOffset + CenterMarginYFirstMatrix;

           

            return GenerateMatrix(form, XFirstMatrix, YFirstMatrix, MarginXForFirstMatrix,
                MarginYForFirstMatrix);

        }

        private static NumericUpDown[,] GenerateSecondMatrix(this MatrixInputForm form, int XSecondMatrix, int YSecondMatrix, int YFirstMatrix, int CenterMarginYSecondMatrix)
        {
            // <summary>
            // Generates the second matrix 
            //</summary>
            int MarginXForSecondMatrix = LeftOffset + MatrixDistance + YFirstMatrix * FieldsTotalWidth - FieldsPaddingLeft;
            int MarginYForSecondMatrix = TopOffset + CenterMarginYSecondMatrix;


            return GenerateMatrix(form, XSecondMatrix, YSecondMatrix, MarginXForSecondMatrix,
                MarginYForSecondMatrix);

        }

        private static TextBox[,] GenerateResultingMatrix(this MatrixInputForm form, int XResultantMatrix, int YResultantMatrix, int YFirstMatrix, int YSecondMatrix, int CenterMarginYResultMatrix)
                                                        
        {
            //<summary>
            // Generates the resulting matrix
            //</summary>
            int MarginXForResultMatrix = LeftOffset + 2*MatrixDistance + YFirstMatrix * FieldsTotalWidth  + YSecondMatrix* FieldsTotalWidth - 2*FieldsPaddingLeft;
            int MarginYForResultMatrix = TopOffset + CenterMarginYResultMatrix;


           return GenerateDisabledTextBoxMatrix(form,XResultantMatrix, YResultantMatrix, MarginXForResultMatrix,
                MarginYForResultMatrix);
        }
        public static (NumericUpDown[,], NumericUpDown[,], TextBox[,]) GenerateMatrices(this MatrixInputForm form, int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix, string Sign)
        {
            //<summary>
            // Generate the first operand matrix, the second operand matrix and the result matrix.
            //</summary>

            (int XResultantMatrix, int YResultantMatrix) = (XFirstMatrix, YSecondMatrix);

            (int CenterMarginYFirstMatrix, int CenterMarginYSecondMatrix, int CenterMarginYResultMatrix) = GetCenteringMargins(XFirstMatrix, XSecondMatrix);

            NumericUpDown[,] FirstMatrix = form.GenerateFirstMatrix(XFirstMatrix, YFirstMatrix, CenterMarginYFirstMatrix);

            NumericUpDown[,] SecondMatrix = form.GenerateSecondMatrix(XSecondMatrix, YSecondMatrix, YFirstMatrix, CenterMarginYSecondMatrix);

            TextBox[,] ResultMatrix = form.GenerateResultingMatrix(XResultantMatrix,YResultantMatrix,YFirstMatrix,YSecondMatrix, CenterMarginYResultMatrix);


            (Label Operation, Label Equals) = GenerateSigns(XFirstMatrix,YFirstMatrix,XSecondMatrix,YSecondMatrix, Sign);
            form.Controls.Add(Operation);
            form.Controls.Add(Equals);


            return (FirstMatrix, SecondMatrix, ResultMatrix);

        }
        private static int GenerateOperationSignY(int XFirstMatrix, int XSecondMatrix)
        {
            return TopOffset + (XFirstMatrix > XSecondMatrix ? (XFirstMatrix * FieldsTotalHeight - FieldsPaddingTop) : (XSecondMatrix * FieldsTotalHeight - FieldsPaddingTop)) / 2 - FontOperationHeight;
        }
        private static int GenerateEqualsSignY(int XFirstMatrix, int XSecondMatrix)
        {
            return TopOffset + (XFirstMatrix > XSecondMatrix ? (XFirstMatrix * FieldsTotalHeight - FieldsPaddingTop) : (XSecondMatrix * FieldsTotalHeight - FieldsPaddingTop)) / 2 - FontEqualsHeight;
        }
        private static int GenerateOperationSignX(int YFirstMatrix)
        {
            return LeftOffset + YFirstMatrix * FieldsTotalWidth - FieldsPaddingLeft + MatrixDistance/2 - FontOperationWidth;
        }
        private static int GenerateEqualsSignX(int YFirstMatrix, int YSecondMatrix) {
            return LeftOffset + (YFirstMatrix + YSecondMatrix) * FieldsTotalWidth - 2*FieldsPaddingLeft + MatrixDistance + MatrixDistance/2 - FontEqualsWidth;
        }
        private static Label GenerateLabel(int Top, int Left, Size size, string Text)
        {
            Label label = new Label();
            label.Top = Top;
            label.Left = Left;
            label.Text = Text;
            label.Size = size;

            return label;
        }
        private static (Label,Label) GenerateSigns(int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix, string Sign)
        {
            //int SignsY = GenerateSignsY(XFirstMatrix,XSecondMatrix);
            int PositionOperationY= GenerateOperationSignY(XFirstMatrix, XSecondMatrix);
            int PositionEqualsY = GenerateEqualsSignY(XFirstMatrix, XSecondMatrix);
            int PositionOperationX = GenerateOperationSignX(YFirstMatrix);
            int PositionEqualsX = GenerateEqualsSignX(YFirstMatrix,YSecondMatrix);


            Label OperationLabel = GenerateLabel(PositionOperationY, PositionOperationX, new Size(FontOperationWidth, FontEqualsHeight), Sign);    
            Label EqualsLabel = GenerateLabel(PositionEqualsY, PositionEqualsX, new Size(FontEqualsWidth, FontEqualsHeight), "="); ;
            
            return (OperationLabel,EqualsLabel);

        }

        

        public static void SetWidthAndHeight(this MatrixInputForm form, int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix)
        {
            (int XResultantMatrix, int YResultantMatrix) = (XFirstMatrix, YSecondMatrix);
            form.Width = (XFirstMatrix + XSecondMatrix + XResultantMatrix) * FieldsTotalWidth + MatrixDistance * 2 + LeftOffset + RightOffset;
            form.Height = Math.Max(YFirstMatrix, YSecondMatrix) * FieldsTotalHeight + TopOffset + BottomOffset;

        }
    }
}
