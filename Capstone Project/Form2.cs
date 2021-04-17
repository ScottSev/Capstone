using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class Form2 : Form
    {
        #region Startup Values (looks messy)
        int round = 1;
        int check = 0;
        int value = 0;
        int Score = 0;
        int How = 0;
        int Turns = 0;
        int[] Code = new int[3];
        string Dificulty2;
        string ChalengeMode2; 
        List<int> Guess = new List<int>();
        Random r = new Random();
        #endregion
        public Form2(string Dificulty, string ChalengeMode)
        {
            Dificulty2 = Dificulty;
            ChalengeMode2 = ChalengeMode;
            InitializeComponent();
            Reset();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Instruction.Hide();
        }

        private void Reset()
        {
            switch (Dificulty2)
            {
                case "Easy":
                    EasyEntryPanel.BringToFront();
                    Code[0] = r.Next(0, 4);
                    Code[1] = r.Next(0, 4);
                    Code[2] = r.Next(0, 4);
                    break;
                case "Medium":
                    MediumEntryPanel.BringToFront();
                    Code[0] = r.Next(0, 7);
                    Code[1] = r.Next(0, 7);
                    Code[2] = r.Next(0, 7);
                    break;
                case "Hard":
                    HardEntryPanel.BringToFront();
                    Code[0] = r.Next(0, 9);
                    Code[1] = r.Next(0, 9);
                    Code[2] = r.Next(0, 9);
                    break;
            }
            switch (ChalengeMode2)
            {
                case "False":
                    ChalengeOn.Hide();
                    ChEasy.Hide();
                    ChHard.Hide();
                    break;
                case "True":
                    progressBar1.Value = 100;
                    ChalengeOn.Show();
                    switch (Dificulty2)
                    {
                        case "Easy":
                            CodeBreakerNext.Hide();
                            Code[0] = r.Next(0, 4);
                            Code[1] = r.Next(0, 4);
                            Code[2] = r.Next(0, 4);
                            break;
                        case "Medium":
                            ChEasy.Hide();
                            CodeBreakerNext.Hide();
                            break;
                        case "Hard":
                            ChEasy.Hide();
                            ChHard.Show();
                            break;
                    }
                    break;
            }
            GuessPanel1.BringToFront();
            CodeBreakerNext.Hide();
            round = 1;
            Test1.Text = Code[0].ToString();
            Test2.Text = Code[1].ToString();
            Test3.Text = Code[2].ToString();

        }

        private void ScreenReset()
        {
            Dis1.ForeColor = Color.Black;
            Dis2.ForeColor = Color.Black;
            Dis3.ForeColor = Color.Black;
            Dis4.ForeColor = Color.Black;
            Dis5.ForeColor = Color.Black;
            Dis6.ForeColor = Color.Black;
            Dis7.ForeColor = Color.Black;
            Dis8.ForeColor = Color.Black;
            Dis9.ForeColor = Color.Black;
            Dis10.ForeColor = Color.Black;
            Dis11.ForeColor = Color.Black;
            Dis12.ForeColor = Color.Black;
            Dis13.ForeColor = Color.Black;
            Dis14.ForeColor = Color.Black;
            Dis15.ForeColor = Color.Black;
            Dis16.ForeColor = Color.Black;
            Dis17.ForeColor = Color.Black;
            Dis18.ForeColor = Color.Black;
            Dis19.ForeColor = Color.Black;
            Dis20.ForeColor = Color.Black;
            Dis21.ForeColor = Color.Black;
            Dis22.ForeColor = Color.Black;
            Dis23.ForeColor = Color.Black;
            Dis24.ForeColor = Color.Black;
            Dis25.ForeColor = Color.Black;
            Dis26.ForeColor = Color.Black;
            Dis27.ForeColor = Color.Black;
            Dis28.ForeColor = Color.Black;
            Dis29.ForeColor = Color.Black;
            Dis30.ForeColor = Color.Black;
            Dis31.ForeColor = Color.Black;
            Dis32.ForeColor = Color.Black;
            Dis33.ForeColor = Color.Black;
            Dis34.ForeColor = Color.Black;
            Dis35.ForeColor = Color.Black;
            Dis36.ForeColor = Color.Black;
            Guess.Clear();
        }

        public void EGo_Click(object sender, EventArgs e)
        {
            Guess.Add((int)E1.Value);
            Guess.Add((int)E2.Value);
            Guess.Add((int)E3.Value);
            GameFunction();
        }

        private void HGo_Click(object sender, EventArgs e)
        {
            Guess.Add((int)H1.Value);
            Guess.Add((int)H2.Value);
            Guess.Add((int)H3.Value);
            GameFunction();
        }

        private void MGo_Click(object sender, EventArgs e)
        {
            Guess.Add((int)M1.Value);
            Guess.Add((int)M2.Value);
            Guess.Add((int)M3.Value);
            GameFunction();
        }

        public void GameFunction()
        {
            switch (round)
            {
                case 1:
                    RoundOne(value, check, Code, round);
                    break;
                case 2:
                    RoundTwo(value, check, Code, round);
                    break;
                case 3:
                    RoundThree(value, check, Code, round);
                    break;
                case 4:
                    RoundFour(value, check, Code, round);
                    break;
                case 5:
                    RoundFive(value, check, Code, round);
                    break;
                case 6:
                    RoundSix(value, check, Code, round);
                    CodeBreakerNext.Show();
                    break;
                case 7:
                    RoundSeven(value, check, Code, round);
                    break;
                case 8:
                    RoundEight(value, check, Code, round);
                    break;
                case 9:
                    RoundNine(value, check, Code, round);
                    break;
                case 10:
                    RoundTen(value, check, Code, round);
                    break;
                case 11:
                    RoundEleven(value, check, Code, round);
                    break;
                case 12:
                    RoundTwelve(value, check, Code, round);
                    break;
            }
            if (ChalengeMode2 == "True")
            {
                ChCheck();
            }
            if (Score == 3)
            {
                EndGameWin();
                ResetPanel.BringToFront();
            }
            else
            {
                Score = 0;
            }
            if ((round == 12 && Score != 3) || (round == 6 && Dificulty2 == "Medium" && Score != 3 && ChalengeMode2 == "True") || (round == 4 && Dificulty2 == "Easy" && Score != 3 && ChalengeMode2 == "True") || (round == 8 && Dificulty2 == "Hard" && Score != 3 && ChalengeMode2 == "True"))
            {
                EndGameLose();
                ResetPanel.BringToFront();
            }
            round = round + 1;
        }

        private void ChCheck()
        {
            switch (Dificulty2)
            {
                case "Easy":
                    Turns = (4 - round);
                    progressBar1.Value = ((100 * Turns)/4);
                    break;
                case "Medium":
                    Turns = (6 - round);
                    progressBar1.Value = ((100 * Turns) / 6);
                    break;
                case "Hard":
                    Turns = (8 - round);
                    progressBar1.Value = ((100 * Turns) / 8);
                    break;
            }
        }

        private void EndGameLose()
        {
            EndText.Text = "Out of Tires :(";
            EndPanel.BringToFront();
        }

        private void EndGameWin()
        {
            EndText.Text = "You Win!!!!";
            EndPanel.BringToFront();
        }
        #region Rounds
        public void RoundOne(int value, int check, int[] Code, int round)
        {
            Dis1.Text = Guess[0 + ((round - 1) * 3)].ToString();
            Dis2.Text = Guess[1 + ((round - 1) * 3)].ToString();
            Dis3.Text = Guess[2 + ((round - 1) * 3)].ToString();
            value = Guess[0 + ((round - 1) * 3)];
            check = Code[0];
            Dis1.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[1 + ((round - 1) * 3)];
            check = Code[1];
            Dis2.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[2 + ((round - 1) * 3)];
            check = Code[2];
            Dis3.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
        }

        public void RoundTwo(int value, int check, int[] Code, int round)
        {
            Dis4.Text = Guess[0 + ((round - 1) * 3)].ToString();
            Dis5.Text = Guess[1 + ((round - 1) * 3)].ToString();
            Dis6.Text = Guess[2 + ((round - 1) * 3)].ToString();
            value = Guess[0 + ((round - 1) * 3)];
            check = Code[0];
            Dis4.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[1 + ((round - 1) * 3)];
            check = Code[1];
            Dis5.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[2 + ((round - 1) * 3)];
            check = Code[2];
            Dis6.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
        }

        public void RoundThree(int value, int check, int[] Code, int round)
        {
            Dis7.Text = Guess[0 + ((round - 1) * 3)].ToString();
            Dis8.Text = Guess[1 + ((round - 1) * 3)].ToString();
            Dis9.Text = Guess[2 + ((round - 1) * 3)].ToString();
            value = Guess[0 + ((round - 1) * 3)];
            check = Code[0];
            Dis7.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[1 + ((round - 1) * 3)];
            check = Code[1];
            Dis8.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[2 + ((round - 1) * 3)];
            check = Code[2];
            Dis9.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
        }

        public void RoundFour(int value, int check, int[] Code, int round)
        {
            Dis10.Text = Guess[0 + ((round - 1) * 3)].ToString();
            Dis11.Text = Guess[1 + ((round - 1) * 3)].ToString();
            Dis12.Text = Guess[2 + ((round - 1) * 3)].ToString();
            value = Guess[0 + ((round - 1) * 3)];
            check = Code[0];
            Dis10.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[1 + ((round - 1) * 3)];
            check = Code[1];
            Dis11.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[2 + ((round - 1) * 3)];
            check = Code[2];
            Dis12.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
        }

        public void RoundFive(int value, int check, int[] Code, int round)
        {
            Dis13.Text = Guess[0 + ((round - 1) * 3)].ToString();
            Dis14.Text = Guess[1 + ((round - 1) * 3)].ToString();
            Dis15.Text = Guess[2 + ((round - 1) * 3)].ToString();
            value = Guess[0 + ((round - 1) * 3)];
            check = Code[0];
            Dis13.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[1 + ((round - 1) * 3)];
            check = Code[1];
            Dis14.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[2 + ((round - 1) * 3)];
            check = Code[2];
            Dis15.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
        }

        public void RoundSix(int value, int check, int[] Code, int round)
        {
            Dis16.Text = Guess[0 + ((round - 1) * 3)].ToString();
            Dis17.Text = Guess[1 + ((round - 1) * 3)].ToString();
            Dis18.Text = Guess[2 + ((round - 1) * 3)].ToString();
            value = Guess[0 + ((round - 1) * 3)];
            check = Code[0];
            Dis16.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[1 + ((round - 1) * 3)];
            check = Code[1];
            Dis17.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[2 + ((round - 1) * 3)];
            check = Code[2];
            Dis18.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
        }

        public void RoundSeven(int value, int check, int[] Code, int round)
        {
            Dis19.Text = Guess[0 + ((round - 1) * 3)].ToString();
            Dis20.Text = Guess[1 + ((round - 1) * 3)].ToString();
            Dis21.Text = Guess[2 + ((round - 1) * 3)].ToString();
            value = Guess[0 + ((round - 1) * 3)];
            check = Code[0];
            Dis19.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[1 + ((round - 1) * 3)];
            check = Code[1];
            Dis20.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[2 + ((round - 1) * 3)];
            check = Code[2];
            Dis21.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
        }

        public void RoundEight(int value, int check, int[] Code, int round)
        {
            Dis22.Text = Guess[0 + ((round - 1) * 3)].ToString();
            Dis23.Text = Guess[1 + ((round - 1) * 3)].ToString();
            Dis24.Text = Guess[2 + ((round - 1) * 3)].ToString();
            value = Guess[0 + ((round - 1) * 3)];
            check = Code[0];
            Dis22.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[1 + ((round - 1) * 3)];
            check = Code[1];
            Dis23.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[2 + ((round - 1) * 3)];
            check = Code[2];
            Dis24.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score += 1;
            }
        }

        public void RoundNine(int value, int check, int[] Code, int round)
        {
            Dis25.Text = Guess[0 + ((round - 1) * 3)].ToString();
            Dis26.Text = Guess[1 + ((round - 1) * 3)].ToString();
            Dis27.Text = Guess[2 + ((round - 1) * 3)].ToString();
            value = Guess[0 + ((round - 1) * 3)];
            check = Code[0];
            Dis25.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score += 1;
            }
            value = Guess[1 + ((round - 1) * 3)];
            check = Code[1];
            Dis26.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[2 + ((round - 1) * 3)];
            check = Code[2];
            Dis27.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
        }

        public void RoundTen(int value, int check, int[] Code, int round)
        {
            Dis28.Text = Guess[0 + ((round - 1) * 3)].ToString();
            Dis29.Text = Guess[1 + ((round - 1) * 3)].ToString();
            Dis30.Text = Guess[2 + ((round - 1) * 3)].ToString();
            value = Guess[0 + ((round - 1) * 3)];
            check = Code[0];
            Dis28.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[1 + ((round - 1) * 3)];
            check = Code[1];
            Dis29.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[2 + ((round - 1) * 3)];
            check = Code[2];
            Dis30.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
        }

        public void RoundEleven(int value, int check, int[] Code, int round)
        {
            Dis31.Text = Guess[0 + ((round - 1) * 3)].ToString();
            Dis32.Text = Guess[1 + ((round - 1) * 3)].ToString();
            Dis33.Text = Guess[2 + ((round - 1) * 3)].ToString();
            value = Guess[0 + ((round - 1) * 3)];
            check = Code[0];
            Dis31.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[1 + ((round - 1) * 3)];
            check = Code[1];
            Dis32.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[2 + ((round - 1) * 3)];
            check = Code[2];
            Dis33.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score += 1;
            }
        }

        public void RoundTwelve(int value, int check, int[] Code, int round)
        {
            Dis34.Text = Guess[0 + ((round - 1) * 3)].ToString();
            Dis35.Text = Guess[1 + ((round - 1) * 3)].ToString();
            Dis36.Text = Guess[2 + ((round - 1) * 3)].ToString();
            value = Guess[0 + ((round - 1) * 3)];
            check = Code[0];
            Dis34.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[1 + ((round - 1) * 3)];
            check = Code[1];
            Dis35.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
            value = Guess[2 + ((round - 1) * 3)];
            check = Code[2];
            Dis36.ForeColor = NumberCheck(value, check, Code);
            if (value == check)
            {
                Score = Score + 1;
            }
        }

#endregion

        public Color NumberCheck(int value, int check, int[] Code)
        {
            Color color;
            if (value == check)
            {
                color = Color.Green;
            }
            else if (Code.Contains(value))
            {
                color= Color.Yellow;
            }
            else
            {
                color = Color.Red;
            }
            return color;
        }
        private void CodeBreakerPrevious_Click(object sender, EventArgs e)
        {
            GuessPanel1.BringToFront();
        }

        private void CodeBreakerNext_Click(object sender, EventArgs e)
        {
            GuessPanel2.BringToFront();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            if (How == 0)
            {
                Instruction.Show();
                How = 1;
            }
            else if (How == 1)
            {
                Instruction.Hide();
                How = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CodeBreakerDificulty.Text != "Dificulty")
            {
                Dificulty2 = CodeBreakerDificulty.Text;
                ChalengeMode2 = checkBox1.Checked.ToString();
                Reset();
                ScreenReset();
                ResetPanel.SendToBack();
                EndPanel.SendToBack();
            }

        }
    }
}
