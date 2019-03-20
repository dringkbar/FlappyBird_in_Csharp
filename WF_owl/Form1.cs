using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_owl
{
    public partial class Form1 : Form
    {
        bool jump = false;
        int pipeSpeed = 5;
        int gravity = 5;
        int Inscore = 0;

        public Form1()
        {
            InitializeComponent();
            endText1.Text = "Game Over";
            endText2.Text = "your final score is:" + Inscore;
            endText1.Visible = false;
            endText2.Visible = false;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            flappyOwl.Top += gravity;
            scoreText.Text = "" + Inscore;

            if (pipeBottom.Left < -80)
            {
                pipeBottom.Left = 400;
                Inscore += 1;
            }
            else if (pipeTop.Left < -95)
            {
                pipeTop.Left = 1500;
                Inscore += 1;
            }

            if (flappyOwl.Bounds.IntersectsWith(ground.Bounds)) GameOver();
            if (flappyOwl.Bounds.IntersectsWith(pipeBottom.Bounds)) GameOver();
            if (flappyOwl.Bounds.IntersectsWith(pipeTop.Bounds)) GameOver();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                jump = true;
                gravity = -7;
            }

            if (e.KeyCode == Keys.R)
                Application.Restart();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jump = false;
                gravity = 7;
            }
        }

        private void GameOver()
        {
            gameTimer.Stop();
            endText1.Visible = true;
            endText2.Visible = true;
        }
    }
}
