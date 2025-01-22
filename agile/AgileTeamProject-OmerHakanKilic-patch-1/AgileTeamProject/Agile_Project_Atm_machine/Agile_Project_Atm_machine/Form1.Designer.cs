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
            groupBox1 = new GroupBox();
            SuspendLayout();
            // 
            // Insert_Button
            // 
            Insert_Button.Anchor = AnchorStyles.None;
            Insert_Button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Insert_Button.BackColor = Color.Green;
            Insert_Button.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Insert_Button.ForeColor = Color.White;
            Insert_Button.Location = new Point(167, 162);
            Insert_Button.Margin = new Padding(2);
            Insert_Button.Name = "Insert_Button";
            Insert_Button.Size = new Size(800, 64);
            Insert_Button.TabIndex = 0;
            Insert_Button.Text = "INSERT A CARD";
            Insert_Button.UseVisualStyleBackColor = false;
            Insert_Button.Click += Insert_Button_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Green;
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1137, 70);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(1137, 450);
            Controls.Add(groupBox1);
            Controls.Add(Insert_Button);
            Margin = new Padding(2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button Insert_Button;
        private GroupBox groupBox1;
    }
}
