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
    public partial class RAF : Form
    {
        public RAF()
        {
            InitializeComponent();
        }
        sql_baglanti baglanti = new sql_baglanti();

        void verilerigoster(string veriler)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti.baglanti());
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button_kaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into RAF (RAF_AD,Bölüm_ID, Oda_ID) values (@p1,@p2,@p3)", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_rad.Text);
            komut.Parameters.AddWithValue("@p2", comboBox_BAD.SelectedValue);
            komut.Parameters.AddWithValue("@p3", comboBox_OAD.SelectedValue);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Kaydedildi");
            verilerigoster("select Raf_ID,Raf_AD,Bölüm_AD,Oda_AD from ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID");
        }
        private void BÖLÜMLER_Load(object sender, EventArgs e)
        {
            

        }


        private void button_sil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from RAF where Raf_ID=@p1", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_rıd.Text);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Silindi");
            verilerigoster("select Raf_ID,Raf_AD,Bölüm_AD,Oda_AD from ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID");
        }

        private void button_güncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update RAF set RAF_AD=@p1 where RAF_ID=@p2", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_rad.Text);
            komut.Parameters.AddWithValue("@p2", textBox_rıd.Text);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Güncellendi");
            verilerigoster("select Raf_ID,Raf_AD,Bölüm_AD,Oda_AD from ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID");
        }

        private void comboBox_OAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = comboBox_OAD.SelectedValue.ToString();
            SqlCommand komut = new SqlCommand("select * from BÖLÜM WHERE Oda_ID=" + label6.Text, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_BAD.ValueMember = "Bölüm_ID";
            comboBox_BAD.DisplayMember = "Bölüm_AD";
            comboBox_BAD.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_rıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox_rad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox_BAD.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox_OAD.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void RAF_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from ODA", baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_OAD.ValueMember = "Oda_ID";
            comboBox_OAD.DisplayMember = "Oda_AD";
            comboBox_OAD.DataSource = dt;

            verilerigoster("select Raf_ID,Raf_AD,Bölüm_AD,Oda_AD from ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID");
        }

        private void textBox_rara_TextChanged(object sender, EventArgs e)
        {
            verilerigoster("select Raf_ID,Raf_AD,Bölüm_AD,Oda_AD from ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID where RAF_AD like '%" + textBox_rara.Text + "%'");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Arşiv_Odası fr = new Arşiv_Odası();
            fr.Show();
            this.Hide();
        }
    }
}

