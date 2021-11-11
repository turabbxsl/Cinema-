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
    public partial class frmsalonekle : Form
    {
        public frmsalonekle()
        {
            InitializeComponent();
        }

        private void frmsalonekle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 ana = new Form1();
            ana.ShowDialog();
        }

        sinemaTableAdapters.salon_bilgilerTableAdapter salon = new sinemaTableAdapters.salon_bilgilerTableAdapter();
        private void btnsalonekle_Click(object sender, EventArgs e)
        {
            try
            {
                salon.Salonekleme(txtsalonadi.Text);
                MessageBox.Show("Salon Elave Olundu", "Qeyd");
            }
            catch (Exception)
            {
                MessageBox.Show("Eyni Salonu Daha Evvel Elave Etdiniz!","Bildiris ");
            }
            txtsalonadi.Text = "";
        }
    }
}
