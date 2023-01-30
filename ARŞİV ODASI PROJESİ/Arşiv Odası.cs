using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARŞİV_ODASI_PROJESİ
{
    public partial class Arşiv_Odası : Form
    {
        public Arşiv_Odası()
        {
            InitializeComponent();
        }

        private void oDALARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ODALAR fr = new ODALAR();
            fr.Show();
            this.Hide();
        }

        private void bÖLÜMLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BÖLÜMLER fr = new BÖLÜMLER();
            fr.Show();
            this.Hide();
        }

        private void rAFLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RAF fr = new RAF();
            fr.Show();
            this.Hide();
        }

        private void kLASÖRLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KLASÖR fr = new KLASÖR();
            fr.Show();
            this.Hide();
        }

        private void dOSYALARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DOSYALAR fr = new DOSYALAR();
            fr.Show();
            this.Hide();
        }

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KAYDET fr = new KAYDET();
            fr.Show();
            this.Hide();
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SİL fr = new SİL();
            fr.Show();
            this.Hide();
        }

        private void gÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GÜNCELLE fr = new GÜNCELLE();
            fr.Show();
            this.Hide();
        }

        private void aRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ARA fr = new ARA();
            fr.Show();
            this.Hide();
        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz?","UYARI",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }           
        }
    }
}
