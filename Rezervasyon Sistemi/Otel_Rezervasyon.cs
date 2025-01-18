using System;
using System.Windows.Forms;

namespace Rezervasyon_Sistemi
{
    public partial class Otel_Rezervasyon : UserControl
    {
        private Kart_Bilgileri kart_BilgileriContol;

        public Otel_Rezervasyon()
        {
            InitializeComponent();

            // Kart Bilgileri kontrolünü gizle
            kart_BilgileriContol = new Kart_Bilgileri
            {
                Dock = DockStyle.Fill,
                Visible = false  // Başlangıçta görünür değil
            };
            this.Controls.Add(kart_BilgileriContol);
        }

        // Yalnızca belirtilen kontrolü görünür yapar
        private void ShowOnlyControl(UserControl control)
        {
            foreach (Control c in this.Controls)
            {
                c.Visible = false;  
            }
            control.Visible = true; 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowOnlyControl(kart_BilgileriContol); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowOnlyControl(kart_BilgileriContol);  
        }
    }
}
