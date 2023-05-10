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
using System.Xml.Linq;

namespace Gestion_Commandes
{
    public partial class OrderPage : Form
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        OrdersTableAdapter adapter = new OrdersTableAdapter();

        private void loginOutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage lp = new LoginPage();
            lp.Show();
        }

        private void SaveClientBtn_Click(object sender, EventArgs e)
        {
            adapter.Insert(int.Parse(txtIdOrder.Text), int.Parse(txtIdClient.Text),DateTime.Parse(txtDate.Text));
            grd.DataSource = adapter.GetData();
            txtIdOrder.Text = "";
            txtIdClient.Text = "";
            txtDate.Text = "";
        }

        private void ShowClientBtn_Click(object sender, EventArgs e)
        {
            grd.DataSource = adapter.GetData();
        }

        private void DelClientBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ShopyBase;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete Orders where Id=@Id ", conn);
            cmd.Parameters.AddWithValue("@Id", int.Parse(txtIdOrder.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            txtIdOrder.Text = "";
            grd.DataSource = adapter.GetData();
        }

        private void UpdClientBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ShopyBase;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Orders set Id=@Id, Client_id=@client_id, Date=@date  where Id=@Id ", conn);
            cmd.Parameters.AddWithValue("@Id", int.Parse(txtIdOrder.Text));
            cmd.Parameters.AddWithValue("@Client_id", txtIdClient.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(txtDate.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            grd.DataSource = adapter.GetData();
        }

        private void dashboard_Paint(object sender, PaintEventArgs e)
        {

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
            PurchasePage pp =new PurchasePage();
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
