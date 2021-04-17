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
    public partial class Form1 : Form
    {
        int DisC = 0;
        int DisT = 0;
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            TetrisOption.Hide();
            CodeBreakerOption.Hide();
            TetrisDown.Hide();
            CodeDown.Hide();
        }

        public void CodeBreakerDificulty_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void CodeBreakerStart_Click(object sender, EventArgs e)
        {

        }

        private void CodeBreaker_Pickup_Click(object sender, EventArgs e)
        {

            if (DisC == 0)
            {
                CodeDown.Show();
                CodeBreakerOption.Show();
                DisC = 1;
            }
            else
            {
                CodeDown.Hide();
                CodeBreakerOption.Hide();
                DisC = 0;
            }
        }

        private void CodeBreaker_Drop_Click_1(object sender, EventArgs e)
        {
            CodeBreakerOption.BringToFront();
        }

        private void CodeBreakerStart_Click_1(object sender, EventArgs e)
        {
            if (CodeBreakerDificulty.Text != "Dificulty")
            {
                Form2 frm = new Form2(CodeBreakerDificulty.Text, ChalengeMode.Checked.ToString());
                frm.Show();
            }
        }

        private void Tetris_Pickup_Click(object sender, EventArgs e)
        {
            if (DisT == 0)
            {
                TetrisDown.Show();
                TetrisOption.Show();
                DisT = 1;
            }
            else
            {
                TetrisDown.Hide();
                TetrisOption.Hide();
                DisT = 0;
            }
        }

        private void Tetris_Start_Click(object sender, EventArgs e)
        {
            Form3 Tet = new Form3();
            Tet.Show();
        }
    }
}
