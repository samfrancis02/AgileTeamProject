namespace Agile_Project_Atm_machine
{
    partial class ReceiptQuestion
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
            YES = new Button();
            NO = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // YES
            // 
            YES.Anchor = AnchorStyles.None;
            YES.BackColor = Color.FromArgb(0, 192, 0);
            YES.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            YES.ForeColor = Color.White;
            YES.Location = new Point(88, 150);
            YES.Name = "YES";
            YES.Size = new Size(227, 85);
            YES.TabIndex = 0;
            YES.Text = "YES";
            YES.UseVisualStyleBackColor = false;
            YES.Click += YES_Click;
            // 
            // NO
            // 
            NO.Anchor = AnchorStyles.None;
            NO.BackColor = Color.FromArgb(0, 192, 0);
            NO.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NO.ForeColor = Color.White;
            NO.Location = new Point(458, 150);
            NO.Name = "NO";
            NO.Size = new Size(227, 85);
            NO.TabIndex = 1;
            NO.Text = "NO";
            NO.UseVisualStyleBackColor = false;
            NO.Click += NO_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 192, 0);
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(76, 60);
            label1.Name = "label1";
            label1.Size = new Size(669, 38);
            label1.TabIndex = 2;
            label1.Text = "DO YOU WANT RECEIPT FOR THIS TRANSACTION";
            // 
            // ReceiptQuestion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 0);
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(NO);
            Controls.Add(YES);
            Name = "ReceiptQuestion";
            Text = "ReceiptQuestion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button YES;
        private Button NO;
        private Label label1;
    }
}