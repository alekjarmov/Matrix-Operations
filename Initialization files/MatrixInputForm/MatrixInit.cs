using MatrixOperations.Exceptions;
using MatrixOperations.Forms.FormTypes;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatrixOperations.Initialization_files;

namespace MatrixOperations
{
    public static class MatrixInit 
    {
        

        


        // Matrix generation
        public static NumericUpDown[,] GenerateMatrix(MatrixInputForm form, int X, int Y, 
                                    int MarginX,int MarginY)
        {
            NumericUpDown[,] numericUpDowns = new NumericUpDown[X, Y];

            for (var i = 0; i < X; i++)
            {
                for (var j = 0; j < Y; j++)
                {
                    numericUpDowns[i, j] = new NumericUpDown();
                    numericUpDowns[i, j].Top = MarginY + i * Variables.FieldsTotalHeight;
                    numericUpDowns[i, j].Left = MarginX + j * Variables.FieldsTotalWidth;
                    numericUpDowns[i, j].Width = Variables.FieldsWidth;
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
                    labels[i, j].Top = MarginY + i * Variables.FieldsTotalHeight;
                    labels[i, j].Left = MarginX + j * Variables.FieldsTotalWidth;
                    labels[i, j].Width = Variables.FieldsWidth;
                    labels[i, j].Enabled = false;
                    form.Controls.Add(labels[i, j]);

                }
            }

            return labels;
        }
        //--------------------------------------------


        // Centering Matrices
        private static (int,int,int) GetCenteringMargins(int XFirstMatrix, int XSecondMatrix)
        {
            int MarginFirstMatrix, MarginSecondMatrix,MarginResultMatrix;
            if (XFirstMatrix > XSecondMatrix)
            {
                MarginFirstMatrix = 0;
                MarginSecondMatrix = ((XFirstMatrix - XSecondMatrix) * Variables.FieldsTotalHeight) /2;

            }
            else
            {
                MarginFirstMatrix = ((XSecondMatrix - XFirstMatrix) * Variables.FieldsTotalHeight) / 2;
                MarginSecondMatrix = 0;
            }
            MarginResultMatrix = MarginFirstMatrix;
            return (MarginFirstMatrix, MarginSecondMatrix, MarginResultMatrix);

        }
        //----------------------------------------------


        // Generating the three matrices
        private static NumericUpDown[,] GenerateFirstMatrix(this MatrixInputForm form, int XFirstMatrix, int YFirstMatrix, int CenterMarginYFirstMatrix)
        {
            // <summary>
            // Generates the first matrix
            //</summary>
            int MarginXForFirstMatrix = Variables.LeftOffset;
            int MarginYForFirstMatrix = Variables.TopOffset + CenterMarginYFirstMatrix;

           

            return GenerateMatrix(form, XFirstMatrix, YFirstMatrix, MarginXForFirstMatrix,
                MarginYForFirstMatrix);

        }
        private static NumericUpDown[,] GenerateSecondMatrix(this MatrixInputForm form, int XSecondMatrix, int YSecondMatrix, int YFirstMatrix, int CenterMarginYSecondMatrix)
        {
            // <summary>
            // Generates the second matrix 
            //</summary>
            int MarginXForSecondMatrix = Variables.LeftOffset + Variables.MatrixDistance + YFirstMatrix * Variables.FieldsTotalWidth - Variables.FieldsPaddingLeft;
            int MarginYForSecondMatrix = Variables.TopOffset + CenterMarginYSecondMatrix;


            return GenerateMatrix(form, XSecondMatrix, YSecondMatrix, MarginXForSecondMatrix,
                MarginYForSecondMatrix);

        }
        private static TextBox[,] GenerateResultingMatrix(this MatrixInputForm form, int XResultantMatrix, int YResultantMatrix, int YFirstMatrix, int YSecondMatrix, int CenterMarginYResultMatrix)
                                                        
