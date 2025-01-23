namespace Agile_Project_Atm_machine
{
    partial class PinForm
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
            text = new TextBox();
            Continue = new Button();
            Exit = new Button();
            Backspace = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button0 = new Button();
            SuspendLayout();
            // 
            // text
            // 
            text.Anchor = AnchorStyles.None;
            text.Cursor = Cursors.No;
            text.Enabled = false;
            text.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            text.Location = new Point(64, 108);
            text.Margin = new Padding(2);
            text.MaxLength = 4;
            text.Name = "text";
            text.PasswordChar = '*';
            text.PlaceholderText = "ENTER YOUR PIN";
            text.ReadOnly = true;
            text.Size = new Size(348, 34);
            text.TabIndex = 1;
            text.TextChanged += text_TextChanged;
            // 
            // Continue
            // 
            Continue.Anchor = AnchorStyles.None;
            Continue.BackColor = Color.Green;
            Continue.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            Continue.ForeColor = Color.White;
            Continue.Location = new Point(446, 242);
            Continue.Margin = new Padding(2);
            Continue.Name = "Continue";
            Continue.Size = new Size(154, 44);
            Continue.TabIndex = 2;
            Continue.Text = "Continue";
            Continue.UseVisualStyleBackColor = false;
            Continue.Click += Continue_Click;
            // 
            // Exit
            // 
            Exit.Anchor = AnchorStyles.None;
            Exit.BackColor = Color.Green;
            Exit.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            Exit.ForeColor = Color.White;
            Exit.Location = new Point(446, 168);
            Exit.Margin = new Padding(2);
            Exit.Name = "Exit";
            Exit.Size = new Size(154, 56);
            Exit.TabIndex = 3;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = false;
            Exit.Click += Exit_Click;
            // 
            // Backspace
            // 
            Backspace.Anchor = AnchorStyles.None;
            Backspace.BackColor = Color.ForestGreen;
            Backspace.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            Backspace.ForeColor = Color.White;
            Backspace.Location = new Point(446, 107);
            Backspace.Margin = new Padding(2);
            Backspace.Name = "Backspace";
            Backspace.Size = new Size(90, 38);
            Backspace.TabIndex = 4;
            Backspace.Text = "⌫";
            Backspace.UseVisualStyleBackColor = false;
            Backspace.Click += Backspace_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Green;
            button1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(64, 162);
            button1.Name = "button1";
            button1.Size = new Size(56, 56);
            button1.TabIndex = 5;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.Green;
            button2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(178, 162);
            button2.Name = "button2";
            button2.Size = new Size(56, 56);
            button2.TabIndex = 6;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.BackColor = Color.Green;
            button3.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(283, 163);
            button3.Name = "button3";
            button3.Size = new Size(56, 56);
            button3.TabIndex = 7;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.None;
            button4.BackColor = Color.Green;
            button4.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(66, 224);
            button4.Name = "button4";
            button4.Size = new Size(56, 56);
            button4.TabIndex = 8;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.None;
            button5.BackColor = Color.Green;
            button5.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Location = new Point(178, 224);
            button5.Name = "button5";
            button5.Size = new Size(56, 56);
            button5.TabIndex = 9;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.None;
            button6.BackColor = Color.Green;
            button6.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            button6.ForeColor = Color.White;
            button6.Location = new Point(283, 226);
            button6.Name = "button6";
            button6.Size = new Size(56, 56);
            button6.TabIndex = 10;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.None;
            button7.BackColor = Color.Green;
            button7.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            button7.ForeColor = Color.White;
            button7.Location = new Point(66, 300);
            button7.Name = "button7";
            button7.Size = new Size(56, 56);
            button7.TabIndex = 11;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.None;
            button8.BackColor = Color.Green;
            button8.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            button8.ForeColor = Color.White;
            button8.Location = new Point(178, 300);
            button8.Name = "button8";
            button8.Size = new Size(56, 56);
            button8.TabIndex = 12;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.None;
            button9.BackColor = Color.Green;
            button9.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            button9.ForeColor = Color.White;
            button9.Location = new Point(283, 300);
            button9.Name = "button9";
            button9.Size = new Size(56, 56);
            button9.TabIndex = 13;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button0
            // 
            button0.Anchor = AnchorStyles.None;
            button0.BackColor = Color.Green;
            button0.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            button0.ForeColor = Color.White;
            button0.Location = new Point(178, 368);
            button0.Name = "button0";
            button0.Size = new Size(56, 56);
            button0.TabIndex = 14;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = false;
            button0.Click += button0_Click;
            // 
            // PinForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(640, 440);
            Controls.Add(button0);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Backspace);
            Controls.Add(Exit);
            Controls.Add(Continue);
            Controls.Add(text);
            ForeColor = Color.White;
            Margin = new Padding(2);
            Name = "PinForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PinForm";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox text;
        private Button Continue;
        private Button Exit;
        private Button Backspace;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button0;
    }
}