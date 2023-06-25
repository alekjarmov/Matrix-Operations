namespace MatrixOperations.Forms
{
    partial class AdditionParameters
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            labelMultiplictationDimensions = new Label();
            MatrixInput = new Button();
            x = new Label();
            NumericalUpDownColumns = new NumericUpDown();
            NumericalUpDownRows = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)NumericalUpDownColumns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericalUpDownRows).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 52);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 18;
            label2.Text = "Matrices Dimensions";
            label2.Click += label2_Click;
            // 
            // labelMultiplictationDimensions
            // 
            labelMultiplictationDimensions.AutoSize = true;
            labelMultiplictationDimensions.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelMultiplictationDimensions.Location = new Point(12, 9);
            labelMultiplictationDimensions.Name = "labelMultiplictationDimensions";
            labelMultiplictationDimensions.Size = new Size(257, 20);
            labelMultiplictationDimensions.TabIndex = 17;
            labelMultiplictationDimensions.Text = "Enter the dimensions of the matrices";
            // 
            // MatrixInput
            // 
            MatrixInput.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            MatrixInput.Location = new Point(225, 39);
            MatrixInput.Name = "MatrixInput";
            MatrixInput.Size = new Size(111, 48);
            MatrixInput.TabIndex = 16;
            MatrixInput.Text = "Go to A+B calculator";
            MatrixInput.UseVisualStyleBackColor = true;
            MatrixInput.Click += MatrixInput_Click;
            // 
            // x
            // 
            x.AutoSize = true;
            x.Location = new Point(106, 72);
            x.Name = "x";
            x.Size = new Size(13, 15);
            x.TabIndex = 14;
            x.Text = "x";
            x.Click += x_Click;
            // 
            // NumericalUpDownColumns
            // 
            NumericalUpDownColumns.Location = new Point(125, 70);
            NumericalUpDownColumns.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NumericalUpDownColumns.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericalUpDownColumns.Name = "NumericalUpDownColumns";
            NumericalUpDownColumns.Size = new Size(85, 23);
            NumericalUpDownColumns.TabIndex = 11;
            NumericalUpDownColumns.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumericalUpDownColumns.ValueChanged += YFirstMatrix_ValueChanged;
            // 
            // NumericalUpDownRows
            // 
            NumericalUpDownRows.BackColor = SystemColors.Window;
            NumericalUpDownRows.Location = new Point(15, 70);
            NumericalUpDownRows.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NumericalUpDownRows.Name = "NumericalUpDownRows";
            NumericalUpDownRows.Size = new Size(85, 23);
            NumericalUpDownRows.TabIndex = 10;
            NumericalUpDownRows.ValueChanged += XFirstMatrix_ValueChanged;
            // 
            // AdditionParameters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 118);
            Controls.Add(label2);
            Controls.Add(labelMultiplictationDimensions);
            Controls.Add(MatrixInput);
            Controls.Add(x);
            Controls.Add(NumericalUpDownColumns);
            Controls.Add(NumericalUpDownRows);
            Name = "AdditionParameters";
            Text = "AdditionParameters";
            ((System.ComponentModel.ISupportInitialize)NumericalUpDownColumns).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericalUpDownRows).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label labelMultiplictationDimensions;
        private Button MatrixInput;
        private Label label1;
        private Label x;
        private NumericUpDown YSecondMatrix;
        private NumericUpDown XSecondMatrix;
        private NumericUpDown YFirstMatrix;
        private NumericUpDown XFirstMatrix;
        private NumericUpDown NumericalUpDownColumns;
        private NumericUpDown NumericalUpDownRows;
    }
}