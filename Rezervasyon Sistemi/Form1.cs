using System;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Rezervasyon_Sistemi
{
    public partial class Form1 : Form
    {
        public Kayýt_Ol kayýtOlControl;
        public Ana_Sayfa anaSayfaControl; 
        private string connectionString = @"Server=KAAN\SQLEXPRESS;Database=RezervasyonDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();

            kayýtOlControl = new Kayýt_Ol(this)
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(kayýtOlControl);

            anaSayfaControl = new Ana_Sayfa()
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(anaSayfaControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text.Trim();
            string sifre = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanýcý adý ve þifre boþ olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KullaniciDogrula(kullaniciAdi, sifre))
            {
                MessageBox.Show("Giriþ baþarýlý!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (Control control in this.Controls)
                {
                    control.Visible = false;
                }

                anaSayfaControl = new Ana_Sayfa
                {
                    Dock = DockStyle.Fill,
                    Visible = true
                };

                this.Controls.Add(anaSayfaControl);
            }
            else
            {
                MessageBox.Show("Kullanýcý adý veya þifre hatalý!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kayýtolButton_Click(object sender, EventArgs e)
        {
            ShowUserControl(kayýtOlControl);
        }

        private bool KullaniciDogrula(string kullaniciAdi, string sifre)
        {
            try
            {
                byte[] hashedSifre = HashPassword(sifre);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT COUNT(*)
                        FROM Kullanici
                        WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                        cmd.Parameters.AddWithValue("@Sifre", hashedSifre);

                        int count = (int)cmd.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Baðlantý Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        // Belirtilen UserControl'ü gösteren yöntem
        public void ShowUserControl(UserControl control)
        {
            foreach (Control c in this.Controls)
            {
                c.Visible = false;  // Tüm kontrolleri gizle
            }
            control.Visible = true;  // Sadece belirtilen kontrolü göster
        }

        // Giriþ ekranýna dönüþ
        public void ShowLoginScreen()
        {
            // Tüm kontrolleri temizleriz ve baþlangýç iþemlerini yeniden yükleriz
            this.Controls.Clear();
            InitializeComponent();

            // Kayýt_Ol UserControl'ü yeniden ekliyoruz
            kayýtOlControl = new Kayýt_Ol(this)
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(kayýtOlControl);

            // Ana_Sayfa UserControl'ü yeniden ekliyoruz
            anaSayfaControl = new Ana_Sayfa()
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(anaSayfaControl);
        }
    }
}