        {
            //<summary>
            // Generates the resulting matrix
            //</summary>
            int MarginXForResultMatrix = Variables.LeftOffset + 2*Variables.MatrixDistance + YFirstMatrix * Variables.FieldsTotalWidth  + YSecondMatrix* Variables.FieldsTotalWidth - 2*Variables.FieldsPaddingLeft;
            int MarginYForResultMatrix = Variables.TopOffset + CenterMarginYResultMatrix;


           return GenerateDisabledTextBoxMatrix(form,XResultantMatrix, YResultantMatrix, MarginXForResultMatrix,
                MarginYForResultMatrix);
        }
        //---------------------------------------------------------


        // Signs generation
        private static int GenerateOperationSignY(int XFirstMatrix, int XSecondMatrix)
        {
            return Variables.TopOffset + (XFirstMatrix > XSecondMatrix ? (XFirstMatrix * Variables.FieldsTotalHeight - Variables.FieldsPaddingTop) : (XSecondMatrix * Variables.FieldsTotalHeight - Variables.FieldsPaddingTop)) / 2 - Variables.FontOperationHeight;
        }
        private static int GenerateEqualsSignY(int XFirstMatrix, int XSecondMatrix)
        {
            return Variables.TopOffset + (XFirstMatrix > XSecondMatrix ? (XFirstMatrix * Variables.FieldsTotalHeight - Variables.FieldsPaddingTop) : (XSecondMatrix * Variables.FieldsTotalHeight - Variables.FieldsPaddingTop)) / 2 - Variables.FontEqualsHeight;
        }
        private static int GenerateOperationSignX(int YFirstMatrix)
        {
            return Variables.LeftOffset + YFirstMatrix * Variables.FieldsTotalWidth - Variables.FieldsPaddingLeft + Variables.MatrixDistance /2 - Variables.FontOperationWidth;
        }
        private static int GenerateEqualsSignX(int YFirstMatrix, int YSecondMatrix) {
            return Variables.LeftOffset + (YFirstMatrix + YSecondMatrix) * Variables.FieldsTotalWidth 
                - 2*Variables.FieldsPaddingLeft + Variables.MatrixDistance + Variables.MatrixDistance /2 - Variables.FontEqualsWidth;
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


            Label OperationLabel = GenerateLabel(PositionOperationY, PositionOperationX, new Size(Variables.FontOperationWidth, Variables.FontEqualsHeight), Sign);    
            Label EqualsLabel = GenerateLabel(PositionEqualsY, PositionEqualsX, new Size(Variables.FontEqualsWidth, Variables.FontEqualsHeight), "="); ;
            
            return (OperationLabel,EqualsLabel);

        }
        //------------------------------------------------


        // Main generation method
        public static (NumericUpDown[,], NumericUpDown[,], TextBox[,]) GenerateMatrices(this MatrixInputForm form, int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix, string Sign)
        {
            //<summary>
            // Generate the first operand matrix, the second operand matrix and the result matrix.
            //</summary>

            (int XResultantMatrix, int YResultantMatrix) = (XFirstMatrix, YSecondMatrix);

            (int CenterMarginYFirstMatrix, int CenterMarginYSecondMatrix, int CenterMarginYResultMatrix) = GetCenteringMargins(XFirstMatrix, XSecondMatrix);

            NumericUpDown[,] FirstMatrix = form.GenerateFirstMatrix(XFirstMatrix, YFirstMatrix, CenterMarginYFirstMatrix);

            NumericUpDown[,] SecondMatrix = form.GenerateSecondMatrix(XSecondMatrix, YSecondMatrix, YFirstMatrix, CenterMarginYSecondMatrix);

            TextBox[,] ResultMatrix = form.GenerateResultingMatrix(XResultantMatrix, YResultantMatrix, YFirstMatrix, YSecondMatrix, CenterMarginYResultMatrix);


            (Label Operation, Label Equals) = GenerateSigns(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix, Sign);
            form.Controls.Add(Operation);
            form.Controls.Add(Equals);


            return (FirstMatrix, SecondMatrix, ResultMatrix);

        }
        //-------------------------------------------------


        

    }
}
