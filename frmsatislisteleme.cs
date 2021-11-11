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
    public partial class frmsatislisteleme : Form
    {
        public frmsatislisteleme()
        {
            InitializeComponent();
        }

        sinemaTableAdapters.satis_bilgileriTableAdapter satislistesi = new sinemaTableAdapters.satis_bilgileriTableAdapter();
        private void frmsatislisteleme_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satislistesi.tarixegorelistele2(dateTimePicker1.Text);
            toplamucrethesabla();
        }
        private void toplamucrethesabla()
        {
            int ucrettoplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ucrettoplam += Convert.ToInt32(dataGridView1.Rows[i].Cells["ucret"].Value);
            }
            label1.Text = "Toplam Satis    " + ucrettoplam + "AZN";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satislistesi.satislistesi2();
            toplamucrethesabla();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satislistesi.tarixegorelistele2(dateTimePicker1.Text);
            toplamucrethesabla();
        }
    }
}
