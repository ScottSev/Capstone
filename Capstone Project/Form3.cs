using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class Form3 : Form
    {
        #region Value Setups (Gross to look at)
        int[][] Screen =
            {
        new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };
        int[] lines = new int[21] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] dummyLines = new int[20];
        int LinePlace = 0;
        int dummy = 1;
        int coreH = 21;
        int coreW = 5;
        int rotation = 1;
        int Score = 0;
        int ClearLine = 0;
        int wait = 1;
        Random block = new Random();
        int DeckBLock = 0;
        Timer timer1 = new Timer
        {
            Interval = 1000
        };
        #endregion

        public Form3()
        {
            InitializeComponent();
            Check();
        }

        #region Screen Start/Stop
        private void Form3_Load(object sender, EventArgs e)
        {
            StartButton.Show();
            StartButton.BringToFront();
            Block0Pan.BringToFront();
            timer1.Tick += new System.EventHandler(button2_Click);
        }
        private void Reset()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    Screen[i][j] = 0;
                };
            }
            for (int i = 0; i < 21; i++)
            {
                lines[i] = 0;
            }
            LinePlace = 0;
            dummy = 1;
            coreH = 20;
            coreW = 5;
            rotation = 1;
            Score = 0;
            ClearLine = 0;
            timer1.Start();
            DeckBLock = block.Next(1, 5);
            NextCheck();
        }
        #endregion

        #region Screen Checks
        //Check to clear full lines
        private void LineCheck()
        {
            for (int i = 20; i > -1; i--)
            {
                if (lines[i] == 10)
                {
                    ClearLine = i;
                    for (int j = 0; j < 10; j++)
                    {
                        Screen[j][i] = 0;
                    }
                    for (int x = ClearLine; x < 20; x++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            dummyLines[x] = Screen[j][x + 1];
                            Screen[j][x] = dummyLines[x];
                            LinePlace = lines[x + 1];
                            lines[x] = LinePlace;
                        }
                    }
                    Check();
                    Score += 100;
                    timer1.Stop();
                    scorelabel.Text = Score.ToString();
                    if (Score == 1000)
                    {
                        WinScreen.BringToFront();
                        StartButton.Show();
                    }
                    else
                    {
                        timer1.Interval = (1000 - (Score));
                        timer1.Start();
                    }
                }
            }
        }

        //Check which uses every check (for refreshing the screen)
        private void Check()
        {
            Check1();
            Check2();
            Check3();
            Check4();
            Check5();
            Check6();
            Check7();
            Check8();
            Check9();
            Check10();
        }

        //Checks for each Columb
        private void Check1()
        {
            if (Screen[0][0] == 1)
            {
                Pixel1.BackColor = Color.White;
            }
            else
            {
                Pixel1.BackColor = Color.Black;
            }
            if (Screen[0][1] == 1)
            {
                Pixel2.BackColor = Color.White;
            }
            else
            {
                Pixel2.BackColor = Color.Black;
            }
            if (Screen[0][2] == 1)
            {
                Pixel3.BackColor = Color.White;
            }
            else
            {
                Pixel3.BackColor = Color.Black;
            }
            if (Screen[0][3] == 1)
            {
                Pixel4.BackColor = Color.White;
            }
            else
            {
                Pixel4.BackColor = Color.Black;
            }
            if (Screen[0][4] == 1)
            {
                Pixel5.BackColor = Color.White;
            }
            else
            {
                Pixel5.BackColor = Color.Black;
            }
            if (Screen[0][5] == 1)
            {
                Pixel6.BackColor = Color.White;
            }
            else
            {
                Pixel6.BackColor = Color.Black;
            }
            if (Screen[0][6] == 1)
            {
                Pixel7.BackColor = Color.White;
            }
            else
            {
                Pixel7.BackColor = Color.Black;
            }
            if (Screen[0][7] == 1)
            {
                Pixel8.BackColor = Color.White;
            }
            else
            {
                Pixel8.BackColor = Color.Black;
            }
            if (Screen[0][8] == 1)
            {
                Pixel9.BackColor = Color.White;
            }
            else
            {
                Pixel9.BackColor = Color.Black;
            }
            if (Screen[0][9] == 1)
            {
                Pixel10.BackColor = Color.White;
            }
            else
            {
                Pixel10.BackColor = Color.Black;
            }
            if (Screen[0][10] == 1)
            {
                Pixel11.BackColor = Color.White;
            }
            else
            {
                Pixel11.BackColor = Color.Black;
            }
            if (Screen[0][11] == 1)
            {
                Pixel12.BackColor = Color.White;
            }
            else
            {
                Pixel12.BackColor = Color.Black;
            }
            if (Screen[0][12] == 1)
            {
                Pixel13.BackColor = Color.White;
            }
            else
            {
                Pixel13.BackColor = Color.Black;
            }
            if (Screen[0][13] == 1)
            {
                Pixel14.BackColor = Color.White;
            }
            else
            {
                Pixel14.BackColor = Color.Black;
            }
            if (Screen[0][14] == 1)
            {
                Pixel15.BackColor = Color.White;
            }
            else
            {
                Pixel15.BackColor = Color.Black;
            }
            if (Screen[0][15] == 1)
            {
                Pixel16.BackColor = Color.White;
            }
            else
            {
                Pixel16.BackColor = Color.Black;
            }
            if (Screen[0][16] == 1)
            {
                Pixel17.BackColor = Color.White;
            }
            else
            {
                Pixel17.BackColor = Color.Black;
            }
            if (Screen[0][17] == 1)
            {
                Pixel18.BackColor = Color.White;
            }
            else
            {
                Pixel18.BackColor = Color.Black;
            }
            if (Screen[0][18] == 1)
            {
                Pixel19.BackColor = Color.White;
            }
            else
            {
                Pixel19.BackColor = Color.Black;
            }
            if (Screen[0][19] == 1)
            {
                Pixel20.BackColor = Color.White;
            }
            else
            {
                Pixel20.BackColor = Color.Black;
            }
        }
        private void Check2()
        {
            if (Screen[1][0] == 1)
            {
                Pixel21.BackColor = Color.White;
            }
            else
            {
                Pixel21.BackColor = Color.Black;
            }
            if (Screen[1][1] == 1)
            {
                Pixel22.BackColor = Color.White;
            }
            else
            {
                Pixel22.BackColor = Color.Black;
            }
            if (Screen[1][2] == 1)
            {
                Pixel23.BackColor = Color.White;
            }
            else
            {
                Pixel23.BackColor = Color.Black;
            }
            if (Screen[1][3] == 1)
            {
                Pixel24.BackColor = Color.White;
            }
            else
            {
                Pixel24.BackColor = Color.Black;
            }
            if (Screen[1][4] == 1)
            {
                Pixel25.BackColor = Color.White;
            }
            else
            {
                Pixel25.BackColor = Color.Black;
            }
            if (Screen[1][5] == 1)
            {
                Pixel26.BackColor = Color.White;
            }
            else
            {
                Pixel26.BackColor = Color.Black;
            }
            if (Screen[1][6] == 1)
            {
                Pixel27.BackColor = Color.White;
            }
            else
            {
                Pixel27.BackColor = Color.Black;
            }
            if (Screen[1][7] == 1)
            {
                Pixel28.BackColor = Color.White;
            }
            else
            {
                Pixel28.BackColor = Color.Black;
            }
            if (Screen[1][8] == 1)
            {
                Pixel29.BackColor = Color.White;
            }
            else
            {
                Pixel29.BackColor = Color.Black;
            }
            if (Screen[1][9] == 1)
            {
                Pixel30.BackColor = Color.White;
            }
            else
            {
                Pixel30.BackColor = Color.Black;
            }
            if (Screen[1][10] == 1)
            {
                Pixel31.BackColor = Color.White;
            }
            else
            {
                Pixel31.BackColor = Color.Black;
            }
            if (Screen[1][11] == 1)
            {
                Pixel32.BackColor = Color.White;
            }
            else
            {
                Pixel32.BackColor = Color.Black;
            }
            if (Screen[1][12] == 1)
            {
                Pixel33.BackColor = Color.White;
            }
            else
            {
                Pixel33.BackColor = Color.Black;
            }
            if (Screen[1][13] == 1)
            {
                Pixel34.BackColor = Color.White;
            }
            else
            {
                Pixel34.BackColor = Color.Black;
            }
            if (Screen[1][14] == 1)
            {
                Pixel35.BackColor = Color.White;
            }
            else
            {
                Pixel35.BackColor = Color.Black;
            }
            if (Screen[1][15] == 1)
            {
                Pixel36.BackColor = Color.White;
            }
            else
            {
                Pixel36.BackColor = Color.Black;
            }
            if (Screen[1][16] == 1)
            {
                Pixel37.BackColor = Color.White;
            }
            else
            {
                Pixel37.BackColor = Color.Black;
            }
            if (Screen[1][17] == 1)
            {
                Pixel38.BackColor = Color.White;
            }
            else
            {
                Pixel38.BackColor = Color.Black;
            }
            if (Screen[1][18] == 1)
            {
                Pixel39.BackColor = Color.White;
            }
            else
            {
                Pixel39.BackColor = Color.Black;
            }
            if (Screen[1][19] == 1)
            {
                Pixel40.BackColor = Color.White;
            }
            else
            {
                Pixel40.BackColor = Color.Black;
            }
        }
        private void Check3()
        {
            if (Screen[2][0] == 1)
            {
                Pixel41.BackColor = Color.White;
            }
            else
            {
                Pixel41.BackColor = Color.Black;
            }
            if (Screen[2][1] == 1)
            {
                Pixel42.BackColor = Color.White;
            }
            else
            {
                Pixel42.BackColor = Color.Black;
            }
            if (Screen[2][2] == 1)
            {
                Pixel43.BackColor = Color.White;
            }
            else
            {
                Pixel43.BackColor = Color.Black;
            }
            if (Screen[2][3] == 1)
            {
                Pixel44.BackColor = Color.White;
            }
            else
            {
                Pixel44.BackColor = Color.Black;
            }
            if (Screen[2][4] == 1)
            {
                Pixel45.BackColor = Color.White;
            }
            else
            {
                Pixel45.BackColor = Color.Black;
            }
            if (Screen[2][5] == 1)
            {
                Pixel46.BackColor = Color.White;
            }
            else
            {
                Pixel46.BackColor = Color.Black;
            }
            if (Screen[2][6] == 1)
            {
                Pixel47.BackColor = Color.White;
            }
            else
            {
                Pixel47.BackColor = Color.Black;
            }
            if (Screen[2][7] == 1)
            {
                Pixel48.BackColor = Color.White;
            }
            else
            {
                Pixel48.BackColor = Color.Black;
            }
            if (Screen[2][8] == 1)
            {
                Pixel49.BackColor = Color.White;
            }
            else
            {
                Pixel49.BackColor = Color.Black;
            }
            if (Screen[2][9] == 1)
            {
                Pixel50.BackColor = Color.White;
            }
            else
            {
                Pixel50.BackColor = Color.Black;
            }
            if (Screen[2][10] == 1)
            {
                Pixel51.BackColor = Color.White;
            }
            else
            {
                Pixel51.BackColor = Color.Black;
            }
            if (Screen[2][11] == 1)
            {
                Pixel52.BackColor = Color.White;
            }
            else
            {
                Pixel52.BackColor = Color.Black;
            }
            if (Screen[2][12] == 1)
            {
                Pixel53.BackColor = Color.White;
            }
            else
            {
                Pixel53.BackColor = Color.Black;
            }
            if (Screen[2][13] == 1)
            {
                Pixel54.BackColor = Color.White;
            }
            else
            {
                Pixel54.BackColor = Color.Black;
            }
            if (Screen[2][14] == 1)
            {
                Pixel55.BackColor = Color.White;
            }
            else
            {
                Pixel55.BackColor = Color.Black;
            }
            if (Screen[2][15] == 1)
            {
                Pixel56.BackColor = Color.White;
            }
            else
            {
                Pixel56.BackColor = Color.Black;
            }
            if (Screen[2][16] == 1)
            {
                Pixel57.BackColor = Color.White;
            }
            else
            {
                Pixel57.BackColor = Color.Black;
            }
            if (Screen[2][17] == 1)
            {
                Pixel58.BackColor = Color.White;
            }
            else
            {
                Pixel58.BackColor = Color.Black;
            }
            if (Screen[2][18] == 1)
            {
                Pixel59.BackColor = Color.White;
            }
            else
            {
                Pixel59.BackColor = Color.Black;
            }
            if (Screen[2][19] == 1)
            {
                Pixel60.BackColor = Color.White;
            }
            else
            {
                Pixel60.BackColor = Color.Black;
            }
        }
        private void Check4()
        {
            if (Screen[3][0] == 1)
            {
                Pixel61.BackColor = Color.White;
            }
            else
            {
                Pixel61.BackColor = Color.Black;
            }
            if (Screen[3][1] == 1)
            {
                Pixel62.BackColor = Color.White;
            }
            else
            {
                Pixel62.BackColor = Color.Black;
            }
            if (Screen[3][2] == 1)
            {
                Pixel63.BackColor = Color.White;
            }
            else
            {
                Pixel63.BackColor = Color.Black;
            }
            if (Screen[3][3] == 1)
            {
                Pixel64.BackColor = Color.White;
            }
            else
            {
                Pixel64.BackColor = Color.Black;
            }
            if (Screen[3][4] == 1)
            {
                Pixel65.BackColor = Color.White;
            }
            else
            {
                Pixel65.BackColor = Color.Black;
            }
            if (Screen[3][5] == 1)
            {
                Pixel66.BackColor = Color.White;
            }
            else
            {
                Pixel66.BackColor = Color.Black;
            }
            if (Screen[3][6] == 1)
            {
                Pixel67.BackColor = Color.White;
            }
            else
            {
                Pixel67.BackColor = Color.Black;
            }
            if (Screen[3][7] == 1)
            {
                Pixel68.BackColor = Color.White;
            }
            else
            {
                Pixel68.BackColor = Color.Black;
            }
            if (Screen[3][8] == 1)
            {
                Pixel69.BackColor = Color.White;
            }
            else
            {
                Pixel69.BackColor = Color.Black;
            }
            if (Screen[3][9] == 1)
            {
                Pixel70.BackColor = Color.White;
            }
            else
            {
                Pixel70.BackColor = Color.Black;
            }
            if (Screen[3][10] == 1)
            {
                Pixel71.BackColor = Color.White;
            }
            else
            {
                Pixel71.BackColor = Color.Black;
            }
            if (Screen[3][11] == 1)
            {
                Pixel72.BackColor = Color.White;
            }
            else
            {
                Pixel72.BackColor = Color.Black;
            }
            if (Screen[3][12] == 1)
            {
                Pixel73.BackColor = Color.White;
            }
            else
            {
                Pixel73.BackColor = Color.Black;
            }
            if (Screen[3][13] == 1)
            {
                Pixel74.BackColor = Color.White;
            }
            else
            {
                Pixel74.BackColor = Color.Black;
            }
            if (Screen[3][14] == 1)
            {
                Pixel75.BackColor = Color.White;
            }
            else
            {
                Pixel75.BackColor = Color.Black;
            }
            if (Screen[3][15] == 1)
            {
                Pixel76.BackColor = Color.White;
            }
            else
            {
                Pixel76.BackColor = Color.Black;
            }
            if (Screen[3][16] == 1)
            {
                Pixel77.BackColor = Color.White;
            }
            else
            {
                Pixel77.BackColor = Color.Black;
            }
            if (Screen[3][17] == 1)
            {
                Pixel78.BackColor = Color.White;
            }
            else
            {
                Pixel78.BackColor = Color.Black;
            }
            if (Screen[3][18] == 1)
            {
                Pixel79.BackColor = Color.White;
            }
            else
            {
                Pixel79.BackColor = Color.Black;
            }
            if (Screen[3][19] == 1)
            {
                Pixel80.BackColor = Color.White;
            }
            else
            {
                Pixel80.BackColor = Color.Black;
            }
        }
        private void Check5()
        {
            if (Screen[4][0] == 1)
            {
                Pixel81.BackColor = Color.White;
            }
            else
            {
                Pixel81.BackColor = Color.Black;
            }
            if (Screen[4][1] == 1)
            {
                Pixel82.BackColor = Color.White;
            }
            else
            {
                Pixel82.BackColor = Color.Black;
            }
            if (Screen[4][2] == 1)
            {
                Pixel83.BackColor = Color.White;
            }
            else
            {
                Pixel83.BackColor = Color.Black;
            }
            if (Screen[4][3] == 1)
            {
                Pixel84.BackColor = Color.White;
            }
            else
            {
                Pixel84.BackColor = Color.Black;
            }
            if (Screen[4][4] == 1)
            {
                Pixel85.BackColor = Color.White;
            }
            else
            {
                Pixel85.BackColor = Color.Black;
            }
            if (Screen[4][5] == 1)
            {
                Pixel86.BackColor = Color.White;
            }
            else
            {
                Pixel86.BackColor = Color.Black;
            }
            if (Screen[4][6] == 1)
            {
                Pixel87.BackColor = Color.White;
            }
            else
            {
                Pixel87.BackColor = Color.Black;
            }
            if (Screen[4][7] == 1)
            {
                Pixel88.BackColor = Color.White;
            }
            else
            {
                Pixel88.BackColor = Color.Black;
            }
            if (Screen[4][8] == 1)
            {
                Pixel89.BackColor = Color.White;
            }
            else
            {
                Pixel89.BackColor = Color.Black;
            }
            if (Screen[4][9] == 1)
            {
                Pixel90.BackColor = Color.White;
            }
            else
            {
                Pixel90.BackColor = Color.Black;
            }
            if (Screen[4][10] == 1)
            {
                Pixel91.BackColor = Color.White;
            }
            else
            {
                Pixel91.BackColor = Color.Black;
            }
            if (Screen[4][11] == 1)
            {
                Pixel92.BackColor = Color.White;
            }
            else
            {
                Pixel92.BackColor = Color.Black;
            }
            if (Screen[4][12] == 1)
            {
                Pixel93.BackColor = Color.White;
            }
            else
            {
                Pixel93.BackColor = Color.Black;
            }
            if (Screen[4][13] == 1)
            {
                Pixel94.BackColor = Color.White;
            }
            else
            {
                Pixel94.BackColor = Color.Black;
            }
            if (Screen[4][14] == 1)
            {
                Pixel95.BackColor = Color.White;
            }
            else
            {
                Pixel95.BackColor = Color.Black;
            }
            if (Screen[4][15] == 1)
            {
                Pixel96.BackColor = Color.White;
            }
            else
            {
                Pixel96.BackColor = Color.Black;
            }
            if (Screen[4][16] == 1)
            {
                Pixel97.BackColor = Color.White;
            }
            else
            {
                Pixel97.BackColor = Color.Black;
            }
            if (Screen[4][17] == 1)
            {
                Pixel98.BackColor = Color.White;
            }
            else
            {
                Pixel98.BackColor = Color.Black;
            }
            if (Screen[4][18] == 1)
            {
                Pixel99.BackColor = Color.White;
            }
            else
            {
                Pixel99.BackColor = Color.Black;
            }
            if (Screen[4][19] == 1)
            {
                Pixel100.BackColor = Color.White;
            }
            else
            {
                Pixel100.BackColor = Color.Black;
            }
        }
        private void Check6()
        {
            if (Screen[5][0] == 1)
            {
                Pixel101.BackColor = Color.White;
            }
            else
            {
                Pixel101.BackColor = Color.Black;
            }
            if (Screen[5][1] == 1)
            {
                Pixel102.BackColor = Color.White;
            }
            else
            {
                Pixel102.BackColor = Color.Black;
            }
            if (Screen[5][2] == 1)
            {
                Pixel103.BackColor = Color.White;
            }
            else
            {
                Pixel103.BackColor = Color.Black;
            }
            if (Screen[5][3] == 1)
            {
                Pixel104.BackColor = Color.White;
            }
            else
            {
                Pixel104.BackColor = Color.Black;
            }
            if (Screen[5][4] == 1)
            {
                Pixel105.BackColor = Color.White;
            }
            else
            {
                Pixel105.BackColor = Color.Black;
            }
            if (Screen[5][5] == 1)
            {
                Pixel106.BackColor = Color.White;
            }
            else
            {
                Pixel106.BackColor = Color.Black;
            }
            if (Screen[5][6] == 1)
            {
                Pixel107.BackColor = Color.White;
            }
            else
            {
                Pixel107.BackColor = Color.Black;
            }
            if (Screen[5][7] == 1)
            {
                Pixel108.BackColor = Color.White;
            }
            else
            {
                Pixel108.BackColor = Color.Black;
            }
            if (Screen[5][8] == 1)
            {
                Pixel109.BackColor = Color.White;
            }
            else
            {
                Pixel109.BackColor = Color.Black;
            }
            if (Screen[5][9] == 1)
            {
                Pixel110.BackColor = Color.White;
            }
            else
            {
                Pixel110.BackColor = Color.Black;
            }
            if (Screen[5][10] == 1)
            {
                Pixel111.BackColor = Color.White;
            }
            else
            {
                Pixel111.BackColor = Color.Black;
            }
            if (Screen[5][11] == 1)
            {
                Pixel112.BackColor = Color.White;
            }
            else
            {
                Pixel112.BackColor = Color.Black;
            }
            if (Screen[5][12] == 1)
            {
                Pixel113.BackColor = Color.White;
            }
            else
            {
                Pixel113.BackColor = Color.Black;
            }
            if (Screen[5][13] == 1)
            {
                Pixel114.BackColor = Color.White;
            }
            else
            {
                Pixel114.BackColor = Color.Black;
            }
            if (Screen[5][14] == 1)
            {
                Pixel115.BackColor = Color.White;
            }
            else
            {
                Pixel115.BackColor = Color.Black;
            }
            if (Screen[5][15] == 1)
            {
                Pixel116.BackColor = Color.White;
            }
            else
            {
                Pixel116.BackColor = Color.Black;
            }
            if (Screen[5][16] == 1)
            {
                Pixel117.BackColor = Color.White;
            }
            else
            {
                Pixel117.BackColor = Color.Black;
            }
            if (Screen[5][17] == 1)
            {
                Pixel118.BackColor = Color.White;
            }
            else
            {
                Pixel118.BackColor = Color.Black;
            }
            if (Screen[5][18] == 1)
            {
                Pixel119.BackColor = Color.White;
            }
            else
            {
                Pixel119.BackColor = Color.Black;
            }
            if (Screen[5][19] == 1)
            {
                Pixel120.BackColor = Color.White;
            }
            else
            {
                Pixel120.BackColor = Color.Black;
            }
        }
        private void Check7()
        {
            if (Screen[6][0] == 1)
            {
                Pixel121.BackColor = Color.White;
            }
            else
            {
                Pixel121.BackColor = Color.Black;
            }
            if (Screen[6][1] == 1)
            {
                Pixel122.BackColor = Color.White;
            }
            else
            {
                Pixel122.BackColor = Color.Black;
            }
            if (Screen[6][2] == 1)
            {
                Pixel123.BackColor = Color.White;
            }
            else
            {
                Pixel123.BackColor = Color.Black;
            }
            if (Screen[6][3] == 1)
            {
                Pixel124.BackColor = Color.White;
            }
            else
            {
                Pixel124.BackColor = Color.Black;
            }
            if (Screen[6][4] == 1)
            {
                Pixel125.BackColor = Color.White;
            }
            else
            {
                Pixel125.BackColor = Color.Black;
            }
            if (Screen[6][5] == 1)
            {
                Pixel126.BackColor = Color.White;
            }
            else
            {
                Pixel126.BackColor = Color.Black;
            }
            if (Screen[6][6] == 1)
            {
                Pixel127.BackColor = Color.White;
            }
            else
            {
                Pixel127.BackColor = Color.Black;
            }
            if (Screen[6][7] == 1)
            {
                Pixel128.BackColor = Color.White;
            }
            else
            {
                Pixel128.BackColor = Color.Black;
            }
            if (Screen[6][8] == 1)
            {
                Pixel129.BackColor = Color.White;
            }
            else
            {
                Pixel129.BackColor = Color.Black;
            }
            if (Screen[6][9] == 1)
            {
                Pixel130.BackColor = Color.White;
            }
            else
            {
                Pixel130.BackColor = Color.Black;
            }
            if (Screen[6][10] == 1)
            {
                Pixel131.BackColor = Color.White;
            }
            else
            {
                Pixel131.BackColor = Color.Black;
            }
            if (Screen[6][11] == 1)
            {
                Pixel132.BackColor = Color.White;
            }
            else
            {
                Pixel132.BackColor = Color.Black;
            }
            if (Screen[6][12] == 1)
            {
                Pixel133.BackColor = Color.White;
            }
            else
            {
                Pixel133.BackColor = Color.Black;
            }
            if (Screen[6][13] == 1)
            {
                Pixel134.BackColor = Color.White;
            }
            else
            {
                Pixel134.BackColor = Color.Black;
            }
            if (Screen[6][14] == 1)
            {
                Pixel135.BackColor = Color.White;
            }
            else
            {
                Pixel135.BackColor = Color.Black;
            }
            if (Screen[6][15] == 1)
            {
                Pixel136.BackColor = Color.White;
            }
            else
            {
                Pixel136.BackColor = Color.Black;
            }
            if (Screen[6][16] == 1)
            {
                Pixel137.BackColor = Color.White;
            }
            else
            {
                Pixel137.BackColor = Color.Black;
            }
            if (Screen[6][17] == 1)
            {
                Pixel138.BackColor = Color.White;
            }
            else
            {
                Pixel138.BackColor = Color.Black;
            }
            if (Screen[6][18] == 1)
            {
                Pixel139.BackColor = Color.White;
            }
            else
            {
                Pixel139.BackColor = Color.Black;
            }
            if (Screen[6][19] == 1)
            {
                Pixel40.BackColor = Color.White;
            }
            else
            {
                Pixel40.BackColor = Color.Black;
            }
        }
        private void Check8()
        {
            if (Screen[7][0] == 1)
            {
                Pixel141.BackColor = Color.White;
            }
            else
            {
                Pixel141.BackColor = Color.Black;
            }
            if (Screen[7][1] == 1)
            {
                Pixel142.BackColor = Color.White;
            }
            else
            {
                Pixel142.BackColor = Color.Black;
            }
            if (Screen[7][2] == 1)
            {
                Pixel143.BackColor = Color.White;
            }
            else
            {
                Pixel143.BackColor = Color.Black;
            }
            if (Screen[7][3] == 1)
            {
                Pixel144.BackColor = Color.White;
            }
            else
            {
                Pixel144.BackColor = Color.Black;
            }
            if (Screen[7][4] == 1)
            {
                Pixel145.BackColor = Color.White;
            }
            else
            {
                Pixel145.BackColor = Color.Black;
            }
            if (Screen[7][5] == 1)
            {
                Pixel146.BackColor = Color.White;
            }
            else
            {
                Pixel146.BackColor = Color.Black;
            }
            if (Screen[7][6] == 1)
            {
                Pixel147.BackColor = Color.White;
            }
            else
            {
                Pixel147.BackColor = Color.Black;
            }
            if (Screen[7][7] == 1)
            {
                Pixel148.BackColor = Color.White;
            }
            else
            {
                Pixel148.BackColor = Color.Black;
            }
            if (Screen[7][8] == 1)
            {
                Pixel149.BackColor = Color.White;
            }
            else
            {
                Pixel149.BackColor = Color.Black;
            }
            if (Screen[7][9] == 1)
            {
                Pixel150.BackColor = Color.White;
            }
            else
            {
                Pixel150.BackColor = Color.Black;
            }
            if (Screen[7][10] == 1)
            {
                Pixel151.BackColor = Color.White;
            }
            else
            {
                Pixel151.BackColor = Color.Black;
            }
            if (Screen[7][11] == 1)
            {
                Pixel152.BackColor = Color.White;
            }
            else
            {
                Pixel152.BackColor = Color.Black;
            }
            if (Screen[7][12] == 1)
            {
                Pixel153.BackColor = Color.White;
            }
            else
            {
                Pixel153.BackColor = Color.Black;
            }
            if (Screen[7][13] == 1)
            {
                Pixel154.BackColor = Color.White;
            }
            else
            {
                Pixel154.BackColor = Color.Black;
            }
            if (Screen[7][14] == 1)
            {
                Pixel155.BackColor = Color.White;
            }
            else
            {
                Pixel155.BackColor = Color.Black;
            }
            if (Screen[7][15] == 1)
            {
                Pixel156.BackColor = Color.White;
            }
            else
            {
                Pixel156.BackColor = Color.Black;
            }
            if (Screen[7][16] == 1)
            {
                Pixel157.BackColor = Color.White;
            }
            else
            {
                Pixel157.BackColor = Color.Black;
            }
            if (Screen[7][17] == 1)
            {
                Pixel158.BackColor = Color.White;
            }
            else
            {
                Pixel158.BackColor = Color.Black;
            }
            if (Screen[7][18] == 1)
            {
                Pixel159.BackColor = Color.White;
            }
            else
            {
                Pixel159.BackColor = Color.Black;
            }
            if (Screen[7][19] == 1)
            {
                Pixel160.BackColor = Color.White;
            }
            else
            {
                Pixel160.BackColor = Color.Black;
            }
        }
        private void Check9()
        {
            if (Screen[8][0] == 1)
            {
                Pixel161.BackColor = Color.White;
            }
            else
            {
                Pixel161.BackColor = Color.Black;
            }
            if (Screen[8][1] == 1)
            {
                Pixel162.BackColor = Color.White;
            }
            else
            {
                Pixel162.BackColor = Color.Black;
            }
            if (Screen[8][2] == 1)
            {
                Pixel163.BackColor = Color.White;
            }
            else
            {
                Pixel163.BackColor = Color.Black;
            }
            if (Screen[8][3] == 1)
            {
                Pixel164.BackColor = Color.White;
            }
            else
            {
                Pixel164.BackColor = Color.Black;
            }
            if (Screen[8][4] == 1)
            {
                Pixel165.BackColor = Color.White;
            }
            else
            {
                Pixel165.BackColor = Color.Black;
            }
            if (Screen[8][5] == 1)
            {
                Pixel166.BackColor = Color.White;
            }
            else
            {
                Pixel166.BackColor = Color.Black;
            }
            if (Screen[8][6] == 1)
            {
                Pixel167.BackColor = Color.White;
            }
            else
            {
                Pixel167.BackColor = Color.Black;
            }
            if (Screen[8][7] == 1)
            {
                Pixel168.BackColor = Color.White;
            }
            else
            {
                Pixel168.BackColor = Color.Black;
            }
            if (Screen[8][8] == 1)
            {
                Pixel169.BackColor = Color.White;
            }
            else
            {
                Pixel169.BackColor = Color.Black;
            }
            if (Screen[8][9] == 1)
            {
                Pixel170.BackColor = Color.White;
            }
            else
            {
                Pixel170.BackColor = Color.Black;
            }
            if (Screen[8][10] == 1)
            {
                Pixel171.BackColor = Color.White;
            }
            else
            {
                Pixel171.BackColor = Color.Black;
            }
            if (Screen[8][11] == 1)
            {
                Pixel172.BackColor = Color.White;
            }
            else
            {
                Pixel172.BackColor = Color.Black;
            }
            if (Screen[8][12] == 1)
            {
                Pixel173.BackColor = Color.White;
            }
            else
            {
                Pixel173.BackColor = Color.Black;
            }
            if (Screen[8][13] == 1)
            {
                Pixel174.BackColor = Color.White;
            }
            else
            {
                Pixel174.BackColor = Color.Black;
            }
            if (Screen[8][14] == 1)
            {
                Pixel175.BackColor = Color.White;
            }
            else
            {
                Pixel175.BackColor = Color.Black;
            }
            if (Screen[8][15] == 1)
            {
                Pixel176.BackColor = Color.White;
            }
            else
            {
                Pixel176.BackColor = Color.Black;
            }
            if (Screen[8][16] == 1)
            {
                Pixel177.BackColor = Color.White;
            }
            else
            {
                Pixel177.BackColor = Color.Black;
            }
            if (Screen[8][17] == 1)
            {
                Pixel178.BackColor = Color.White;
            }
            else
            {
                Pixel178.BackColor = Color.Black;
            }
            if (Screen[8][18] == 1)
            {
                Pixel179.BackColor = Color.White;
            }
            else
            {
                Pixel179.BackColor = Color.Black;
            }
            if (Screen[8][19] == 1)
            {
                Pixel180.BackColor = Color.White;
            }
            else
            {
                Pixel180.BackColor = Color.Black;
            }
        }
        private void Check10()
        {
            if (Screen[9][0] == 1)
            {
                Pixel181.BackColor = Color.White;
            }
            else
            {
                Pixel181.BackColor = Color.Black;
            }
            if (Screen[9][1] == 1)
            {
                Pixel182.BackColor = Color.White;
            }
            else
            {
                Pixel182.BackColor = Color.Black;
            }
            if (Screen[9][2] == 1)
            {
                Pixel183.BackColor = Color.White;
            }
            else
            {
                Pixel183.BackColor = Color.Black;
            }
            if (Screen[9][3] == 1)
            {
                Pixel184.BackColor = Color.White;
            }
            else
            {
                Pixel184.BackColor = Color.Black;
            }
            if (Screen[9][4] == 1)
            {
                Pixel185.BackColor = Color.White;
            }
            else
            {
                Pixel185.BackColor = Color.Black;
            }
            if (Screen[9][5] == 1)
            {
                Pixel186.BackColor = Color.White;
            }
            else
            {
                Pixel186.BackColor = Color.Black;
            }
            if (Screen[9][6] == 1)
            {
                Pixel187.BackColor = Color.White;
            }
            else
            {
                Pixel187.BackColor = Color.Black;
            }
            if (Screen[9][7] == 1)
            {
                Pixel188.BackColor = Color.White;
            }
            else
            {
                Pixel188.BackColor = Color.Black;
            }
            if (Screen[9][8] == 1)
            {
                Pixel189.BackColor = Color.White;
            }
            else
            {
                Pixel189.BackColor = Color.Black;
            }
            if (Screen[9][9] == 1)
            {
                Pixel190.BackColor = Color.White;
            }
            else
            {
                Pixel190.BackColor = Color.Black;
            }
            if (Screen[9][10] == 1)
            {
                Pixel191.BackColor = Color.White;
            }
            else
            {
                Pixel191.BackColor = Color.Black;
            }
            if (Screen[9][11] == 1)
            {
                Pixel192.BackColor = Color.White;
            }
            else
            {
                Pixel192.BackColor = Color.Black;
            }
            if (Screen[9][12] == 1)
            {
                Pixel193.BackColor = Color.White;
            }
            else
            {
                Pixel193.BackColor = Color.Black;
            }
            if (Screen[9][13] == 1)
            {
                Pixel194.BackColor = Color.White;
            }
            else
            {
                Pixel194.BackColor = Color.Black;
            }
            if (Screen[9][14] == 1)
            {
                Pixel195.BackColor = Color.White;
            }
            else
            {
                Pixel195.BackColor = Color.Black;
            }
            if (Screen[9][15] == 1)
            {
                Pixel196.BackColor = Color.White;
            }
            else
            {
                Pixel196.BackColor = Color.Black;
            }
            if (Screen[9][16] == 1)
            {
                Pixel197.BackColor = Color.White;
            }
            else
            {
                Pixel197.BackColor = Color.Black;
            }
            if (Screen[9][17] == 1)
            {
                Pixel198.BackColor = Color.White;
            }
            else
            {
                Pixel198.BackColor = Color.Black;
            }
            if (Screen[9][18] == 1)
            {
                Pixel199.BackColor = Color.White;
            }
            else
            {
                Pixel199.BackColor = Color.Black;
            }
            if (Screen[9][19] == 1)
            {
                Pixel200.BackColor = Color.White;
            }
            else
            {
                Pixel200.BackColor = Color.Black;
            }
        }

        private void NextCheck()
        {
            switch (DeckBLock)
            {
                case 1:
                    Block1Pan.BringToFront();
                    break;
                case 2:
                    Block2Pan.BringToFront();
                    break;
                case 3:
                    Block3Pan.BringToFront();
                    break;
                case 4:
                    Block4Pan.BringToFront();
                    break;
            }
        }
        #endregion

        /// <summary>
        /// Timer Check - Event triggered by the timer (checks which block is active)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            switch (dummy)
            {
                case 0:
                    wait = 1;
                    LineCheck();
                    coreH = 20;
                    coreW = 5;
                    rotation = 1;
                    //dummy = 4;
                    dummy = DeckBLock;
                    DeckBLock = block.Next(1, 5);
                    NextCheck();
                    if (dummy == 1)
                    {
                        coreH = 21;
                    }
                    break;
                case 1:
                    LongPiece();
                    break;
                case 2:
                    SquarePiece();
                    break;
                case 3:
                    TeePiece();
                    break;
                case 4:
                    LPiece();
                    break;
            };

        }

        #region User Inputs
        /// <summary>
        /// Left Button - Moves the current block left 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            //Left
            switch (dummy)
            {
                case 1:
                    LongPieceLeft();
                    break;
                case 2:
                    SquarePieceLeft();
                    break;
                case 3:
                    TeePieceLeft();
                    break;
                case 4:
                    LPieceLeft();
                    break;
            }
        }

        /// <summary>
        /// Right Button - Moves the current block right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Right
            switch (dummy)
            {
                case 1:
                    LongPieceRight();
                    break;
                case 2:
                    SquarePieceRight();
                    break;
                case 3:
                    TeePieceRight();
                    break;
                case 4:
                    LPieceRight();
                    break;
            }
        }

        /// <summary>
        /// Rotation Button - Cycles through the blocks rotations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //rotation
            switch (dummy)
            {
                case 1:
                    LongPieceRotate();
                    break;
                case 2:
                    //Its a Block, so Im good
                    break;
                case 3:
                    TeePieceRotate();
                    break;
                case 4:
                    LPieceRotate();
                    break;
            }
        }

        /// <summary>
        /// Drop Button - Places blocks at the lowest level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //drop
            if (coreH < 19 && wait == 1)
            {
                wait = 0;
                int done = 0;
                timer1.Stop();
                switch (dummy)
                {
                    case 1:
                        if (rotation == 1)
                        {
                            Screen[coreW - 1][coreH + 2] = 0;
                            Screen[coreW - 1][coreH + 1] = 0;
                            Screen[coreW - 1][coreH] = 0;
                            Screen[coreW - 1][coreH - 1] = 0;
                            Screen[coreW - 1][coreH - 2] = 0;
                            do
                            {
                                if (coreH == 2)
                                {
                                    done = 1;
                                }
                                else if (Screen[coreW - 1][coreH - 3] == 1)
                                {
                                    done = 1;
                                }
                                else
                                {
                                    coreH -= 1;
                                }
                            } while (done == 0);
                            Screen[coreW - 1][coreH + 1] = 1;
                            Screen[coreW - 1][coreH] = 1;
                            Screen[coreW - 1][coreH - 1] = 1;
                            Screen[coreW - 1][coreH - 2] = 1;
                        }
                        else if (rotation == 2)
                        {
                            Screen[coreW - 2][coreH + 1] = 0;
                            Screen[coreW - 3][coreH + 1] = 0;
                            Screen[coreW][coreH + 1] = 0;
                            Screen[coreW - 1][coreH + 1] = 0;
                            Screen[coreW - 2][coreH] = 0;
                            Screen[coreW - 3][coreH] = 0;
                            Screen[coreW][coreH] = 0;
                            Screen[coreW - 1][coreH] = 0;
                            do
                            {
                                if (coreH == 0)
                                {
                                    done = 1;
                                }
                                else if (Screen[coreW - 1][coreH - 1] == 1 || Screen[coreW][coreH - 1] == 1 || Screen[coreW - 2][coreH - 1] == 1 || Screen[coreW - 3][coreH - 1] == 1)
                                {
                                    done = 1;
                                }
                                else
                                {
                                    coreH -= 1;
                                }
                            } while (done == 0);
                            Screen[coreW - 2][coreH] = 1;
                            Screen[coreW - 3][coreH] = 1;
                            Screen[coreW][coreH] = 1;
                            Screen[coreW - 1][coreH] = 1;
                        }
                        else if (rotation == 3)
                        {
                            Screen[coreW - 1][coreH + 3] = 0;
                            Screen[coreW - 1][coreH + 2] = 0;
                            Screen[coreW - 1][coreH + 1] = 0;
                            Screen[coreW - 1][coreH] = 0;
                            Screen[coreW - 1][coreH - 1] = 0;
                            do
                            {
                                if (coreH == 1)
                                {
                                    done = 1;
                                }
                                else if (Screen[coreW - 1][coreH - 2] == 1)
                                {
                                    done = 1;
                                }
                                else
                                {
                                    coreH -= 1;
                                }
                            } while (done == 0);
                            Screen[coreW - 1][coreH + 2] = 1;
                            Screen[coreW - 1][coreH + 1] = 1;
                            Screen[coreW - 1][coreH] = 1;
                            Screen[coreW - 1][coreH - 1] = 1;
                        }
                        else if (rotation == 4)
                        {
                            Screen[coreW - 2][coreH + 1] = 0;
                            Screen[coreW + 1][coreH + 1] = 0;
                            Screen[coreW][coreH + 1] = 0;
                            Screen[coreW - 1][coreH + 1] = 0;
                            Screen[coreW - 2][coreH] = 0;
                            Screen[coreW + 1][coreH] = 0;
                            Screen[coreW][coreH] = 0;
                            Screen[coreW - 1][coreH] = 0;
                            do
                            {
                                if (coreH == 0)
                                {
                                    done = 1;
                                }
                                else if (Screen[coreW - 1][coreH - 1] == 1 || Screen[coreW][coreH - 1] == 1 || Screen[coreW + 1][coreH - 1] == 1 || Screen[coreW - 2][coreH - 1] == 1)
                                {
                                    done = 1;
                                }
                                else
                                {
                                    coreH -= 1;
                                }
                            } while (done == 0);
                            Screen[coreW - 2][coreH] = 1;
                            Screen[coreW + 1][coreH] = 1;
                            Screen[coreW][coreH] = 1;
                            Screen[coreW - 1][coreH] = 1;
                        }
                        timer1.Start();
                        LongPiece();
                        Check();
                        break;
                    case 2:
                        Screen[coreW - 1][coreH + 2] = 0;
                        Screen[coreW][coreH + 2] = 0;
                        Screen[coreW - 1][coreH + 1] = 0;
                        Screen[coreW][coreH + 1] = 0;
                        Screen[coreW - 1][coreH] = 0;
                        Screen[coreW][coreH] = 0;
                        do
                        {

                            if (coreH == 0)
                            {
                                done = 1;
                            }
                            else if (Screen[coreW - 1][coreH - 1] == 1 || Screen[coreW][coreH - 1] == 1)
                            {
                                done = 1;
                            }
                            else
                            {
                                coreH -= 1;
                            }
                        } while (done == 0);
                        Screen[coreW - 1][coreH + 1] = 1;
                        Screen[coreW][coreH + 1] = 1;
                        Screen[coreW - 1][coreH] = 1;
                        Screen[coreW][coreH] = 1;
                        SquarePiece();
                        Check();
                        timer1.Start();
                        break;
                    case 3:
                        if (rotation == 1)
                        {
                            Screen[coreW][coreH + 2] = 0;
                            Screen[coreW - 1][coreH + 1] = 0;
                            Screen[coreW - 1][coreH] = 0;
                            Screen[coreW][coreH + 1] = 0;
                            Screen[coreW][coreH] = 0;
                            Screen[coreW][coreH - 1] = 0;
                            do
                            {
                                if (coreH == 1)
                                {
                                    done = 1;
                                }
                                else if (Screen[coreW][coreH - 2] == 1 || Screen[coreW - 1][coreH - 1] == 1)
                                {
                                    done = 1;
                                }
                                else
                                {
                                    coreH -= 1;
                                }
                            } while (done == 0);
                            Screen[coreW - 1][coreH] = 1;
                            Screen[coreW][coreH + 1] = 1;
                            Screen[coreW][coreH] = 1;
                            Screen[coreW][coreH - 1] = 1;
                        }
                        else if (rotation == 2)
                        {
                            Screen[coreW - 1][coreH + 1] = 0;
                            Screen[coreW][coreH + 1] = 0;
                            Screen[coreW + 1][coreH + 1] = 0;
                            Screen[coreW - 1][coreH] = 0;
                            Screen[coreW][coreH] = 0;
                            Screen[coreW + 1][coreH] = 0;
                            Screen[coreW][coreH - 1] = 0;
                            do
                            {
                                if (coreH == 1)
                                {
                                    done = 1;
                                }
                                else if (Screen[coreW][coreH - 2] == 1 || Screen[coreW - 1][coreH - 1] == 1 || Screen[coreW + 1][coreH - 1] == 1)
                                {
                                    done = 1;
                                }
                                else
                                {
                                    coreH -= 1;
                                }
                            } while (done == 0);
                            Screen[coreW - 1][coreH] = 1;
                            Screen[coreW][coreH] = 1;
                            Screen[coreW + 1][coreH] = 1;
                            Screen[coreW][coreH - 1] = 1;
                        }
                        else if (rotation == 3)
                        {
                            Screen[coreW][coreH + 2] = 0;
                            Screen[coreW + 1][coreH + 1] = 0;
                            Screen[coreW + 1][coreH] = 0;
                            Screen[coreW][coreH + 1] = 0;
                            Screen[coreW][coreH] = 0;
                            Screen[coreW][coreH - 1] = 0;
                            do
                            {
                                if (coreH == 1)
                                {
                                    done = 1;
                                }
                                else if (Screen[coreW][coreH - 2] == 1 || Screen[coreW + 1][coreH - 1] == 1)
                                {
                                    done = 1;
                                }
                                else
                                {
                                    coreH -= 1;
                                }
                            } while (done == 0);
                            Screen[coreW + 1][coreH] = 1;
                            Screen[coreW][coreH + 1] = 1;
                            Screen[coreW][coreH] = 1;
                            Screen[coreW][coreH - 1] = 1;
                        }
                        else if (rotation == 4)
                        {
                            Screen[coreW - 1][coreH + 1] = 0;
                            Screen[coreW][coreH + 2] = 0;
                            Screen[coreW + 1][coreH + 1] = 0;
                            Screen[coreW - 1][coreH] = 0;
                            Screen[coreW][coreH] = 0;
                            Screen[coreW + 1][coreH] = 0;
                            Screen[coreW][coreH + 1] = 0;
                            do
                            {
                                if (coreH == 0)
                                {
                                    done = 1;
                                }
                                else if (Screen[coreW][coreH - 1] == 1 || Screen[coreW - 1][coreH - 1] == 1 || Screen[coreW + 1][coreH - 1] == 1)
                                {
                                    done = 1;
                                }
                                else
                                {
                                    coreH -= 1;
                                }
                            } while (done == 0);
                            Screen[coreW - 1][coreH] = 1;
                            Screen[coreW][coreH] = 1;
                            Screen[coreW + 1][coreH] = 1;
                            Screen[coreW][coreH + 1] = 1;
                        }
                        TeePiece();
                        Check();
                        timer1.Start();
                        break;
                    case 4:
                        if (rotation == 1)
                        {
                            Screen[coreW][coreH + 2] = 0;
                            Screen[coreW - 1][coreH + 2] = 0;
                            Screen[coreW - 1][coreH + 1] = 0;
                            Screen[coreW][coreH + 1] = 0;
                            Screen[coreW][coreH] = 0;
                            Screen[coreW][coreH - 1] = 0;
                            do
                            {
                                if (coreH == 1)
                                {
                                    done = 1;
                                }
                                else if (Screen[coreW - 1][coreH] == 1 || Screen[coreW][coreH - 2] == 1)
                                {
                                    done = 1;
                                }
                                else
                                {
                                    coreH -= 1;
                                }
                            } while (done == 0);
                            Screen[coreW - 1][coreH + 1] = 1;
                            Screen[coreW][coreH + 1] = 1;
                            Screen[coreW][coreH] = 1;
                            Screen[coreW][coreH - 1] = 1;
                        }
                        else if (rotation == 2)
                        {
                            Screen[coreW + 1][coreH + 1] = 0;
                            Screen[coreW - 1][coreH + 1] = 0;
                            Screen[coreW][coreH + 1] = 0;
                            Screen[coreW - 1][coreH - 1] = 0;
                            Screen[coreW - 1][coreH] = 0;
                            Screen[coreW + 1][coreH] = 0;
                            Screen[coreW][coreH] = 0;
                            do
                            {
                                if (coreH == 1)
                                {
                                    done = 1;
                                }
                                else if (Screen[coreW - 1][coreH - 2] == 1 || Screen[coreW][coreH - 1] == 1 || Screen[coreW + 1][coreH - 1] == 1)
                                {
                                    done = 1;
                                }
                                else
                                {
                                    coreH -= 1;
                                }
                            } while (done == 0);
                            Screen[coreW - 1][coreH - 1] = 1;
                            Screen[coreW - 1][coreH] = 1;
                            Screen[coreW + 1][coreH] = 1;
                            Screen[coreW][coreH] = 1;
                        }
                        else if (rotation == 3)
                        {
                            Screen[coreW + 1][coreH] = 0;
                            Screen[coreW][coreH + 2] = 0;
                            Screen[coreW][coreH + 1] = 0;
                            Screen[coreW][coreH] = 0;
                            Screen[coreW][coreH - 1] = 0;
                            Screen[coreW + 1][coreH - 1] = 0;
                            do
                            {
                                if (coreH == 1)
                                {
                                    done = 1;
                                }
                                else if (Screen[coreW][coreH - 2] == 1 || Screen[coreW + 1][coreH - 2] == 1)
                                {
                                    done = 1;
                                }
                                else
                                {
                                    coreH -= 1;
                                }

                            } while (done == 0);
                            Screen[coreW][coreH + 1] = 1;
                            Screen[coreW][coreH] = 1;
                            Screen[coreW][coreH - 1] = 1;
                            Screen[coreW + 1][coreH - 1] = 1;
                        }
                        else if (rotation == 4)
                        {
                            Screen[coreW + 1][coreH + 2] = 0;
                            Screen[coreW - 1][coreH + 1] = 0;
                            Screen[coreW][coreH + 1] = 0;
                            Screen[coreW + 1][coreH + 1] = 0;
                            Screen[coreW - 1][coreH] = 0;
                            Screen[coreW + 1][coreH] = 0;
                            Screen[coreW][coreH] = 0;
                            do
                            {
                                if (coreH == 0)
                                {
                                    done = 1;
                                }
                                else if (Screen[coreW - 1][coreH - 1] == 1 || Screen[coreW][coreH - 1] == 1 || Screen[coreW + 1][coreH - 1] == 1)
                                {
                                    done = 1;
                                }
                                else
                                {
                                    coreH -= 1;
                                }
                            } while (done == 0);
                            Screen[coreW + 1][coreH + 1] = 1;
                            Screen[coreW - 1][coreH] = 1;
                            Screen[coreW + 1][coreH] = 1;
                            Screen[coreW][coreH] = 1;
                        }
                        LPiece();
                        Check();
                        timer1.Start();
                        break;
                }
            }
        }

        /// <summary>
        /// Start Button - Begins the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //start button
            StartButton.Hide();
            LoseScreen.SendToBack();
            Reset();
        }
        #endregion

        #region Ambient Blocks

        /// <summary>
        /// Long Piece Ambient - The falling of the Long Piece
        /// </summary>
        private void LongPiece()
        {

            if (rotation == 1)
            {
                Screen[coreW - 1][coreH + 2] = 0;
                Screen[coreW - 1][coreH + 1] = 1;
                Screen[coreW - 1][coreH] = 1;
                Screen[coreW - 1][coreH - 1] = 1;
                Screen[coreW - 1][coreH - 2] = 1;
                Check();
                if (coreH == 2)
                {
                    dummy = 0;
                }
                else if (Screen[coreW - 1][coreH - 3] == 1)
                {
                    dummy = 0;
                }
                if (dummy == 0)
                {
                    try
                    {
                        lines[coreH] += 1;
                        lines[coreH - 1] += 1;
                        lines[coreH - 2] += 1;
                        lines[coreH + 1] += 1;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        timer1.Stop();
                        LoseScreen.BringToFront();
                        StartButton.Show();
                    }
                }
                coreH -= 1;

            }
            else if (rotation == 2)
            {
                Screen[coreW - 2][coreH + 1] = 0;
                Screen[coreW - 3][coreH + 1] = 0;
                Screen[coreW][coreH + 1] = 0;
                Screen[coreW - 1][coreH + 1] = 0;
                Screen[coreW - 2][coreH] = 1;
                Screen[coreW - 3][coreH] = 1;
                Screen[coreW][coreH] = 1;
                Screen[coreW - 1][coreH] = 1;
                Check();
                if (coreH == 0)
                {
                    dummy = 0;
                }
                else if (Screen[coreW - 1][coreH - 1] == 1 || Screen[coreW][coreH - 1] == 1 || Screen[coreW - 2][coreH - 1] == 1 || Screen[coreW - 3][coreH - 1] == 1)
                {
                    dummy = 0;
                }
                if (dummy == 0)
                {
                    try
                    {
                        lines[coreH] += 4;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        timer1.Stop();
                        LoseScreen.BringToFront();
                        StartButton.Show();
                    }
                }
                coreH -= 1;
            }
            else if (rotation == 3)
            {
                Screen[coreW - 1][coreH + 3] = 0;
                Screen[coreW - 1][coreH + 2] = 1;
                Screen[coreW - 1][coreH + 1] = 1;
                Screen[coreW - 1][coreH] = 1;
                Screen[coreW - 1][coreH - 1] = 1;
                Check();
                if (coreH == 1)
                {
                    dummy = 0;
                }
                else if (Screen[coreW - 1][coreH - 2] == 1)
                {
                    dummy = 0;
                }
                if (dummy == 0)
                {
                    try
                    {
                        lines[coreH] += 1;
                        lines[coreH - 1] += 1;
                        lines[coreH + 2] += 1;
                        lines[coreH + 1] += 1;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        timer1.Stop();
                        LoseScreen.BringToFront();
                        StartButton.Show();
                    }
                }
                coreH -= 1;

            }
            else if (rotation == 4)
            {
                Screen[coreW - 2][coreH + 1] = 0;
                Screen[coreW + 1][coreH + 1] = 0;
                Screen[coreW][coreH + 1] = 0;
                Screen[coreW - 1][coreH + 1] = 0;
                Screen[coreW - 2][coreH] = 1;
                Screen[coreW + 1][coreH] = 1;
                Screen[coreW][coreH] = 1;
                Screen[coreW - 1][coreH] = 1;
                Check();
                if (coreH == 0)
                {
                    dummy = 0;
                }
                else if (Screen[coreW - 1][coreH - 1] == 1 || Screen[coreW][coreH - 1] == 1 || Screen[coreW + 1][coreH - 1] == 1 || Screen[coreW - 2][coreH - 1] == 1)
                {
                    dummy = 0;
                }
                if (dummy == 0)
                {
                    try
                    {
                        lines[coreH] += 4;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        timer1.Stop();
                        LoseScreen.BringToFront();
                        StartButton.Show();
                    }
                }
                coreH -= 1;
            }
        }

        /// <summary>
        /// Square Piece Ambient - The falling of the Square Piece
        /// </summary>
        private void SquarePiece()
        {
            Screen[coreW - 1][coreH + 2] = 0;
            Screen[coreW][coreH + 2] = 0;
            Screen[coreW - 1][coreH + 1] = 1;
            Screen[coreW][coreH + 1] = 1;
            Screen[coreW - 1][coreH] = 1;
            Screen[coreW][coreH] = 1;
            Check();
            if (coreH == 0)
            {
                dummy = 0;
            }
            else if (Screen[coreW - 1][coreH - 1] == 1 || Screen[coreW][coreH - 1] == 1)
            {
                dummy = 0;
            }
            if (dummy == 0)
            {
                try
                {
                    lines[coreH + 1] += 2;
                    lines[coreH] += 2;
                }
                catch (IndexOutOfRangeException)
                {
                    timer1.Stop();
                    LoseScreen.BringToFront();
                    StartButton.Show();
                }
            }
            coreH -= 1;
        }

        /// <summary>
        /// Tee Piece Ambient - The falling of the Tee Piece
        /// </summary>
        private void TeePiece()
        {

            if (rotation == 1)
            {
                Screen[coreW][coreH + 2] = 0;
                Screen[coreW - 1][coreH + 1] = 0;
                Screen[coreW - 1][coreH] = 1;
                Screen[coreW][coreH + 1] = 1;
                Screen[coreW][coreH] = 1;
                Screen[coreW][coreH - 1] = 1;
                Check();
                if (coreH == 1)
                {
                    dummy = 0;
                }
                else if (Screen[coreW][coreH - 2] == 1 || Screen[coreW - 1][coreH - 1] == 1)
                {
                    dummy = 0;
                }
                if (dummy == 0)
                {
                    try
                    {
                        lines[coreH] += 2;
                        lines[coreH + 1] += 1;
                        lines[coreH - 1] += 1;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        timer1.Stop();
                        LoseScreen.BringToFront();
                        StartButton.Show();
                    }
                }
                coreH -= 1;

            }
            else if (rotation == 2)
            {
                Screen[coreW - 1][coreH + 1] = 0;
                Screen[coreW][coreH + 1] = 0;
                Screen[coreW + 1][coreH + 1] = 0;
                Screen[coreW - 1][coreH] = 1;
                Screen[coreW][coreH] = 1;
                Screen[coreW + 1][coreH] = 1;
                Screen[coreW][coreH - 1] = 1;
                Check();
                if (coreH == 1)
                {
                    dummy = 0;
                }
                else if (Screen[coreW][coreH - 2] == 1 || Screen[coreW - 1][coreH - 1] == 1 || Screen[coreW + 1][coreH - 1] == 1)
                {
                    dummy = 0;
                }
                if (dummy == 0)
                {
                    try
                    {
                        lines[coreH] += 3;
                        lines[coreH - 1] += 1;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        timer1.Stop();
                        LoseScreen.BringToFront();
                        StartButton.Show();
                    }
                }
                coreH -= 1;
            }
            else if (rotation == 3)
            {
                Screen[coreW][coreH + 2] = 0;
                Screen[coreW + 1][coreH + 1] = 0;
                Screen[coreW + 1][coreH] = 1;
                Screen[coreW][coreH + 1] = 1;
                Screen[coreW][coreH] = 1;
                Screen[coreW][coreH - 1] = 1;
                Check();
                if (coreH == 1)
                {
                    dummy = 0;
                }
                else if (Screen[coreW][coreH - 2] == 1 || Screen[coreW + 1][coreH - 1] == 1)
                {
                    dummy = 0;
                }
                if (dummy == 0)
                {
                    try
                    {
                        lines[coreH] += 2;
                        lines[coreH + 1] += 1;
                        lines[coreH - 1] += 1;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        timer1.Stop();
                        LoseScreen.BringToFront();
                        StartButton.Show();
                    }
                }
                coreH -= 1;

            }
            else if (rotation == 4)
            {
                Screen[coreW - 1][coreH + 1] = 0;
                Screen[coreW][coreH + 2] = 0;
                Screen[coreW + 1][coreH + 1] = 0;
                Screen[coreW - 1][coreH] = 1;
                Screen[coreW][coreH] = 1;
                Screen[coreW + 1][coreH] = 1;
                Screen[coreW][coreH + 1] = 1;
                Check();
                if (coreH == 0)
                {
                    dummy = 0;
                }
                else if (Screen[coreW][coreH - 1] == 1 || Screen[coreW - 1][coreH - 1] == 1 || Screen[coreW + 1][coreH - 1] == 1)
                {
                    dummy = 0;
                }
                if (dummy == 0)
                {
                    try
                    {
                        lines[coreH] += 3;
                        lines[coreH + 1] += 1;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        timer1.Stop();
                        LoseScreen.BringToFront();
                        StartButton.Show();
                    }
                }
                coreH -= 1;
            }
        }

        /// <summary>
        /// L Piece Ambient - The falling of the L Piece
        /// </summary>
        private void LPiece()
        {

            if (rotation == 1)
            {
                Screen[coreW][coreH + 2] = 0;
                Screen[coreW - 1][coreH + 2] = 0;
                Screen[coreW - 1][coreH + 1] = 1;
                Screen[coreW][coreH + 1] = 1;
                Screen[coreW][coreH] = 1;
                Screen[coreW][coreH - 1] = 1;
                Check();
                if (coreH == 1)
                {
                    dummy = 0;
                }
                else if (Screen[coreW - 1][coreH] == 1 || Screen[coreW][coreH - 2] == 1)
                {
                    dummy = 0;
                }
                if (dummy == 0)
                {
                    try
                    {
                        lines[coreH] += 1;
                        lines[coreH - 1] += 1;
                        lines[coreH + 1] += 2;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        timer1.Stop();
                        LoseScreen.BringToFront();
                        StartButton.Show();
                    }
                }
                coreH -= 1;

            }
            else if (rotation == 2)
            {
                Screen[coreW + 1][coreH + 1] = 0;
                Screen[coreW - 1][coreH + 1] = 0;
                Screen[coreW][coreH + 1] = 0;
                Screen[coreW - 1][coreH - 1] = 1;
                Screen[coreW - 1][coreH] = 1;
                Screen[coreW + 1][coreH] = 1;
                Screen[coreW][coreH] = 1;
                Check();
                if (coreH == 1)
                {
                    dummy = 0;
                }
                else if (Screen[coreW - 1][coreH - 2] == 1 || Screen[coreW][coreH - 1] == 1 || Screen[coreW + 1][coreH - 1] == 1)
                {
                    dummy = 0;
                }
                if (dummy == 0)
                {
                    try
                    {
                        lines[coreH - 1] += 1;
                        lines[coreH] += 3;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        timer1.Stop();
                        LoseScreen.BringToFront();
                        StartButton.Show();
                    }
                }
                coreH -= 1;
            }
            else if (rotation == 3)
            {
                Screen[coreW + 1][coreH] = 0;
                Screen[coreW][coreH + 2] = 0;
                Screen[coreW][coreH + 1] = 1;
                Screen[coreW][coreH] = 1;
                Screen[coreW][coreH - 1] = 1;
                Screen[coreW + 1][coreH - 1] = 1;
                Check();
                if (coreH == 1)
                {
                    dummy = 0;
                }
                else if (Screen[coreW][coreH - 2] == 1 || Screen[coreW + 1][coreH - 2] == 1)
                {
                    dummy = 0;
                }
                if (dummy == 0)
                {
                    try
                    {
                        lines[coreH] += 1;
                        lines[coreH - 1] += 2;
                        lines[coreH + 1] += 1;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        timer1.Stop();
                        LoseScreen.BringToFront();
                        StartButton.Show();
                    }
                }
                coreH -= 1;

            }
            else if (rotation == 4)
            {
                Screen[coreW + 1][coreH + 2] = 0;
                Screen[coreW - 1][coreH + 1] = 0;
                Screen[coreW][coreH + 1] = 0;
                Screen[coreW + 1][coreH + 1] = 1;
                Screen[coreW - 1][coreH] = 1;
                Screen[coreW + 1][coreH] = 1;
                Screen[coreW][coreH] = 1;
                Check();
                if (coreH == 0)
                {
                    dummy = 0;
                }
                else if (Screen[coreW - 1][coreH - 1] == 1 || Screen[coreW][coreH - 1] == 1 || Screen[coreW + 1][coreH - 1] == 1)
                {
                    dummy = 0;
                }
                if (dummy == 0)
                {
                    try
                    {
                        lines[coreH] += 3;
                        lines[coreH + 1] += 1;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        timer1.Stop();
                        LoseScreen.BringToFront();
                        StartButton.Show();
                    }
                }
                coreH -= 1;
            }
        }
