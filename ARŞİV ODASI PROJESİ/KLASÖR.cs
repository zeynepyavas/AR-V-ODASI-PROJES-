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
    public partial class KLASÖR : Form
    {
        public KLASÖR()
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_kaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into KLASÖR (KLASÖR_AD,RAF_ID,Bölüm_ID, Oda_ID) values (@p1,@p2,@p3,@p4)", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_kad.Text);
            komut.Parameters.AddWithValue("@p2", comboBox_RAD.SelectedValue);
            komut.Parameters.AddWithValue("@p3", comboBox_BAD.SelectedValue);
            komut.Parameters.AddWithValue("@p4", comboBox_OAD.SelectedValue);

            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Kaydedildi");
            verilerigoster("SELECT Klasör_ID,Klasör_AD,Raf_AD,Bölüm_AD,Oda_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID");
        }

        private void button1_sil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from KLASÖR where KLASÖR_ID=@p1", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_kıd.Text);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Silindi");
            verilerigoster("SELECT Klasör_ID,Klasör_AD,Raf_AD,Bölüm_AD,Oda_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID");
        }

        private void button1_güncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update KLASÖR set KLASÖR_AD=@p1 where KLASÖR_ID=@p2", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_kad.Text);
            komut.Parameters.AddWithValue("@p2", textBox_kıd.Text);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Güncellendi");
            verilerigoster("SELECT Klasör_ID,Klasör_AD,Raf_AD,Bölüm_AD,Oda_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID");
        }

        private void comboBox_OAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = comboBox_OAD.SelectedValue.ToString();
            SqlCommand komut = new SqlCommand("select * from BÖLÜM WHERE Oda_ID=" + label7.Text, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_BAD.ValueMember = "Bölüm_ID";
            comboBox_BAD.DisplayMember = "Bölüm_AD";
            comboBox_BAD.DataSource = dt;
        }

        private void comboBox_BAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = comboBox_BAD.SelectedValue.ToString();
            SqlCommand komut = new SqlCommand("select * from RAF WHERE Bölüm_ID=" + label7.Text, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_RAD.ValueMember = "RAF_ID";
            comboBox_RAD.DisplayMember = "RAF_AD";
            comboBox_RAD.DataSource = dt;
        }

        private void KLASÖR_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from ODA", baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_OAD.ValueMember = "Oda_ID";
            comboBox_OAD.DisplayMember = "Oda_AD";
            comboBox_OAD.DataSource = dt;

            verilerigoster("SELECT Klasör_ID,Klasör_AD,Raf_AD,Bölüm_AD,Oda_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID");
        }

        private void comboBox_RAD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_kıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox_kad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox_OAD.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox_BAD.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox_RAD.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void textBox_kara_TextChanged(object sender, EventArgs e)
        {
            verilerigoster("SELECT Klasör_ID,Klasör_AD,Raf_AD,Bölüm_AD,Oda_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID where KLASÖR_AD like '%" + textBox_kara.Text + "%'");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Arşiv_Odası fr = new Arşiv_Odası();
            fr.Show();
            this.Hide();
        }
    }
}
