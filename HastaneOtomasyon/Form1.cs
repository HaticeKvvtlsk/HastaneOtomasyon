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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool durum1;
        bool durum2;
        bool durum3;

        private void Form1_Load(object sender, EventArgs e)
        { 

        }

        private void BtnPersonel_Click(object sender, EventArgs e)
        {
            if (durum1 == false)
            {
                Form2 F2 = new Form2();
                F2.MdiParent = this.ParentForm;
                F2.FormClosed += F2_FormClosed;
                F2.Show();
                durum1 = true;

            }
            else
            {
                MessageBox.Show("PERSONEL FORMU AÇIK DURUMDA");
            }
        }
        private void F2_FormClosed(object sender, FormClosedEventArgs e)
        {
            durum1 = false;
        }

        private void BtnHasta_Click(object sender, EventArgs e)
        {
            if (durum2 == false)
            {
                Form3 F3 = new Form3();
                F3.MdiParent = this.ParentForm;
                F3.FormClosed += F3_FormClosed;  //Çarpıya basıldığında özelliği F2'ye devrettim 
                F3.Show();
                durum2 = true;


            }
            else
            {
                MessageBox.Show("HASTA FORMU AÇIK DURUMDA");
            }
        }
        private void F3_FormClosed(object sender, FormClosedEventArgs e)
        {
            durum2 = false;
        }

        private void BtnRandevu_Click(object sender, EventArgs e)
        {
            if (durum3 == false)
            {
                Form4 F4 = new Form4();
                F4.MdiParent = this.ParentForm;
                F4.FormClosed += F4_FormClosed;  //Çarpıya basıldığında özelliği F2'ye devrettim 
                F4.Show();
                durum2 = true;


            }
            else
            {
                MessageBox.Show("RANDEVU FORMU AÇIK DURUMDA");
            }
        }
        private void F4_FormClosed(object sender, FormClosedEventArgs e)
        {
            durum3 = false;
        }
    }
}
