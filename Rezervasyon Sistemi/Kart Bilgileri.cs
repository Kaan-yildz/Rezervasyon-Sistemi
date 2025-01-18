using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Rezervasyon_Sistemi.Otel_Rezervasyon;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Rezervasyon_Sistemi
{
    public partial class Kart_Bilgileri : UserControl
    {
        public Kart_Bilgileri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string isimsoyisim = textBox1.Text.Trim();
            string kartnumara = textBox2.Text.Trim();
            string cvv = textBox3.Text.Trim();
            string sonkullanımtarih1 = textBox4.Text.Trim();
            string sonkullanımtarih2 = textBox5.Text.Trim();

            if (string.IsNullOrEmpty(isimsoyisim) || string.IsNullOrEmpty(kartnumara) || string.IsNullOrEmpty(cvv) || string.IsNullOrEmpty(sonkullanımtarih1) || string.IsNullOrEmpty(sonkullanımtarih2))
            {
                MessageBox.Show("herhangi bir kart bilgisi boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DialogResult dialogResult = MessageBox.Show("Ödemeyi onaylıyor musunuz?",
                "Ödeme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Ödeme başarılı! Teşekkürler.", "Onay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ödeme işlemi iptal edildi.", "İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
