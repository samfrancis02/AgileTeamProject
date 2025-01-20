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
    public partial class FastCash : Form
    {
        public FastCash()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fourtyDollar_Click(object sender, EventArgs e)
        {
            int balance = 1000;

            int amount;
            if (int.TryParse(fashCashText.Text, out amount))
            {
                // Parsing successful, now you can use the amount as an integer
                MessageBox.Show($"Amount entered: {amount}");
                fashCashText.Text = amount.ToString();
                Confirm confirm = new Confirm();
                confirm.Show();
                this.Hide();
            }
            else
            {
                // Handle the case where parsing fails
                MessageBox.Show("Invalid amount entered. Please enter a valid number.", "Error");
            }
        }

        private void fiveHundred_Click(object sender, EventArgs e)
        {
            int balance = 1000;

            int amount;
            if (int.TryParse(fashCashText.Text, out amount))
            {
                // Parsing successful, now you can use the amount as an integer
                MessageBox.Show($"Amount entered: {amount}");
                fashCashText.Text = amount.ToString();
                Confirm confirm = new Confirm();
                confirm.Show();
                this.Hide();
            }
            else
            {
                // Handle the case where parsing fails
                MessageBox.Show("Invalid amount entered. Please enter a valid number.", "Error");
            }
        }

        private void hundred_Click(object sender, EventArgs e)
        {
            int balance = 1000;

            int amount;
            if (int.TryParse(fashCashText.Text, out amount))
            {
                // Parsing successful, now you can use the amount as an integer
                MessageBox.Show($"Amount entered: {amount}");
                fashCashText.Text = amount.ToString();
                Confirm confirm = new Confirm();
                confirm.Show();
                this.Hide();
            }
            else
            {
                // Handle the case where parsing fails
                MessageBox.Show("Invalid amount entered. Please enter a valid number.", "Error");
            }
        }
    }
}