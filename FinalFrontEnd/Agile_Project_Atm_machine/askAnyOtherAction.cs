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
    public partial class askAnyOtherAction : Form
    {
        public askAnyOtherAction()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            PinForm pinForm = new PinForm();
            pinForm.Show();
            this.Close();
        }

        private void No_Click(object sender, EventArgs e)
        {
            takeYourCard takeYourCard = new takeYourCard();
            takeYourCard.Show();
            this.Close();
        }
    }
}
