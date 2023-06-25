using MatrixOperations.Forms.FormTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixOperations.Initialization_files
{
    public static class HelperControlsInit
    {
        // Matrix Labels setting
        public static void GenerateFirstMatrixLabel(this MatrixInputForm form, int YFirstMatrix)
        {
            Label Label = new Label();
            Label.Text = "First matrix";
            Label.Top = Variables.TopOffset - Variables.DistanceFromMatrixes;
            Label.Left = Variables.LeftOffset + (YFirstMatrix * Variables.FieldsTotalWidth - Variables.FieldsPaddingLeft - Label.Width) / 2;
            form.Controls.Add(Label);
        }
        public static void GenerateSecondMatrixLabel(this MatrixInputForm form, int YFirstMatrix, int YSecondMatrix)
        {
            Label Label = new Label();
            Label.Text = "Second matrix";
            Label.Top = Variables.TopOffset - Variables.DistanceFromMatrixes;
            Label.Left = Variables.LeftOffset + (YFirstMatrix * Variables.FieldsTotalWidth - Variables.FieldsPaddingLeft) + Variables.MatrixDistance +
                (YSecondMatrix * Variables.FieldsTotalWidth - Variables.FieldsPaddingLeft - Label.Width) / 2;
            form.Controls.Add(Label);

        }
        public static void GenerateResultantMatrixLabel(this MatrixInputForm form, int YFirstMatrix, int YSecondMatrix)
        {
            Label Label = new Label();
            Label.Text = "Result matrix";
            Label.Top = Variables.TopOffset - Variables.DistanceFromMatrixes;
            Label.Left = Variables.LeftOffset + (YFirstMatrix * Variables.FieldsTotalWidth - Variables.FieldsPaddingLeft) + Variables.MatrixDistance +
                (YSecondMatrix * Variables.FieldsTotalWidth - Variables.FieldsPaddingLeft) + Variables.MatrixDistance + 
                (YSecondMatrix * Variables.FieldsTotalWidth - Variables.FieldsPaddingLeft - Label.Width) / 2;
            form.Controls.Add(Label);

        }

        
        public static void GenerateLabels(this MatrixInputForm form, int YFirstMatrix,int YSecondMatrix)
        
        {
            form.GenerateFirstMatrixLabel(YFirstMatrix);
            form.GenerateSecondMatrixLabel(YFirstMatrix, YSecondMatrix);
            form.GenerateResultantMatrixLabel(YFirstMatrix,YSecondMatrix);

        }
        //---------------------------------------------------


        // Form dimensions setting
        public static void SetWidthAndHeight(this MatrixInputForm form, int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix)
        {
            (int XResultantMatrix, int YResultantMatrix) = (XFirstMatrix, YSecondMatrix);
            form.Width = (YFirstMatrix + YSecondMatrix + YResultantMatrix) * Variables.FieldsTotalWidth + Variables.MatrixDistance * 2 + Variables.LeftOffset + Variables.RightOffset;
            form.Height = Math.Max(XFirstMatrix, XSecondMatrix) * Variables.FieldsTotalHeight + Variables.TopOffset + Variables.BottomOffset;

        }
        //---------------------------------------------------


        // Button generation
        public static Button GenerateButton(this MatrixInputForm form, int XFirstMatrix, int XSecondMatrix, string Text,EventHandler ClickMethod,int LeftOffset)
        {
            Button Button = new Button();
            Button.Top = Math.Max(XFirstMatrix, XSecondMatrix) * Variables.FieldsTotalHeight + Variables.TopOffset;
            Button.Left = LeftOffset;
            Button.Text = Text;
            Button.Width = Variables.ButtonWidth;
            Button.Height = Variables.ButtonHeight;
            Button.Click += ClickMethod;

            form.Controls.Add(Button);
            
            return Button;

        }
        //---------------------------------------------------



    }
}
