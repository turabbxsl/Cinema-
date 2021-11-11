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
    public partial class frmseansekle : Form
    {
        public frmseansekle()
        {
            InitializeComponent();
        }

        string seans = "";
        private void Radiobuttonseciliyse()
        {
            if (radioButton1.Checked == true)
            {
                seans = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                seans = radioButton2.Text;
            }
            else if (radioButton3.Checked == true)
            {
                seans = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                seans = radioButton4.Text;
            }
            else if (radioButton5.Checked == true)
            {
                seans = radioButton5.Text;
            }
            else if (radioButton6.Checked == true)
            {
                seans = radioButton6.Text;
            }
            else if (radioButton7.Checked == true)
            {
                seans = radioButton7.Text;
            }
            else if (radioButton8.Checked == true)
            {
                seans = radioButton8.Text;
            }
            else if (radioButton9.Checked == true)
            {
                seans = radioButton9.Text;
            }
            else if (radioButton10.Checked == true)
            {
                seans = radioButton10.Text;
            }
            else if (radioButton11.Checked == true)
            {
                seans = radioButton11.Text;
            }
            else if (radioButton12.Checked == true)
            {
                seans = radioButton12.Text;
            }
          
        }

        sinemaTableAdapters.seans_bilgileriTableAdapter filmseansi = new sinemaTableAdapters.seans_bilgileriTableAdapter();
        
        private void btnekkle_Click(object sender, EventArgs e)
        {
            Radiobuttonseciliyse();
            if (seans != "")
            {          
                filmseansi.SeansEkleme(cmbfilm.Text, cmbsalon.Text, dateTimePicker1.Text, seans);
                MessageBox.Show("Seans Elave Etme Heyata Kecirildi","Qeyd");
            }
            else if (seans == "")
            {
                MessageBox.Show("Seans Secimi Etmediniz!!", "Qeyd");
            }
            cmbsalon.Text = "";
            cmbfilm.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=sinema;Integrated Security=True");

        private void frmseansekle_Load(object sender, EventArgs e)
        {
            Filmsalongoster(cmbfilm, "select * from film_bilgileri","filmadi");
            Filmsalongoster(cmbsalon, "select * from salon_bilgiler", "salonadi");
        }
        private void Filmsalongoster(ComboBox combo,string sql,string sql2)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand(sql,baglanti);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read[sql2].ToString());
            }
            baglanti.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control item1 in groupBox1.Controls)
            {
                item1.Enabled = true;
            }
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime yeni = DateTime.Parse(dateTimePicker1.Text);
            if (yeni == bugun)
            {
                foreach (Control item in groupBox1.Controls)
                {
                    if (DateTime.Parse(DateTime.Now.ToShortTimeString()) > DateTime.Parse(item.Text))
                    {
                        item.Enabled = false;
                    }
                }
                Tarixi_Karsilastir();
            }
            else if (yeni > bugun)
            {
                Tarixi_Karsilastir();
            }
            else if (yeni < bugun)
            {
                MessageBox.Show("Geriye Donus Prosesi Edile Bilmez!","Bildiris");
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void Tarixi_Karsilastir()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from seans_bilgileri where salonadi='" + cmbsalon.Text + "' and tarix = '" + dateTimePicker1.Text + "'", baglanti);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item2 in groupBox1.Controls)
                {
                    if (read["seans"].ToString() == item2.Text)
                    {
                        item2.Enabled = false;
                    }
                }
            }
            baglanti.Close();
        }

        private void cmbsalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }
    }
}
