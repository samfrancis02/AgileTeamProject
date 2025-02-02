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
    public partial class TransactionMenu : Form
    {
        public TransactionMenu()
        {
            InitializeComponent();
        }

        private void balance_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void withdrawal_Click(object sender, EventArgs e)
        {
            Acknowledgment acknowledgment = new Acknowledgment();
            acknowledgment.Show();
            this.Hide();
        }
    }
}
