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
    public partial class takeMoneyAndReceipt : Form
    {
        int amount;
        public takeMoneyAndReceipt()
        {
            InitializeComponent();
        }
        public takeMoneyAndReceipt(int amount)
        {
            this.amount = amount;
            InitializeComponent();

        }

        public int getAmount()
        {
            return amount;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Confirm_Shown(object sender, EventArgs e)
        {
            label1.Text = $"Successfully {amount} pounds withdrawn. Please take your money and your receipt.";
        }
        private void takeMoneyAndReceipt_Click(object sender, EventArgs e)
        {
            askAnyOtherAction askAnyOtherAction = new askAnyOtherAction();
            askAnyOtherAction.Show();
            this.Close();
        }

        private void Confirm_Load(object sender, EventArgs e)
        {

        }
    }
}
