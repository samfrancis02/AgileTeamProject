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
    public partial class thankYou : Form
    {
        public thankYou()
        {
            InitializeComponent();
        }

        private void thankYou_Click(object sender, EventArgs e)
        {

            insertCard insertCard = new insertCard();
            insertCard.Show();
            this.Close();
        }
    }
}
