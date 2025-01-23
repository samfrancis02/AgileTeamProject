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
    public partial class ReceiptQuestion : Form
    {
        private int amount;
        public ReceiptQuestion(int amount)
        {
            this.amount = amount;
            InitializeComponent();
        }

        private void YES_Click(object sender, EventArgs e)
        {
            Confirm confirm = new Confirm(amount);
            confirm.Show();
            this.Hide();
        }

        private void NO_Click(object sender, EventArgs e)
        {
            NoReceipt noReceipt = new NoReceipt(amount);
            noReceipt.Show(); this.Hide();

        }
    }
}
