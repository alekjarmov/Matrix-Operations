using MatrixOperations.Forms.FormTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations.Initialization_files
{
    public static class HelperControlsInit
    {

        // Form dimensions setting
        public static void SetWidthAndHeight(this MatrixInputForm form, int XFirstMatrix, int YFirstMatrix, int XSecondMatrix, int YSecondMatrix)
        {
            (int XResultantMatrix, int YResultantMatrix) = (XFirstMatrix, YSecondMatrix);
            form.Width = (YFirstMatrix + YSecondMatrix + YResultantMatrix) * Variables.FieldsTotalWidth + Variables.MatrixDistance * 2 + Variables.LeftOffset + Variables.RightOffset;
            form.Height = Math.Max(XFirstMatrix, XSecondMatrix) * Variables.FieldsTotalHeight + Variables.TopOffset + Variables.BottomOffset;

        }
        //---------------------------------------------------

        // Button generation
        public static Button GenerateAnimationButton(this MatrixInputForm form, int XFirstMatrix, int XSecondMatrix)
        {
            Button AnimateButton = new Button();
            AnimateButton.Top = Math.Max(XFirstMatrix, XSecondMatrix) * Variables.FieldsTotalHeight + Variables.TopOffset;
            AnimateButton.Left = Variables.LeftOffset;
            AnimateButton.Text = "Calculate";
            AnimateButton.Width = Variables.ButtonWidth;
            AnimateButton.Height = Variables.ButtonHeight;

            form.Controls.Add(AnimateButton);

            return AnimateButton;

        }
        //---------------------------------------------------
    }
}
