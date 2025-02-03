namespace Agile_Project_Atm_machine
{
    partial class balanceViewcs
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            accountNameLabel = new Label();
            balanceLabel = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // accountNameLabel
            // 
            accountNameLabel.Anchor = AnchorStyles.None;
            accountNameLabel.AutoSize = true;
            accountNameLabel.BackColor = Color.ForestGreen;
            accountNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accountNameLabel.ForeColor = Color.White;
            accountNameLabel.Location = new Point(99, 109);
            accountNameLabel.Name = "accountNameLabel";
            accountNameLabel.Size = new Size(581, 51);
            accountNameLabel.TabIndex = 9;
            accountNameLabel.Text = "Account name: {account_name}";
            accountNameLabel.Click += accountNameLabel_Click;
            // 
            // balanceLabel
            // 
            balanceLabel.Anchor = AnchorStyles.None;
            balanceLabel.AutoSize = true;
            balanceLabel.BackColor = Color.ForestGreen;
            balanceLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            balanceLabel.ForeColor = Color.White;
            balanceLabel.Location = new Point(99, 243);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new Size(501, 51);
            balanceLabel.TabIndex = 10;
            balanceLabel.Text = "Account balance: {balance}";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.ForestGreen;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(375, 486);
            label3.Name = "label3";
            label3.Size = new Size(505, 51);
            label3.TabIndex = 11;
            label3.Text = "Click anywhere to continue";
            // 
            // balanceViewcs
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(1300, 720);
            Controls.Add(label3);
            Controls.Add(balanceLabel);
            Controls.Add(accountNameLabel);
            Margin = new Padding(5);
            Name = "balanceViewcs";
            Text = "Balance View";
            WindowState = FormWindowState.Maximized;
            Load += balanceViewcs_Load;
            Click += balanceViewcs_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label accountNameLabel;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.Label label3;
    }
}
