using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace Number143311020
{

    partial class Form1 : Form
    {
        public int mayinsizSay = 0,index;
        public bool oyunDevamediyormu = false, gecit = false;
        public Random rnd = new Random();
        public int sayi = 0, sayaca=0;
        public int sayac = 0, rastgeleSay = 0,mayinSayisi,sure;
        public int[] array = new int[25];
        public Form1()
        {
            InitializeComponent();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sayi >= 0)
            {
                timer1.Interval = 1000;
                timer1.Enabled = true;
                sayaca = sayi--;
                lblSure.Text = "Kalan Süre=" + sayaca.ToString();
                if(sayaca==0)  // Zaman bittiğinde paneli temizler
                {
                    MessageBox.Show("Oyun Bitti.", "Bilgilendirme Penceresi");
                    panel1.Controls.Clear();
                    sure = 0;
                    gecit = false;
                    nmcMayinSayisi.Text = "0";
                    nmcSure.Text = "0";
                    islem();
                }
            }
        }

        public void islem() // Panelin içerisine özellikleriyle beraber 25 tane buton ekler
        {
            
            int count = panel1.Controls.OfType<TextBox>().ToList().Count;
            panel1.BackColor = Color.LightGoldenrodYellow;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sayac++;
                    Button btn = new Button();
                    btn.Text = "";
                    btn.Name = "button" + (count + 1);
                    btn.BackColor = Color.DarkGray;
                    count++;
                    btn.Size = new Size(37, 37);
                    btn.Location = new Point(50 * i, 50 * j);
                    btn.Click += new EventHandler(button1_Click); // Event olayları aynı click e verildi
                    panel1.Controls.Add(btn);
                }
            }

        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            islem(); // Program çalıştığında panelin içini doldurur
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();

            bool hataVer = false;
            
            mayinSayisi = Convert.ToInt32(nmcMayinSayisi.Text);
            sure = Convert.ToInt32(nmcSure.Text);

            if (oyunDevamediyormu) // Oyun devam ederken başla butonuna bastığında buraya girer
            {
                DialogResult secenek = MessageBox.Show("yeni oyun başlatmak istediğinizden emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (secenek == DialogResult.Yes)
                {
                    gecit = true;
                    hataVer = true;
                    temizle();
                    frm.Close();
                }  // Evet seçildi ise
                else if (secenek == DialogResult.No)
                {

                }  // Hayır seçildi ise
            }

            if (mayinSayisi>25 || mayinSayisi == 0 || sure ==0) // Değerler kontrol ediliyor, 1-24 arası girilmedi ise hata verir
            {
                if (hataVer == false)
                    MessageBox.Show("Mayın sayısı 0-24 arası, süre 0'dan büyük olmalıdır.", "Bilgilendirme Penceresi");
                
            } 

            else
            {
                Random r = new Random();
                oyunDevamediyormu = true; // Oyun başladı
                gecit = true; // Sonuç başarılı, işlemlerin yapılmasına izin verildi

                int sayMayin = 0;

                while (sayMayin < mayinSayisi) // Array dizisine mayın sayısı kadar rastgele farklı değerler atar
                {
                    sayi = sure;
                    timer1.Interval = 1000;
                    timer1.Enabled = true;

                    int randomSayi = r.Next(0, 25);
                    if (array.Contains(randomSayi))
                        continue;
                    array[sayMayin] = randomSayi;
                    frm.array[sayMayin] = randomSayi;
                    sayMayin++;
                }
                
                frm.mayinSayisi = mayinSayisi;
                frm.Show();
            }
            
        }

        private void button1_Click(object sender, EventArgs e) // Paneldeki butonları Click fonksiyonu
        {
            int say = 0;

            if(gecit)
            {
                sure = Convert.ToInt32(nmcSure.Text);
                sayi = sure;
                timer1.Interval = 1000;
                timer1.Enabled = true;
                bool door = true;
                Button button = (sender as Button); // Basılan butonun indexi bulunuyor
                index = int.Parse(button.Name.Split('n')[1]);
                Button btn = (Button)(panel1.Controls.Find("button" + index, true)[0]); // Bu indexe karşılık gelen buton bulunuyor panelden

                for (int i = 0; i < mayinSayisi; i++) // Hangi kutucuğun çevresinde kaç tane mayın var hesaplanıp buluyor
                {
                    if (index == array[i] + 1)
                        say++;
                    if (array[i] != 6 && array[i] != 11 && array[i] != 16 && array[i] != 21)
                    {
                        if (index == array[i] - 1)
                            say++;
                    }
                    if(array[i]!=1 && array[i] != 6 && array[i] != 11 && array[i] != 16 && array[i] != 21)
                    {
                        if (index == array[i] + 4)
                            say++;
                    }
                    if (array[i] != 5 && array[i] != 10 && array[i] != 15 && array[i] != 20 && array[i] != 25)
                    {
                        if (index == array[i] - 4)
                            say++;
                    }
                    if (index == array[i] + 5)
                        say++;
                    if (index == array[i] - 5)
                        say++;
                    if (array[i] != 5 && array[i] != 10 && array[i] != 15)
                    {
                        if (index == array[i] + 6)
                            say++;
                    } 
                    if(array[i] != 11 && array[i] != 16 && array[i] != 21)
                    {
                        if (index == array[i] - 6)
                            say++;
                    }
                    
                }


                for (int j = 0; j < mayinSayisi; j++)
                {
                    if (index == array[j]) // Mayını buldu mu ?
                    {
                        btn.BackColor = Color.Red;
                        btn.Text = say.ToString();
                        door = false;
                        MessageBox.Show("Oyun Bitti.", "Bilgilendirme Penceresi");
                        gecit = false;

                        temizle();
                        break;
                    }
                }
                if (door)
                {
                    btn.BackColor = Color.Green;
                    btn.Text = say.ToString();
                    mayinsizSay++;

                }
                if (mayinsizSay == 25 - mayinSayisi)
                {
                    MessageBox.Show("tebrikler kazandınız", "Bilgilendirme Penceresi");
                    gecit = false;
                    temizle();

                }

            }

        }

        private void temizle() // Yeni oyun veya bitmesi durumunda ekranı temizler
        {
            timer1.Enabled = false;
            oyunDevamediyormu = false; // Oyun bitti 
            lblSure.Text = "Kalan Süre=0";
            panel1.Controls.Clear();
            sure = 0;
            mayinsizSay = 0;
            nmcMayinSayisi.Text = "0";
            nmcSure.Text = "0";
            islem();
        }

        /////// ----- SORU 2 ----- /////////

        private void btnBul_Click(object sender, EventArgs e)
        {
            int altSinir, ustSinir;
            altSinir = Convert.ToInt32(txtAltsinir.Text);
            ustSinir = Convert.ToInt32(txtUstsinir.Text);

            for (int i = altSinir; i < ustSinir; i++)
            {
                int a = i / 100;
                int b = (i - a * 100) / 10;
                int c = (i - a * 100 - b * 10);

                int d = a * a * a + b * b * b + c * c * c;

                if (i == d)
                    listBox1.Items.Add(i);
            }
        }
    }
}
