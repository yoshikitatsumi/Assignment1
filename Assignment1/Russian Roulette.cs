using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{

    public partial class RouletteForm : Form
    {
        RRClass RR = new RRClass();

        public RouletteForm()
        {
            InitializeComponent();
            // initial button control to enable or not
            LoadBtn.Enabled = true;
            SpinBtn.Enabled = false;
            Fire1.Enabled = false;
            fire2.Enabled = false;
        }

        private void RouletteForm_Load(object sender, EventArgs e)
        {
            // Starting message
            Welcome.Text = "Game Start!";
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            RR.Load();
            // setting for button control after loading
            LoadBtn.Enabled = false;
            SpinBtn.Enabled = true;
        }

        private void SpinBtn_Click(object sender, EventArgs e)
        {
            RR.Spin();
            RR.BulletB();
            // setting for button control after spin
            SpinBtn.Enabled = false;
            Fire1.Enabled = true;
            fire2.Enabled = true;
            // total point and shot to show
            Points.Text = RR.Point.ToString();
            Shots.Text = RR.Shot.ToString();
        }

        private void Fire1_Click(object sender, EventArgs e)
        {
            Welcome.Text = "Brave shot!";
            RR.Sound();
            RR.ShotA();
            // setting bullet = 5 as firing bullet to yourself which means dead.
            if (RR.Bullet == 5)
            {
                RR.PointC();
                Result.Text = "LOST!";
                Statement.Text = "DEAD!";
                Fire1.Enabled = false;
                fire2.Enabled = false;
                MessageBox.Show("Game over!");
            }
            // 4 times shot yourself without bullet means remaining shot to be air
            else if (RR.Shot1 == 4)
            {
                RR.PointA();
                Result.Text = "WIN!";
                Statement.Text = "You have airshot for remaining.";
                Fire1.Enabled = false;
                fire2.Enabled = false;
                MessageBox.Show("Game over!");
            }

            RR.PointB();
            RR.BulletA();
            RR.BulletB();

            // total point and shot to show
            Points.Text = RR.Point.ToString();
            Shots.Text = RR.Shot.ToString();
        }

        private void fire2_Click(object sender, EventArgs e)
        {
            Welcome.Text = "Secure shot!";
            RR.Sound();
            RR.ShotB();
            // setting bullet = 5 as firing bullet to Air which means survived.
            if (RR.Bullet == 5)
            {
                RR.PointA();
                Result.Text = "WIN!";
                Statement.Text = "Game Over!";
                Fire1.Enabled = false;
                fire2.Enabled = false;
                MessageBox.Show("Game over!");
            }
            if (RR.Shot2 == 2)
            {
                // air shot is available only twice.
                fire2.Enabled = false;
            }

            RR.BulletA();
            RR.BulletB();

            // total point and shot to show
            Points.Text = RR.Point.ToString();
            Shots.Text = RR.Shot.ToString();
        }
    }
}
