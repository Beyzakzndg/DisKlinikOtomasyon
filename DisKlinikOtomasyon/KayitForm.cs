using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisKlinikOtomasyon
{
    public partial class KayitForm : Form
    {
        DentistDbEntities1 db = new DentistDbEntities1();
        public KayitForm()
        {
            InitializeComponent();
        }

        private void KayitForm_Load(object sender, EventArgs e)
        {
            DataGridView1.Visible= true;


            var kullanicilar=db.PersonelKayit.ToList();

            DataGridView1.DataSource=kullanicilar.ToList();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
