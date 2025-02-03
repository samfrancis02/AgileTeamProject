namespace Agile_Project_Atm_machine
{
    partial class viewOrPrintBalance
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
            Receipt = new Button();
            View = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.ForestGreen;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(112, 155);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(493, 32);
            label1.TabIndex = 5;
            label1.Text = "View balance on screen or print a receipt?";
            // 
            // Receipt
            // 
            Receipt.Anchor = AnchorStyles.None;
            Receipt.BackColor = Color.ForestGreen;
            Receipt.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Receipt.ForeColor = Color.White;
            Receipt.Location = new Point(417, 227);
            Receipt.Margin = new Padding(2);
            Receipt.Name = "Receipt";
            Receipt.Size = new Size(182, 68);
            Receipt.TabIndex = 4;
            Receipt.Text = "Receipt";
            Receipt.UseVisualStyleBackColor = false;
            Receipt.Click += Receipt_Click;
            // 
            // View
            // 
            View.Anchor = AnchorStyles.None;
            View.BackColor = Color.ForestGreen;
            View.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            View.ForeColor = Color.White;
            View.Location = new Point(121, 227);
            View.Margin = new Padding(2);
            View.Name = "View";
            View.Size = new Size(182, 68);
            View.TabIndex = 3;
            View.Text = "View";
            View.UseVisualStyleBackColor = false;
            View.Click += View_Click;
            // 
            // viewOrPrintBalance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(Receipt);
            Controls.Add(View);
            Name = "viewOrPrintBalance";
            Text = "viewOrPrintBalance";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Receipt;
        private Button View;
    }
}