using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    /*mohammed lotfi al omari(145887)
     wael mohammed ali mallah(136810)
     mohammad Nebras sami fares
     */


    public partial class Form1 : Form
    {
        public int SnailY=0;
        public int SnailX=0;
        public int score1 = 0;
        public int score2 = 0;
        public bool Fup, Fdown, Sup, Sdown;
        public int speed = 15;//for shooters movements
        public bool start = false;
        public int Mv = 1;//minutes vlaue
        public int Sv = 60;//seconds value
        public int Lcounter = 1;//level counter
        public int numOfProfiles = 3;
        public int numOfGames =0;
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sg.SelectedIndex = 1;
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {//end menustrip button
            numOfGames++;
            Sg.SelectedIndex = 0;
            score1 = 0;
            score2 = 0;
            progressBar1.Value = 100;
            progressBar2.Value = 100;
            comboBox3.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            Mv = 1;
            Sv = 60;
            textBox2.Text = score2 + " : " + score1;
            textBox3.Text = " " + Mv + ":" + Sv;
            Lcounter = 1;

        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sg.SelectedIndex = 2;
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sg.SelectedIndex = 2;
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sg.SelectedIndex = 4;
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sg.SelectedIndex = 5;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Blue;
          
            label2.BackColor = Color.Blue;
            panel1.BackColor = Color.Blue;
            textBox4.BackColor = Color.Blue;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Yellow;
            label2.BackColor = Color.Yellow;
            panel1.BackColor = Color.Yellow;
            textBox4.BackColor = Color.Yellow;  
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Green;
            label2.BackColor = Color.Green;
            textBox4.BackColor = Color.Green;
            panel1.BackColor = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Lcounter == 1||Lcounter==3)
            {
                button2.Visible = false;
                button2.Enabled = false;
            }
            else
            {
                button2.Visible = true;
                start = true;
                groupBox2.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {//start on menu
            if(Lcounter==3)
            {
                button4.Visible = false;
                button4.Enabled = false;
            }
            start = true;
            groupBox2.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {//reset menu button
            numOfGames++;
            Sg.SelectedIndex = 1;
            score1 = 0;
            score2 = 0;
            progressBar1.Value = 100;
            progressBar2.Value = 100;
            comboBox3.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;
            Mv = 1;
            Sv = 60;
            textBox2.Text = score2 + " : " + score1;
            textBox3.Text = " " + Mv + ":" + Sv;
            Lcounter = 1;    



        }

        private void button8_Click(object sender, EventArgs e)
        {
            numOfGames++;
            start = true;
            button8.Visible = false;

            if (start == false)
                button8.Visible = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = " " + Mv + ":" + Sv;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {//bullet of shooter one(in the left)
            if (start == true)

            {

                int x = pictureBox4.Location.X;
                int y = pictureBox2.Location.Y;
                if (x >= 440)
                    x = 61;
                pictureBox4.Location = new Point(x + 5, y);
            }


            if (pictureBox4.Bounds.IntersectsWith(pictureBox5.Bounds))
                timer1.Interval = 100;
            if (pictureBox4.Bounds.IntersectsWith(pictureBox6.Bounds))
                timer1.Interval = 10;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {//move palayers (Locations )
            if (start == true)
            {
                if (Fup == true && pictureBox2.Top >= 40)
                {
                    pictureBox2.Top -= speed;
                }
                if (Sup == true && pictureBox1.Top >= 40)
                {
                    pictureBox1.Top -= speed;
                }
                if (Fdown == true && pictureBox2.Top <= 280)
                {
                    pictureBox2.Top += speed;
                }
                if (Sdown == true && pictureBox1.Top <= 280)
                {
                    pictureBox1.Top += speed;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {//bullet of shoter two(in the right)
         //& snail and wind intervals
            if (start == true)
            {
                int x1 = pictureBox3.Location.X;
                int y1 = pictureBox1.Location.Y;
                if (x1 <= 60)
                  
                    x1 = 415;
                pictureBox3.Location = new Point(x1 - 5, y1);
    
            if (pictureBox3.Bounds.IntersectsWith(pictureBox5.Bounds))
                timer3.Interval = 100;
            if (pictureBox3.Bounds.IntersectsWith(pictureBox6.Bounds))
                timer3.Interval = 10;

        }
 }
        private void timer4_Tick(object sender, EventArgs e)
        {//actions when the bullt intersects with the player

            if (start == true)
            {
               

                if (pictureBox3.Bounds.IntersectsWith(pictureBox2.Bounds))
                {//bullet of shooter one(progress bar)
                    score1++;
                    progressBar1.Value = (progressBar1.Value - 20);
                    textBox2.Text = score2 + " : " + score1;
                }
                if (pictureBox4.Bounds.IntersectsWith(pictureBox1.Bounds))
                {//bullet of shooter two (progress bar)
                    score2++;
                    progressBar2.Value = (progressBar2.Value - 20);
                    textBox2.Text = score2+ " : " + score1;

                }
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {//snail &  wind move
            if (start == true)
            {
                if (Lcounter == 2)
{//--------------------------------------------------
//snail
                 
                    {
pictureBox6.Visible = true;
pictureBox5.Visible = true;
int x1 = pictureBox5.Location.X;
int y1 = pictureBox5.Location.Y;
if (y1 >= 900)
y1 = 32;
pictureBox5.Location = new Point(x1 , y1+20);




                        //--------------------------------------------------
                        //wind

                        pictureBox6.Visible = true;
pictureBox5.Visible = true;
int x2 = pictureBox6.Location.X;
int y2 = pictureBox6.Location.Y;
if (y2 >= 900)
y2 = 32;
pictureBox6.Location = new Point(x2, y2 + 15);
                        //----------------------------------------------------
if (pictureBox4.Bounds.IntersectsWith(pictureBox5.Bounds))
                            timer1.Interval = 100;
if (pictureBox4.Bounds.IntersectsWith(pictureBox6.Bounds))
                            timer1.Interval = 10;
if (pictureBox2.Bounds.IntersectsWith(pictureBox5.Bounds))
                            timer3.Interval = 100;
if (pictureBox2.Bounds.IntersectsWith(pictureBox6.Bounds))
                            timer3.Interval = 10;

                    }
                }
                else
                {
                    pictureBox6.Visible = false;
                    pictureBox5.Visible = false;
                }
            }
        }
        

        private void timer6_Tick(object sender, EventArgs e)
        {//time
            if (start == true)
            {
                textBox6.Text = "Level  : " + Lcounter;
                timer6.Enabled = true;
                int a = Sv--;
                textBox3.Text = a.ToString();
                if (a == 1)
                {
                    Sv = 59;
                    Mv--;
                }


                if (Mv == 0 && Sv == 1 || progressBar2.Value == 0 || progressBar1.Value == 0)
                {
                    Lcounter++;
                    Mv = 1;
                    Sv = 60;
                    progressBar1.Value = 100;
                    progressBar2.Value = 100;
                    groupBox2.Visible = true;
                    start = false;
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            if (start == true)
                Visible = false;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {//profiles
            int index = comboBox3.SelectedIndex;
            if (index == 0)//built in
            {
                textBox1.Text = "Sam";
                radioButton2.Checked = true;
                radioButton5.Checked = true;
                textBox4.Text = "Shooter 2 : Sam";
               // comboBox2.Items.RemoveAt(0);


            }
                    
               else if(index==1)//built in
                    {

                        textBox1.Text = "Mike";
                        radioButton2.Checked = true;
                        radioButton5.Checked = true;
                        textBox4.Text = "Shooter 2 : Mike";
                         // comboBox2.Items.RemoveAt(1);

            }
               else if(index==2)//built in
            {

                        textBox1.Text = "Joun";
                        radioButton2.Checked = true;
                        radioButton3.Checked = true;
                        textBox4.Text = "Shooter 2 : Joun";
               // comboBox2.Items.RemoveAt(2);
                       

                    }
            if (index == 3)//new profile
            {
                textBox4.Text = "Shooter 2 : " + textBox1.Text.ToString();
               // comboBox2.Items.RemoveAt(3);

            }
            if (index == 4)//new profile
            {
                textBox5.Text = "Shooter 2 : " + textBox7.Text.ToString();
              //  comboBox2.Items.RemoveAt(4);

            }
            if (index == 5)//new profile
            {
                textBox5.Text = "Shooter 2 : " + textBox1.Text.ToString();
                //  comboBox2.Items.RemoveAt(5);

            }
            if (index == 6)//new profile
            {
                textBox5.Text = "Shooter 2 : " + textBox7.Text.ToString();
                //  comboBox2.Items.RemoveAt(6);

            }


        }
        

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {//player two choose profile
            int index = comboBox2.SelectedIndex;


            if (index == 0)//built in profile
            {
                textBox1.Text = "Sam";
                radioButton7.Checked = true;//for panel color 
                radioButton9.Checked = true;//for gender
                textBox7.Text = "Sam";
                textBox5.Text = "Shooter 1 : Sam";
                //comboBox3.Items.RemoveAt(0);



            }
            else if (index == 1) //built in profile
            {

                textBox1.Text = "Mike";
                radioButton8.Checked = true;
                radioButton10.Checked = true;
                textBox7.Text = "Mike";
                textBox5.Text = "Shooter 1 : Mike";
                //comboBox3.Items.RemoveAt(1);
            }
             else if(index == 2) //built in profile
            {

                        textBox1.Text = "Joun";
                        radioButton6.Checked = true;
                        radioButton9.Checked = true;
                        textBox7.Text = "Joun";
                      textBox5.Text = "Shooter 1 : Joun";
                //comboBox3.Items.RemoveAt(2);


            }
            else if (index == 3)//new profile
            {

                textBox5.Text = "Shooter 1 : " + textBox1.Text.ToString();
                //omboBox3.Items.RemoveAt(3);


            }



            if (index == 4)//new profile
            {
                textBox5.Text = "Shooter 1 : " + textBox7.Text.ToString();
                //comboBox3.Items.RemoveAt(4);

            }
            if (index == 5)//new profile
            {
                textBox5.Text = "Shooter 1 : " + textBox1.Text.ToString();
                //comboBox3.Items.RemoveAt(5);

            }
            if (index == 6)//new profile
            {
                textBox5.Text = "Shooter 1 : " + textBox7.Text.ToString();
                //comboBox3.Items.RemoveAt(6);

            }
        }
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Sg_KeyDown(object sender, KeyEventArgs e)
        {//start press(start the move)
            if (e.KeyCode == Keys.W)
            {
                Fup = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                Sup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                Sdown = true;
            }
            if (e.KeyCode == Keys.S)
            {
                Fdown = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (start == true)
                {

                    start = false;
                    groupBox2.Visible = true;
                }
                else
                {
                    start = true;
                    groupBox2.Visible = false;
                }

            }
          
        }

        private void Sg_KeyUp(object sender, KeyEventArgs e)
        {// stop pressing (stop the move)

            if (e.KeyCode == Keys.W)
            {
                Fup = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                Sup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                Sdown = false;
            }
            if (e.KeyCode == Keys.S)
            {
                Fdown = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sg.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Sg.SelectedIndex = 2;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {//to add a new profile 
            numOfProfiles++;
            comboBox3.Items.Add(textBox1.Text);
            comboBox2.Items.Add(textBox1.Text);
            comboBox2.Items.Add(textBox7.Text);
            Sg.SelectedIndex = 1;
            comboBox3.Items.Add(textBox7.Text);
        }

        private void label18_Click(object sender, EventArgs e)
        {
            label18.Text = numOfGames.ToString();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            label20.Text = numOfProfiles.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {
        
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            if(score1>=score2)
            label18.Text = score1.ToString();

            if (score2 >= score1)
                label18.Text = score2.ToString();
        }

        private void label24_Click(object sender, EventArgs e)
        {
          /*  if (score1 <= score2)
                label18.Text = score1.ToString();

            if (score2 <= score1)
                label18.Text = score2.ToString();*/
        }

        private void label24_Click_1(object sender, EventArgs e)
        {
            if (score1 >= score2)
                label24.Text = score1.ToString();

            if (score2 >= score1)
                label24.Text = score2.ToString();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (score1 < score2)
                label9.Text = score1.ToString();

            if (score2 < score1)
                label9.Text = score2.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click_2(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Blue;
            label2.BackColor = Color.Blue;
            panel2.BackColor = Color.Blue;
            textBox5.BackColor = Color.Blue;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Yellow;

            label2.BackColor = Color.Yellow;
            panel2.BackColor = Color.Yellow;
            textBox5.BackColor = Color.Yellow;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.Green;
            label2.BackColor = Color.Green;
            panel2.BackColor = Color.Green;
            textBox5.BackColor = Color.Green;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (start == true)
                label10.Text = "30";
            else
                label10.Text = "none";
        }

        private void label15_Click(object sender, EventArgs e)
        { if (start == true)
            {

                if (Lcounter == 1)
                    label15.Text = "30";
                else
                    label15.Text = "10";
            }
        else 
                label15.Text = "none";
        }

        private void label17_Click(object sender, EventArgs e)
        {if (start == true)
            {

                label17.Text = "30";
            }
            else
                label17.Text = "none";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Sg.SelectedIndex = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (comboBox2.Text == "choose profile" || comboBox3.Text == "choose profile")

            {
                MessageBox.Show("no profile has been choosen");
            }
            else
            {
                start = false;
                Sg.SelectedIndex = 3;
            }
        }


    }
}
