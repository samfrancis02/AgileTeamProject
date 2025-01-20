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
            fashCashText = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(295, 23);
            label1.Name = "label1";
            label1.Size = new Size(190, 45);
            label1.TabIndex = 0;
            label1.Text = "FAST CASH";
            label1.Click += label1_Click;
            // 
            // fourtyDollar
            // 
            fourtyDollar.BackColor = Color.FromArgb(0, 192, 0);
            fourtyDollar.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fourtyDollar.ForeColor = Color.White;
            fourtyDollar.Location = new Point(74, 79);
            fourtyDollar.Name = "fourtyDollar";
            fourtyDollar.Size = new Size(160, 59);
            fourtyDollar.TabIndex = 1;
            fourtyDollar.Text = "$40";
            fourtyDollar.UseVisualStyleBackColor = false;
            fourtyDollar.Click += fourtyDollar_Click;
            // 
            // hundred
            // 
            hundred.BackColor = Color.FromArgb(0, 192, 0);
            hundred.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hundred.ForeColor = Color.White;
            hundred.Location = new Point(74, 212);
            hundred.Name = "hundred";
            hundred.Size = new Size(160, 59);
            hundred.TabIndex = 2;
            hundred.Text = "$100";
            hundred.UseVisualStyleBackColor = false;
            hundred.Click += hundred_Click;
            // 
            // fiveHundred
            // 
            fiveHundred.BackColor = Color.FromArgb(0, 192, 0);
            fiveHundred.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fiveHundred.ForeColor = Color.White;
            fiveHundred.Location = new Point(530, 79);
            fiveHundred.Name = "fiveHundred";
            fiveHundred.Size = new Size(160, 59);
            fiveHundred.TabIndex = 3;
            fiveHundred.Text = "$500";
            fiveHundred.UseVisualStyleBackColor = false;
            fiveHundred.Click += fiveHundred_Click;
            // 
            // OTHERAMOUNT
            // 
            OTHERAMOUNT.BackColor = Color.FromArgb(0, 192, 0);
            OTHERAMOUNT.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OTHERAMOUNT.ForeColor = Color.White;
            OTHERAMOUNT.Location = new Point(530, 201);
            OTHERAMOUNT.Name = "OTHERAMOUNT";
            OTHERAMOUNT.Size = new Size(160, 91);
            OTHERAMOUNT.TabIndex = 4;
            OTHERAMOUNT.Text = "OTHER AMOUNT";
            OTHERAMOUNT.UseVisualStyleBackColor = false;
            // 
            // fashCashText
            // 
            fashCashText.Location = new Point(243, 158);
            fashCashText.Name = "fashCashText";
            fashCashText.Size = new Size(272, 31);
            fashCashText.TabIndex = 5;
            // 
            // FastCash
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(fashCashText);
            Controls.Add(OTHERAMOUNT);
            Controls.Add(fiveHundred);
            Controls.Add(hundred);
            Controls.Add(fourtyDollar);
            Controls.Add(label1);
            Name = "FastCash";
            Text = "FastCash";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button fourtyDollar;
        private Button hundred;
        private Button fiveHundred;
        private Button OTHERAMOUNT;
        private TextBox fashCashText;
    }
}