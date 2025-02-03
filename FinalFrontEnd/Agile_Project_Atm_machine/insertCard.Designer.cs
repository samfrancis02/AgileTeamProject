namespace Agile_Project_Atm_machine
{
    partial class insertCard
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
            Insert_Button.Anchor = AnchorStyles.None;
            Insert_Button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Insert_Button.BackColor = Color.ForestGreen;
            Insert_Button.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Insert_Button.ForeColor = Color.White;
            Insert_Button.Location = new Point(134, 130);
            Insert_Button.Margin = new Padding(2);
            Insert_Button.Name = "Insert_Button";
            Insert_Button.Size = new Size(640, 51);
            Insert_Button.TabIndex = 0;
            Insert_Button.Text = "INSERT A CARD";
            Insert_Button.UseVisualStyleBackColor = false;
            Insert_Button.Click += Insert_Button_Click;
            // 
            // insertCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(910, 360);
            Controls.Add(Insert_Button);
            Margin = new Padding(2);
            Name = "insertCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Insert Card Page";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            Shown += insertCard_Shown;
            ResumeLayout(false);
        }

        #endregion

        private Button Insert_Button;
    }
}
