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

namespace Sinema_Proqrami
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=sinema;Integrated Security=True");

        private void btncixis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int saygac = 0;
        private void Filmvesalongetir(ComboBox combo, string sql1, string sql2)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand(sql1, baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                combo.Items.Add(dr[sql2].ToString());
            }
            baglanti.Close();
        }

        private void Filmarsivigoster()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from film_bilgileri where filmadi = '" + cmbfilmadi.SelectedItem + "'", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                pictureBox1.ImageLocation = dr["resim"].ToString();
            }
            baglanti.Close();
        }

        private void yenidenrenglendir()
        {
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    item.BackColor = Color.White;
                }
            }
        }
        private void combodolukoltuklar()
        {
            cmbsalonlegv.Items.Clear();
            cmbsalonlegv.Text = "";
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    if (item.BackColor == Color.Red)
                    {
                        cmbsalonlegv.Items.Add(item.Text);
                    }
                }
            }
        }
        private void veritabanidolukoltuklar()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from satis_bilgileri where filmadi = '" + cmbfilmadi.SelectedItem + "' and salonadi = '" + cmbsalonadi.Text + "' and tarix = '" + cmbtarix.SelectedItem + "' and saat = '" + cmbseans.SelectedItem + "'", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (Control item in panel1.Controls)
                {
                    if (item is Button)
                    {
                        if (dr["koltukno"].ToString() == item.Text)
                        {
                            item.BackColor = Color.Red;
                        }
                    }
                }
            }
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Boskoltuklar();
            Filmvesalongetir(cmbfilmadi, "select * from film_bilgileri", "filmadi");
            Filmvesalongetir(cmbsalonadi, "select * from salon_bilgiler", "salonadi");
        }

        private void Boskoltuklar()
        {
            saygac = 1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(30, 30);
                    btn.Location = new Point(j * 30 + 30, i * 30 + 30);
                    btn.Name = saygac.ToString();
                    btn.Text = saygac.ToString();
                    btn.ForeColor = Color.Black;
                    btn.BackColor = Color.White;
                    if (j == 4)
                    {
                        continue;
                    }
                    saygac++;
                    this.panel1.Controls.Add(btn);
                    btn.Click += Btn_Click;

                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)

        {
            Button b = (Button)sender;
            if (b.BackColor == Color.White)
            {
                txtkoltukno.Text = b.Text;
            }
        }

        private void btnsalonekle_Click(object sender, EventArgs e)
        {
            frmsalonekle ekle = new frmsalonekle();
            ekle.Show();
            this.Hide();
        }

        private void btnfilmekle_Click(object sender, EventArgs e)
        {
            filmekle ekle = new filmekle();
            ekle.Show();
            this.Hide();
        }

        private void btnseansekle_Click(object sender, EventArgs e)
        {
            frmseansekle ekle = new frmseansekle();
            ekle.Show();
            this.Hide();
        }

        private void btnseanslistele_Click(object sender, EventArgs e)
        {
            frmseanslisteleme frm = new frmseanslisteleme();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmsatislisteleme frm = new frmsatislisteleme();
            frm.Show();
            this.Hide();
        }

        private void cmbfilmadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbseans.Items.Clear();
            cmbtarix.Items.Clear();
            cmbseans.Text = "";
            cmbtarix.Text = "";
            cmbsalonadi.Text = "";
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            Filmarsivigoster();
            yenidenrenglendir();
            combodolukoltuklar();
        }

        sinemaTableAdapters.satis_bilgileriTableAdapter satis = new sinemaTableAdapters.satis_bilgileriTableAdapter();
        private void btnbiletsat_Click(object sender, EventArgs e)
        {
            if (txtkoltukno.Text != "")
            {

                satis.satisyap(txtkoltukno.Text, cmbsalonadi.Text, cmbfilmadi.Text, cmbtarix.Text, cmbseans.Text, txtad.Text, txtsoyad.Text, cmbucret.Text, DateTime.Now.ToString());
                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
                yenidenrenglendir();
                veritabanidolukoltuklar();
                combodolukoltuklar();

            }
            else
            {
                MessageBox.Show("Koltuk Secimi Etmediniz", "Bildiris!");
            }
        }

        private void filmtarixgetir()
        {
            cmbtarix.Text = "";
            cmbseans.Text = "";
            cmbtarix.Items.Clear();
            cmbseans.Items.Clear();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from seans_bilgileri where filmadi = '" + cmbfilmadi.SelectedItem + "' and salonadi = '" + cmbsalonadi.SelectedItem + "'", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (DateTime.Parse(dr["tarix"].ToString()) >= DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    if (!cmbtarix.Items.Contains(dr["tarix"].ToString()))
                    {
                        cmbtarix.Items.Add(dr["tarix"].ToString());
                    }
                }

            }
            baglanti.Close();
        }
        private void cmbsalonadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            filmtarixgetir();
        }

        private void Filmseansigetir()
        {
            cmbseans.Text = "";
            cmbseans.Items.Clear();

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from seans_bilgileri where filmadi = '" + cmbfilmadi.SelectedItem + "' and salonadi = '" + cmbsalonadi.SelectedItem + "' and tarix = '" + cmbtarix.SelectedItem + "'", baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (DateTime.Parse(dr["tarix"].ToString()) == DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    if (DateTime.Parse(dr["seans"].ToString()) > DateTime.Parse(DateTime.Now.ToShortTimeString()))
                    {
                        cmbseans.Items.Add(dr["seans"].ToString());
                    }
                }
                else if (DateTime.Parse(dr["tarix"].ToString()) > DateTime.Parse(DateTime.Now.ToShortDateString()))
                {

                    cmbseans.Items.Add(dr["seans"].ToString());

                }
            }
            baglanti.Close();


        }
        private void cmbtarix_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filmseansigetir();
        }

        private void cmbseans_SelectedIndexChanged(object sender, EventArgs e)
        {
            yenidenrenglendir();
            veritabanidolukoltuklar();
            combodolukoltuklar();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            if (cmbsalonlegv.Text != "")
            {
  satis.satisiptal(cmbfilmadi.Text,cmbsalonadi.Text,cmbtarix.Text,cmbseans.Text,cmbsalonlegv.Text);
                yenidenrenglendir();
                veritabanidolukoltuklar();
                combodolukoltuklar();
            }
            else
            {
                MessageBox.Show("Koltuk Secimi Etmediniz","Bildiris");
            }
          
        }
    }
}
