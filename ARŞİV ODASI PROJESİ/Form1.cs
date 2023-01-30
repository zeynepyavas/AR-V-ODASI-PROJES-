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

namespace ARŞİV_ODASI_PROJESİ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        sql_baglanti baglanti=new sql_baglanti();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Pink;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into KULLANICI(Kullanıcı_AD,Kullanıcı_SOYAD,Kullanıcı_SİFRE,Kullanıcı_SİFRETEKRAR) VALUES (@p1,@p2,@p3,@p4)", baglanti.baglanti());
            if (textBox_ad.Text == "" || textBox_soyad.Text == "" || textBox_sifre.Text == "" || textBox_sifretekrar.Text == "")
            {
                MessageBox.Show("Alanlar boş geçilemez");

            }
            else if (textBox_sifre.Text!=textBox_sifretekrar.Text)
            {
                MessageBox.Show("Şifreler aynı değil tekrar giriniz");
            }
            else
            {
                komut.Parameters.AddWithValue("@p1",textBox_ad.Text);
                komut.Parameters.AddWithValue("@p2", textBox_soyad.Text);
                komut.Parameters.AddWithValue("@p3", textBox_sifre.Text);
                komut.Parameters.AddWithValue("@p4", textBox_sifretekrar.Text);
                komut.ExecuteNonQuery();
                baglanti.baglanti().Close();
                MessageBox.Show("KAYIT OLUŞTURULDU");
                textBox_ad.Clear();
                textBox_soyad.Clear();
                textBox_sifre.Clear();
                textBox_sifretekrar.Clear();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from KULLANICI where Kullanıcı_AD=@p1 and Kullanıcı_SİFRE=@p2", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_adı.Text);
            komut.Parameters.AddWithValue("@p2", textBox_sifresi.Text);
            SqlDataReader oku = komut.ExecuteReader();

            if (oku.Read())
            {
                MessageBox.Show("Başarılı Giriş");
                Arşiv_Odası ars = new Arşiv_Odası();
                ars.Show();
                this.Hide();
            }
            else if(textBox_adı.Text==""|| textBox_sifresi.Text=="")
            {
                MessageBox.Show("Kullanıcı adı veya Şifre boş bırakılamaz tekrar deneyiniz","UYARI!!", MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya Şifre hatalı tekrar deneyiniz", "UYARI!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }




        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            DialogResult cıkıs = new DialogResult();
            cıkıs = MessageBox.Show("Programdan çıkmak istediğine emin misin?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cıkıs == DialogResult.Yes)
            {
                MessageBox.Show("Sistemden çıkış yapılıyor", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Arşiv_Odası fr = new Arşiv_Odası();
            fr.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
