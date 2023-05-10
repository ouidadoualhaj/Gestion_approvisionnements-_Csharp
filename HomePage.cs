﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Commandes
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ClientPage cp = new ClientPage();
            cp.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ItemPage ip = new ItemPage();
            ip.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PurchasePage pp = new PurchasePage();
            pp.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //HomePage homePage = new HomePage();
            //homePage.Show();
            //this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OrderPage op = new OrderPage();
            op.Show();
            this.Hide();
        }

    }
}
