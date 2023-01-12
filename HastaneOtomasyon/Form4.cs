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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        HastaneVeriTabaniEntities db = new HastaneVeriTabaniEntities();
        SqlConnection conn = new SqlConnection(@"server=LAPTOP-47D8GKTS;database=HastaneVeriTabani;UID=sa;PWD=HaticeK.1029");

        int secilenHastaID;
        private void Form4_Load(object sender, EventArgs e)
        {
            Poliklinikdoldur();
            label9.Visible = false;
        }

        private void Poliklinikdoldur()
        {
            comboBox2.SelectedIndexChanged -= comboBox2_SelectedIndexChanged;

            SqlCommand cmd = new SqlCommand("Select * from Poliklinik", conn); 
            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter("Select PoliklinikID, PoliklinkAdi from Poliklinik", conn); 
            dap.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "PoliklinkAdi";
            comboBox2.ValueMember = "PoliklinikID";
            comboBox2.Text = "Seçiniz...";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select p.PersonelAdi+' '+p.PersonelSoyadi as doktoradi ,d.DoktorID from Doktorlar d Join Personel p on p.PersonelID=d.PersonelID where PoliklinikID = " + comboBox2.SelectedValue, conn);
                da.Fill(dt);
                comboBox1.ValueMember = "DoktorID";
                comboBox1.DisplayMember = "doktoradi";
                comboBox1.DataSource = dt;
                comboBox1.Text = "Seçiniz...";
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenHastaID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            dataGridView2.DataSource = db.RandevuDetay.Where(r => r.Randevu.HastaID == secilenHastaID).Select(r => new
            {
                r.RandevuID,
                r.RandevuTarihi,
                r.RandevuSaati,
                r.Randevu.Sikayet
            }).ToList();
        }
            private void button1_Click(object sender, EventArgs e)
        {
            secilenHastaID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

            label9.Text = (dateTimePicker1.Text + " tarihinde saat:" + dateTimePicker2.Text + " randevunuz oluşturulmuştur");

            

            Randevu yeniRandevu = new Randevu();
            RandevuDetay yeniRandevuDetay = new RandevuDetay();

            yeniRandevu.HastaID = secilenHastaID;
            yeniRandevu.DoktorID = Convert.ToInt32(comboBox1.SelectedValue);
            yeniRandevu.Sikayet = txtSikayet.Text;

            db.Randevu.Add(yeniRandevu);
            db.SaveChanges();
            int eklenenRandevuID = yeniRandevu.RandevuID;

            yeniRandevuDetay.RandevuID = eklenenRandevuID;
            yeniRandevuDetay.RandevuTarihi = dateTimePicker1.Value;
            yeniRandevuDetay.RandevuSaati = TimeSpan.Parse(dateTimePicker2.Value.ToString("HH:mm:ss"));

            db.RandevuDetay.Add(yeniRandevuDetay);
            db.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           


            Randevu yeniRandevu = db.Randevu.Find(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value);
            RandevuDetay yeniRandevuDetay = db.RandevuDetay.Where(rd => rd.RandevuID == yeniRandevu.RandevuID).SingleOrDefault();

            yeniRandevu.HastaID = secilenHastaID;
            yeniRandevu.DoktorID = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            yeniRandevu.Sikayet = txtSikayet.Text;
            yeniRandevu.Tedavi = txtTedavi.Text;
            yeniRandevu.Teshis = txtTeshis.Text;

            db.SaveChanges();

            yeniRandevuDetay.RandevuTarihi = dateTimePicker1.Value;
            yeniRandevuDetay.RandevuSaati = TimeSpan.Parse(dateTimePicker2.Value.ToString("HH:mm:ss"));
            yeniRandevuDetay.HastaGeldimi = checkBox1.Checked ? "E" : "H";
            yeniRandevuDetay.YeniRandevuTarihi = dateTimePicker3.Value;


            db.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Randevu mevcutRandevu = db.Randevu.Find(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value);
           RandevuDetay mevcutRandevuDetay =db.RandevuDetay.Where(rd=>rd.RandevuID== mevcutRandevu.RandevuID).SingleOrDefault();


            if (DateTime.Now < mevcutRandevuDetay.RandevuTarihi)
            {
                db.RandevuDetay.Remove(mevcutRandevuDetay);
                db.SaveChanges();

                db.Randevu.Remove(mevcutRandevu);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Randevu tarihi geçmiş, silinemez");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 11)
            {
                dataGridView1.DataSource = db.Hasta.Select(h => new
                {
                    h.HastaID,
                    h.TCKN,
                    h.HastaAdi,
                    h.HastaSoyadi
                }).ToList();
            }
            else
            {
                dataGridView1.DataSource = db.Hasta.Where(h => h.TCKN == textBox1.Text).Select(h => new
                {
                    h.HastaID,
                    h.TCKN,
                    h.HastaAdi,
                    h.HastaSoyadi
                }).ToList();

            }
        } 
       
        int randevuid;
        private void button5_Click(object sender, EventArgs e)
        {
                Form5 f5 = new Form5();
                f5.randevuid = (int)dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value;

                f5.Show();
                this.Hide();

        }

       
    }
}
