namespace MatrixOperations
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            listBoxOptions = new ListBox();
            buttonShowOperation = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(156, 17);
            label1.TabIndex = 1;
            label1.Text = "Select matrix operation:";
            label1.Click += label1_Click;
            // 
            // listBoxOptions
            // 
            listBoxOptions.BackColor = SystemColors.ControlLight;
            listBoxOptions.FormattingEnabled = true;
            listBoxOptions.ItemHeight = 15;
            listBoxOptions.Items.AddRange(new object[] { "Addition", "Subtraction", "Multiplication", "Graph Visualization" });
            listBoxOptions.Location = new Point(14, 49);
            listBoxOptions.Name = "listBoxOptions";
            listBoxOptions.Size = new Size(154, 94);
            listBoxOptions.TabIndex = 2;
            listBoxOptions.SelectedIndexChanged += listBoxOptions_SelectedIndexChanged;
            // 
            // buttonShowOperation
            // 
            buttonShowOperation.BackColor = SystemColors.Highlight;
            buttonShowOperation.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            buttonShowOperation.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonShowOperation.ForeColor = SystemColors.ControlLight;
            buttonShowOperation.Location = new Point(181, 18);
            buttonShowOperation.Name = "buttonShowOperation";
            buttonShowOperation.Size = new Size(143, 125);
            buttonShowOperation.TabIndex = 3;
            buttonShowOperation.Text = "Show operation";
            buttonShowOperation.UseVisualStyleBackColor = false;
            buttonShowOperation.Click += buttonShowOperation_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(336, 155);
            Controls.Add(buttonShowOperation);
            Controls.Add(listBoxOptions);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Matrix Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ListBox listBoxOptions;
        private Button buttonShowOperation;
    }
}