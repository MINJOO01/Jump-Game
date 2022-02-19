using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JumpGame
{
    public partial class player_PB : Form
    {
        int sec;

        Score s1HScore;
        Game s1Hgame;

        bool goLeft, goRight, goUpper, isGameOver;  //방향키 3개의 입력 여부 판별 목적

        int goUpperMovement;    //Up키 눌렀을 때 캐릭터의 이동변수
        int force;
        int playerMovement = 15;  //플레이어의 이동변수

        int enemy1PBMovement = 10;   //enemy1의 이동변수
        int enemy2PBMovement = 10;   //enemy2의 이동변수

        int coin = 0;   //모은 코인의 개수

        int horizontalMovement = 20; //수평 방향으로 움직이는 platform 이동변수
        int verticalMovement = 20;   //수직~

        public player_PB()
        {
            InitializeComponent();
            s1HScore = new Score();
            s1Hgame = new Game();
            s1HScore.score = 0; //Stage1 Hare Mode에서의 score
            s1Hgame.life = 3; //~ 남은 life
            sec = 0;
        }

        private void player_PB_Load(object sender, EventArgs e)
        {

        }

        private void MainGameTimer(object sender, EventArgs e)
        {
            label1.Text = "SCORE: " + s1HScore.score + "\nCOIN: " + coin + "\nLIFE: " + s1Hgame.life;
            //현재 score, 모은 coin, 남은 life를 게임 진행되는 동안 계속 보여줄 것.

            /*
             Up, Left, Right키 눌렀을 때의
             플레이어 위치 변화 설정
            */
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

            //픽쳐박스 설정
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    //platform Tag
                    if((string)x.Tag == "platform")
                    {
                        if(playerPB.Bounds.IntersectsWith(x.Bounds))
                        {
                           force = 8;
                            playerPB.Top = x.Top - playerPB.Height;

                            if((string)x.Name == "horizontalPlatform" && goLeft==false || (string)x.Name=="horizontalPlatform" && goRight==false)
                            {
                                playerPB.Left -= horizontalMovement;
                            }
                        }

                        x.BringToFront();
                    }
                    //coin Tag
                    if((string)x.Tag == "coin")
                    {
                        if(playerPB.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            s1HScore.score += 10;
                            coin++;
                        }
                    }
                    //enemy Tag
                    if((string)x.Tag == "enemy")
                    {
                        if(playerPB.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            isGameOver = true;
                            label1.Text = "SCORE: " + s1HScore.score + "\nCOIN: " + coin + "\nLIFE: " + s1Hgame.life + "\nGAME OVER";
                        }
                    }
                }
            }

            //수평으로 움직이는 플랫폼의 이동설정
            horizontalPlatform.Left -= horizontalMovement;
            if(horizontalPlatform.Left<0 || horizontalPlatform.Left + horizontalPlatform.Width>this.ClientSize.Width)
            { 
                horizontalMovement = -horizontalMovement;
            }

            //수직으로 움직이는 플랫폼 이동설정
            verticalPlatform.Top += verticalMovement;
            if(verticalPlatform.Top<126||verticalPlatform.Top>559)
            {
                verticalMovement = -verticalMovement;
            }

            //enemy1의 이동 설정
            enemy1PB.Left -= enemy1PBMovement;
            if(enemy1PB.Left<pictureBox7.Left||enemy1PB.Left+enemy1PB.Width>pictureBox7.Left+pictureBox7.Width)
            {
                enemy1PBMovement = -enemy1PBMovement;
            }

            //enemy2의 이동 설정
            enemy2PB.Left -= enemy2PBMovement;
            if (enemy2PB.Left < pictureBox3.Left || enemy2PB.Left + enemy2PB.Width > pictureBox3.Left + pictureBox3.Width)
            {
                enemy2PBMovement = -enemy2PBMovement;
            }

            //GAME OVER
            if(playerPB.Top + playerPB.Height > this.ClientSize.Height+50)
            {
                gameTimer.Stop();
                isGameOver = true;
                label1.Text = "SCORE: " + s1HScore.score + "\nCOIN: " + coin + "\nLIFE: " + s1Hgame.life + "\nGAME OVER";
            }

            //CLEAR
            if(playerPB.Bounds.IntersectsWith(goalPB.Bounds)&&coin==18)
            {
                gameTimer.Stop();
                label1.Text = "SCORE: " + s1HScore.score + "\nCOIN : " + coin + "\nLIFE: " + s1Hgame.life + "\nCLEAR";
                SuccessResult();
            }

            // goal 도달했지만 coin을 덜 모은 경우
            if(playerPB.Bounds.IntersectsWith(goalPB.Bounds)&&coin<18)
            {
                label1.Text = "SCORE: " + s1HScore.score + "\nCOIN: " + coin + "\nLIFE: " + s1Hgame.life + "\n코인 부족";
            }
        }

        // 키 눌렸을 때
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

        //키를 빠져나갔을 때
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
          if(e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
          if(e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if(goUpper == true)
            {
                goUpper = false;
            }
            if(e.KeyCode == Keys.Up)
            {
                goUpper = false;
            }

          if(e.KeyCode == Keys.Enter && isGameOver == true)
           //게임 오버 상태에서 엔터 키 눌렀을 때, 생명 남았으면 재시작, 아니면 실패결과 메서드 실행
            {
                if(s1Hgame.life>0)
                {
                    RestartGame();
                }
                else
                {
                    FaultResult();
                }
            }
        }


        //게임 재시작 메서드
        private void RestartGame()
        {
            goUpper = false;
            goLeft = false;
            goRight = false;

            isGameOver = false;

            s1HScore.score -= 100;  //stage1 hard mode에서 얻을 수 있는 최저점: -300, 최고점: +160(easy와 동일)
            s1Hgame.life -= 1;

            label1.Text = "SCORE: " + s1HScore.score + "\nCOIN: \nLIFE:" + s1Hgame.life;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && Visible == false)
                {
                    x.Visible = true;   
                }
            }


            //픽쳐박스 위치 초기화

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

        //성공화면 호출 메서드
        private void SuccessResult()
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec == 3)
            {
                Stage1_Result_T S1RT = new Stage1_Result_T();
                S1RT.Show();
                this.Hide();
            }
        }

        //실패화면 호출 메서드
        private void FaultResult()
        {
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec == 3)
            {
                Stage1_Result_F S1RF = new Stage1_Result_F();
                S1RF.Show();
                this.Hide();
            }
        }
    }
}
