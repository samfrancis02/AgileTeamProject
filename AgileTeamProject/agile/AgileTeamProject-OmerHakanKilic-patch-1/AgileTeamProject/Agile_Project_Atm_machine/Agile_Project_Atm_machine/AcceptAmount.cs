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
    public partial class AcceptAmount : Form
    {
        int amount;
        public AcceptAmount(int amount)
        {
            this.amount = amount;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AcceptAmount_Shown(object sender, EventArgs e)
        {
            label2.Text = $"Are you sure you want to withdraw {amount} pounds?";
        }

        private void YES_Click(object sender, EventArgs e)
        {
            ReceiptQuestion receiptQuestion = new ReceiptQuestion(amount);
            receiptQuestion.Show();
            this.Hide();
        }

        private void NO_Click(object sender, EventArgs e)
        {
            FastCash fastCash = new FastCash();
            fastCash.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
