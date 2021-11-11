using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Proqrami
{
    public partial class filmekle : Form
    {
        public filmekle()
        {
            InitializeComponent();
        }

        private void filmekle_Load(object sender, EventArgs e)
        {

        }

        private void btnsekilsec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
        }

        sinemaTableAdapters.film_bilgileriTableAdapter film = new sinemaTableAdapters.film_bilgileriTableAdapter();
        private void btnfilmekle_Click(object sender, EventArgs e)
        {
            try
            {
                film.filmekleme(txtfilmadi.Text, txtyonetmen.Text, cmbfilmturu.Text, txtsure.Text, dateTimePicker1.Text, txtyapimyil.Text, pictureBox2.ImageLocation);
                MessageBox.Show("Film ELave Olundu","Qeyd");
            }
            catch (Exception)
            {

                MessageBox.Show("Bu Film Daha Evvel Elave Olunub","Bildiris");
            }
          
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                cmbfilmturu.Text = "";
            }
        }
    }
}
