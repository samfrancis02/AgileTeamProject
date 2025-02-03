using System;
using System.Windows.Forms;

namespace Agile_Project_Atm_machine
{
    public partial class balanceAccountSelection : Form
    {
        public balanceAccountSelection()
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
            transactionCancelled transactionCancelled = new transactionCancelled();
            transactionCancelled.Show();
            this.Close();
        }

        private void SAVINGS_Click(object sender, EventArgs e)
        {
            OpenBalanceView();
        }

        private void CHECKING_Click(object sender, EventArgs e)
        {
            OpenBalanceView();
        }

        private void CREDIT_Click(object sender, EventArgs e)
        {
            OpenBalanceView();
        }

        private void LOANS_Click(object sender, EventArgs e)
        {
            OpenBalanceView();
        }

        private void OpenBalanceView()
        {
            viewOrPrintBalance viewOrPrintBalance = new viewOrPrintBalance();
            viewOrPrintBalance.Show();
            this.Hide();
        }
    }
}
