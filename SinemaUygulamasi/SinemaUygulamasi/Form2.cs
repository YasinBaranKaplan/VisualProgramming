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

namespace SinemaUygulamasi
{
    public partial class Form2 : Form
    {
        private string isimForm1;
        private string soyIisimForm1;
        private string telNoForm1;


        public Form2(string isimForm1, string soyIisimForm1, string telNoForm1)
        {
            InitializeComponent();
            this.isimForm1 = isimForm1;
            this.soyIisimForm1 = soyIisimForm1;
            this.telNoForm1 = telNoForm1;
        }

     

        SqlConnection connection = new SqlConnection(@"Data Source=YASIN;Initial Catalog=SINEMA;Integrated Security=True");

        public void sec()
        {
            SqlCommand scm = new SqlCommand("INSERT INTO ORDERS(MusteriAd,MusteriSoyad,TelNo,Film) VALUES(@MusteriAd,@MusteriSoyad,@TelNo,@Film)", connection);
            connection.Open();
            scm.Parameters.AddWithValue("@MusteriAd", this.isimForm1);
            scm.Parameters.AddWithValue("@MusteriSoyad", this.soyIisimForm1);
            scm.Parameters.AddWithValue("@Telno", this.telNoForm1);
            scm.Parameters.AddWithValue("@Film", comboBox1.Text);
            scm.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Bilet Satın Alınıştır.");
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            sec();
        }
       
    }
}
