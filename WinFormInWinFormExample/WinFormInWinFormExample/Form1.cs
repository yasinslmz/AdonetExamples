using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormInWinFormExample
{
    public partial class Form1 : Form
    {
        SqlConnection db = new SqlConnection(@"data source=DESKTOP-JU3J93J;initial catalog=SchoolDb;user id=sa;password=123456789");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginStatusLbl.Visible=false;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            db.Open();

            SqlCommand cmd = new SqlCommand("Login",db);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Email",SqlDbType.NVarChar,250).Value=EmailTxt.Text;
            cmd.Parameters.Add("Password",SqlDbType.NVarChar,50).Value=PasswordTxt.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show(dr["Name"]+ " " + dr["Surname"] +" Hoşgeldin\nGiriş Başarılı");
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }

            db.Close();
        }
    }
}
