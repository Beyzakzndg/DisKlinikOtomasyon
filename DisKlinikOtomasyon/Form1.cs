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
    public partial class Form1 : Form
    {
        DentistDbEntities1 db=new DentistDbEntities1();
        
        public Form1()
        {
            InitializeComponent();
            DataInit();
            DataSave();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PasswdTxt.PasswordChar = '•';
            checkBox1.Text = "Göster";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState==CheckState.Checked)
            {
                PasswdTxt.PasswordChar = '\0';
                checkBox1.Text = "Gizle";
            }
            else
            {
                PasswdTxt.PasswordChar = '•';
                checkBox1.Text = "Göster";
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string gelenAd=UserTxt.Text;
            string gelenSifre=PasswdTxt.Text;

            var personeller = db.PersonelKayit.Where(x => x.Personel_Kullanici == gelenAd && x.Personel_Sifre==gelenSifre).FirstOrDefault();
            if (personeller==null)
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı!");
            }
            else
            {
                MessageBox.Show("Hoşgeldiniz");

                DataSave();
            }
        }
        void DataInit()
        {
            if (Properties.Settings.Default.UserName!=string.Empty)
            {
                if (Properties.Settings.Default.Remember==true)
                {
                    UserTxt.Text = Properties.Settings.Default.UserName;
                    PasswdTxt.Text = Properties.Settings.Default.PassWord;
                    checkBox1.Checked = true;
                }
                else
                {
                    UserTxt.Text= Properties.Settings.Default.UserName;
                }
            }
        }

        void DataSave()
        {
            if (checkBox1.Checked)
            {
               Properties.Settings.Default.UserName = UserTxt.Text;
                Properties.Settings.Default.PassWord = PasswdTxt.Text;
                Properties.Settings.Default.Remember = true;
               Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.PassWord = "";
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Save();
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KayitForm kayitForm = new KayitForm();
            kayitForm.Show();
            this.Hide();
        }
    }
}
