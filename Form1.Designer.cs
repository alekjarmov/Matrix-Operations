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
            listBox1 = new ListBox();
            button1 = new Button();
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
            // listBox1
            // 
            listBox1.BackColor = SystemColors.ControlLight;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "Addition", "Multiplication" });
            listBox1.Location = new Point(14, 49);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(154, 94);
            listBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            button1.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlLight;
            button1.Location = new Point(187, 18);
            button1.Name = "button1";
            button1.Size = new Size(130, 125);
            button1.TabIndex = 3;
            button1.Text = "Show operation";
            button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(329, 155);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Matrix Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ListBox listBox1;
        private Button button1;
    }
}