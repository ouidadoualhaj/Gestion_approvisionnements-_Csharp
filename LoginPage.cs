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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }


        private void loginBtn_Click(object sender, EventArgs e)
        { 
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ShopyBase;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Users where email=@email AND password=@password", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@email",txtEmail.Text);
            cmd.Parameters.AddWithValue("@password", txtPwd.Text);
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                rd.Read();
                if(rd[4].ToString() == "Padmin")
                {
                    this.Hide();
                    HomePage home = new HomePage();
                    home.Show();
                }
                else if(rd[4].ToString() == "Sadmin")
                {
                    this.Hide();
                    HomePage home = new HomePage();
                    home.Show();
                }               
            }
            else
            {
                MessageBox.Show("email or password is incorrect !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterPage rp= new RegisterPage();
            rp.Show();
            this.Hide();
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
