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
    public partial class balancePrint : Form
    {
        public balancePrint()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void balancePrint_Click(object sender, EventArgs e)
        {
            askAnyOtherAction askAnyOtherAction = new askAnyOtherAction();
            askAnyOtherAction.Show();
            this.Close();
        }

        private void balancePrint_Load(object sender, EventArgs e)
        {

        }
    }
}
