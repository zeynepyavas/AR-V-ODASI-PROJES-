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
    public partial class ODALAR : Form
    {
        public ODALAR()
        {
            InitializeComponent();
        }

        sql_baglanti baglanti=new sql_baglanti();

        void verilerigoster(string veriler)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(veriler,baglanti.baglanti());
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }


        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into ODA (Oda_AD) values (@p1)",baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_ad.Text);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Oda Adı Kaydedildi");
            verilerigoster("select * from ODA");
        }

        private void ODALAR_Load(object sender, EventArgs e)
        {
            verilerigoster("select * from ODA");
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from ODA where Oda_ID=@p1", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_ıd.Text);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Oda Adı silindi");
            verilerigoster("select * from ODA");

        }

        private void btn_güncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update ODA set Oda_AD=@p1 where Oda_ID=@p2", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_ad.Text);
            komut.Parameters.AddWithValue("@p2", textBox_ıd.Text);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Oda Adı Güncellendi");
            verilerigoster("select * from ODA");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_ıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox_ad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void textBox_oara_TextChanged(object sender, EventArgs e)
        {
            verilerigoster("select * from ODA where Oda_AD like '%"+textBox_oara.Text+"%'");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Arşiv_Odası fr = new Arşiv_Odası();
            fr.Show();
            this.Hide();
        }
    }
}
