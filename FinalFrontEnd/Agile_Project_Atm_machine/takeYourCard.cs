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
    public partial class takeYourCard : Form
    {
        public takeYourCard()
        {
            InitializeComponent();
        }

        private void takeYourCard_Click(object sender, EventArgs e)
        {
            thankYou thankYou = new thankYou();
            thankYou.Show();
            this.Close();
        }
    }
}
