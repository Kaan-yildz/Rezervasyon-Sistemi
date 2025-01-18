using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rezervasyon_Sistemi
{
    public partial class Araç_Kiralama : UserControl
    {
        private Kart_Bilgileri kart_BilgileriControl;
        public Araç_Kiralama()
        {
            InitializeComponent();

            kart_BilgileriControl = new Kart_Bilgileri
            {
                Dock = DockStyle.Fill,
                Visible = false
            };

            this.Controls.Add(kart_BilgileriControl);
        }

        private void ShowOnlyControl(Kart_Bilgileri control)
        {
            foreach (Control c in this.Controls)
            {
                c.Visible = (c == control);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowOnlyControl(kart_BilgileriControl);
        }
    }
}
