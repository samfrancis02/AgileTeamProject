﻿namespace Agile_Project_Atm_machine
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
            balance.BackColor = Color.Green;
            balance.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            balance.ForeColor = Color.White;
            balance.Location = new Point(12, 103);
            balance.Name = "balance";
            balance.Size = new Size(324, 162);
            balance.TabIndex = 0;
            balance.Text = "BALANCE INQUIRY";
            balance.UseVisualStyleBackColor = false;
            balance.Click += balance_Click;
            // 
            // withdrawal
            // 
            withdrawal.BackColor = Color.Green;
            withdrawal.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            withdrawal.ForeColor = Color.White;
            withdrawal.Location = new Point(464, 103);
            withdrawal.Name = "withdrawal";
            withdrawal.Size = new Size(324, 173);
            withdrawal.TabIndex = 1;
            withdrawal.Text = "CASH WITHDRAWAL";
            withdrawal.UseVisualStyleBackColor = false;
            withdrawal.Click += withdrawal_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(218, 18);
            label1.Name = "label1";
            label1.Size = new Size(404, 45);
            label1.TabIndex = 2;
            label1.Text = "SELECT A TRANSACTION'";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(0, 0, 64);
            button1.Location = new Point(310, 320);
            button1.Name = "button1";
            button1.Size = new Size(210, 72);
            button1.TabIndex = 3;
            button1.Text = "EXIT";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TransactionMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(withdrawal);
            Controls.Add(balance);
            Name = "TransactionMenu";
            Text = "TransactionMenu";
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