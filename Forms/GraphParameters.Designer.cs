namespace MatrixOperations.Forms
{
    partial class GraphParameters
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
            NumVerticles = new NumericUpDown();
            VerticlesInputBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)NumVerticles).BeginInit();
            SuspendLayout();
            // 
            // labelMultiplictationDimensions
            // 
            labelMultiplictationDimensions.AutoSize = true;
            labelMultiplictationDimensions.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelMultiplictationDimensions.Location = new Point(12, 9);
            labelMultiplictationDimensions.Name = "labelMultiplictationDimensions";
            labelMultiplictationDimensions.Size = new Size(207, 20);
            labelMultiplictationDimensions.TabIndex = 8;
            labelMultiplictationDimensions.Text = "Enter the number of verticles";
            // 
            // NumVerticles
            // 
            NumVerticles.BackColor = SystemColors.Window;
            NumVerticles.Location = new Point(12, 48);
            NumVerticles.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            NumVerticles.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumVerticles.Name = "NumVerticles";
            NumVerticles.Size = new Size(117, 23);
            NumVerticles.TabIndex = 9;
            NumVerticles.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // VerticlesInputBtn
            // 
            VerticlesInputBtn.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
            VerticlesInputBtn.Location = new Point(145, 37);
            VerticlesInputBtn.Name = "VerticlesInputBtn";
            VerticlesInputBtn.Size = new Size(176, 39);
            VerticlesInputBtn.TabIndex = 10;
            VerticlesInputBtn.Text = "Continue";
            VerticlesInputBtn.UseVisualStyleBackColor = true;
            VerticlesInputBtn.Click += VerticlesInputBtn_Click;
            // 
            // GraphParameters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 94);
            Controls.Add(VerticlesInputBtn);
            Controls.Add(NumVerticles);
            Controls.Add(labelMultiplictationDimensions);
            Name = "GraphParameters";
            Text = "GraphParamaters";
            ((System.ComponentModel.ISupportInitialize)NumVerticles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMultiplictationDimensions;
        private NumericUpDown NumVerticles;
        private Button VerticlesInputBtn;
    }
}