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
        // initial variable setting
        public static int bullet = 0; // bullet place 0-5
        public static int shot = 0; // shot total 1-6
        public static int shot1 = 0; // shot for yourself
        public static int shot2 = 0; // shot for air
        public static int point = 0; // points 
        public RouletteForm()
        {
            InitializeComponent();
            // initial button control to enable or not
            LoadBtn.Enabled = true;
            SpinBtn.Enabled = false;
            Fire1.Enabled = false;
            fire2.Enabled = false;
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            // 0 setting for bullet loading
            bullet = 0;
            // setting for button control after loading
            LoadBtn.Enabled = false;
            SpinBtn.Enabled = true;
        }

        private void SpinBtn_Click(object sender, EventArgs e)
        {
            // random setting for bullet loading
            Random rand = new Random();
            bullet = rand.Next(0, 6);
            // setting for button control after spin
            SpinBtn.Enabled = false;
            Fire1.Enabled = true;
            fire2.Enabled = true;
            // checking actual bullet number in the console
            Console.WriteLine("Bullet is at: " + bullet);
        }

        private void Fire1_Click(object sender, EventArgs e)
        {
            // sound starts after clicking Fire1 (Fire yourself).
            SoundPlayer player = new SoundPlayer(ResourcesFile.Sound);
            player.Play();

            // setting bullet = 5 as firing bullet which means dead.
            if (bullet == 5)
            {
                Result.Text = "LOSE";
                Statement.Text = "Dead!";
                point = point - 5;
                Fire1.Enabled = false;
                fire2.Enabled = false;
            }
            else
            {
                // survived case as adding one point 
                point = point + 1;
            }

            // 5 times shot yourself without bullet means remaining shot to be air
            if (shot1 == 4)
            {
                Result.Text = "WIN!";
                Statement.Text = "You have airshot for remaining.";
                point = point + 10;
                Fire1.Enabled = false;
                fire2.Enabled = false;
            }

            // bullet shifts next location
            bullet = bullet + 1;
            if (bullet < 6)
            {
                Console.WriteLine("Bullet is at: " + bullet);
            }
            // total point to show
            Points.Text = point.ToString();
            // calculationg total shot counts and display
            shot1 = shot1 + 1;
            shot = shot1 + shot2;
            Shots.Text = shot.ToString();
        }

        private void fire2_Click(object sender, EventArgs e)
        {
            // sound starts after clicking fire2 (Fire air).
            SoundPlayer player = new SoundPlayer(ResourcesFile.Sound);
            player.Play();

            // bullet used to air which means win
            if (bullet == 5)
            {
                Result.Text = "WIN!";
                Statement.Text = "Game Over!";
                point = point + 10;
                Fire1.Enabled = false;
                fire2.Enabled = false;
            }

            if (shot2 == 1)
            {
                // air shot is available only twice.
                fire2.Enabled = false;
            }
            // airshot without bullet twice which means lost
            if (shot2 >= 3)
            {
                Result.Text = "LOST";
                Statement.Text = "Airshot twice.";
                point = point - 5;
                Fire1.Enabled = false;
                fire2.Enabled = false;
            }

            // bullet shifts next location
            bullet = bullet + 1;
            if (bullet < 6)
            {
                Console.WriteLine("Bullet is at: " + bullet);
            }
            // total point to show
            Points.Text = point.ToString();
            // counting shot total
            shot2 = shot2 + 1;
            shot = shot1 + shot2;
            Shots.Text = shot.ToString();
        }

        public void MyMethod()
        {
        RRClass myObj = new RRClass();
        Welcome.Text = myObj.starttitle;

        }

        private void RouletteForm_Load(object sender, EventArgs e)
        {
            MyMethod();
        }


    }

}
