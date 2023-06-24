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
            ((System.ComponentModel.ISupportInitialize)XFirstMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YFirstMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XSecondMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YSecondMatrix).BeginInit();
            SuspendLayout();
            // 
            // XFirstMatrix
            // 
            XFirstMatrix.Location = new Point(51, 51);
            XFirstMatrix.Name = "XFirstMatrix";
            XFirstMatrix.Size = new Size(85, 23);
            XFirstMatrix.TabIndex = 0;
            // 
            // YFirstMatrix
            // 
            YFirstMatrix.Location = new Point(161, 51);
            YFirstMatrix.Name = "YFirstMatrix";
            YFirstMatrix.Size = new Size(85, 23);
            YFirstMatrix.TabIndex = 1;
            // 
            // XSecondMatrix
            // 
            XSecondMatrix.Location = new Point(51, 94);
            XSecondMatrix.Name = "XSecondMatrix";
            XSecondMatrix.Size = new Size(85, 23);
            XSecondMatrix.TabIndex = 2;
            // 
            // YSecondMatrix
            // 
            YSecondMatrix.Location = new Point(161, 122);
            YSecondMatrix.Name = "YSecondMatrix";
            YSecondMatrix.Size = new Size(85, 23);
            YSecondMatrix.TabIndex = 3;
            // 
            // x
            // 
            x.AutoSize = true;
            x.Location = new Point(142, 53);
            x.Name = "x";
            x.Size = new Size(13, 15);
            x.TabIndex = 4;
            x.Text = "x";
            x.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(142, 124);
            label1.Name = "label1";
            label1.Size = new Size(13, 15);
            label1.TabIndex = 5;
            label1.Text = "x";
            // 
            // MatrixInput
            // 
            MatrixInput.Location = new Point(293, 92);
            MatrixInput.Name = "MatrixInput";
            MatrixInput.Size = new Size(107, 23);
            MatrixInput.TabIndex = 6;
            MatrixInput.Text = "To matrix input";
            MatrixInput.UseVisualStyleBackColor = true;
            // 
            // labelMultiplictationDimensions
            // 
            labelMultiplictationDimensions.AutoSize = true;
            labelMultiplictationDimensions.Location = new Point(65, 25);
            labelMultiplictationDimensions.Name = "labelMultiplictationDimensions";
            labelMultiplictationDimensions.Size = new Size(38, 15);
            labelMultiplictationDimensions.TabIndex = 7;
            labelMultiplictationDimensions.Text = "label2";
            // 
            // MultiplicationParameters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 232);
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
    }
}