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
    public partial class ARA : Form
    {
        public ARA()
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

        private void comboBox_OAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = comboBox_OAD.SelectedValue.ToString();
            SqlCommand komut = new SqlCommand("select * from BÖLÜM Where ODA_ID=" + label7.Text, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_BAD.ValueMember = "BÖLÜM_ID";
            comboBox_BAD.DisplayMember = "BÖLÜM_AD";
            comboBox_BAD.DataSource = dt;
        }

        private void ARA_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from ODA", baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_OAD.ValueMember = "Oda_ID";
            comboBox_OAD.DisplayMember = "Oda_AD";
            comboBox_OAD.DataSource = dt;
            verilerigoster("select EVRAK_ID,EVRAK_AD,DOSYA_AD,KLASÖR_AD,RAF_AD,BÖLÜM_AD,ODA_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID INNER JOIN DOSYA ON KLASÖR.Klasör_ID=DOSYA.Klasör_ID INNER JOIN EVRAK ON DOSYA.Dosya_ID=EVRAK.Dosya_ID");
        }

        private void comboBox_BAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = comboBox_BAD.SelectedValue.ToString();
            SqlCommand komut = new SqlCommand("select * from RAF Where Bölüm_ID=" + label7.Text, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_RAD.ValueMember = "RAF_ID";
            comboBox_RAD.DisplayMember = "RAF_AD";
            comboBox_RAD.DataSource = dt;
        }

        private void comboBox_RAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = comboBox_RAD.SelectedValue.ToString();
            SqlCommand komut = new SqlCommand("select * from KLASÖR Where RAF_ID=" + label7.Text, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_KAD.ValueMember = "KLASÖR_ID";
            comboBox_KAD.DisplayMember = "KLASÖR_AD";
            comboBox_KAD.DataSource = dt;
        }

        private void comboBox_KAD_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = comboBox_KAD.SelectedValue.ToString();
            SqlCommand komut = new SqlCommand("select * from DOSYA Where KLASÖR_ID=" + label7.Text, baglanti.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox_DAD.ValueMember = "DOSYA_ID";
            comboBox_DAD.DisplayMember = "DOSYA_AD";
            comboBox_DAD.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textbox_evrakid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox_evrak.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox_DAD.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox_KAD.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox_RAD.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox_BAD.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                comboBox_OAD.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //verilerigoster("select EVRAK_ID,EVRAK_AD,DOSYA_AD,KLASÖR_AD,RAF_AD,BÖLÜM_AD,ODA_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID INNER JOIN DOSYA ON KLASÖR.Klasör_ID=DOSYA.Klasör_ID INNER JOIN EVRAK ON DOSYA.Dosya_ID=EVRAK.Dosya_ID where Evrak_AD like '%"+textBox_evrak.Text+"%'");
        }

        private void textBox_evrak_TextChanged(object sender, EventArgs e)
        {
            verilerigoster("select EVRAK_ID,EVRAK_AD,DOSYA_AD,KLASÖR_AD,RAF_AD,BÖLÜM_AD,ODA_AD FROM ODA INNER JOIN BÖLÜM ON ODA.Oda_ID=BÖLÜM.Oda_ID INNER JOIN RAF ON BÖLÜM.Bölüm_ID=RAF.Bölüm_ID INNER JOIN KLASÖR ON RAF.Raf_ID=KLASÖR.Raf_ID INNER JOIN DOSYA ON KLASÖR.Klasör_ID=DOSYA.Klasör_ID INNER JOIN EVRAK ON DOSYA.Dosya_ID=EVRAK.Dosya_ID where Evrak_AD like '%" + textBox_evrak.Text + "%'");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Arşiv_Odası fr = new Arşiv_Odası();
            fr.Show();
            this.Hide();
        }
    }
}
