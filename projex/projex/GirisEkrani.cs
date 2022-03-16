using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projex
{
    public partial class GirisEkrani : Form
    {
        
        public GirisEkrani()
        {
            InitializeComponent();            
        }
        
        public static int aracHizilimit = 0;
        public static string aracismi=" ";

        private void button1_Click(object sender, EventArgs e)
        {   //Mini Cooper
            Form1 yarisEkrani = new Form1();
            yarisEkrani.pictureBoxcar.Image = Properties.Resources.upCar1;
            
            aracismi = "Mini Cooper";
            aracHizilimit = 20;
            
            yarisEkrani.labelaracismi.Text = aracismi;
            yarisEkrani.labeldeneme.Text = aracHizilimit.ToString();
            yarisEkrani.Show();
            this.Hide();
                       
        }

        private void button2_Click(object sender, EventArgs e)
        {   //BMW Yellow2010
            Form1 yarisEkrani = new Form1();
            yarisEkrani.pictureBoxcar.Image = Properties.Resources.upCar2;

            aracismi = "BMW Yellow2010";
            aracHizilimit = 45;

            yarisEkrani.labelaracismi.Text = aracismi;
            yarisEkrani.labeldeneme.Text = aracHizilimit.ToString();
            yarisEkrani.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {   //Land Rover
            Form1 yarisEkrani = new Form1();
            yarisEkrani.pictureBoxcar.Image = Properties.Resources.upCar3;

            aracismi = "Land Rover";
            aracHizilimit = 40;

            yarisEkrani.labelaracismi.Text = aracismi;
            yarisEkrani.labeldeneme.Text = aracHizilimit.ToString();
            yarisEkrani.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {   //BMW Blue2020
            Form1 yarisEkrani = new Form1();
            yarisEkrani.pictureBoxcar.Image = Properties.Resources.upCar4;

            aracismi = "BMW Blue2020";
            aracHizilimit = 50;

            yarisEkrani.labelaracismi.Text = aracismi;
            yarisEkrani.labeldeneme.Text = aracHizilimit.ToString();
            yarisEkrani.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {   //Mercedes
            Form1 yarisEkrani = new Form1();
            yarisEkrani.pictureBoxcar.Image = Properties.Resources.upCar5;

            aracHizilimit = 40;
            aracismi = "Mercedes";

            yarisEkrani.labelaracismi.Text = aracismi;
            yarisEkrani.labeldeneme.Text = aracHizilimit.ToString();
            yarisEkrani.Show();
            this.Hide();
        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {
            
        }
    }
}
