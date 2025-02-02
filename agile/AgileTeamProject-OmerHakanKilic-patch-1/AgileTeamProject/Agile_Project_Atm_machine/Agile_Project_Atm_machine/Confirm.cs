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
    public partial class Confirm : Form
    {
        int amount;
        public Confirm()
        {
            InitializeComponent();
        }
        public Confirm(int amount)
        {
            this.amount = amount;
            InitializeComponent();

        }

        public int getAmount()
        {
            return amount;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Confirm_Shown(object sender, EventArgs e)
        {
            label1.Text = $"Successfully {amount} pounds withdrawn. Please take your money and your receipt.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Confirm_Load(object sender, EventArgs e)
        {

        }
    }
}
