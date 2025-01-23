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
            YES.BackColor = Color.ForestGreen;
            YES.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            YES.ForeColor = Color.White;
            YES.Location = new Point(70, 120);
            YES.Margin = new Padding(2);
            YES.Name = "YES";
            YES.Size = new Size(182, 68);
            YES.TabIndex = 0;
            YES.Text = "YES";
            YES.UseVisualStyleBackColor = false;
            YES.Click += YES_Click;
            // 
            // NO
            // 
            NO.Anchor = AnchorStyles.None;
            NO.BackColor = Color.ForestGreen;
            NO.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NO.ForeColor = Color.White;
            NO.Location = new Point(366, 120);
            NO.Margin = new Padding(2);
            NO.Name = "NO";
            NO.Size = new Size(182, 68);
            NO.TabIndex = 1;
            NO.Text = "NO";
            NO.UseVisualStyleBackColor = false;
            NO.Click += NO_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.ForestGreen;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(61, 48);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(577, 32);
            label1.TabIndex = 2;
            label1.Text = "DO YOU WANT RECEIPT FOR THIS TRANSACTION";
            // 
            // ReceiptQuestion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(640, 360);
            Controls.Add(label1);
            Controls.Add(NO);
            Controls.Add(YES);
            Margin = new Padding(2);
            Name = "ReceiptQuestion";
            Text = "ReceiptQuestion";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button YES;
        private Button NO;
        private Label label1;
    }
}