#endregion

        #region Block Movement
        #region Long Movement
        private void LongPieceLeft()
        {
            if (coreW > 1 && rotation == 1 && coreH > 1)
            {
                if (Screen[coreW - 2][coreH + 1] != 1 && Screen[coreW - 2][coreH - 2] != 1 && Screen[coreW - 2][coreH - 1] != 1 && Screen[coreW - 2][coreH] != 1)
                {
                    Screen[coreW - 1][coreH + 2] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW - 2][coreH + 1] = 1;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW - 2][coreH] = 1;
                    Screen[coreW - 1][coreH - 1] = 0;
                    Screen[coreW - 2][coreH - 1] = 1;
                    Screen[coreW - 1][coreH - 2] = 0;
                    Screen[coreW - 2][coreH - 2] = 1;
                    coreW -= 1;
                    Check();
                }
            }
            else if (rotation == 2 && (coreW - 3) > 0)
            {
                if (Screen[coreW - 4][coreH] != 1)
                {
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW - 4][coreH + 1] = 1;
                    coreW -= 1;
                    Check();
                }
            }
            else if (coreW > 1 && rotation == 3 && coreH > 1)
            {
                if (Screen[coreW - 2][coreH + 1] != 1 && Screen[coreW - 2][coreH + 2] != 1 && Screen[coreW - 2][coreH - 1] != 1 && Screen[coreW - 2][coreH] != 1)
                {
                    Screen[coreW - 1][coreH + 3] = 0;
                    Screen[coreW - 1][coreH + 2] = 0;
                    Screen[coreW - 2][coreH + 2] = 1;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW - 2][coreH] = 1;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW - 2][coreH + 1] = 1;
                    Screen[coreW - 1][coreH - 1] = 0;
                    Screen[coreW - 2][coreH - 1] = 1;
                    coreW -= 1;
                    Check();
                }
            }
            else if (rotation == 4 && (coreW - 2) > 0)
            {
                if (Screen[coreW - 3][coreH] != 1)
                {
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW - 3][coreH + 1] = 1;
                    coreW -= 1;
                    Check();
                }
            }
        }

        private void LongPieceRight()
        {
            if (coreW < 10 && rotation == 1 && coreH > 1)
            {
                if (Screen[coreW][coreH + 1] != 1 && Screen[coreW][coreH - 2] != 1 && Screen[coreW][coreH - 1] != 1 && Screen[coreW][coreH] != 1)
                {
                    Screen[coreW - 1][coreH + 2] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 1;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW - 1][coreH - 1] = 0;
                    Screen[coreW][coreH - 1] = 1;
                    Screen[coreW - 1][coreH - 2] = 0;
                    Screen[coreW][coreH - 2] = 1;
                    coreW += 1;
                    Check();
                }
            }
            else if (rotation == 2 && (coreW + 1) < 10 && coreH >= 0)
            {
                if (Screen[coreW + 1][coreH] != 1)
                {
                    Screen[coreW - 3][coreH + 1] = 0;
                    Screen[coreW + 1][coreH + 1] = 1;
                    coreW += 1;
                    Check();
                }
            }
            else if (coreW < 10 && rotation == 3 && coreH > 1)
            {
                if (Screen[coreW][coreH + 1] != 1 && Screen[coreW][coreH + 2] != 1 && Screen[coreW][coreH - 1] != 1 && Screen[coreW][coreH] != 1)
                {
                    Screen[coreW - 1][coreH + 3] = 0;
                    Screen[coreW - 1][coreH + 2] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW - 1][coreH - 1] = 0;
                    Screen[coreW - 1][coreH - 2] = 0;
                    Screen[coreW][coreH + 1] = 1;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW][coreH + 2] = 1;
                    Screen[coreW][coreH - 1] = 1;
                    coreW += 1;
                    Check();
                }
            }
            else if (rotation == 4 && (coreW + 2) < 10)
            {
                if (Screen[coreW + 2][coreH] != 1)
                {
                    Screen[coreW - 2][coreH + 1] = 0;
                    Screen[coreW + 2][coreH + 1] = 1;
                    coreW += 1;
                    Check();
                }
            }
        }

        private void LongPieceRotate()
        {
            if (rotation == 1 && (coreW) < 10 && (coreW - 2) > 0)
            {
                if (Screen[coreW - 2][coreH] != 1 && Screen[coreW - 3][coreH] != 1 && Screen[coreW][coreH] != 1)
                {
                    Screen[coreW - 1][coreH + 2] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW - 1][coreH - 1] = 0;
                    Screen[coreW - 1][coreH - 2] = 0;
                    rotation = 2;
                    Screen[coreW - 2][coreH] = 1;
                    Screen[coreW - 3][coreH] = 1;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Check();
                }
            }
            else if (rotation == 2 && coreH > 1)
            {
                if (
                Screen[coreW - 1][coreH - 1] != 1 &&
                Screen[coreW - 1][coreH + 2] != 1 &&
                Screen[coreW - 1][coreH] != 1)
                {
                    Screen[coreW - 2][coreH + 1] = 0;
                    Screen[coreW - 3][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW - 2][coreH] = 0;
                    Screen[coreW - 3][coreH] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    rotation = 3;

                    Screen[coreW - 1][coreH + 1] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW - 1][coreH - 1] = 1;
                    Screen[coreW - 1][coreH + 2] = 1;
                }
                Check();
            }
            else if (rotation == 3 && (coreW - 2) > 0 && (coreW + 1) < 10)
            {
                if (
                Screen[coreW - 2][coreH] != 1 &&
                Screen[coreW + 1][coreH] != 1 &&
                Screen[coreW][coreH] != 1)
                {
                    Screen[coreW - 1][coreH + 3] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW - 1][coreH - 1] = 0;
                    Screen[coreW - 1][coreH + 2] = 0;
                    rotation = 4;

                    Screen[coreW - 2][coreH] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Check();
                }
            }
            else if (rotation == 4 && coreH > 2)
            {
                if (
                Screen[coreW][coreH] != 1 &&
                Screen[coreW - 1][coreH - 1] != 1 &&
                Screen[coreW - 1][coreH - 2] != 1)
                {
                    Screen[coreW - 2][coreH + 1] = 0;
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW - 2][coreH] = 0;
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    rotation = 1;

                    Screen[coreW - 1][coreH + 1] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW - 1][coreH - 1] = 1;
                    Screen[coreW - 1][coreH - 2] = 1;
                }
                Check();
            }
        }
        #endregion

        #region Square Movement
        private void SquarePieceLeft()
        {
            if (coreW > 1 && coreH > 0)
            {
                if (Screen[coreW - 2][coreH + 1] != 1 && Screen[coreW - 2][coreH] != 1)
                {
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW - 2][coreH + 1] = 1;
                    Screen[coreW - 2][coreH] = 1;
                    Screen[coreW - 1][coreH + 1] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    coreW -= 1;
                    Check();
                }
            }
        }

        private void SquarePieceRight()
        {
            if (coreW < 9 && coreH > 0)
            {
                if (Screen[coreW + 1][coreH + 1] != 1 && Screen[coreW + 1][coreH] != 1)
                {
                    Screen[coreW - 1][coreH + 2] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW + 1][coreH + 1] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Screen[coreW][coreH + 1] = 1;
                    Screen[coreW][coreH] = 1;
                    coreW += 1;
                    Check();
                }
            }
        }
        #endregion

        #region Tee Movement
        private void TeePieceLeft()
        {
            if (coreW > 1 && rotation == 1 && coreH > 1)
            {
                if (Screen[coreW - 2][coreH] != 1 && Screen[coreW - 1][coreH - 1] != 1)
                {
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW - 1][coreH + 1] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW - 1][coreH - 1] = 1;
                    Screen[coreW - 2][coreH] = 1;
                    coreW -= 1;
                    Check();
                }
            }
            else if (rotation == 2 && (coreW) > 1)
            {
                if (Screen[coreW - 2][coreH] != 1 && Screen[coreW - 1][coreH - 1] != 1)
                {
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW - 2][coreH] = 1;
                    Screen[coreW - 1][coreH - 1] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW][coreH] = 1;
                    coreW -= 1;
                    Check();
                }
            }
            else if (coreW > 0 && rotation == 3 && coreH > 1)
            {
                if (Screen[coreW - 1][coreH] != 1 && Screen[coreW - 1][coreH - 1] != 1 && Screen[coreW - 1][coreH + 1] != 1)
                {
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW - 1][coreH + 1] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW - 1][coreH - 1] = 1;
                    Screen[coreW][coreH] = 1;
                    coreW -= 1;
                    Check();
                }
            }
            else if (rotation == 4 && coreW > 1)
            {
                if (Screen[coreW - 2][coreH] != 1 && Screen[coreW - 2][coreH] != 1)
                {
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW - 2][coreH] = 1;
                    Screen[coreW - 1][coreH + 1] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW][coreH] = 1;
                    coreW -= 1;
                    Check();
                }
            }
        }

        private void TeePieceRight()
        {
            if (coreW < 9 && rotation == 1 && coreH > 1)
            {
                if (Screen[coreW + 1][coreH] != 1 && Screen[coreW + 1][coreH - 1] != 1 && Screen[coreW + 1][coreH + 1] != 1)
                {
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW + 1][coreH + 1] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Screen[coreW + 1][coreH - 1] = 1;
                    Screen[coreW][coreH] = 1;
                    coreW += 1;
                    Check();
                }
            }
            else if (rotation == 2 && (coreW + 1) < 9 && coreH > 1)
            {
                if (Screen[coreW + 2][coreH] != 1 && Screen[coreW + 1][coreH - 1] != 1)
                {
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW + 2][coreH] = 1;
                    Screen[coreW + 1][coreH - 1] = 1;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    coreW += 1;
                    Check();
                }
            }
            else if (coreW < 8 && rotation == 3 && coreH > 1)
            {
                if (Screen[coreW + 2][coreH] != 1 && Screen[coreW + 1][coreH - 1] != 1)
                {
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW + 1][coreH + 1] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Screen[coreW + 1][coreH - 1] = 1;
                    Screen[coreW + 2][coreH] = 1;
                    coreW += 1;
                    Check();
                }
            }
            else if (rotation == 4 && coreW < 8)
            {
                if (Screen[coreW + 2][coreH] != 1 && Screen[coreW + 2][coreH] != 1)
                {
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW + 2][coreH] = 1;
                    Screen[coreW + 1][coreH + 1] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Screen[coreW][coreH] = 1;
                    coreW += 1;
                    Check();
                }
            }
        }

        private void TeePieceRotate()
        {
            if ((coreW + 1) < 10 && rotation == 1)
            {
                if (Screen[coreW][coreH - 1] != 1)
                {
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    rotation = 2;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW][coreH - 1] = 1;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Check();
                }
            }
            else if (rotation == 2)
            {
                if (Screen[coreW][coreH + 2] != 1)
                {
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    rotation = 3;
                    Screen[coreW][coreH + 1] = 1;
                    Screen[coreW][coreH - 1] = 1;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Check();
                }
            }
            else if (rotation == 3 && coreH > 1)
            {
                if (Screen[coreW - 1][coreH] != 1)
                {
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    rotation = 4;
                    Screen[coreW][coreH + 1] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Check();
                }
            }
            else if (rotation == 4 && (coreW) > 1 && coreH > 1)
            {
                if (Screen[coreW - 1][coreH] != 1)
                {
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    rotation = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW][coreH + 1] = 1;
                    Screen[coreW][coreH - 1] = 1;
                    Screen[coreW][coreH] = 1;
                    Check();
                }
            }
        }
        #endregion

        #region L Movement
        private void LPieceLeft()
        {
            if (coreW > 1 && rotation == 1 && coreH > 1)
            {
                if (Screen[coreW - 2][coreH + 1] != 1 && Screen[coreW - 1][coreH] != 1 && Screen[coreW - 1][coreH - 1] != 1)
                {
                    Screen[coreW-1][coreH + 1] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW -1][coreH + 2] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW - 2][coreH + 1] = 1;
                    Screen[coreW - 1][coreH + 1] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW - 1][coreH - 1] = 1;
                    coreW -= 1;
                    Check();
                }
            }
            else if (rotation == 2 && (coreW -1) > 0)
            {
                if (Screen[coreW - 2][coreH] != 1 && Screen[coreW - 2][coreH - 1] != 1)
                {
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW - 1][coreH - 1] = 0;
                    Screen[coreW - 2][coreH - 1] = 1;
                    Screen[coreW - 2][coreH] = 1;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    coreW -= 1;
                    Check();
                }
            }
            else if (coreW > 0 && rotation == 3 && coreH > 1)
            {
                if (Screen[coreW - 1][coreH + 1] != 1 && Screen[coreW - 1][coreH] != 1 && Screen[coreW - 1][coreH - 1] != 1)
                {
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW + 1][coreH - 1] = 0;
                    Screen[coreW][coreH - 1] = 1;
                    Screen[coreW - 1][coreH + 1] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW - 1][coreH - 1] = 1;
                    coreW -= 1;
                    Check();
                }
            }
            else if (rotation == 4 && (coreW - 1) > 0)
            {
                if (Screen[coreW - 2][coreH] != 1)
                {
                    Screen[coreW + 1][coreH + 2] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW - 2][coreH] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW][coreH + 1] = 1;
                    coreW -= 1;
                    Check();
                }
            }
        }

        private void LPieceRight()
        {
            if ((coreW + 1) < 10 && rotation == 1 && coreH > 1)
            {
                if (Screen[coreW + 1][coreH + 1] != 1 && Screen[coreW + 1][coreH] != 1 && Screen[coreW + 1][coreH - 1] != 1)
                {
                    Screen[coreW - 1][coreH + 2] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW][coreH + 1] = 1;
                    Screen[coreW + 1][coreH + 1] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Screen[coreW + 1][coreH - 1] = 1;
                    coreW += 1;
                    Check();
                }
            }
            else if (rotation == 2 && (coreW + 2) < 10)
            {
                if (Screen[coreW + 2][coreH] != 1 && Screen[coreW + 2][coreH - 1] != 1)
                {
                    Screen[coreW - 1][coreH + 2] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW - 1][coreH - 1] = 0;
                    Screen[coreW - 1][coreH + 2] = 0;
                    Screen[coreW][coreH - 1] = 1;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Screen[coreW + 2][coreH] = 1;
                    coreW += 1;
                    Check();
                }
            }
            else if ((coreW + 2) < 10 && rotation == 3 && coreH > 1)
            {
                if (Screen[coreW + 1][coreH + 1] != 1 && Screen[coreW + 2][coreH - 1] != 1)
                {
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW + 1][coreH] = 1;
                    Screen[coreW + 1][coreH + 1] = 1;
                    Screen[coreW + 2][coreH - 1] = 1;
                    Screen[coreW + 1][coreH - 1] = 1;
                    coreW += 1;
                    Check();
                }
            }
            else if (rotation == 4 && (coreW + 2) < 10)
            {
                if (Screen[coreW + 2][coreH] != 1 || Screen[coreW + 2][coreH + 1] != 1)
                {
                    Screen[coreW + 1][coreH + 2] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Screen[coreW + 2][coreH] = 1;
                    Screen[coreW + 2][coreH + 1] = 1;
                    coreW += 1;
                    Check();
                }
            }
        }

        private void LPieceRotate()
        {
            if (rotation == 1 && (coreW) < 10 && (coreW - 1) > 0)
            {
                if (Screen[coreW + 1][coreH] != 1 && Screen[coreW - 1][coreH - 1] != 1)
                {
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW - 1][coreH + 2] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    rotation = 2;
                    Screen[coreW - 1][coreH - 1] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Screen[coreW][coreH] = 1;
                    Check();
                }
            }
            else if (rotation == 2 && coreW < 10)
            {
                if (Screen[coreW][coreH - 1] != 1 && Screen[coreW + 1][coreH - 1] != 1)
                {
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW - 1][coreH - 1] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW][coreH] = 0;
                    rotation = 3;

                    Screen[coreW][coreH + 1] = 1;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW][coreH - 1] = 1;
                    Screen[coreW + 1][coreH - 1] = 1;
                }
                Check();
            }
            else if (rotation == 3 && (coreW - 1) > 0 && (coreW + 1) < 10)
            {
                if (Screen[coreW - 1][coreH] != 1)
                {
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW][coreH + 2] = 0;
                    Screen[coreW - 1][coreH - 1] = 0;
                    Screen[coreW][coreH - 1] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW + 1][coreH - 1] = 0;
                    Screen[coreW][coreH] = 0;
                    rotation = 4;

                    Screen[coreW + 1][coreH + 1] = 1;
                    Screen[coreW - 1][coreH] = 1;
                    Screen[coreW + 1][coreH] = 1;
                    Screen[coreW][coreH] = 1;
                    Check();
                }
            }
            else if (rotation == 4 && coreH > 2)
            {
                if (
                Screen[coreW][coreH] != 1 &&
                Screen[coreW - 1][coreH - 1] != 1 &&
                Screen[coreW - 1][coreH - 2] != 1)
                {
                    Screen[coreW + 1][coreH + 2] = 0;
                    Screen[coreW - 1][coreH + 1] = 0;
                    Screen[coreW][coreH + 1] = 0;
                    Screen[coreW + 1][coreH + 1] = 0;
                    Screen[coreW - 1][coreH] = 0;
                    Screen[coreW + 1][coreH] = 0;
                    Screen[coreW][coreH] = 0;
                    rotation = 1;
                    Screen[coreW - 1][coreH + 1] = 1;
                    Screen[coreW][coreH + 1] = 1;
                    Screen[coreW][coreH] = 1;
                    Screen[coreW][coreH - 1] = 1;
                }
                Check();
            }
        }
        #endregion

        #endregion
    }
}
