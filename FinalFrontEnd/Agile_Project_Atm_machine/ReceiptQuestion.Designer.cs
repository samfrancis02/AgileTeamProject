namespace Agile_Project_Atm_machine
{
    partial class ReceiptQuestion
    {
        private System.ComponentModel.IContainer components = null;
        private Button YES;
        private Button NO;
        private Label label1;
        private Label rawResponseLabel; // New label for displaying the raw response

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
            this.YES = new System.Windows.Forms.Button();
            this.NO = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rawResponseLabel = new System.Windows.Forms.Label(); // Initialize the new label

            this.SuspendLayout();

            // YES Button
            this.YES.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.YES.BackColor = System.Drawing.Color.ForestGreen;
            this.YES.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.YES.ForeColor = System.Drawing.Color.White;
            this.YES.Location = new System.Drawing.Point(70, 200);
            this.YES.Name = "YES";
            this.YES.Size = new System.Drawing.Size(182, 68);
            this.YES.TabIndex = 0;
            this.YES.Text = "YES";
            this.YES.UseVisualStyleBackColor = false;
            this.YES.Click += new System.EventHandler(this.YES_Click);

            // NO Button
            this.NO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NO.BackColor = System.Drawing.Color.ForestGreen;
            this.NO.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.NO.ForeColor = System.Drawing.Color.White;
            this.NO.Location = new System.Drawing.Point(366, 200);
            this.NO.Name = "NO";
            this.NO.Size = new System.Drawing.Size(182, 68);
            this.NO.TabIndex = 1;
            this.NO.Text = "NO";
            this.NO.UseVisualStyleBackColor = false;
            this.NO.Click += new System.EventHandler(this.NO_Click);

            // Label for receipt question
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.ForestGreen;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(61, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(577, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Do you want a receipt for this transaction?";
            this.label1.Click += new System.EventHandler(this.label1_Click);

            // Raw response label
            this.rawResponseLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rawResponseLabel.AutoSize = true;
            this.rawResponseLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.rawResponseLabel.ForeColor = System.Drawing.Color.White;
            this.rawResponseLabel.Location = new System.Drawing.Point(70, 300);
            this.rawResponseLabel.Name = "rawResponseLabel";
            this.rawResponseLabel.Size = new System.Drawing.Size(478, 20);
            this.rawResponseLabel.TabIndex = 3;
            this.rawResponseLabel.Text = ""; // Start with an empty text, it will be set dynamically
            this.rawResponseLabel.Visible = true; // Initially visible

            // ReceiptQuestion Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.Controls.Add(this.rawResponseLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NO);
            this.Controls.Add(this.YES);
            this.Name = "ReceiptQuestion";
            this.Text = "Receipt Question";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
