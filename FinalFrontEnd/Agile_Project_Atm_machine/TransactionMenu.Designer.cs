namespace Agile_Project_Atm_machine
{
    partial class TransactionMenu
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
            balance = new Button();
            withdrawal = new Button();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // balance
            // 
            balance.Anchor = AnchorStyles.None;
            balance.BackColor = Color.Green;
            balance.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            balance.ForeColor = Color.White;
            balance.Location = new Point(11, 148);
            balance.Margin = new Padding(2, 2, 2, 2);
            balance.Name = "balance";
            balance.Size = new Size(300, 71);
            balance.TabIndex = 0;
            balance.Text = "BALANCE INQUIRY";
            balance.UseVisualStyleBackColor = false;
            balance.Click += balance_Click;
            // 
            // withdrawal
            // 
            withdrawal.Anchor = AnchorStyles.None;
            withdrawal.BackColor = Color.Green;
            withdrawal.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            withdrawal.ForeColor = Color.White;
            withdrawal.Location = new Point(332, 148);
            withdrawal.Margin = new Padding(2, 2, 2, 2);
            withdrawal.Name = "withdrawal";
            withdrawal.Size = new Size(297, 71);
            withdrawal.TabIndex = 1;
            withdrawal.Text = "CASH WITHDRAWAL";
            withdrawal.UseVisualStyleBackColor = false;
            withdrawal.Click += withdrawal_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Green;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(129, 77);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(371, 33);
            label1.TabIndex = 2;
            label1.Text = "SELECT A TRANSACTION";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Green;
            button1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(174, 235);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(300, 77);
            button1.TabIndex = 3;
            button1.Text = "EXIT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // TransactionMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(640, 360);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(withdrawal);
            Controls.Add(balance);
            Margin = new Padding(2, 2, 2, 2);
            Name = "TransactionMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transaction Menu";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button balance;
        private Button withdrawal;
        private Label label1;
        private Button button1;
    }
}