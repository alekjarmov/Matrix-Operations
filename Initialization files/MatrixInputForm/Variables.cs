using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations.Initialization_files
{
    public class Variables
    {
        // Properites per field
        public static readonly int FieldsWidth = 80;
        public static readonly int FieldsHeight = 23; //Default height per textBox and numericalUpDown
        public static readonly int FieldsPaddingLeft = 10;
        public static readonly int FieldsPaddingTop = 10;
        public static readonly int FieldsTotalHeight = FieldsHeight + FieldsPaddingTop;
        public static readonly int FieldsTotalWidth = FieldsWidth + FieldsPaddingLeft;
        //------------------------------


        // Distance between matrices
        public static readonly int MatrixDistance = 30;
        //------------------------------


        // Offset from the matrices block
        public static readonly int TopOffset = 50;
        public static readonly int BottomOffset = 120;
        public static readonly int LeftOffset = 65;
        public static readonly int RightOffset = 65;
        //------------------------------


        //Operators Text Size
        public static readonly int FontEqualsHeight = 11;
        public static readonly int FontEqualsWidth = 8;
        public static readonly int FontOperationHeight = 8;
        public static readonly int FontOperationWidth = 10;
        //------------------------------

        //Button dimensions
        public static readonly int ButtonWidth = 80;
        public static readonly int ButtonHeight = 30;
        //------------------------------

        // Buttons options
        public static readonly int ButtonsMarginLeft = 20;
        public static readonly int ButtonsMarginBottom = 20;
        //------------------------------

        // Labels offset
        public static readonly int DistanceFromMatrixes = 30;
        //------------------------------

        // Time between iterations in ms
        public static readonly int MinimumIterationTime = 1;
        public static readonly int MaximumIterationTime = 1000;
        public static int IterationPercentage = 50;
        //------------------------------
        
    }
}
