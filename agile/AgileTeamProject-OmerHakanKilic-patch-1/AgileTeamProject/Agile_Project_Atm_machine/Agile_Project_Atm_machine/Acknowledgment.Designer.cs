﻿namespace Agile_Project_Atm_machine
{
    partial class Acknowledgment
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
            YESCONFIRM = new Button();
            DECLINE = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Green;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(268, 258);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(1204, 45);
            label1.TabIndex = 0;
            label1.Text = "YOU MAY BE CHARGE A FEE FOR THIS TRANSACTION DO WISH TO CONTINUE";
            label1.Click += label1_Click;
            // 
            // YESCONFIRM
            // 
            YESCONFIRM.Anchor = AnchorStyles.None;
            YESCONFIRM.BackColor = Color.FromArgb(0, 192, 0);
            YESCONFIRM.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            YESCONFIRM.ForeColor = Color.White;
            YESCONFIRM.Location = new Point(977, 367);
            YESCONFIRM.Margin = new Padding(6, 5, 6, 5);
            YESCONFIRM.Name = "YESCONFIRM";
            YESCONFIRM.Size = new Size(294, 90);
            YESCONFIRM.TabIndex = 1;
            YESCONFIRM.Text = "ACCEPT";
            YESCONFIRM.UseVisualStyleBackColor = false;
            YESCONFIRM.Click += YESCONFIRM_Click;
            // 
            // DECLINE
            // 
            DECLINE.Anchor = AnchorStyles.None;
            DECLINE.BackColor = Color.FromArgb(0, 192, 0);
            DECLINE.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DECLINE.ForeColor = Color.White;
            DECLINE.Location = new Point(169, 367);
            DECLINE.Margin = new Padding(6, 5, 6, 5);
            DECLINE.Name = "DECLINE";
            DECLINE.Size = new Size(314, 90);
            DECLINE.TabIndex = 2;
            DECLINE.Text = "DECLINE";
            DECLINE.UseVisualStyleBackColor = false;
            DECLINE.Click += DECLINE_Click;
            // 
            // Acknowledgment
            // 
            AutoScaleDimensions = new SizeF(19F, 45F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 0);
            ClientSize = new Size(1520, 810);
            Controls.Add(DECLINE);
            Controls.Add(YESCONFIRM);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Margin = new Padding(6, 5, 6, 5);
            Name = "Acknowledgment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acknowledgment";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button YESCONFIRM;
        private Button DECLINE;
    }
}