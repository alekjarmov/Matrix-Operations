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
using System.Drawing.Printing;

namespace MatrixOperations
{
    public static class MatrixInit
    {
        // Matrix generation
        public static (NumericUpDown[,], Label[]) GenerateGraphVizMatrix(MatrixInputForm form, int X, int Y,
                                    int MarginX, int MarginY, int Minimum, int Maximum)
        {
            NumericUpDown[,] numericUpDowns = new NumericUpDown[X, Y];
            Label[] labels = new Label[X + Y];
            System.Diagnostics.Debug.WriteLine("Console from graphviz");
            for (var i = 0; i < X + 1; i++)
            {
                for (var j = 0; j < Y + 1; j++)
                {
                    if (i==0 && j==0)
                    {
                        continue;
                    }
                    else if (i != 0 && j == 0)
                    {
                        labels[i + j - 1] = new Label
                        {
                            Text = $"{i}"
,
                            Width = Variables.CharacterWidth,
                            Top = MarginY + i * Variables.FieldsTotalHeight,
                            Left = MarginX + j * Variables.FieldsTotalWidth + Variables.FieldsTotalWidth / 2
                        };
                        form.Controls.Add(labels[i + j - 1]);
                    }
                    else if (i == 0 && j != 0)
                    {
                        labels[Y + j - 1] = new Label();
                        labels[Y + j - 1].Text = $"{j}";
                        labels[Y + j - 1].Width = Variables.CharacterWidth;
                        labels[Y + j - 1].Top = MarginY + i * Variables.FieldsTotalHeight;
                        labels[Y + j - 1].Left = MarginX + j * Variables.FieldsTotalWidth + Variables.FieldsTotalWidth/2;
                        form.Controls.Add(labels[Y + j - 1]);
                    }
                    else
                    {
                        numericUpDowns[i - 1, j - 1] = new NumericUpDown();
                        numericUpDowns[i - 1, j - 1].Top = MarginY + i * Variables.FieldsTotalHeight;
                        numericUpDowns[i - 1, j - 1].Left = MarginX + j * Variables.FieldsTotalWidth;
                        numericUpDowns[i - 1, j - 1].Width = Variables.FieldsWidth;
                        numericUpDowns[i - 1, j - 1].Minimum = Minimum;
                        numericUpDowns[i - 1, j - 1].Maximum = Maximum;
                        form.Controls.Add(numericUpDowns[i - 1, j - 1]);
                    }

                }
            }

            return (numericUpDowns, labels);
        }
        public static NumericUpDown[,] GenerateOperationMatrix(MatrixInputForm form, int X, int Y,
                                    int MarginX, int MarginY, int Minimum, int Maximum)
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
                    numericUpDowns[i, j].Minimum = Minimum;
                    numericUpDowns[i, j].Maximum = Maximum;
                    form.Controls.Add(numericUpDowns[i, j]);


                }
            }

            return numericUpDowns;
        }
        public static (NumericUpDown[,], Label[]) GenerateMatrix(MatrixInputForm form, int X, int Y,
                                    int MarginX, int MarginY, int Minimum, int Maximum, bool InitializeHelperComponents = true)
        {
            NumericUpDown[,] numericUpDowns;
            Label[]? labels = null; 
            if(!InitializeHelperComponents)
            {
                (numericUpDowns, labels) = GenerateGraphVizMatrix(form, X, Y, MarginX, MarginY, Minimum, Maximum);
            }
            else
            {
                numericUpDowns = GenerateOperationMatrix(form, X, Y, MarginX, MarginY, Minimum, Maximum);
            }
            return (numericUpDowns, labels);
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
        private static (int, int, int) GetCenteringMargins(int XFirstMatrix, int XSecondMatrix)
        {
            int MarginFirstMatrix, MarginSecondMatrix, MarginResultMatrix;
            if (XFirstMatrix > XSecondMatrix)
            {
                MarginFirstMatrix = 0;
                MarginSecondMatrix = ((XFirstMatrix - XSecondMatrix) * Variables.FieldsTotalHeight) / 2;

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
        private static NumericUpDown[,] GenerateFirstMatrix(this MatrixInputForm form, int XFirstMatrix, int YFirstMatrix, int CenterMarginYFirstMatrix, int Minimum, int Maximum, bool InitializeHelperComponents)
        {
            // <summary>
            // Generates the first matrix
            //</summary>
            int MarginXForFirstMatrix = Variables.LeftOffset;
            int MarginYForFirstMatrix = Variables.TopOffset + CenterMarginYFirstMatrix;



            return GenerateMatrix(form, XFirstMatrix, YFirstMatrix, MarginXForFirstMatrix,
                MarginYForFirstMatrix, Minimum, Maximum, InitializeHelperComponents).Item1;

        }
        private static NumericUpDown[,] GenerateSecondMatrix(this MatrixInputForm form, int XSecondMatrix, int YSecondMatrix, int YFirstMatrix, int CenterMarginYSecondMatrix, int Minimum, int Maximum)
        {
            // <summary>
            // Generates the second matrix 
            //</summary>
            int MarginXForSecondMatrix = Variables.LeftOffset + Variables.MatrixDistance + YFirstMatrix * Variables.FieldsTotalWidth - Variables.FieldsPaddingLeft;
            int MarginYForSecondMatrix = Variables.TopOffset + CenterMarginYSecondMatrix;


            return GenerateMatrix(form, XSecondMatrix, YSecondMatrix, MarginXForSecondMatrix,
                MarginYForSecondMatrix, Minimum, Maximum).Item1;

        }
        private static TextBox[,] GenerateResultingMatrix(this MatrixInputForm form, int XResultantMatrix, int YResultantMatrix, int YFirstMatrix, int YSecondMatrix, int CenterMarginYResultMatrix)

        {
            //<summary>
            // Generates the resulting matrix
            //</summary>
            int MarginXForResultMatrix = Variables.LeftOffset + 2 * Variables.MatrixDistance + YFirstMatrix * Variables.FieldsTotalWidth + YSecondMatrix * Variables.FieldsTotalWidth - 2 * Variables.FieldsPaddingLeft;
            int MarginYForResultMatrix = Variables.TopOffset + CenterMarginYResultMatrix;


            return GenerateDisabledTextBoxMatrix(form, XResultantMatrix, YResultantMatrix, MarginXForResultMatrix,
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
            return Variables.LeftOffset + YFirstMatrix * Variables.FieldsTotalWidth - Variables.FieldsPaddingLeft + Variables.MatrixDistance / 2 - Variables.FontOperationWidth;
        }
        private static int GenerateEqualsSignX(int YFirstMatrix, int YSecondMatrix)
        {
            return Variables.LeftOffset + (YFirstMatrix + YSecondMatrix) * Variables.FieldsTotalWidth
                - 2 * Variables.FieldsPaddingLeft + Variables.MatrixDistance + Variables.MatrixDistance / 2 - Variables.FontEqualsWidth;
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
        private static (Label, Label) GenerateSigns(int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix, string Sign)
        {
            int PositionOperationY = GenerateOperationSignY(XFirstMatrix, XSecondMatrix);
            int PositionEqualsY = GenerateEqualsSignY(XFirstMatrix, XSecondMatrix);
            int PositionOperationX = GenerateOperationSignX(YFirstMatrix);
            int PositionEqualsX = GenerateEqualsSignX(YFirstMatrix, YSecondMatrix);


            Label OperationLabel = GenerateLabel(PositionOperationY, PositionOperationX, new Size(Variables.FontOperationWidth, Variables.FontEqualsHeight), Sign);
            Label EqualsLabel = GenerateLabel(PositionEqualsY, PositionEqualsX, new Size(Variables.FontEqualsWidth, Variables.FontEqualsHeight), "="); ;

            return (OperationLabel, EqualsLabel);

        }
        //------------------------------------------------


        // Main generation method
        public static (NumericUpDown[,], NumericUpDown[,], TextBox[,]) GenerateMatrices(this MatrixInputForm form, int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix, 
                                                                                        string? Sign, int Minimum, int Maximum, bool InitializeHelperComponents)
        {
            //<summary>
            // Generate the first operand matrix, the second operand matrix and the result matrix.
            //</summary>

            (int XResultantMatrix, int YResultantMatrix) = (XFirstMatrix, YSecondMatrix);

            (int CenterMarginYFirstMatrix, int CenterMarginYSecondMatrix, int CenterMarginYResultMatrix) = GetCenteringMargins(XFirstMatrix, XSecondMatrix);

            NumericUpDown[,] FirstMatrix = form.GenerateFirstMatrix(XFirstMatrix, YFirstMatrix, CenterMarginYFirstMatrix, Minimum, Maximum, InitializeHelperComponents);

            NumericUpDown[,] SecondMatrix = form.GenerateSecondMatrix(XSecondMatrix, YSecondMatrix, YFirstMatrix, CenterMarginYSecondMatrix, Minimum, Maximum);

            TextBox[,] ResultMatrix = form.GenerateResultingMatrix(XResultantMatrix, YResultantMatrix, YFirstMatrix, YSecondMatrix, CenterMarginYResultMatrix);

            if (InitializeHelperComponents)
            {
                (Label Operation, Label Equals) = GenerateSigns(XFirstMatrix, YFirstMatrix, XSecondMatrix, YSecondMatrix, Sign);
                form.Controls.Add(Operation);
                form.Controls.Add(Equals);
            }


            return (FirstMatrix, SecondMatrix, ResultMatrix);

        }
        //-------------------------------------------------




    }
}
