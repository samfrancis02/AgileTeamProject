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
    public partial class AccountSelection : Form
    {
        public AccountSelection()
        {
            InitializeComponent();
        }

        private void MAINMENU_Click(object sender, EventArgs e)
        {
            TransactionMenu transactionMenu = new TransactionMenu();
            transactionMenu.Show();
            this.Close();
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            transactionCancelled transactionCancelled=new transactionCancelled();
            transactionCancelled.Show();
            this.Close();
        }

        private void SAVINGS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are now on savings account");
            FastCash fastCash = new FastCash();
            fastCash.Show(this);
            this.Hide();

        }

        private void CHECKING_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are now on checking account");
            FastCash fastCash = new FastCash();
            fastCash.Show(this);
            this.Hide();
        }

        private void CREDIT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are now on credit account");
            FastCash fastCash = new FastCash();
            fastCash.Show(this);
            this.Hide();
        }

        private void LOANS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are now on loan account");
            FastCash fastCash = new FastCash();
            fastCash.Show(this);
            this.Hide();
        }

        private void AccountSelection_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
