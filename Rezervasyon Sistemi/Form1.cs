using System;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Rezervasyon_Sistemi
{
    public partial class Form1 : Form
    {
        public Kay�t_Ol kay�tOlControl;
        public Ana_Sayfa anaSayfaControl; 
        private string connectionString = @"Server=KAAN\SQLEXPRESS;Database=RezervasyonDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();

            kay�tOlControl = new Kay�t_Ol(this)
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(kay�tOlControl);

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
                MessageBox.Show("Kullan�c� ad� ve �ifre bo� olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KullaniciDogrula(kullaniciAdi, sifre))
            {
                MessageBox.Show("Giri� ba�ar�l�!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Kullan�c� ad� veya �ifre hatal�!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kay�tolButton_Click(object sender, EventArgs e)
        {
            ShowUserControl(kay�tOlControl);
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
                MessageBox.Show("Hata: " + ex.Message, "Ba�lant� Hatas�", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Belirtilen UserControl'� g�steren y�ntem
        public void ShowUserControl(UserControl control)
        {
            foreach (Control c in this.Controls)
            {
                c.Visible = false;  // T�m kontrolleri gizle
            }
            control.Visible = true;  // Sadece belirtilen kontrol� g�ster
        }

        // Giri� ekran�na d�n��
        public void ShowLoginScreen()
        {
            // T�m kontrolleri temizleriz ve ba�lang�� i�emlerini yeniden y�kleriz
            this.Controls.Clear();
            InitializeComponent();

            // Kay�t_Ol UserControl'� yeniden ekliyoruz
            kay�tOlControl = new Kay�t_Ol(this)
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(kay�tOlControl);

            // Ana_Sayfa UserControl'� yeniden ekliyoruz
            anaSayfaControl = new Ana_Sayfa()
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(anaSayfaControl);
        }
    }
}
