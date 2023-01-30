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
    public partial class BÖLÜMLER : Form
    {
        public BÖLÜMLER()
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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into BÖLÜM (BÖLÜM_AD,ODA_ID) values (@p1,@P2)", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_bad.Text);
            komut.Parameters.AddWithValue("@p2", comboBox_AD.SelectedValue);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Kaydedildi");
            verilerigoster("SELECT Bölüm_ID AS 'Bölüm ID',Bölüm_AD AS 'Bölüm AD',Oda_AD AS 'Oda AD' FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID");
        }
        private void BÖLÜMLER_Load(object sender, EventArgs e)
        {
            verilerigoster("SELECT Bölüm_ID AS 'Bölüm ID',Bölüm_AD AS 'Bölüm AD',Oda_AD AS 'Oda AD' FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from BÖLÜM where BÖLÜM_ID=@p1", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_bıd.Text);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Silindi");
            verilerigoster("SELECT Bölüm_ID AS 'Bölüm ID',Bölüm_AD AS 'Bölüm AD',Oda_AD AS 'Oda AD' FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update BÖLÜM set BÖLÜM_AD=@p1 where BÖLÜM_ID=@p2", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_bad.Text);
            komut.Parameters.AddWithValue("@p2", textBox_bıd.Text);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Oda Adı Güncellendi");
            verilerigoster("SELECT Bölüm_ID AS 'Bölüm ID',Bölüm_AD AS 'Bölüm AD',Oda_AD AS 'Oda AD' FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID");
        }

        private void BÖLÜMLER_Load_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from ODA",baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_AD.ValueMember = "Oda_ID";
            comboBox_AD.DisplayMember = "Oda_AD";
            comboBox_AD.DataSource = dt;
            verilerigoster("SELECT Bölüm_ID AS 'Bölüm ID',Bölüm_AD AS 'Bölüm AD',Oda_AD AS 'Oda AD' FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox_bara_TextChanged(object sender, EventArgs e)
        {
            verilerigoster("SELECT Bölüm_ID AS 'Bölüm ID',Bölüm_AD AS 'Bölüm AD',Oda_AD AS 'Oda AD' FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID where BÖLÜM_AD like '%" + textBox_bara.Text + "%'");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox_bıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_bad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox_AD.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Arşiv_Odası fr = new Arşiv_Odası();
            fr.Show();
            this.Hide();
        }
    }
}
