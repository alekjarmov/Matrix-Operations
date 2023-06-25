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
        public static readonly int FieldsWidth = 50;
        public static readonly int FieldsHeight = 23; //Default height per textBox and numericalUpDown
        public static readonly int FieldsPaddingLeft = 20;
        public static readonly int FieldsPaddingTop = 20;
        public static readonly int FieldsTotalHeight = FieldsHeight + FieldsPaddingTop;
        public static readonly int FieldsTotalWidth = FieldsWidth + FieldsPaddingLeft;
        //------------------------------


        // Distance between matrices
        public static readonly int MatrixDistance = 50;
        //------------------------------


        // Offset from the matrices block
        public static readonly int TopOffset = 50;
        public static readonly int BottomOffset = 250;
        public static readonly int LeftOffset = 50;
        public static readonly int RightOffset = 50;
        //------------------------------


        //Operators Text Size
        public static readonly int FontEqualsHeight = 11;
        public static readonly int FontEqualsWidth = 8;
        public static readonly int FontOperationHeight = 8;
        public static readonly int FontOperationWidth = 10;
        //------------------------------

        //Button dimensions
        public static readonly int ButtonWidth = 70;
        public static readonly int ButtonHeight = 20;
        //------------------------------

        // Labels offset
        public static readonly int DistanceFromMatrixes = 30;
        //------------------------------
    }
}
