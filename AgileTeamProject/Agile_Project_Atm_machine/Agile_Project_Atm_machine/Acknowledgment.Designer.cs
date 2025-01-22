namespace Agile_Project_Atm_machine
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
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 0, 64);
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(28, 153);
            label1.Name = "label1";
            label1.Size = new Size(750, 28);
            label1.TabIndex = 0;
            label1.Text = "YOU MAY BE CHARGE A FEE FOR THIS TRANSACTION DO WISH TO CONTINUE";
            label1.Click += label1_Click;
            // 
            // YESCONFIRM
            // 
            YESCONFIRM.BackColor = Color.FromArgb(0, 192, 0);
            YESCONFIRM.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            YESCONFIRM.ForeColor = Color.White;
            YESCONFIRM.Location = new Point(514, 204);
            YESCONFIRM.Name = "YESCONFIRM";
            YESCONFIRM.Size = new Size(155, 50);
            YESCONFIRM.TabIndex = 1;
            YESCONFIRM.Text = "ACCEPT";
            YESCONFIRM.UseVisualStyleBackColor = false;
            YESCONFIRM.Click += YESCONFIRM_Click;
            // 
            // DECLINE
            // 
            DECLINE.BackColor = Color.FromArgb(0, 192, 0);
            DECLINE.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DECLINE.ForeColor = Color.White;
            DECLINE.Location = new Point(89, 204);
            DECLINE.Name = "DECLINE";
            DECLINE.Size = new Size(165, 50);
            DECLINE.TabIndex = 2;
            DECLINE.Text = "DECLINE";
            DECLINE.UseVisualStyleBackColor = false;
            DECLINE.Click += DECLINE_Click;
            // 
            // Acknowledgment
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DECLINE);
            Controls.Add(YESCONFIRM);
            Controls.Add(label1);
            Name = "Acknowledgment";
            Text = "Acknowledgment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button YESCONFIRM;
        private Button DECLINE;
    }
}