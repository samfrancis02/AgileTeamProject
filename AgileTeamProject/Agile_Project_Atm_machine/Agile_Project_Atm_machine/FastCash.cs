﻿using System;
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
    public partial class FastCash : Form
    {
        public FastCash()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void fourtyDollar_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Amount entered: {40}");
            Confirm confirm = new Confirm(40);
            confirm.Show();
            this.Hide();

        }

        private void fiveHundred_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Amount entered: {500}");
            Confirm confirm = new Confirm(500);
            confirm.Show();
            this.Hide();
        }

        private void hundred_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Amount entered: {100}");
            Confirm confirm = new Confirm(100);
            confirm.Show();
            this.Hide();
        }

        private void otherAmount_click(object sender, EventArgs e)
        {
            //confirm.Show();
            //this.Hide();
        }

        private void FastCash_Load(object sender, EventArgs e)
        {

        }
    }
}