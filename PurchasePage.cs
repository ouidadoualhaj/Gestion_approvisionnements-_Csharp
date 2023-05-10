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
    public partial class PurchasePage : Form
    {
        public PurchasePage()
        {
            InitializeComponent();
        }

        PurchasesTableAdapter adapter = new PurchasesTableAdapter();

        private void PurchasePage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage lp = new LoginPage();
            lp.ShowDialog();
        }

        private void SaveClientBtn_Click(object sender, EventArgs e)
        {
            adapter.Insert(int.Parse(txtIdPurch.Text), int.Parse(txtIdFour.Text), DateTime.Parse(txtDate.Text));
            grd.DataSource = adapter.GetData();
            txtIdPurch.Text = "";
            txtIdFour.Text = "";
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
            SqlCommand cmd = new SqlCommand("delete Purchases where Id=@Id ", conn);
            cmd.Parameters.AddWithValue("@Id", int.Parse(txtIdPurch.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            txtIdPurch.Text = "";
            grd.DataSource = adapter.GetData();
        }

        private void UpdClientBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=.;Database=ShopyBase;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Orders set Id=@Id, four_id=@four_id, date=@date  where Id=@Id ", conn);
            cmd.Parameters.AddWithValue("@Id", int.Parse(txtIdPurch.Text));
            cmd.Parameters.AddWithValue("@four_id", int.Parse(txtIdFour.Text));
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(txtDate.Text));
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
            ClientPage clientPage = new ClientPage();
            clientPage.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ItemPage itemPage = new ItemPage();
            itemPage.Show();
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
            LoginPage lp=new LoginPage();   
            lp.Show();
            this.Hide();
        }
    }
}
