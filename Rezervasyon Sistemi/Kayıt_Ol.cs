using System;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Rezervasyon_Sistemi
{
    public partial class Kayıt_Ol : UserControl
    {
        private string connectionString = @"Server=KAAN\SQLEXPRESS;Database=RezervasyonDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private Form1 parentForm;

        public Kayıt_Ol(Form1 parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void bilgilerikaydetButton_Click(object sender, EventArgs e)
        {
            string ad = adgirişTextbox.Text.Trim();
            string sifre = şifregirişTextbox.Text.Trim();
            string eposta = mailgirişiTextbox.Text.Trim();
            string telefon = numaragirişTextbox.Text.Trim();
            string soyad = soyadgirişTextbox.Text.Trim();

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(eposta))
            {
                MessageBox.Show("Ad, şifre ve e-posta boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] hashedSifre = HashPassword(sifre);

            if (KullaniciKaydet(ad, hashedSifre, eposta, telefon, soyad))
            {
                MessageBox.Show("Kayıt başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parentForm.ShowLoginScreen();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya e-posta zaten var!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool KullaniciKaydet(string ad, byte[] sifre, string eposta, string telefon, string soyad)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Kullanici WHERE KullaniciAdi = @KullaniciAdi OR Eposta = @Eposta";
                    using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@KullaniciAdi", ad);
                        cmdCheck.Parameters.AddWithValue("@Eposta", eposta);
                        int count = (int)cmdCheck.ExecuteScalar();
                        if (count > 0)
                        {
                            return false;
                        }
                    }

                    string query = @"
                        INSERT INTO Kullanici (KullaniciAdi, Sifre, Eposta, Telefon, Soyad, Ad)
                        VALUES (@KullaniciAdi, @Sifre, @Eposta, @Telefon, @Soyad, @Ad)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@KullaniciAdi", ad);
                        cmd.Parameters.AddWithValue("@Sifre", sifre);
                        cmd.Parameters.AddWithValue("@Eposta", eposta);
                        cmd.Parameters.AddWithValue("@Telefon", telefon);
                        cmd.Parameters.AddWithValue("@Soyad", soyad);
                        cmd.Parameters.AddWithValue("@Ad", ad);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.Parent; //form1 e geçiş
            form1.ShowLoginScreen();
        }
    }
}
