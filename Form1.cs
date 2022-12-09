using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Съедобное_несъедобное
{
    public partial class Form1 : Form
    {
        int time = 30;
        int points;
        int record;
        bool game = false;
        List<Image> imgs = new List<Image> { Properties.Resources.pizza, Properties.Resources.burger, Properties.Resources.boot, Properties.Resources.chair};
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = time.ToString();
            
            timer1.Interval = 900;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if(game)
            {

            }

            if(time < 1)
            {
                timer1.Stop();
                points = 0;
                time = 31;
                MessageBox.Show("Время вышло!\n" + label2.Text + label3.Text);
                button1.Text = "Начать";
                game = false;
                
            }
            time -= 1;
            if(points > record) record = points;
            label1.Text = time.ToString();
            label3.Text = record.ToString();
            label5.Text = points.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            points = 0;
            time = 30;
            if (!game)
            {
                timer1.Start();
                button1.Text = "Заново";
                game = true;
            }
            else
            {
                //timer1.Stop();
                //points = 0;
                //time = 30;
                game = false;
            }

            setImages();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image == imgs[0] || pictureBox1.Image == imgs[1])
            {
                points += 1;
            }
            setImages();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == imgs[0] || pictureBox2.Image == imgs[1])
            {
                points += 1;
            }
            setImages();
        }

        
        private void setImages()
        {
            pictureBox1.Image = imgs[r.Next(imgs.Count())];
            pictureBox2.Image = imgs[r.Next(imgs.Count())];
            if(pictureBox1.Image == pictureBox2.Image) setImages();
            if (pictureBox1.Image == imgs[2] || pictureBox1.Image == imgs[3] && pictureBox2.Image == imgs[2] || pictureBox2.Image == imgs[3]) setImages();
            //if (pictureBox1.Image == imgs[0] || pictureBox1.Image == imgs[1] && pictureBox2.Image == imgs[0] || pictureBox2.Image == imgs[1]) setImages();
        }
    }
}
