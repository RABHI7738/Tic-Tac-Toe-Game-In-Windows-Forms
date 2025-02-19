using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XO_Game.Properties;

namespace XO_Game
{
  
        

    public partial class Form1 : Form
    {

   
        public Form1()
        {
            InitializeComponent();
        }
        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;

        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }


        private void EnabledButtons(bool Value)
        {
            if (btn1.Tag.ToString() == "?")
            {
                btn1.Enabled = Value;
            }
            if (btn2.Tag.ToString() == "?")
            {
                btn2.Enabled = Value;
            }
            if (btn3.Tag.ToString() == "?")
            {
                btn3.Enabled = Value;
            }
            if (btn4.Tag.ToString() == "?")
            {
                btn4.Enabled = Value;
            }
            if (btn5.Tag.ToString() == "?")
            {
                btn5.Enabled = Value;
            }
            if (btn5.Tag.ToString() == "?")
            {
                btn5.Enabled = Value;
            }
            if (btn6.Tag.ToString() == "?")
            {
                btn6.Enabled = Value;
            }
            if (btn7.Tag.ToString() == "?")
            {
                btn7.Enabled = Value;
            }
            if (btn8.Tag.ToString() == "?")
            {
                btn8.Enabled = Value;
            }
            if (btn9.Tag.ToString() == "?")
            {
                btn9.Enabled = Value;
            }

        }
        private void ClickSound()
        {

            try
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.mixkit_retro_game_notification_212);

                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
        private void WinSound()
        {

            try
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.GoodResult);

                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void EndGame()
        {
            lblTurn.Text = "Game Over";



            switch (GameStatus.Winner)
            {

                case enWinner.Player1:

                    lblWinner.Text = "Player 1";
                    break;

                case enWinner.Player2:
                    lblWinner.Text = "Player 2";
                    break;

                default:
                    lblWinner.Text = "Draw";
                    break;

            }
            EnabledButtons(false);

            MessageBox.Show("Game Over", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void PanelSetColor()
        {
            panel15.BackColor = Color.Chartreuse;
            panel16.BackColor = Color.Chartreuse;
            panel11.BackColor = Color.Chartreuse;
            panel12.BackColor = Color.Chartreuse;
            panel13.BackColor = Color.Chartreuse;
            panel14.BackColor = Color.Chartreuse;
            panel17.BackColor = Color.Chartreuse;
            panel18.BackColor = Color.Chartreuse;

        
        }

        public bool ChekValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.Chartreuse;
                btn2.BackColor = Color.Chartreuse;
                btn3.BackColor = Color.Chartreuse;
                lblWinner.ForeColor = Color.Chartreuse;
                lblTurn.ForeColor = Color.Chartreuse;
             
                WinSound();

                PanelSetColor();
                if (btn1.Tag.ToString() == "X")
                {
                  
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;

                }

            }
            GameStatus.GameOver = false;
            return false;

        }
        public void ChekWinner()
        {
            if (ChekValues(btn1, btn2, btn3))
                return;

            if (ChekValues(btn4, btn5, btn6))
                return;

            if (ChekValues(btn7, btn8, btn9))
                return;

            if (ChekValues(btn1, btn4, btn7))
                return;

            if (ChekValues(btn2, btn5, btn8))
                return;

            if (ChekValues(btn3, btn6, btn9))
                return;

            if (ChekValues(btn1, btn5, btn9))
                return;

            if (ChekValues(btn3, btn5, btn7))
                return;




        }
        public void ChangeImage(object sender)
        {
            ClickSound();

            Button btn = (Button)sender;

            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        GameStatus.PlayCount++;
                        lblTurn.Text = "Player 2";
                        btn.Tag = "X";
                        ChekWinner();
                        break;

                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        GameStatus.PlayCount++;
                        lblTurn.Text = "Player 1";
                        btn.Tag = "O";
                        ChekWinner();
                        break;

                }

            }
            else
            {
                MessageBox.Show("Game Over", "Wrong Choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                panel15.BackColor = Color.Red;
                panel16.BackColor = Color.Red;
                panel11.BackColor = Color.Red;
                panel12.BackColor = Color.Red;
                panel13.BackColor = Color.Red;
                panel14.BackColor = Color.Red;
                panel17.BackColor = Color.Red;
                panel18.BackColor = Color.Red;
                EndGame();

              
            }
        }

        private void RestButton(Button btn)
        {
            btn.Tag = "?";
            btn.Image = Resources.question_mark_96;
            btn.BackColor = Color.Black;


        }

        private void RestartGame()
        {


            try
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.mixkit_select_click_1109);

                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }

            RestButton(btn1);
            RestButton(btn2);
            RestButton(btn3);
            RestButton(btn4);
            RestButton(btn5);
            RestButton(btn6);
            RestButton(btn7);
            RestButton(btn8);
            RestButton(btn9);


            PlayerTurn = enPlayer.Player1;
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            lblTurn.Text = "Player 1";
            lblWinner.Text = "In Progress";

            panel15.BackColor = Color.White;
            panel16.BackColor = Color.White;
            panel11.BackColor = Color.White;
            panel12.BackColor = Color.White;
            panel13.BackColor = Color.White;
            panel14.BackColor = Color.White;
            panel17.BackColor = Color.White;
            panel18.BackColor = Color.White;

            lblWinner.ForeColor = Color.White;
            lblTurn.ForeColor = Color.White;

            EnabledButtons(true);
}
    




        private void lblTurn_Click(object sender, EventArgs e)
        {

        }


        private void Button_Click(object sender, EventArgs e)
        {
            
            ChangeImage(sender);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     
    }
}
