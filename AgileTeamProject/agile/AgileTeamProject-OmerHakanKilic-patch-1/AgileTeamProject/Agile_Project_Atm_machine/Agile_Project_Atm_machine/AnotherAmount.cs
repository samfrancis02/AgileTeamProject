using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agile_Project_Atm_machine
{
    public partial class AnotherAmount : Form
    {
        public AnotherAmount()
        {
            InitializeComponent();
        }

        private void AnotherAmount_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "1";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "4";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "9";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "8";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (text.TextLength < 4) text.Text += "0";
        }

        private void Backspace_Click(object sender, EventArgs e)
        {
            if (text.Text.Length > 0)
            {
                // Remove the last character
                text.Text = text.Text.Substring(0, text.Text.Length - 1);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text.Text))
            {
                MessageBox.Show("Please enter the amount you want to withdraw.");
                return;
            }
            else 
            {
                AcceptAmount acceptAmount = new AcceptAmount(int.Parse(text.Text));
                acceptAmount.Show();
                this.Hide();
            }
        }
    }
}
