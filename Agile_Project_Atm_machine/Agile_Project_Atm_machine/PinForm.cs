using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Agile_Project_Atm_machine
{
    public partial class PinForm : Form
    {
        public PinForm()
        {
            InitializeComponent();
        }

        private void text_TextChanged(object sender, EventArgs e)
        {

        }

        private void Continue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text.Text))
            {
                MessageBox.Show("Please enter your PIN.");
                return;
            }

            if (text.Text.Trim() == "1234")
            {
                MessageBox.Show("PIN ACCEPTED");
                TransactionMenu transactionMenu = new TransactionMenu();
                transactionMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid PIN. Please try again.");
            }
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
    }
}
