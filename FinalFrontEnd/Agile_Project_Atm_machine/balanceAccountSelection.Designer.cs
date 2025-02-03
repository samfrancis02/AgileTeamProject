namespace Agile_Project_Atm_machine
{
    partial class balanceAccountSelection
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
            MAINMENU = new Button();
            EXIT = new Button();
            LOANS = new Button();
            CREDIT = new Button();
            CHECKING = new Button();
            SAVINGS = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // MAINMENU
            // 
            MAINMENU.Anchor = AnchorStyles.None;
            MAINMENU.BackColor = Color.ForestGreen;
            MAINMENU.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MAINMENU.ForeColor = Color.White;
            MAINMENU.Location = new Point(489, 337);
            MAINMENU.Margin = new Padding(2);
            MAINMENU.Name = "MAINMENU";
            MAINMENU.Size = new Size(208, 54);
            MAINMENU.TabIndex = 13;
            MAINMENU.Text = "MAINMENU";
            MAINMENU.UseVisualStyleBackColor = false;
            MAINMENU.Click += MAINMENU_Click;
            // 
            // EXIT
            // 
            EXIT.Anchor = AnchorStyles.None;
            EXIT.BackColor = Color.ForestGreen;
            EXIT.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EXIT.ForeColor = Color.White;
            EXIT.Location = new Point(146, 337);
            EXIT.Margin = new Padding(2);
            EXIT.Name = "EXIT";
            EXIT.Size = new Size(129, 54);
            EXIT.TabIndex = 12;
            EXIT.Text = "EXIT";
            EXIT.UseVisualStyleBackColor = false;
            EXIT.Click += EXIT_Click;
            // 
            // LOANS
            // 
            LOANS.Anchor = AnchorStyles.None;
            LOANS.BackColor = Color.ForestGreen;
            LOANS.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LOANS.ForeColor = Color.White;
            LOANS.Location = new Point(489, 236);
            LOANS.Margin = new Padding(2);
            LOANS.Name = "LOANS";
            LOANS.Size = new Size(208, 84);
            LOANS.TabIndex = 11;
            LOANS.Text = "LOANS";
            LOANS.UseVisualStyleBackColor = false;
            LOANS.Click += LOANS_Click;
            // 
            // CREDIT
            // 
            CREDIT.Anchor = AnchorStyles.None;
            CREDIT.BackColor = Color.ForestGreen;
            CREDIT.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CREDIT.ForeColor = Color.White;
            CREDIT.Location = new Point(104, 236);
            CREDIT.Margin = new Padding(2);
            CREDIT.Name = "CREDIT";
            CREDIT.Size = new Size(208, 84);
            CREDIT.TabIndex = 10;
            CREDIT.Text = "CREDIT";
            CREDIT.UseVisualStyleBackColor = false;
            CREDIT.Click += CREDIT_Click;
            // 
            // CHECKING
            // 
            CHECKING.Anchor = AnchorStyles.None;
            CHECKING.BackColor = Color.ForestGreen;
            CHECKING.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CHECKING.ForeColor = Color.White;
            CHECKING.Location = new Point(489, 137);
            CHECKING.Margin = new Padding(2);
            CHECKING.Name = "CHECKING";
            CHECKING.Size = new Size(208, 84);
            CHECKING.TabIndex = 9;
            CHECKING.Text = "CHECKING";
            CHECKING.UseVisualStyleBackColor = false;
            CHECKING.Click += CHECKING_Click;
            // 
            // SAVINGS
            // 
            SAVINGS.Anchor = AnchorStyles.None;
            SAVINGS.BackColor = Color.ForestGreen;
            SAVINGS.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SAVINGS.ForeColor = Color.White;
            SAVINGS.Location = new Point(104, 137);
            SAVINGS.Margin = new Padding(2);
            SAVINGS.Name = "SAVINGS";
            SAVINGS.Size = new Size(208, 84);
            SAVINGS.TabIndex = 8;
            SAVINGS.Text = "SAVINGS";
            SAVINGS.UseVisualStyleBackColor = false;
            SAVINGS.Click += SAVINGS_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.ForestGreen;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(266, 60);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(279, 32);
            label1.TabIndex = 7;
            label1.Text = "SELECT ACCOUNT TYPE";
            // 
            // balanceAccountSelection
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(800, 450);
            Controls.Add(MAINMENU);
            Controls.Add(EXIT);
            Controls.Add(LOANS);
            Controls.Add(CREDIT);
            Controls.Add(CHECKING);
            Controls.Add(SAVINGS);
            Controls.Add(label1);
            Name = "balanceAccountSelection";
            Text = "balanceAccountSelection";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button MAINMENU;
        private Button EXIT;
        private Button LOANS;
        private Button CREDIT;
        private Button CHECKING;
        private Button SAVINGS;
        private Label label1;
    }
}