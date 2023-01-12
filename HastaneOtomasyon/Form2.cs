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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        HastaneVeriTabaniEntities db = new HastaneVeriTabaniEntities();
        SqlConnection conn = new SqlConnection(@"server=LAPTOP-47D8GKTS;database=HastaneVeriTabani;UID=sa;PWD=HaticeK.1029");
        DateTime zaman = DateTime.Now;
        DataTable dt;
        private void Form2_Load(object sender, EventArgs e)
        {
            BilgileriGetir();
            egitim();
            cinsiyet();
            meslek();
            kanGrubu();
            dataGridView1.Columns["Durum"].Visible = false;
            dataGridView1.Columns["PersonelID"].Visible = false;
            Temizle();
        }

        private void Temizle()
        {
            txtAd.Text = "";  
            txtSoyad.Text = "";
            txtTCKN.Text = "";
            txtTel.Text = "";
            txtAdres.Text = "";
            txtMail.Text = "";
            dtpDogumTarihi.Value = DateTime.Now;
            dtpİseGiris.Value = DateTime.Now;
            cmbCinsiyet.Text = null;
            cmbEgitimi.Text = null;
            cmbKan.Text = null;
            cmbMeslek.Text = null;
            txtIzinID.Text = "";
            txtIzinPersonelID.Text = "";
            txtIzinTuru.Text = "";
            dtpIzinBaslangic.Value = DateTime.Now;
            dtpIzinBitis.Value = DateTime.Now;
            txtIzinAdresi.Text = "";
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

        private void meslek()
        {
            SqlCommand cmd = new SqlCommand("Select * from Meslek", conn); 
            dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter("Select MeslekID, MeslekTuru from Meslek", conn); 
            dap.Fill(dt);
            cmbMeslek.DataSource = dt;
            cmbMeslek.DisplayMember = "MeslekTuru";
            cmbMeslek.ValueMember = "MeslekID";
            cmbMeslek.Text = "Seçiniz...";
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

        private void egitim()
        {
            object[] egitimdurumu = new object[] { "İlkokul", "Lise", "Önlisans", "Lisans", "Yüksek Lisans", "Doktora" };
            cmbEgitimi.Items.AddRange(egitimdurumu);
            cmbEgitimi.Text = "Seçiniz";
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            for (int i = 0; i < cmbEgitimi.Items.Count; i++)
            {
                collection.Add(cmbEgitimi.Items[i].ToString());
            }
            cmbEgitimi.AutoCompleteCustomSource = collection;
            cmbEgitimi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEgitimi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbEgitimi.Text = "Seçiniz...";
        }

        private void BilgileriGetir()
        {
            var pKisiler = from p in db.Personel
                           select new
                           {
                               p.PersonelID,
                               p.TCKN,
                               p.PersonelAdi,
                               p.PersonelSoyadi,
                               p.Meslek.MeslekTuru,
                               p.İseGirisTarihi,
                               p.DogumTarihi,
                               p.EnSonMezuniyetBilgisi,
                               p.Cinsiyet,
                               p.KanGrubuID,
                               p.TelefonNo,
                               p.Adres,
                               p.Mail,
                               p.Durum
                           };
            dataGridView1.DataSource = pKisiler.Where(x => x.Durum == true).ToList();

        }

       

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            db.SaveChanges();
        }
        Personel secilenVeri;
        Izinler secilenIzin;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > -1)
            {
                dataGridView2.Columns.Clear(); //tekrarları engellemek için
                dataGridView2.Columns.Add("IzinID", "IzinID");
                dataGridView2.Columns.Add("IzınTuru", "IzınTuru");

                secilenVeri = db.Personel.Find((dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));  

                txtAd.Text = secilenVeri.PersonelAdi;
                txtSoyad.Text = secilenVeri.PersonelSoyadi;
                txtTCKN.Text = secilenVeri.TCKN;
                txtTel.Text = secilenVeri.TelefonNo;
                txtAdres.Text = secilenVeri.Adres;
                txtMail.Text = secilenVeri.Mail;
                dtpDogumTarihi.Value = secilenVeri.DogumTarihi.Value;


                if (secilenVeri.Izinler.Count > 0)
                {
                    foreach (var izin in secilenVeri.Izinler)
                    {
                        dataGridView2.Rows.Add(izin.IzinID.ToString(), izin.IzınTuru.ToString());
                    }

                }
            }
            else
            {

                MessageBox.Show("Lütfen bir satır seçiniz");
            }

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Personel yeniKisi = new Personel();
            yeniKisi.HastaneID = 1;
            yeniKisi.MeslekID = int.Parse(cmbMeslek.SelectedValue.ToString());
            yeniKisi.PersonelAdi = txtAd.Text;
            yeniKisi.PersonelSoyadi = txtSoyad.Text;
            yeniKisi.TCKN = txtTCKN.Text;
            yeniKisi.İseGirisTarihi = dtpİseGiris.Value;
            yeniKisi.DogumTarihi = dtpDogumTarihi.Value;
            yeniKisi.EnSonMezuniyetBilgisi = cmbEgitimi.SelectedItem.ToString();
            yeniKisi.Cinsiyet = (cmbCinsiyet.SelectedValue.ToString());
            yeniKisi.KanGrubuID = cmbKan.SelectedValue.ToString();
            yeniKisi.TelefonNo = txtTel.Text;
            yeniKisi.Adres = txtAdres.Text;
            yeniKisi.Mail = txtMail.Text;

            db.Personel.Add(yeniKisi);
            db.SaveChanges();
            MessageBox.Show("Eklendi");
            BilgileriGetir();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            secilenVeri.PersonelAdi = txtAd.Text;
            secilenVeri.PersonelSoyadi = txtSoyad.Text;
            secilenVeri.TCKN = txtTCKN.Text;
            secilenVeri.TelefonNo = txtTel.Text;
            secilenVeri.Adres = txtAdres.Text;
            secilenVeri.Mail = txtMail.Text;
            secilenVeri.HastaneID = 1;
            secilenVeri.MeslekID = int.Parse(cmbMeslek.SelectedValue.ToString());
            secilenVeri.İseGirisTarihi = dtpİseGiris.Value;
            secilenVeri.DogumTarihi = dtpDogumTarihi.Value;
            secilenVeri.EnSonMezuniyetBilgisi = cmbEgitimi.SelectedItem.ToString();
            secilenVeri.Cinsiyet = cmbCinsiyet.SelectedValue.ToString();
            secilenVeri.KanGrubuID = cmbKan.SelectedValue.ToString();


            db.SaveChanges(); //database e ilgili değişiklileri atma işlemi
            MessageBox.Show("Güncellendi");
            BilgileriGetir();//ekrana gelsin diye
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            secilenVeri = db.Personel.Find((dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value));  //secilen verinin idsini getirme çağırma işlemi

            if (MessageBox.Show("Personeli Silmek İstediğinize Emin Misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                secilenVeri.Durum = false;
                db.SaveChanges(); //database e ilgili değişiklileri atma işlemi
                Temizle(); //textboxlar temizlensin diye

            }
            else
            {
                MessageBox.Show("Silme İşlemi iptal edildi");
                Temizle(); //textboxlar temizlensin diye
            }


        }
        private void txtTCKN_TextChanged(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.Personel.Where(k => k.TCKN.StartsWith(txtTCKN.Text)).ToList();

        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > -1)
            {

                secilenIzin = db.Izinler.Find(Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value));  //secilen verinin idsini getirme çağırma işlemi

                txtIzinID.Text = secilenIzin.IzinID.ToString();
                txtIzinPersonelID.Text = secilenIzin.PersonelID.ToString();
                txtIzinTuru.Text = secilenIzin.IzınTuru;
                txtIzinAdresi.Text = secilenIzin.IzinAdresi.ToString();
                dtpIzinBaslangic.Value = secilenIzin.IzinBaslangic;
                dtpIzinBitis.Value = secilenIzin.IzinBitis;
            }

            else
            {

                MessageBox.Show("Lütfen bir satır seçiniz");
            }
        }

        private void btnIzinKaydet_Click(object sender, EventArgs e)
        {
            Izinler yeniizin = new Izinler();
            yeniizin.PersonelID = Convert.ToInt32(txtIzinPersonelID.Text);
            yeniizin.IzınTuru = txtIzinTuru.Text;
            yeniizin.IzinAdresi = txtIzinAdresi.Text;
            yeniizin.IzinBaslangic = dtpIzinBaslangic.Value;
            yeniizin.IzinBitis = dtpIzinBitis.Value;

            db.Izinler.Add(yeniizin);
            db.SaveChanges();
            MessageBox.Show("Yeni İzin Eklendi");
            BilgileriGetir();
        }
        private void btnIzinGuncelle_Click(object sender, EventArgs e)
        {
            secilenIzin.IzinID = Convert.ToInt32(txtIzinID.Text);
            secilenIzin.PersonelID = Convert.ToInt32(txtIzinPersonelID.Text);
            secilenIzin.IzınTuru = txtIzinTuru.Text;
            secilenIzin.IzinAdresi = txtIzinAdresi.Text;
            secilenIzin.IzinBaslangic = dtpIzinBaslangic.Value;
            secilenIzin.IzinBitis = dtpIzinBitis.Value;

            db.SaveChanges();
            MessageBox.Show("İzin Bilgileri Güncellendi");
            BilgileriGetir();
        }

        private void btnIzinSil_Click(object sender, EventArgs e)
        {
            int aktifid = Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value);
            db.Izinler.Remove(db.Izinler.Find(aktifid));

            db.SaveChanges();
            MessageBox.Show("Mevcut İzin Silindi");
            BilgileriGetir();
        }
    }
}
