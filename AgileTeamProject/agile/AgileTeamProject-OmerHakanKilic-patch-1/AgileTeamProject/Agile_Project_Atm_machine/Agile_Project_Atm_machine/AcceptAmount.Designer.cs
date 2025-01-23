namespace Agile_Project_Atm_machine
{
    partial class AcceptAmount
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
            label1 = new Label();
            NO = new Button();
            YES = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(525, 117);
            label1.Margin = new Padding(10, 0, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            label1.Click += label1_Click;
            // 
            // NO
            // 
            NO.Anchor = AnchorStyles.None;
            NO.BackColor = Color.ForestGreen;
            NO.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NO.ForeColor = Color.White;
            NO.Location = new Point(640, 223);
            NO.Margin = new Padding(2);
            NO.Name = "NO";
            NO.Size = new Size(182, 68);
            NO.TabIndex = 3;
            NO.Text = "NO";
            NO.UseVisualStyleBackColor = false;
            NO.Click += NO_Click;
            // 
            // YES
            // 
            YES.Anchor = AnchorStyles.None;
            YES.BackColor = Color.ForestGreen;
            YES.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            YES.ForeColor = Color.White;
            YES.Location = new Point(344, 223);
            YES.Margin = new Padding(2);
            YES.Name = "YES";
            YES.Size = new Size(182, 68);
            YES.TabIndex = 2;
            YES.Text = "YES";
            YES.UseVisualStyleBackColor = false;
            YES.Click += YES_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Green;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(422, 137);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(279, 32);
            label2.TabIndex = 4;
            label2.Text = "SELECT ACCOUNT TYPE";
            label2.Click += label2_Click;
            // 
            // AcceptAmount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(1167, 514);
            Controls.Add(label2);
            Controls.Add(NO);
            Controls.Add(YES);
            Controls.Add(label1);
            Name = "AcceptAmount";
            Text = "AcceptAmount";
            WindowState = FormWindowState.Maximized;
            Shown += AcceptAmount_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button NO;
        private Button YES;
        private Label label2;
    }
}