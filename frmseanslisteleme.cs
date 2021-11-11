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
    public partial class frmseanslisteleme : Form
    {
        public frmseanslisteleme()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=sinema;Integrated Security=True");
        sinemaTableAdapters.seans_bilgileriTableAdapter filmseansi = new sinemaTableAdapters.seans_bilgileriTableAdapter();
        DataTable table = new DataTable();

        private void seanslistele(string sql)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, baglanti);
            da.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();
        }
        private void frmseanslisteleme_Load(object sender, EventArgs e)
        {
            table.Clear();
            seanslistele("select * from seans_bilgileri where tarix like '" + dateTimePicker1.Text + "'");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            table.Clear();
            seanslistele("select * from seans_bilgileri where tarix like '" + dateTimePicker1.Text + "'");
        }

        private void btnbutunseans_Click(object sender, EventArgs e)
        {
            table.Clear(); 
            seanslistele("select * from seans_bilgileri");
        }
    }
}
