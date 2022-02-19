using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class Stage3_EasyMode : Form
    {
        int sec;

        Score s3EScore;
        Game s3Egame;

        bool goLeft, goRight, goUpper, isGameOver;

        int goUpperMovement;
        int force;
        int playerMovement = 15;

        int enemy1PBMovement = 10;
        int enemy2PBMovement = 10;

        int coin = 0;

        int horizontalMovement = 20;
        int verticalMovement = 20;
        public Stage3_EasyMode()
        {
            InitializeComponent();
            s3EScore = new Score();
            s3Egame = new Game();
            s3Egame.hp = 10;
            s3EScore.score = 0;
            s3Egame.life = 4;
            sec = 0;
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }


            if (e.KeyCode == Keys.Up && goUpper == false)
            {
                goUpper = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUpper = true;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (goUpper == true)
            {
                goUpper = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUpper = false;
            }

            if (e.KeyCode == Keys.Enter && isGameOver == true)

            {
                if (s3Egame.life > 0)
                {
                    RestartGame();
                }
                else
                {
                    FaultResult();
                }
            }
        }


        private void MainGameTimer(object sender, EventArgs e)
        {
            label1.Text = "SCORE: " + s3EScore.score + "\nCOIN: " + coin + "\nLIFE: " + s3Egame.life + "\nHP: " + s3Egame.hp;

            playerPB.Top += goUpperMovement;

            if (goLeft == true)
            {
                playerPB.Left -= playerMovement;
            }
            if (goRight == true)
            {
                playerPB.Left += playerMovement;
            }

            if (goUpper == true && force < 0)
            {
                goUpper = false;
            }
            if (goUpper == true && force >= 0)
            {
                goUpperMovement = -8;
                force -= 1;
            }

            if (goUpper == true)
            {
                playerPB.Top -= goUpperMovement;
            }

            else
            {
                goUpperMovement = 10;
            }


            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "item_great")
                    {
                        if (playerPB.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            s3Egame.hp += 45;
                            x.Visible = false;
                        }
                    }

                    if ((string)x.Tag == "platform")
                    {
                        if (playerPB.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            playerPB.Top = x.Top - playerPB.Height;

                            if ((string)x.Name == "horizontalPlatform" && goLeft == false || (string)x.Name == "horizontalPlatform" && goRight == false)
                            {
                                playerPB.Left -= horizontalMovement;
                            }
                        }

                        x.BringToFront();
                    }

                    if ((string)x.Tag == "coin")
                    {
                        if (playerPB.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            s3EScore.score += 10;
                            coin++;
                        }
                    }

                    if ((string)x.Tag == "enemy")
                    {
                        if (playerPB.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            isGameOver = true;
                            label1.Text = "SCORE: " + s3EScore.score + "\nCOIN: " + coin + "\nLIFE: " + s3Egame.life + "\nHP: " + s3Egame.hp + "\nGAME OVER";
                        }
                    }
                }
            }


            horizontalPlatform.Left -= horizontalMovement;
            if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                horizontalMovement = -horizontalMovement;
            }


            verticalPlatform.Top += verticalMovement;
            if (verticalPlatform.Top < 126 || verticalPlatform.Top > 559)
            {
                verticalMovement = -verticalMovement;
            }

            enemy1PB.Left -= enemy1PBMovement;
            if (enemy1PB.Left < pictureBox7.Left || enemy1PB.Left + enemy1PB.Width > pictureBox7.Left + pictureBox7.Width)
            {
                enemy1PBMovement = -enemy1PBMovement;
            }

            enemy2PB.Left -= enemy2PBMovement;
            if (enemy2PB.Left < pictureBox3.Left || enemy2PB.Left + enemy2PB.Width > pictureBox3.Left + pictureBox3.Width)
            {
                enemy2PBMovement = -enemy2PBMovement;
            }

            if (playerPB.Top + playerPB.Height > this.ClientSize.Height + 50)
            {
                gameTimer.Stop();
                isGameOver = true;
                label1.Text = "SCORE: " + s3EScore.score + "\nCOIN: " + coin + "\nLIFE: " + s3Egame.life + "\nHP: " + s3Egame.hp + "\nGAME OVER";
            }

            if (playerPB.Bounds.IntersectsWith(goalPB.Bounds) && coin == 5)
            {
                gameTimer.Stop();
                label1.Text = "SCORE: " + s3EScore.score + "\nCOIN : " + coin + "\nLIFE: " + s3Egame.life + "\nHP: " + s3Egame.hp + "\nCLEAR";
                SuccessResult();
            }

            if (playerPB.Bounds.IntersectsWith(goalPB.Bounds) && coin < 5)
            {
                label1.Text = "SCORE: " + s3EScore.score + "\nCOIN: " + coin + "\nLIFE: " + s3Egame.life + "\nHP: " + s3Egame.hp + "\n코인 부족";
            }

            if (s3Egame.hp == 100)
            {
                s3Egame.life++;
            }

            
        }

        private void RestartGame()
        {
            goUpper = false;
            goLeft = false;
            goRight = false;

            isGameOver = false;

            s3EScore.score -= 100;
            s3Egame.life -= 1;

            label1.Text = "SCORE: " + s3EScore.score + "\nCOIN: \nLIFE:" + s3Egame.life + "\nHP: " + s3Egame.hp;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && Visible == false)
                {
                    x.Visible = true;
                }
            }

            playerPB.Left = 10;
            playerPB.Top = 591;

            enemy1PB.Left = 167;
            enemy1PB.Top = 263;

            enemy2PB.Left = 202;
            enemy2PB.Top = 521;

            horizontalPlatform.Left = 183;
            horizontalPlatform.Top = 126;

            verticalPlatform.Left = 373;
            verticalPlatform.Top = 471;

            gameTimer.Start();
        }

        private void SuccessResult()
        {
            timer1.Enabled = true;
        }

        private void Stage3_EasyMode_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec == 3)
            {
                Stage3_Result_T S3RT = new Stage3_Result_T();
                S3RT.Show();
                this.Hide();
            }
        }

        private void FaultResult()
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec == 3)
            {
                Stage3_Result_F S3RF = new Stage3_Result_F();
                S3RF.Show();
                this.Hide();
            }
        }
    }
}