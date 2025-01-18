namespace Rezervasyon_Sistemi
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            girişyapButton = new Button();
            kullanıcıAdı_label = new Label();
            şifre_label = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            linkLabel1 = new LinkLabel();
            kayıtolButton = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // girişyapButton
            // 
            girişyapButton.BackColor = Color.FromArgb(255, 224, 192);
            girişyapButton.Cursor = Cursors.Hand;
            girişyapButton.Location = new Point(315, 362);
            girişyapButton.Name = "girişyapButton";
            girişyapButton.Size = new Size(94, 29);
            girişyapButton.TabIndex = 0;
            girişyapButton.Text = "GİRİŞ";
            girişyapButton.UseVisualStyleBackColor = false;
            girişyapButton.Click += button1_Click;
            // 
            // kullanıcıAdı_label
            // 
            kullanıcıAdı_label.AutoSize = true;
            kullanıcıAdı_label.BackColor = Color.Transparent;
            kullanıcıAdı_label.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            kullanıcıAdı_label.Location = new Point(170, 258);
            kullanıcıAdı_label.Name = "kullanıcıAdı_label";
            kullanıcıAdı_label.Size = new Size(152, 25);
            kullanıcıAdı_label.TabIndex = 1;
            kullanıcıAdı_label.Text = "KULLANICI ADI :";
            // 
            // şifre_label
            // 
            şifre_label.AutoSize = true;
            şifre_label.BackColor = Color.Transparent;
            şifre_label.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            şifre_label.Location = new Point(253, 306);
            şifre_label.Name = "şifre_label";
            şifre_label.Size = new Size(69, 25);
            şifre_label.TabIndex = 2;
            şifre_label.Text = "ŞİFRE :";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.GradientInactiveCaption;
            textBox1.Location = new Point(328, 258);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(221, 27);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.GradientInactiveCaption;
            textBox2.Location = new Point(328, 307);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(221, 27);
            textBox2.TabIndex = 4;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(137, 371);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(121, 20);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Şifremi Unuttum!";
            // 
            // kayıtolButton
            // 
            kayıtolButton.BackColor = Color.FromArgb(255, 224, 192);
            kayıtolButton.Cursor = Cursors.Hand;
            kayıtolButton.Location = new Point(444, 362);
            kayıtolButton.Name = "kayıtolButton";
            kayıtolButton.Size = new Size(94, 29);
            kayıtolButton.TabIndex = 7;
            kayıtolButton.Text = "KAYIT OL";
            kayıtolButton.UseVisualStyleBackColor = false;
            kayıtolButton.Click += kayıtolButton_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(315, 42);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(242, 178);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(947, 533);
            Controls.Add(pictureBox2);
            Controls.Add(kayıtolButton);
            Controls.Add(linkLabel1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(şifre_label);
            Controls.Add(kullanıcıAdı_label);
            Controls.Add(girişyapButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "REZERVASYON";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button girişyapButton;
        private System.Windows.Forms.Label kullanıcıAdı_label;
        private System.Windows.Forms.Label şifre_label;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button kayıtolButton;
        private PictureBox pictureBox2;
    }
}
