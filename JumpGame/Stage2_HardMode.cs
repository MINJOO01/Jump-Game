using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class Stage2_HardMode : Form
    {
        int sec;

        Score s2HScore;
        Game s2Hgame;

        bool goLeft, goRight, goUpper, isGameOver;

        int goUpperMovement;
        int force;
        int playerMovement = 15;

        int enemy1PBMovement = 10;
        int enemy2PBMovement = 10;

        int coin = 0;

        int horizontalMovement = 20;
        int verticalMovement = 20;

        public Stage2_HardMode()
        {
            InitializeComponent();

            s2HScore = new Score();
            s2Hgame = new Game();

            s2HScore.score = 0;
            s2Hgame.life = 3;
            s2Hgame.second = 60;

            sec = 0;
        }

        private void MainGameTimer(object sender, EventArgs e)
        {
            secTimer.Enabled = true;
            label1.Text = "SECOND: " + s2Hgame.second + "\nSCORE: " + s2HScore.score + "\nCOIN: " + coin + "\nLIFE: " + s2Hgame.life;

            playerPB.Top += goUpperMovement;
            if(goLeft == true)
            {
                playerPB.Left -= playerMovement;
            }
            if(goRight == true)
            {
                playerPB.Left += playerMovement;
            }
            if(goUpper == true && force<0)
            {
                goUpper = false;
            }
            if(goUpper == true && force>=0)
            {
                goUpperMovement = -8;
                force -= 1;
            }
            if(goUpper == true)
            {
                playerPB.Top -= goUpperMovement;
            }
            else
            {
                goUpperMovement = 10;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag == "platform")
                    {
                        if(playerPB.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            playerPB.Top = x.Top - playerPB.Height;
                            if((string)x.Name == "horizontalPlatform" && goLeft==false||(string)x.Name =="horizontalPlatform"&&goRight==false)
                            {
                                playerPB.Left -= horizontalMovement;
                            }                         
                        }
                        x.BringToFront();
                    }
                }
                if((string)x.Tag == "enemy")
                {
                    if(playerPB.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        isGameOver = true;
                        label1.Text = "SECOND: " + s2Hgame.second + "\nSCORE: " + s2HScore.score + "\nCOIN: " + coin + "\nLIFE: " + s2Hgame.life+"\nGAME OVER";
                    }
                }
                if ((string)x.Tag == "coin")
                {
                    if (playerPB.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        s2HScore.score += 10;
                        coin++;
                    }
                }
                if((string)x.Tag == "item_worst")
                {
                    if(playerPB.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                    {
                        x.Visible = false;
                        s2Hgame.second -= 30;
                    }
                }
            }

            horizontalPlatform.Left -= horizontalMovement;
            if(horizontalPlatform.Left<0 || horizontalPlatform.Left + horizontalPlatform.Width>this.ClientSize.Width)
            {
                horizontalMovement = -horizontalMovement;
            }

            verticalPlatform.Top += verticalMovement;
            if(verticalPlatform.Top<126||verticalPlatform.Top>559)
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
                label1.Text = "SECOND: " + s2Hgame.second + "\nSCORE: " + s2HScore.score + "\nCOIN: " + coin + "\nLIFE: " + s2Hgame.life + "\nGAMEOVER";

            }

            if(playerPB.Bounds.IntersectsWith(goalPB.Bounds)&&coin==16)
            {
                gameTimer.Stop();
                label1.Text = "SECOND: " + s2Hgame.second + "\nSCORE: " + s2HScore.score + "\nCOIN: " + coin + "\nLIFE: " + s2Hgame.life+"\nCLEAR";
                SuccessResult();
            }

            if(playerPB.Bounds.IntersectsWith(goalPB.Bounds)&&coin<16)
            {
                label1.Text = "SECOND: " + s2Hgame.second + "\nSCORE: " + s2HScore.score + "\nCOIN: " + coin + "\nLIFE: " + s2Hgame.life + "\n코인 부족" ;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if(e.KeyCode == Keys.Up && goUpper == false)
            {
                goUpper = true;
            }
            if(e.KeyCode == Keys.Up)
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
            //게임 오버 상태에서 엔터 키 눌렀을 때, 생명 남았으면 재시작, 아니면 실패결과 메서드 실행
            {
                if (s2Hgame.life > 0)
                {
                    RestartGame();
                }
                else
                {
                    FaultResult();
                }
            }
        }

        private void RestartGame()
        {
            goUpper = false;
            goLeft = false;
            goRight = false;

            isGameOver = false;

            s2HScore.score -= 100;
            s2Hgame.life -= 1;

            label1.Text = "SECOND: " + s2Hgame.second + "\nSCORE: " + s2HScore.score + "\nCOIN: " + coin + "\nLIFE: " + s2Hgame.life;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && Visible == false)
                {
                    x.Visible = true;
                }
            }

            playerPB.Left = 389;
            playerPB.Top = 587;

            enemy1PB.Left = 167;
            enemy1PB.Top = 263;

            enemy2PB.Left = 92;
            enemy2PB.Top = 513;

            horizontalPlatform.Left = 114;
            horizontalPlatform.Top = 126;

            verticalPlatform.Left = 7;
            verticalPlatform.Top = 471;

            s2Hgame.second = 60;

            gameTimer.Start();
        }

        private void secTimer_Tick(object sender, EventArgs e)
        {
            s2Hgame.second--;
            if(s2Hgame.second == 0)
            {
                s2Hgame.second = 60;
                gameTimer.Stop();
                isGameOver = true;
                label1.Text = "SECOND: " + s2Hgame.second + "\nSCORE: " + s2HScore.score + "\nCOIN: " + coin + "\nLIFE: " + s2Hgame.life+"\nGAME OVER";
            }
        }

        private void SuccessResult()
        {
            timer1.Enabled = true;
        }

        private void Stage2_HardMode_Load(object sender, EventArgs e)
        {

        }

        private void FaultResult()
        {
            timer2.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if(sec == 3)
            {
                Stage2_Result_T S2RT = new Stage2_Result_T();
                S2RT.Show();
                this.Hide();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec == 3)
            {
                Stage2_Result_F S2RF = new Stage2_Result_F();
                S2RF.Show();
                this.Hide();
            }
        }

    }
}
