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

namespace HastaneOtomasyon
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        HastaneVeriTabaniEntities db = new HastaneVeriTabaniEntities();
        SqlConnection conn = new SqlConnection(@"server=LAPTOP-47D8GKTS;database=HastaneVeriTabani;UID=sa;PWD=HaticeK.1029");
        DateTime zaman = DateTime.Now;
        DataTable dt;
        private void Form3_Load(object sender, EventArgs e)
        {
            cinsiyet();
            kanGrubu();
            BilgileriGetir();
            dataGridView1.Columns["HastaID"].Visible = false;
            dataGridView1.Columns["Durum"].Visible = false;
        }

        private void BilgileriGetir()
        {
            var pHasta = from p in db.Hasta
                         select new
                         {
                             p.HastaID,
                             p.TCKN,
                             p.HastaAdi,
                             p.HastaSoyadi,
                             p.DogumTarihi,
                             p.Kilo,
                             // p.KanGrubuID,
                             p.KanGrubu.KanGrubuTuru,
                             p.Cinsiyet,
                             //p.Cinsiyet1,
                             p.HastaTelefonNo,
                             p.HastaAdres,
                             p.HastaMail,
                             p.HastaGecmisi.KullandigiIlac,
                             p.HastaGecmisi.GecirdigiHastalik,
                             p.HastaGecmisi.GecirdigiAmeliyat,
                             p.HastaGecmisi.Alerjiler,
                             p.Durum
                         };

            dataGridView1.DataSource = pHasta.Where(x => x.Durum == true).ToList();
        }

        private void kanGrubu()
        {
            SqlCommand cmd = new SqlCommand("Select * from KanGrubu", conn); 
            dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter("Select * from KanGrubu", conn);
            dap.Fill(dt);
            cmbKan.DataSource = dt;
            cmbKan.DisplayMember = "KanGrubuTuru";
            cmbKan.ValueMember = "KanGrubuID";
            cmbKan.Text = "Seçiniz...";
        }

        private void cinsiyet()
        {
            SqlCommand cmd = new SqlCommand("Select * from Cinsiyet", conn); 
            dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter("Select CinsiyetID,Cinsiyet from Cinsiyet", conn);
            dap.Fill(dt);
            cmbCinsiyet.DataSource = dt;
            cmbCinsiyet.DisplayMember = "Cinsiyet";
            cmbCinsiyet.ValueMember = "CinsiyetID";
            cmbCinsiyet.Text = "Seçiniz...";
        }

        private void btnHKayıt_Click(object sender, EventArgs e)
        {
            var gecmis = new HastaGecmisi
            {
                KullandigiIlac = txtİlac.Text,
                GecirdigiHastalik = txtHastalık.Text,
                GecirdigiAmeliyat = txtAmeliyat.Text,
                Alerjiler = txtAlerji.Text,
            };
            db.HastaGecmisi.Add(gecmis);

            Hasta yeniHasta = new Hasta();
            yeniHasta.HastaAdi = txtAd.Text;
            yeniHasta.HastaSoyadi = txtSoyad.Text;
            yeniHasta.TCKN = txtTCKN.Text;
            yeniHasta.Kilo = (int)nudKilo.Value;
            yeniHasta.DogumTarihi = dtpDogumTarihi.Value;
            yeniHasta.Cinsiyet = cmbCinsiyet.SelectedValue.ToString();
            yeniHasta.KanGrubuID = cmbKan.SelectedValue.ToString();
            yeniHasta.HastaTelefonNo = txtTel.Text;
            yeniHasta.HastaMail = txtMail.Text;
            yeniHasta.HastaAdres = txtAdres.Text;
            yeniHasta.Durum = true;
            yeniHasta.HastaGecmisiID = gecmis.HastaGecmisiID;

            db.Hasta.Add(yeniHasta);
            db.SaveChanges();
            BilgileriGetir();
            Temizle();

        }

        private void Temizle()
        {
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = new TextBox();
                    txt = (TextBox)item;
                    txt.Clear();

                }
                else if (item is NumericUpDown)
                {
                    NumericUpDown nup = new NumericUpDown();
                    nup = (NumericUpDown)item;
                    nup.Value = 0;

                }
                else if (item is DateTimePicker)
                {
                    DateTimePicker dtp = new DateTimePicker();
                    dtp = (DateTimePicker)item;
                    dtp.Value = DateTime.Now;
                }
            }
        }
        private void btnHGuncelle_Click(object sender, EventArgs e)
        {
            secilenVeri = db.Hasta.Find(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);


            secilenVeri.HastaGecmisi.KullandigiIlac = txtİlac.Text;
            secilenVeri.HastaGecmisi.GecirdigiHastalik = txtHastalık.Text;
            secilenVeri.HastaGecmisi.GecirdigiAmeliyat = txtAmeliyat.Text;
            secilenVeri.HastaGecmisi.Alerjiler = txtAlerji.Text;

            secilenVeri.HastaAdi = txtAd.Text;
            secilenVeri.HastaSoyadi = txtSoyad.Text;
            secilenVeri.TCKN = txtTCKN.Text;
            secilenVeri.Kilo = (int)nudKilo.Value;
            secilenVeri.DogumTarihi = dtpDogumTarihi.Value;
            secilenVeri.Cinsiyet = cmbCinsiyet.SelectedValue.ToString();
            secilenVeri.KanGrubuID = cmbKan.SelectedValue.ToString();
            secilenVeri.HastaTelefonNo = txtTel.Text;
            secilenVeri.HastaMail = txtMail.Text;
            secilenVeri.HastaAdres = txtAdres.Text;
            db.SaveChanges();
            BilgileriGetir();
            Temizle(); 
        }

        private void btnHSil_Click(object sender, EventArgs e)
        {
            secilenVeri = db.Hasta.Find(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);


            if (MessageBox.Show("Hastaya Ait Mevcut Bilgiler Silinsin mi?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                secilenVeri.Durum = false;
                db.SaveChanges(); 
                Temizle(); 


            }
            else
            {
                MessageBox.Show("Silme İşlemi iptal edildi");
                Temizle(); 
            }


            BilgileriGetir();


        }
        Hasta secilenVeri;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > -1)
            {
               
                txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); 
                txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTCKN.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTel.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtAdres.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            }

            else
            {

                MessageBox.Show("Lütfen bir satır seçiniz");
            }

        }
    }
}
