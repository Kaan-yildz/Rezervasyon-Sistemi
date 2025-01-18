using System;
using System.Windows.Forms;

namespace Rezervasyon_Sistemi
{
    public partial class Ana_Sayfa : UserControl
    {
        private Otel_Rezervasyon otelRezervasyonControl;
        private Araç_Kiralama araçKiralamaControl;

        public Ana_Sayfa()
        {
            InitializeComponent();

            // Otel_Rezervasyon kontrolünü gizle
            otelRezervasyonControl = new Otel_Rezervasyon
            {
                Dock = DockStyle.Fill,
                Visible = false  // Başlangıçta görünür değil
            };
            this.Controls.Add(otelRezervasyonControl);

            araçKiralamaControl = new Araç_Kiralama
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(araçKiralamaControl);
        }

        // Yalnızca belirtilen sayfayı görünür yapar
        public void ShowOnlyControl(UserControl control)
        {
            foreach (Control c in this.Controls)
            {
                c.Visible = false;  // Tüm kontrolleri gizliyorux
            }
            control.Visible = true;  // Yalnızca belirtilen kontrolü gösterimi
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ShowOnlyControl(otelRezervasyonControl); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowOnlyControl(araçKiralamaControl); 
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.Parent;
            form1.ShowLoginScreen();
        }    
    }
}
