namespace Agile_Project_Atm_machine
{
    partial class askAnyOtherAction
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
            No = new Button();
            Yes = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.ForestGreen;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(123, 160);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(550, 32);
            label1.TabIndex = 8;
            label1.Text = "Is there any other action you want to perform?";
            // 
            // No
            // 
            No.Anchor = AnchorStyles.None;
            No.BackColor = Color.ForestGreen;
            No.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            No.ForeColor = Color.White;
            No.Location = new Point(459, 227);
            No.Margin = new Padding(2);
            No.Name = "No";
            No.Size = new Size(182, 68);
            No.TabIndex = 7;
            No.Text = "No";
            No.UseVisualStyleBackColor = false;
            No.Click += No_Click;
            // 
            // Yes
            // 
            Yes.Anchor = AnchorStyles.None;
            Yes.BackColor = Color.ForestGreen;
            Yes.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Yes.ForeColor = Color.White;
            Yes.Location = new Point(163, 227);
            Yes.Margin = new Padding(2);
            Yes.Name = "Yes";
            Yes.Size = new Size(182, 68);
            Yes.TabIndex = 6;
            Yes.Text = "Yes";
            Yes.UseVisualStyleBackColor = false;
            Yes.Click += Yes_Click;
            // 
            // askAnyOtherAction
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(No);
            Controls.Add(Yes);
            Name = "askAnyOtherAction";
            Text = "askAnyOtherAction";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button No;
        private Button Yes;
    }
}