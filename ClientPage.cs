using Gestion_Commandes.DSTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Gestion_Commandes
{
    public partial class ClientPage : Form
    {
        public ClientPage()
        {
            InitializeComponent();
        }

        ClientsTableAdapter adapter = new ClientsTableAdapter();


        private void SaveClientBtn_Click(object sender, EventArgs e)
        {
            adapter.Insert(int.Parse(txtCodeClient.Text), txtName.Text, int.Parse(txtPhone.Text));
            grd.DataSource = adapter.GetData();
            txtCodeClient.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
        }

        private void ShowClientBtn_Click(object sender, EventArgs e)
        {
            grd.DataSource= adapter.GetData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void DelClientBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ShopyBase;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete Clients where Id=@Id ", conn);
            cmd.Parameters.AddWithValue("@Id", int.Parse(txtCodeClient.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            txtCodeClient.Text = "";
            grd.DataSource = adapter.GetData();
        }

        private void UpdClientBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ShopyBase;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Clients set Id=@Id, name=@name, phone=@phone where Id=@Id ", conn);
            cmd.Parameters.AddWithValue("@Id", int.Parse(txtCodeClient.Text));
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@phone", int.Parse(txtPhone.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            grd.DataSource = adapter.GetData();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OrderPage op = new OrderPage();
            op.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage lp = new LoginPage();
            lp.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientPage cp = new ClientPage();
            cp.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            PurchasePage pp = new PurchasePage();
            pp.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
            this.Hide();
        }
    }
}
