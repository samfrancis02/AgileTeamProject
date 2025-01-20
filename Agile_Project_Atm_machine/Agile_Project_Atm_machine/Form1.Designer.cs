namespace Agile_Project_Atm_machine
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Insert_Button = new Button();
            SuspendLayout();
            // 
            // Insert_Button
            // 
            Insert_Button.BackColor = Color.Green;
            Insert_Button.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Insert_Button.ForeColor = Color.White;
            Insert_Button.Location = new Point(175, 76);
            Insert_Button.Name = "Insert_Button";
            Insert_Button.Size = new Size(319, 63);
            Insert_Button.TabIndex = 0;
            Insert_Button.Text = "INSERT A CARD";
            Insert_Button.UseVisualStyleBackColor = false;
            Insert_Button.Click += Insert_Button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Insert_Button);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button Insert_Button;
    }
}
