namespace MatrixOperations
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
            labelMultiplictationDimensions = new Label();
            MatrixInput = new Button();
            x = new Label();
            YFirstMatrix = new NumericUpDown();
            XFirstMatrix = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)YFirstMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XFirstMatrix).BeginInit();
            SuspendLayout();
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
            MatrixInput.Location = new Point(12, 65);
            MatrixInput.Name = "MatrixInput";
            MatrixInput.Size = new Size(257, 73);
            MatrixInput.TabIndex = 16;
            MatrixInput.Text = "Go to A+B calculator";
            MatrixInput.UseVisualStyleBackColor = true;
            MatrixInput.Click += MatrixInput_Click;
            // 
            // x
            // 
            x.AutoSize = true;
            x.Location = new Point(135, 34);
            x.Name = "x";
            x.Size = new Size(13, 15);
            x.TabIndex = 14;
            x.Text = "x";
            // 
            // YFirstMatrix
            // 
            YFirstMatrix.Location = new Point(151, 32);
            YFirstMatrix.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            YFirstMatrix.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            YFirstMatrix.Name = "YFirstMatrix";
            YFirstMatrix.Size = new Size(118, 23);
            YFirstMatrix.TabIndex = 11;
            YFirstMatrix.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // XFirstMatrix
            // 
            XFirstMatrix.Location = new Point(12, 32);
            XFirstMatrix.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            XFirstMatrix.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            XFirstMatrix.Name = "XFirstMatrix";
            XFirstMatrix.Size = new Size(118, 23);
            XFirstMatrix.TabIndex = 10;
            XFirstMatrix.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // AdditionParameters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 150);
            Controls.Add(labelMultiplictationDimensions);
            Controls.Add(MatrixInput);
            Controls.Add(x);
            Controls.Add(YFirstMatrix);
            Controls.Add(XFirstMatrix);
            Name = "AdditionParameters";
            Text = "Dimensions";
            ((System.ComponentModel.ISupportInitialize)YFirstMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)XFirstMatrix).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelMultiplictationDimensions;
        private Button MatrixInput;
        private Label x;
        private NumericUpDown YFirstMatrix;
        private NumericUpDown XFirstMatrix;
    }
}