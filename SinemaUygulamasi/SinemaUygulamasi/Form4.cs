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
using System.Security.Cryptography;

namespace SinemaUygulamasi
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=YASIN;Initial Catalog=SINEMA;Integrated Security=True");


        public string hashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "");
            }
        }

        public void signUp()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO USERS_ (KullaniciAdi,Email,Sifre) VALUES(@KullaniciAdi,@Email,@Sifre)", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@Email", textBox2.Text);
            string password = textBox3.Text;
            cmd.Parameters.AddWithValue("@Sifre", hashPassword(password));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt Başarılı.");
            this.Hide();
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

     

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            signUp();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
            textBox3.UseSystemPasswordChar = true;
        }
    }
}
