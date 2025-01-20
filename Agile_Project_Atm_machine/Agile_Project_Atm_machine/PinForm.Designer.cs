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
            label1 = new Label();
            text = new TextBox();
            Continue = new Button();
            Exit = new Button();
            Backspace = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Green;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(208, 26);
            label1.Name = "label1";
            label1.Size = new Size(367, 45);
            label1.TabIndex = 0;
            label1.Text = "ENTER A KEY OR A PIN";
            // 
            // text
            // 
            text.Location = new Point(244, 84);
            text.Name = "text";
            text.PasswordChar = '*';
            text.Size = new Size(270, 31);
            text.TabIndex = 1;
            text.TextChanged += text_TextChanged;
            // 
            // Continue
            // 
            Continue.BackColor = Color.Green;
            Continue.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Continue.ForeColor = Color.White;
            Continue.Location = new Point(288, 138);
            Continue.Name = "Continue";
            Continue.Size = new Size(193, 55);
            Continue.TabIndex = 2;
            Continue.Text = "Continue";
            Continue.UseVisualStyleBackColor = false;
            Continue.Click += Continue_Click;
            // 
            // Exit
            // 
            Exit.BackColor = Color.Green;
            Exit.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Exit.ForeColor = Color.White;
            Exit.Location = new Point(288, 199);
            Exit.Name = "Exit";
            Exit.Size = new Size(193, 48);
            Exit.TabIndex = 3;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = false;
            Exit.Click += Exit_Click;
            // 
            // Backspace
            // 
            Backspace.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Backspace.Location = new Point(558, 84);
            Backspace.Name = "Backspace";
            Backspace.Size = new Size(112, 48);
            Backspace.TabIndex = 4;
            Backspace.Text = "X";
            Backspace.UseVisualStyleBackColor = true;
            Backspace.Click += Backspace_Click;
            // 
            // PinForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Backspace);
            Controls.Add(Exit);
            Controls.Add(Continue);
            Controls.Add(text);
            Controls.Add(label1);
            Name = "PinForm";
            Text = "PinForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox text;
        private Button Continue;
        private Button Exit;
        private Button Backspace;
    }
}