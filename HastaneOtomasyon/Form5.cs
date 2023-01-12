using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        HastaneVeriTabaniEntities db = new HastaneVeriTabaniEntities();
        public int randevuid { get; set; }
        private void Form5_Load(object sender, EventArgs e)
        {
            IlacSec();
            KullanimSekli();
            IlacDozu();
            temizle();
            
        }

        private void temizle()
        {
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = new TextBox();
                    txt = (TextBox)item;
                    txt.Clear();

                }
                else if (item is ComboBox)
                {
                    ComboBox cmb = new ComboBox();
                    cmb = (ComboBox)item;
                    cmb.Text = null;

                }

            }
        }

        private void IlacDozu()
        {
            string[] ilacdozu = new string[] { "1x1", "1x2", "1x3", "Haftada bir", "15", "Gün aşırı" };
            comboBox3.DataSource = ilacdozu;
            comboBox3.Text = null;
        }

        private void KullanimSekli()
        {
            string[] kullanimsekli = new string[] { "oral", "krem", "enj", "damla", "toz", "topikal", "fitil" };
            comboBox2.DataSource = kullanimsekli;
            comboBox2.Text = null;
        }

        private void IlacSec()
        {
            var ilaclar = (from il in db.Ilaclar

                           select il).ToList();
            comboBox1.ValueMember = "BarkodID";
            comboBox1.DisplayMember = "IlacAdi";
            comboBox1.DataSource = ilaclar;
            comboBox1.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReceteDetay yenirecetedetay = new ReceteDetay();

            yenirecetedetay.RandevuID = randevuid;
            yenirecetedetay.BarkodNo = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            yenirecetedetay.KullanımSekli = comboBox2.Text;
            yenirecetedetay.IlacDozu = comboBox3.Text;
            yenirecetedetay.IlacAdet =Convert.ToInt32(textBox2.Text.ToString());

            String karakterler = "0123456789ABCDEFGHIJKLMNOPRSTUVYZ";
            Random rnd = new Random();
            String pano = "";
            for (int i = 0; i < 8; i++)
            {
                pano += karakterler[rnd.Next(karakterler.Length)];
            }


            db.ReceteDetay.Add(yenirecetedetay);
            db.SaveChanges(); 
            MessageBox.Show("REÇETE NUMARANIZ  : "+pano);
            temizle(); 


       

        }
    }
}
