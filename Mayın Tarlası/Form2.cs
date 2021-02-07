using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number143311020
{
    public partial class Form2 : Form
    {
        public int[] array = new int[25];
        public int sayac = 0, say = 0, mayinSayisi;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 form = new Form1();

            int count = panel1.Controls.OfType<TextBox>().ToList().Count;
            panel1.BackColor = Color.LightGoldenrodYellow;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++) // Panelin içine 25 tane buton eklenir, form 1 den bilgiler alınarak içleriona göre doldurulur.
                {
                    sayac++;
                    bool kotrol = false;
                    Button btn = new Button();
                    btn.Name = "button" + (count + 1);
                    count++;
                    btn.Size = new Size(37, 37);
                    btn.Location = new Point(50 * i, 50 * j);

                    for (int r = 0; r < 25; r++)
                    {
                        if (sayac == array[r])
                        {
                            kotrol = true;
                            break;
                        }
                    }

                    if(kotrol)
                        btn.BackColor = Color.Red;
                    else
                        btn.BackColor = Color.Green;


                    for (int t = 0; t < mayinSayisi; t++)
                    {
                        if (sayac == array[t] + 1)
                            say++;
                        if (array[i] != 6 && array[t] != 11 && array[t] != 16 && array[t] != 21)
                        {
                            if (sayac == array[t] - 1)
                                say++;
                        }
                        if (array[t] != 1 && array[t] != 6 && array[t] != 11 && array[t] != 16 && array[t] != 21)
                        {
                            if (sayac == array[t] + 4)
                                say++;
                        }
                        if (array[t] != 5 && array[t] != 10 && array[t] != 15 && array[t] != 20 && array[t] != 25)
                        {
                            if (sayac == array[t] - 4)
                                say++;
                        }
                        if (sayac == array[t] + 5)
                            say++;
                        if (sayac == array[t] - 5)
                            say++;
                        if (array[i] != 5 && array[t] != 10 && array[t] != 15)
                        {
                            if (sayac == array[t] + 6)
                                say++;
                        }
                        if (array[t] != 11 && array[t] != 16 && array[t] != 21)
                        {
                            if (sayac == array[t] - 6)
                                say++;
                        }

                    }
                    btn.Text = say.ToString();
                    say = 0;
                    panel1.Controls.Add(btn);
                }
            }


        }


    }
}
