namespace Agile_Project_Atm_machine
{
    partial class AccountSelection
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
            SAVINGS = new Button();
            CHECKING = new Button();
            CREDIT = new Button();
            LOANS = new Button();
            EXIT = new Button();
            MAINMENU = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Green;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(215, 36);
            label1.Name = "label1";
            label1.Size = new Size(324, 38);
            label1.TabIndex = 0;
            label1.Text = "SELECT ACCOUNT TYPE";
            // 
            // SAVINGS
            // 
            SAVINGS.BackColor = Color.FromArgb(0, 192, 0);
            SAVINGS.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SAVINGS.ForeColor = Color.White;
            SAVINGS.Location = new Point(12, 132);
            SAVINGS.Name = "SAVINGS";
            SAVINGS.Size = new Size(260, 105);
            SAVINGS.TabIndex = 1;
            SAVINGS.Text = "SAVINGS";
            SAVINGS.UseVisualStyleBackColor = false;
            SAVINGS.Click += SAVINGS_Click;
            // 
            // CHECKING
            // 
            CHECKING.BackColor = Color.FromArgb(0, 192, 0);
            CHECKING.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CHECKING.ForeColor = Color.White;
            CHECKING.Location = new Point(494, 117);
            CHECKING.Name = "CHECKING";
            CHECKING.Size = new Size(260, 105);
            CHECKING.TabIndex = 2;
            CHECKING.Text = "CHECKING";
            CHECKING.UseVisualStyleBackColor = false;
            CHECKING.Click += CHECKING_Click;
            // 
            // CREDIT
            // 
            CREDIT.BackColor = Color.FromArgb(0, 192, 0);
            CREDIT.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CREDIT.ForeColor = Color.White;
            CREDIT.Location = new Point(12, 256);
            CREDIT.Name = "CREDIT";
            CREDIT.Size = new Size(260, 105);
            CREDIT.TabIndex = 3;
            CREDIT.Text = "CREDIT";
            CREDIT.UseVisualStyleBackColor = false;
            CREDIT.Click += CREDIT_Click;
            // 
            // LOANS
            // 
            LOANS.BackColor = Color.FromArgb(0, 192, 0);
            LOANS.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LOANS.ForeColor = Color.White;
            LOANS.Location = new Point(494, 256);
            LOANS.Name = "LOANS";
            LOANS.Size = new Size(260, 105);
            LOANS.TabIndex = 4;
            LOANS.Text = "LOANS";
            LOANS.UseVisualStyleBackColor = false;
            LOANS.Click += LOANS_Click;
            // 
            // EXIT
            // 
            EXIT.BackColor = Color.FromArgb(0, 192, 0);
            EXIT.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EXIT.ForeColor = Color.White;
            EXIT.Location = new Point(65, 383);
            EXIT.Name = "EXIT";
            EXIT.Size = new Size(161, 67);
            EXIT.TabIndex = 5;
            EXIT.Text = "EXIT";
            EXIT.UseVisualStyleBackColor = false;
            EXIT.Click += EXIT_Click;
            // 
            // MAINMENU
            // 
            MAINMENU.BackColor = Color.FromArgb(0, 192, 0);
            MAINMENU.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MAINMENU.ForeColor = Color.White;
            MAINMENU.Location = new Point(511, 383);
            MAINMENU.Name = "MAINMENU";
            MAINMENU.Size = new Size(243, 67);
            MAINMENU.TabIndex = 6;
            MAINMENU.Text = "MAINMENU";
            MAINMENU.UseVisualStyleBackColor = false;
            MAINMENU.Click += MAINMENU_Click;
            // 
            // AccountSelection
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MAINMENU);
            Controls.Add(EXIT);
            Controls.Add(LOANS);
            Controls.Add(CREDIT);
            Controls.Add(CHECKING);
            Controls.Add(SAVINGS);
            Controls.Add(label1);
            Name = "AccountSelection";
            Text = "AccountSelection";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button SAVINGS;
        private Button CHECKING;
        private Button CREDIT;
        private Button LOANS;
        private Button EXIT;
        private Button MAINMENU;
    }
}