//Jade Legare
//Final Project

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Form1 : Form
    {
        public int lives;
        public int score;

        public Rectangle player;
        public Rectangle hurdle;
        public Rectangle goal;
        public int ylimit, ground;
        public bool jumping;
        public int upper, gravity;

        public int hurdleDirX = 1;
        public int hurdleMoveX = 1;

        public int goalDirX = 1;
        public int goalMoveX = 1;

        int upper_inc = 18;
        int grav_inc = 5;

        //set fairy image
        private Image character = Image.FromFile(Application.StartupPath + @"\fairy.jpg", true);
        //enemy image array
        private Image[] enemy;
        //dog image array
        private Image[] dog;

            //timer
        public Timer jumptimer;
        public Timer picTimer;

        int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lives = 3;
            score = 0;

            //set enemy array to hold 3
            enemy = new Image[3];
            //set each array value to an image of a dragon
           enemy[0] = Image.FromFile(Application.StartupPath + @"\dragon.jpg", true);
           enemy[1] = Image.FromFile(Application.StartupPath + @"\dragon2.jpg", true);
           enemy[2] = Image.FromFile(Application.StartupPath + @"\dragon3.jpg", true);
            
            //set dog array to hold 5
           dog = new Image[5];
            //set each vlue to an image of a dog
           dog[0] = Image.FromFile(Application.StartupPath + @"\dog.jpg", true);
           dog[1] = Image.FromFile(Application.StartupPath + @"\dog1.jpg", true);
           dog[2] = Image.FromFile(Application.StartupPath + @"\dog2.jpg", true);
           dog[3] = Image.FromFile(Application.StartupPath + @"\dog3.jpg", true);
           dog[4] = Image.FromFile(Application.StartupPath + @"\dog4.jpg", true);


            //set y limit
            ylimit = this.Height - 40;
            ground = this.Height - 60;

            //set to not jump at start
            jumping = false;

            //set up player
            player = new Rectangle(50, ground, 20, 20);
            hurdle = new Rectangle(0, this.Height-50, 10, 10);
            goal = new Rectangle(0, this.Height - 50, 10, 10);

            //event to draw on screen adn key down
            this.DoubleBuffered = true;
            this.Paint +=new PaintEventHandler(Form1_Paint);
            this.KeyDown +=new KeyEventHandler(Form1_KeyDown);

            picTimer = new Timer();
            picTimer.Interval = 5000;
            picTimer.Tick += new EventHandler(picTimer_Tick);
            picTimer.Start();
            this.Invalidate();

            //set up timer
            jumptimer = new Timer();
            jumptimer.Interval = 1000/60;
            jumptimer.Tick +=new EventHandler(jumptimer_Tick);
            jumptimer.Start();
            this.Invalidate();
        }

        void picTimer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            counter++;
                if (counter == 3)
                {
                    counter = 0;
                }
          
        }

void  jumptimer_Tick(object sender, EventArgs e)
{
 	//throw new NotImplementedException();
    //refresh the screen
    this.Invalidate();

    //if jumping
    if (jumping)
    {
        //if not at ylimit
        if (player.Bottom <= ylimit)
        {
            //keep jumping
            jumping = true;

            //move player up by upper value
            player.Y -= upper;

            //move player down by gravity value
            player.Y += gravity;

            //if still pos upper value
            //down by one to rech peak of jump
            if (upper >= 0)
            {
                --upper;
            }
            //if hit ylimit
            if (player.Bottom >= ylimit)
            {
                //stop jumping
                jumping = false;

                //set bottom of player to ylimit
                player.Y = ground; 

                //make upper 0
                upper = 0;

                //make gravity zero
                gravity = 0;
            }
        }
    }
    if (goal.Left < 0)
    {
        goalDirX = 1;
    }
    else if (goal.Right > (this.Width - 30))
    {
        goalDirX = -1;
    }

    //move goal
  //  goal.X += (goalMoveX * goalDirX);



//jump over hurdle 
    if (hurdle.Left < 0)
    {
        hurdleDirX = 1;
    }
    else if (hurdle.Right > (this.Width - 20))
    {
        hurdleDirX = -1;
    }

    //move the hurdle
    hurdle.X += (hurdleMoveX * hurdleDirX);

    //fix the bottom in case window resize
    hurdle.Y = this.Height - 50;
    goal.Y = this.Height - 50;
    ylimit = this.Height - 40;
    ground = this.Height - 60;

    //test for collision 
    if ((player.Bottom >= hurdle.Top) && (((player.Right >= hurdle.Left) 
        && (player.Right<= hurdle.Right)) ||
((player.Left <= hurdle.Right) && (player.Left >= hurdle.Left))))

    {

        lives = lives - 1;
        //you got hit
        jumptimer.Stop();
        DialogResult result1 = MessageBox.Show("You died! Try Again?" , "DEAD",MessageBoxButtons.YesNo);
        if (result1 == DialogResult.Yes)
        {
            //restart

            //stop jumping
            jumping = false;

            //set bottom of player to ylimit
            player.Y = ground;

            //make upper 0
            upper = 0;

            //make gravity zero
            gravity = 0;

            //move hurtle to restart
            hurdle.X = this.Width /2;

            //start the timer again
            jumptimer.Start();

            //redraw
            this.Invalidate();
        }
        else
        {
            Application.Exit();
        }

    }

     //test for collision 
    if ((player.Bottom >= goal.Top) && (((player.Right >= goal.Left) 
        && (player.Right<= goal.Right)) ||
((player.Left <= goal.Right) && (player.Left >= goal.Left))))

    {
        score = score + 100;

    }

}





void  Form1_KeyDown(object sender, KeyEventArgs e)
{
 	//throw new NotImplementedException();

    //when press space key
    if (e.KeyCode == Keys.Space)
    {
        // if not jumping 
        if (!jumping)
        {
            //start jumping 
            jumping = true;

            //Set upper value 
            upper = upper_inc;

            //set gravity value 
            gravity = grav_inc;
        }
    }
    //keys to move jumping box
    else if (e.KeyCode == Keys.Z)
    {
        player.X -= 5;
    }
    else if (e.KeyCode == Keys.X)
    {
        player.X += 5;
    }
    //keys to platy with jump height and gravity
    else if (e.KeyCode == Keys.Q)
    {
        upper_inc ++;
    }
    else if (e.KeyCode == Keys.A)
    {
        upper_inc --;
    }
    else if(e.KeyCode == Keys.W)
    {
        grav_inc++;
    }
    else if (e.KeyCode == Keys.S)
    {
        grav_inc--;
    }
    else if (e.KeyCode == Keys.P)
    {
        ;
    }

}

void  Form1_Paint(object sender, PaintEventArgs e)
{
 	//throw new NotImplementedException();
    // create pen
    Pen colorpen1 = new Pen(Color.Aquamarine, 3);
    Pen colorpen2 = new Pen (Color.Coral, 3);
    
    //set to draw new rectangle 
    e.Graphics.DrawRectangle(colorpen1, player);
    //draw image
    e.Graphics.DrawImage(character, player);
    //draw rectangle 
    e.Graphics.DrawRectangle(colorpen2, hurdle);
    e.Graphics.DrawImage(enemy[counter], hurdle);
    //draw rectangle
    e.Graphics.DrawRectangle(colorpen2, goal);
    e.Graphics.DrawImage(dog[counter], goal);
}

private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}
    }
}
