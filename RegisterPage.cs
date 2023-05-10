using Gestion_Commandes.DSTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Gestion_Commandes
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        UsersTableAdapter adapter = new UsersTableAdapter();

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ShopyBase;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Users(name,email,password) values(@name,@email,@password)", conn);
            cmd.Parameters.AddWithValue("@name", txtUserName.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@password", txtPwd.Text);
            conn.Close();
            
            //adapter.Insert(,txtUserName.Text, txtEmail.Text, txtPwd.Text,null);

            this.Hide();
            LoginPage loginPgae = new LoginPage();
            loginPgae.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage lp= new LoginPage();
            lp.Show();
        }
    }
}
