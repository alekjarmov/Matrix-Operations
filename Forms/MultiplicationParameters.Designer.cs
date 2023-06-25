namespace MatrixOperations
{
    partial class MultiplicationParameters
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
            XFirstMatrix = new NumericUpDown();
            YFirstMatrix = new NumericUpDown();
            XSecondMatrix = new NumericUpDown();
            YSecondMatrix = new NumericUpDown();
            x = new Label();
            label1 = new Label();
            MatrixInput = new Button();
            labelMultiplictationDimensions = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)XFirstMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YFirstMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XSecondMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YSecondMatrix).BeginInit();
            SuspendLayout();
            // 
            // XFirstMatrix
            // 
            XFirstMatrix.BackColor = SystemColors.Window;
            XFirstMatrix.Location = new Point(15, 58);
            XFirstMatrix.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            XFirstMatrix.Name = "XFirstMatrix";
            XFirstMatrix.Size = new Size(85, 23);
            XFirstMatrix.TabIndex = 0;
            XFirstMatrix.ValueChanged += XFirstMatrix_ValueChanged;
            // 
            // YFirstMatrix
            // 
            YFirstMatrix.Location = new Point(125, 58);
            YFirstMatrix.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            YFirstMatrix.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            YFirstMatrix.Name = "YFirstMatrix";
            YFirstMatrix.Size = new Size(85, 23);
            YFirstMatrix.TabIndex = 1;
            YFirstMatrix.Value = new decimal(new int[] { 1, 0, 0, 0 });
            YFirstMatrix.ValueChanged += YFirstMatrix_ValueChanged;
            // 
            // XSecondMatrix
            // 
            XSecondMatrix.Location = new Point(15, 106);
            XSecondMatrix.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            XSecondMatrix.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            XSecondMatrix.Name = "XSecondMatrix";
            XSecondMatrix.Size = new Size(85, 23);
            XSecondMatrix.TabIndex = 2;
            XSecondMatrix.Value = new decimal(new int[] { 1, 0, 0, 0 });
            XSecondMatrix.ValueChanged += XSecondMatrix_ValueChanged;
            // 
            // YSecondMatrix
            // 
            YSecondMatrix.Location = new Point(125, 106);
            YSecondMatrix.Name = "YSecondMatrix";
            YSecondMatrix.Size = new Size(85, 23);
            YSecondMatrix.TabIndex = 3;
            // 
            // x
            // 
            x.AutoSize = true;
            x.Location = new Point(106, 60);
            x.Name = "x";
            x.Size = new Size(13, 15);
            x.TabIndex = 4;
            x.Text = "x";
            x.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(106, 108);
            label1.Name = "label1";
            label1.Size = new Size(13, 15);
            label1.TabIndex = 5;
            label1.Text = "x";
            // 
            // MatrixInput
            // 
            MatrixInput.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            MatrixInput.Location = new Point(225, 56);
            MatrixInput.Name = "MatrixInput";
            MatrixInput.Size = new Size(112, 73);
            MatrixInput.TabIndex = 6;
            MatrixInput.Text = "Go to AxB calculator";
            MatrixInput.UseVisualStyleBackColor = true;
            MatrixInput.Click += MatrixInput_Click;
            // 
            // labelMultiplictationDimensions
            // 
            labelMultiplictationDimensions.AutoSize = true;
            labelMultiplictationDimensions.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelMultiplictationDimensions.Location = new Point(12, 9);
            labelMultiplictationDimensions.Name = "labelMultiplictationDimensions";
            labelMultiplictationDimensions.Size = new Size(257, 20);
            labelMultiplictationDimensions.TabIndex = 7;
            labelMultiplictationDimensions.Text = "Enter the dimensions of the matrices";
            labelMultiplictationDimensions.Click += labelMultiplictationDimensions_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 40);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 8;
            label2.Text = "Matrix A dimensions:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 87);
            label3.Name = "label3";
            label3.Size = new Size(118, 15);
            label3.TabIndex = 9;
            label3.Text = "Matrix B dimensions:";
            // 
            // MultiplicationParameters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(354, 140);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(labelMultiplictationDimensions);
            Controls.Add(MatrixInput);
            Controls.Add(label1);
            Controls.Add(x);
            Controls.Add(YSecondMatrix);
            Controls.Add(XSecondMatrix);
            Controls.Add(YFirstMatrix);
            Controls.Add(XFirstMatrix);
            Name = "MultiplicationParameters";
            Text = "MultiplicationParameters";
            ((System.ComponentModel.ISupportInitialize)XFirstMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)YFirstMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)XSecondMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)YSecondMatrix).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown XFirstMatrix;
        private NumericUpDown YFirstMatrix;
        private NumericUpDown XSecondMatrix;
        private NumericUpDown YSecondMatrix;
        private Label x;
        private Label label1;
        private Button MatrixInput;
        private Label labelMultiplictationDimensions;
        private Label label2;
        private Label label3;
    }
}