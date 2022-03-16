using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace projex
{
    public partial class Form1 : Form
    {
        public GirisEkrani grsEkran;
        public GirisEkrani yeniEkran;

        public Form1()
        {
            grsEkran = new GirisEkrani();
            yeniEkran = new GirisEkrani();
            InitializeComponent();                      
        }

        public int alinanYol = 0;
        public int durum = 0;
        public int turboKalan = 110;

        private void Form1_Load(object sender, EventArgs e)
        {
            grsEkran.Close();
            labelHighScore.Text = Settings1.Default.HighScore.ToString();
            for (var i = 0; i < rndCar.Length; i++)
            {

                rndCar[i] = new RandomCar();

            }

            rndCar[0].time = true;
            
        }

        class RandomCar
        {

            public bool fakeHaveCar = false;
            public PictureBox fakeCar;
            public bool time = false;
            
        }

        RandomCar[] rndCar = new RandomCar[2];

        Random R = new Random();

        void RandomArabaGetir(PictureBox pb)
        {

            int rnd = R.Next(0, 5);

            switch (rnd)
            {
                case 0:
                    pb.Image = Properties.Resources.downCar1;
                    break;

                case 1:
                    pb.Image = Properties.Resources.downCar2;
                    break;

                case 2:
                    pb.Image = Properties.Resources.downCar3;
                    break;

                case 3:
                    pb.Image = Properties.Resources.downCar4;
                    break;

                case 4:
                    pb.Image = Properties.Resources.downCar5;
                    break;

            }

            pb.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           
            for (int i = 0; i < rndCar.Length; i++)
            {
                
                if (!rndCar[i].fakeHaveCar && rndCar[i].time)
                {
                    rndCar[i].fakeCar = new PictureBox();
                    RandomArabaGetir(rndCar[i].fakeCar);
                    rndCar[i].fakeCar.Size = new Size(80, 120);
                    rndCar[i].fakeCar.Top = -rndCar[i].fakeCar.Height;

                    int yerlestir = R.Next(0, 4);

                    if (yerlestir == 0)
                    {
                        rndCar[i].fakeCar.Left = 50;
                    }

                    else if (yerlestir == 1)
                    {
                        rndCar[i].fakeCar.Left = 195;
                    }

                    else if (yerlestir == 2)
                    {
                        rndCar[i].fakeCar.Left = 350;
                    }

                    else if (yerlestir == 3)
                    {
                        rndCar[i].fakeCar.Left = 490;
                    }

                    this.Controls.Add(rndCar[i].fakeCar);
                    rndCar[i].fakeHaveCar = true;

                }

                else
                {
                    if (rndCar[i].time)
                    {
                        rndCar[i].fakeCar.Top += genelhiz;

                        if (rndCar[i].fakeCar.Top >= 154)
                        {
                            for (int j = 0; j < rndCar.Length; j++)
                            {
                                if (!rndCar[j].time)
                                {
                                    rndCar[j].time = true;
                                    break;
                                }
                            }
                        }
                        if (rndCar[i].fakeCar.Top >= this.Height - 20)
                        {
                            rndCar[i].fakeCar.Dispose();
                            rndCar[i].fakeHaveCar = false;
                            rndCar[i].time = false;
                        }
                    }
                }

                if (rndCar[i].time)
                {
                    float MutlakX = Math.Abs((pictureBoxcar.Left + (pictureBoxcar.Width / 2)) - (rndCar[i].fakeCar.Left + (rndCar[i].fakeCar.Width / 2)));
                    float MutlakY = Math.Abs((pictureBoxcar.Top + (pictureBoxcar.Height / 2)) - (rndCar[i].fakeCar.Top + (rndCar[i].fakeCar.Height / 2)));
                    float FarkGenislik = (pictureBoxcar.Width / 2) + (rndCar[i].fakeCar.Width / 2);
                    float FarkYukseklik = (pictureBoxcar.Height / 2) + (rndCar[i].fakeCar.Height / 2);

                    if ((FarkGenislik > MutlakX) && (FarkYukseklik > MutlakY))
                    {

                        timerRndCar.Enabled = false;
                        timerSerit.Enabled = false;
                        timeralinanyol.Enabled = false;
                     
                        DialogResult replay = MessageBox.Show("Kaza Yapıldı Tekrar Oynamak İstermisiniz ?"," Kaza", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        labelHighScore.Text = Settings1.Default.HighScore.ToString()+"m";
                        

                        if (replay == DialogResult.Yes)
                        {
                            timerRndCar.Enabled = true;
                            timerSerit.Enabled = true;
                            timeralinanyol.Enabled = true;

                            if (alinanYol > Settings1.Default.HighScore)
                            {
                                Settings1.Default.HighScore = alinanYol;
                                labelHighScore.Text = Settings1.Default.HighScore.ToString();
                            }


                            this.Close();
                            yeniEkran.Hide();
                            yeniEkran.Show();
                            
                            
                            if (Settings1.Default.HighScore > 100 && Settings1.Default.HighScore<200)
                            {
                                yeniEkran.button3.Enabled = true;
                                
                            }

                            if (Settings1.Default.HighScore >= 200 && Settings1.Default.HighScore < 300)
                            {
                                yeniEkran.button3.Enabled = true;
                                yeniEkran.button5.Enabled = true;

                            }
                            if (Settings1.Default.HighScore >= 300 )
                            {
                                yeniEkran.button2.Enabled = true;
                                yeniEkran.button3.Enabled = true;
                                yeniEkran.button5.Enabled = true;

                            }

                            if (Settings1.Default.HighScore >= 500)
                            {
                                yeniEkran.button2.Enabled = true;
                                yeniEkran.button3.Enabled = true;
                                yeniEkran.button5.Enabled = true;
                                yeniEkran.button4.Enabled = true;


                            }
                        }

                        else if (replay == DialogResult.No)
                        {
                            this.Close();
                            Application.Exit();
                        }
                    }
                }
            }
        }


                int genelhiz = 5;

                private void Form1_KeyDown(object sender, KeyEventArgs e)
                {

                    int x = pictureBoxcar.Location.X;
                    int y = pictureBoxcar.Location.Y;



                    if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                    {
                        if (x < 500)
                        {
                            x = x + 30;
                            pictureBoxcar.Location = new Point(x, y);
                            durum = 2;

                        }
                    }

                    else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                    {
                        if (x > 30)
                        {
                            x = x - 30;
                            pictureBoxcar.Location = new Point(x, y);
                            durum = 2;
                        }

                    }

                    else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                    {
                        if (genelhiz < Convert.ToInt16(labeldeneme.Text))
                        {
                            genelhiz = genelhiz + 1;

                             durum = 1;
                        }  
                    }

                    else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                    {
                         
                         if (genelhiz > 5)
                         {
                              genelhiz = genelhiz - 1;

                              durum = 0;
                         }
                         
                }

                    else if (e.KeyCode == Keys.Space || e.KeyCode == Keys.T)
                    {
                        
                            if (genelhiz < Convert.ToInt16(labeldeneme.Text) + 10)
                            {
                                genelhiz = genelhiz + 1;
                            }
                        
                    }
                }


                private void timer1_Tick(object sender, EventArgs e)
                {
                    
                    seritHareketi(genelhiz);
                    labelhiz.Text = (5 * genelhiz).ToString() + " Km/s";

                    if (genelhiz == Convert.ToInt16(labeldeneme.Text))
                    {
                        labelhizUyarisi.Text = "Maksimum Hızdasınız";
                    }

                    else if (genelhiz == 5)
                    {
                        labelhizUyarisi.Text = "Minimum Hızdasınız";
                    }

                    else if(genelhiz> Convert.ToInt16(labeldeneme.Text))
                    {
        
                        labelhizUyarisi.Text = "Turbo Moddasınız";
                        labelTurboKalan.Visible = true;
                        turboKalan--;
                        labelTurboKalan.Text = (turboKalan/10).ToString();


                        if (turboKalan <= 0)
                        {
                            genelhiz = Convert.ToInt16(labeldeneme.Text);
                            turboKalan = 100;
                           labelTurboKalan.Visible = false;
                        }
                    }

                    else
                    {
                        labelhizUyarisi.Text = "";
                    }
                }

                void seritHareketi(int seritHizi)
                {

                    if (labelsag1.Location.Y >= 500)
                    {
                        labelsag1.Top = 10;
                        labelorta1.Top = 10;
                        labelsol1.Top = 10;
                    }

                    else if (labelsag2.Location.Y >= 500)
                    {
                        labelsag2.Top = 10;
                        labelorta2.Top = 10;
                        labelsol2.Top = 10;
                    }

                    else if (labelsag3.Location.Y >= 500)
                    {
                        labelsag3.Top = 10;
                        labelorta3.Top = 10;
                        labelsol3.Top = 10;
                    }

                    else if (labelsag4.Location.Y >= 500)
                    {
                        labelsag4.Top = 10;
                        labelorta4.Top = 10;
                        labelsol4.Top = 10;
                    }

                    else
                    {
                        labelsag1.Top += seritHizi;
                        labelorta1.Top += seritHizi;
                        labelsol1.Top += seritHizi;

                        labelsag2.Top += seritHizi;
                        labelorta2.Top += seritHizi;
                        labelsol2.Top += seritHizi;

                        labelsag3.Top += seritHizi;
                        labelorta3.Top += seritHizi;
                        labelsol3.Top += seritHizi;

                        labelsag4.Top += seritHizi;
                        labelorta4.Top += seritHizi;
                        labelsol4.Top += seritHizi;
                    }
                }

        private void timeralinanyol_Tick(object sender, EventArgs e)
        {
          
            alinanYol++;
   
            labelalinanYol.Text = alinanYol.ToString()+"m";

            timeralinanyol.Interval = 1000 - (16 * genelhiz);

            /*  if(timeralinanyol.Interval > 3*genelhiz && durum == 1)
              {
                  timeralinanyol.Interval = timeralinanyol.Interval - 3 * genelhiz;
              }

              else if(timeralinanyol.Interval > 3*genelhiz && durum == 0)
              {
                  timeralinanyol.Interval = timeralinanyol.Interval + 3 * genelhiz;
              } */

        }

 
    }
} 
