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

namespace Gestion_Commandes
{
    public partial class ItemPage : Form
    {
        public ItemPage()
        {
            InitializeComponent();
        }

        ItemsTableAdapter adapter = new ItemsTableAdapter();

        private void loginOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage lp = new LoginPage();
            lp.Show();
        }

        private void SaveClientBtn_Click(object sender, EventArgs e)
        {
            adapter.Insert(int.Parse(txtId.Text), txtName.Text, int.Parse(txtPrice.Text), int.Parse(txtStock.Text));
            grd.DataSource = adapter.GetData();
            txtId.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtStock.Text = "";
        }

        private void ShowClientBtn_Click(object sender, EventArgs e)
        {
            grd.DataSource = adapter.GetData();
        }

        private void DelClientBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ShopyBase;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete Items where Id=@Id ", conn);
            cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            txtId.Text = "";
            grd.DataSource = adapter.GetData();
        }

        private void UpdClientBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ShopyBase;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Items set Id=@Id, name=@name, price=@price,  stock=@stock where Id=@Id ", conn);
            cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@price", int.Parse(txtPrice.Text));
            cmd.Parameters.AddWithValue("@stock", int.Parse(txtStock.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            grd.DataSource = adapter.GetData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OrderPage op = new OrderPage();
            op.Show(); 
            this.Hide();
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
    }
}
