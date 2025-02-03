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
    public partial class viewOrPrintBalance : Form
    {
        public viewOrPrintBalance()
        {
            InitializeComponent();
        }

        private void View_Click(object sender, EventArgs e)
        {
            balanceViewcs balanceViewcs = new balanceViewcs();
            balanceViewcs.Show();
            this.Close();
        }

        private void Receipt_Click(object sender, EventArgs e)
        {
            balancePrint balancePrint = new balancePrint();
            balancePrint.Show();
            this.Close();
        }
    }
}
