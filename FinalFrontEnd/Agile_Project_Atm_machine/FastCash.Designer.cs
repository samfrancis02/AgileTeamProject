namespace Agile_Project_Atm_machine
{
    partial class FastCash
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
            fourtyDollar = new Button();
            hundred = new Button();
            fiveHundred = new Button();
            OTHERAMOUNT = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.ForestGreen;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(236, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(159, 37);
            label1.TabIndex = 0;
            label1.Text = "FAST CASH";
            label1.Click += label1_Click;
            // 
            // fourtyDollar
            // 
            fourtyDollar.Anchor = AnchorStyles.None;
            fourtyDollar.BackColor = Color.ForestGreen;
            fourtyDollar.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fourtyDollar.ForeColor = Color.White;
            fourtyDollar.Location = new Point(59, 63);
            fourtyDollar.Margin = new Padding(2);
            fourtyDollar.Name = "fourtyDollar";
            fourtyDollar.Size = new Size(128, 47);
            fourtyDollar.TabIndex = 1;
            fourtyDollar.Text = "$40";
            fourtyDollar.UseVisualStyleBackColor = false;
            fourtyDollar.Click += fourtyDollar_Click;
            // 
            // hundred
            // 
            hundred.Anchor = AnchorStyles.None;
            hundred.BackColor = Color.ForestGreen;
            hundred.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hundred.ForeColor = Color.White;
            hundred.Location = new Point(59, 170);
            hundred.Margin = new Padding(2);
            hundred.Name = "hundred";
            hundred.Size = new Size(128, 47);
            hundred.TabIndex = 2;
            hundred.Text = "$100";
            hundred.UseVisualStyleBackColor = false;
            hundred.Click += hundred_Click;
            // 
            // fiveHundred
            // 
            fiveHundred.Anchor = AnchorStyles.None;
            fiveHundred.BackColor = Color.ForestGreen;
            fiveHundred.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fiveHundred.ForeColor = Color.White;
            fiveHundred.Location = new Point(424, 63);
            fiveHundred.Margin = new Padding(2);
            fiveHundred.Name = "fiveHundred";
            fiveHundred.Size = new Size(128, 47);
            fiveHundred.TabIndex = 3;
            fiveHundred.Text = "$500";
            fiveHundred.UseVisualStyleBackColor = false;
            fiveHundred.Click += fiveHundred_Click;
            // 
            // OTHERAMOUNT
            // 
            OTHERAMOUNT.Anchor = AnchorStyles.None;
            OTHERAMOUNT.BackColor = Color.ForestGreen;
            OTHERAMOUNT.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OTHERAMOUNT.ForeColor = Color.White;
            OTHERAMOUNT.Location = new Point(424, 161);
            OTHERAMOUNT.Margin = new Padding(2);
            OTHERAMOUNT.Name = "OTHERAMOUNT";
            OTHERAMOUNT.Size = new Size(154, 73);
            OTHERAMOUNT.TabIndex = 4;
            OTHERAMOUNT.Text = "OTHER AMOUNT";
            OTHERAMOUNT.UseVisualStyleBackColor = false;
            OTHERAMOUNT.Click += otherAmount_click;
            // 
            // FastCash
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(640, 360);
            Controls.Add(OTHERAMOUNT);
            Controls.Add(fiveHundred);
            Controls.Add(hundred);
            Controls.Add(fourtyDollar);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "FastCash";
            Text = "FastCash";
            WindowState = FormWindowState.Maximized;
            Load += FastCash_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button fourtyDollar;
        private Button hundred;
        private Button fiveHundred;
        private Button OTHERAMOUNT;
    }
}