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
    public partial class NoReceipt : Form
    {
        int amount;
        public NoReceipt()
        {
            InitializeComponent();

        }

        public NoReceipt(int amount)
        {
            this.amount = amount;
            InitializeComponent();
            this.Shown += Confirm_Shown;

        }


        private void NoReceipt_Load(object sender, EventArgs e)
        {

        }

        private void Confirm_Shown(object sender, EventArgs e)
        {
            label1.Text = $"Successfully {amount} pounds withdrawn. Please take your money";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
