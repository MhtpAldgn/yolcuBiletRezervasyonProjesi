using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace yolcuBiletRezervasyonProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-B2AV4A5\\SQLDEVELOPER;Initial Catalog=YolcuBiletRezervasyonSistemi;Integrated Security=True");

        void temizle()
        {
            txtYolcuAd.Text = "";
            txtYolcuSoyad.Text = "";
            mskYolcuTelefon.Text = "";
            mskYolcuTC.Text = "";
            cmbCinsiyet.Text = "";
            txtYolcuMail.Text = "";
            mskYolcuTC.Focus();
        }
        void seferdetay()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from SEFERDETAY", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        void seferlistesi()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("select * from SEFERBILGI", baglanti);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
        public string cinsiyet;
        void cinsiyetsec()
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("select CINSIYET from YOLCUBILGI where TC='" + mskTC.Text + "'", baglanti);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.Read())
            {
                cinsiyet = dr[0].ToString();
            }
            baglanti.Close();

        }
        void koltuksec()
        {
            cinsiyetsec();
            switch (txtKoltukNo.Text)
            {
                case "1":
                    {
                        if (cinsiyet == "ERKEK") { btn1.BackColor = Color.Teal; }
                        else { btn1.BackColor = Color.PaleVioletRed; }
                        break;
                    }
                case "2":
                    {
                        if (cinsiyet == "ERKEK") { btn2.BackColor = Color.Teal; }
                        else { btn2.BackColor = Color.PaleVioletRed; }
                        break;
                    }
                case "3":
                    {
                        if (cinsiyet == "ERKEK") { btn3.BackColor = Color.Teal; }
                        else { btn3.BackColor = Color.PaleVioletRed; }
                        break;
                    }
                case "4":
                    {
                        if (cinsiyet == "ERKEK") { btn4.BackColor = Color.Teal; }
                        else { btn4.BackColor = Color.PaleVioletRed; }
                        break;
                    }
                case "5":
                    {
                        if (cinsiyet == "ERKEK") { btn5.BackColor = Color.Teal; }
                        else { btn5.BackColor = Color.PaleVioletRed; }
                        break;
                    }
                case "6":
                    {
                        if (cinsiyet == "ERKEK") { btn6.BackColor = Color.Teal; }
                        else { btn6.BackColor = Color.PaleVioletRed; }
                        break;
                    }
                case "7":
                    {
                        if (cinsiyet == "ERKEK") { btn7.BackColor = Color.Teal; }
                        else { btn7.BackColor = Color.PaleVioletRed; }
                        break;
                    }
                case "8":
                    {
                        if (cinsiyet == "ERKEK") { btn8.BackColor = Color.Teal; }
                        else { btn8.BackColor = Color.PaleVioletRed; }
                        break;
                    }
                case "9":
                    {
                        if (cinsiyet == "ERKEK") { btn9.BackColor = Color.Teal; }
                        else { btn9.BackColor = Color.PaleVioletRed; }
                        break;
                    }

            }
        }
        private void btnKydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("insert into YOLCUBILGI (AD,SOYAD,TELEFON,TC,CINSIYET,MAIL) values (@E1,@E2,@E3,@E4,@E5,@E6)", baglanti);
            kmt.Parameters.AddWithValue("@E1", txtYolcuAd.Text);
            kmt.Parameters.AddWithValue("@e2", txtYolcuSoyad.Text);
            kmt.Parameters.AddWithValue("@e3", mskYolcuTelefon.Text);
            kmt.Parameters.AddWithValue("@e4", mskYolcuTC.Text);
            kmt.Parameters.AddWithValue("@e5", cmbCinsiyet.Text);
            kmt.Parameters.AddWithValue("@e6", txtYolcuMail.Text);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yolcu Bilgileri Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnKaptan_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("insert into KAPTAN(KAPTANNO,ADSOYAD,TELEFON) values(@w1,@w2,@w3)", baglanti);
            kmt.Parameters.AddWithValue("@w1", txtKaptanNo.Text);
            kmt.Parameters.AddWithValue("@w2", txtKaptanAdsoyad.Text);
            kmt.Parameters.AddWithValue("@w3", mskKaptanTelefon.Text);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaptan Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnSeferOlustur_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand("insert into SEFERBILGI(KALKIS,VARIS,TARIH,SAAT,KAPTAN,FIYAT) values(@s1,@s2,@s3,@s4,@s5,@s6)", baglanti);
            kmt.Parameters.AddWithValue("@s1", txtKalkıs.Text);
            kmt.Parameters.AddWithValue("@s2", txtVaris.Text);
            kmt.Parameters.AddWithValue("@s3", mskTarih.Text);
            kmt.Parameters.AddWithValue("@s4", mskSaat.Text);
            kmt.Parameters.AddWithValue("@s5", mskKaptan.Text);
            kmt.Parameters.AddWithValue("@s6", txtFiyat.Text);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sefer Bilgileri Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            seferlistesi();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seferdetay();
            seferlistesi();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSeferNumarası.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "3";

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtKoltukNo.Text = "9";
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand kmt = new SqlCommand("insert into SEFERDETAY(SEFERNO,YOLCUTC,KOLTUK) values(@a1,@a2,@a3)", baglanti);
            kmt.Parameters.AddWithValue("@a1", txtSeferNumarası.Text);
            kmt.Parameters.AddWithValue("@a2", mskTC.Text);
            kmt.Parameters.AddWithValue("@a3", txtKoltukNo.Text);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Rezervasyon Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            koltuksec();
            seferdetay();
        }

    }
}
