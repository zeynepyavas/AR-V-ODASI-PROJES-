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
    public partial class DOSYALAR : Form
    {
        public DOSYALAR()
        {
            InitializeComponent();
        }
        sql_baglanti baglanti = new sql_baglanti();

        void verilerigoster(string veriler)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti.baglanti());
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_dkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into DOSYA (DOSYA_AD , KLASÖR_ID,RAF_ID,Bölüm_ID, Oda_ID) values (@p1,@p2,@p3,@p4,@p5)", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_dad.Text);
            komut.Parameters.AddWithValue("@p2", comboBox_KAD.SelectedValue);
            komut.Parameters.AddWithValue("@p3", comboBox_RAD.SelectedValue);
            komut.Parameters.AddWithValue("@p4",comboBox_BAD.SelectedValue);
            komut.Parameters.AddWithValue("@p5", comboBox_OAD.SelectedValue);

            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Kaydedildi");
            verilerigoster("SELECT Dosya_ID,Dosya_AD,Klasör_AD,Raf_AD,Bölüm_AD,Oda_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID INNER JOIN DOSYA ON KLASÖR.Klasör_ID=DOSYA.Klasör_ID");
        }

      

        private void btn_dsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from DOSYA where DOSYA_ID=@p1", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_dıd.Text);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Silindi");
            verilerigoster("SELECT Dosya_ID,Dosya_AD,Klasör_AD,Raf_AD,Bölüm_AD,Oda_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID INNER JOIN DOSYA ON KLASÖR.Klasör_ID=DOSYA.Klasör_ID");
        }

        private void btn_dgüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update DOSYA set DOSYA_AD=@p1 where DOSYA_ID=@p2", baglanti.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox_dad.Text);
            komut.Parameters.AddWithValue("@p2", textBox_dıd.Text);
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Güncellendi");
            verilerigoster("SELECT Dosya_ID,Dosya_AD,Klasör_AD,Raf_AD,Bölüm_AD,Oda_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID INNER JOIN DOSYA ON KLASÖR.Klasör_ID=DOSYA.Klasör_ID");
        }

        private void textBox_dara_TextChanged(object sender, EventArgs e)
        {
            verilerigoster("SELECT Dosya_ID,Dosya_AD,Klasör_AD,Raf_AD,Bölüm_AD,Oda_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID INNER JOIN DOSYA ON KLASÖR.Klasör_ID=DOSYA.Klasör_ID where DOSYA_AD like '%" + textBox_dara.Text + "%'");
        }

       

        private void comboBox_BAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = comboBox_BAD.SelectedValue.ToString();
            SqlCommand komut = new SqlCommand("select * from RAF Where Bölüm_ID=" + label8.Text, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_RAD.ValueMember = "RAF_ID";
            comboBox_RAD.DisplayMember = "RAF_AD";
            comboBox_RAD.DataSource = dt;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                textBox_dıd.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_dad.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox_OAD.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox_BAD.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox_RAD.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox_KAD.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            
            
        }

        private void DOSYALAR_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from ODA", baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_OAD.ValueMember = "Oda_ID";
            comboBox_OAD.DisplayMember = "Oda_AD";
            comboBox_OAD.DataSource = dt;
            verilerigoster("SELECT Dosya_ID,Dosya_AD,Klasör_AD,Raf_AD,Bölüm_AD,Oda_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID INNER JOIN DOSYA ON KLASÖR.Klasör_ID=DOSYA.Klasör_ID");
        }

        private void comboBox_OAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text=comboBox_OAD.SelectedValue.ToString();  
            SqlCommand komut = new SqlCommand("select * from BÖLÜM Where ODA_ID="+label8.Text, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_BAD.ValueMember = "BÖLÜM_ID";
            comboBox_BAD.DisplayMember = "BÖLÜM_AD";
            comboBox_BAD.DataSource = dt;

            
        }

      

        private void comboBox_RAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = comboBox_RAD.SelectedValue.ToString();
            SqlCommand komut = new SqlCommand("select * from KLASÖR Where RAF_ID=" + label8.Text, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_KAD.ValueMember = "KLASÖR_ID";
            comboBox_KAD.DisplayMember = "KLASÖR_AD";
            comboBox_KAD.DataSource = dt;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Arşiv_Odası fr = new Arşiv_Odası();
            fr.Show();
            this.Hide();
        }
    }
}
