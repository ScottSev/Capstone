
namespace Capstone_Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.NamePlate = new System.Windows.Forms.Label();
            this.NamePlate2 = new System.Windows.Forms.Label();
            this.NamePlate1 = new System.Windows.Forms.Label();
            this.CodeBreakerDificulty = new System.Windows.Forms.ComboBox();
            this.ChalengeMode = new System.Windows.Forms.CheckBox();
            this.CodeBreakerOption = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.CodeBreaker_Pickup = new System.Windows.Forms.Label();
            this.CodeBreakerStart = new System.Windows.Forms.Button();
            this.TetrisOption = new System.Windows.Forms.Panel();
            this.Tetris_Start = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.Tetris_Pickup = new System.Windows.Forms.Label();
            this.CodeDown = new System.Windows.Forms.Label();
            this.TetrisDown = new System.Windows.Forms.Label();
            this.CodeBreakerOption.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TetrisOption.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // NamePlate
            // 
            this.NamePlate.AutoSize = true;
            this.NamePlate.CausesValidation = false;
            this.NamePlate.ForeColor = System.Drawing.Color.Silver;
            this.NamePlate.Location = new System.Drawing.Point(12, 18);
            this.NamePlate.Name = "NamePlate";
            this.NamePlate.Size = new System.Drawing.Size(166, 13);
            this.NamePlate.TabIndex = 3;
            this.NamePlate.Text = "Don\'t-Sue Entertainment Presents";
            // 
            // NamePlate2
            // 
            this.NamePlate2.AutoSize = true;
            this.NamePlate2.CausesValidation = false;
            this.NamePlate2.ForeColor = System.Drawing.Color.Silver;
            this.NamePlate2.Location = new System.Drawing.Point(172, 53);
            this.NamePlate2.Name = "NamePlate2";
            this.NamePlate2.Size = new System.Drawing.Size(0, 13);
            this.NamePlate2.TabIndex = 4;
            // 
            // NamePlate1
            // 
            this.NamePlate1.AutoSize = true;
            this.NamePlate1.CausesValidation = false;
            this.NamePlate1.Font = new System.Drawing.Font("Tahoma", 30F);
            this.NamePlate1.ForeColor = System.Drawing.Color.White;
            this.NamePlate1.Location = new System.Drawing.Point(103, 31);
            this.NamePlate1.Name = "NamePlate1";
            this.NamePlate1.Size = new System.Drawing.Size(632, 48);
            this.NamePlate1.TabIndex = 5;
            this.NamePlate1.Text = "Not-A-Scam Entertainment System";
            // 
            // CodeBreakerDificulty
            // 
            this.CodeBreakerDificulty.CausesValidation = false;
            this.CodeBreakerDificulty.FormattingEnabled = true;
            this.CodeBreakerDificulty.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.CodeBreakerDificulty.Location = new System.Drawing.Point(21, 15);
            this.CodeBreakerDificulty.Name = "CodeBreakerDificulty";
            this.CodeBreakerDificulty.Size = new System.Drawing.Size(121, 21);
            this.CodeBreakerDificulty.TabIndex = 6;
            this.CodeBreakerDificulty.Text = "Dificulty";
            this.CodeBreakerDificulty.SelectedIndexChanged += new System.EventHandler(this.CodeBreakerDificulty_SelectedIndexChanged);
            // 
            // ChalengeMode
            // 
            this.ChalengeMode.CausesValidation = false;
            this.ChalengeMode.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ChalengeMode.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.ChalengeMode.Location = new System.Drawing.Point(21, 42);
            this.ChalengeMode.Name = "ChalengeMode";
            this.ChalengeMode.Size = new System.Drawing.Size(110, 24);
            this.ChalengeMode.TabIndex = 7;
            this.ChalengeMode.Text = "Chalenge Mode";
            this.ChalengeMode.UseVisualStyleBackColor = true;
            // 
            // CodeBreakerOption
            // 
            this.CodeBreakerOption.BackColor = System.Drawing.SystemColors.Control;
            this.CodeBreakerOption.CausesValidation = false;
            this.CodeBreakerOption.Controls.Add(this.CodeBreakerStart);
            this.CodeBreakerOption.Controls.Add(this.CodeBreakerDificulty);
            this.CodeBreakerOption.Controls.Add(this.ChalengeMode);
            this.CodeBreakerOption.Location = new System.Drawing.Point(68, 216);
            this.CodeBreakerOption.Name = "CodeBreakerOption";
            this.CodeBreakerOption.Size = new System.Drawing.Size(260, 119);
            this.CodeBreakerOption.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.CausesValidation = false;
            this.panel1.Controls.Add(this.CodeDown);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CodeBreaker_Pickup);
            this.panel1.Location = new System.Drawing.Point(68, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 74);
            this.panel1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(209, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "/\\";
            // 
            // CodeBreaker_Pickup
            // 
            this.CodeBreaker_Pickup.Font = new System.Drawing.Font("Tahoma", 20F);
            this.CodeBreaker_Pickup.ForeColor = System.Drawing.Color.White;
            this.CodeBreaker_Pickup.Location = new System.Drawing.Point(3, 0);
            this.CodeBreaker_Pickup.Name = "CodeBreaker_Pickup";
            this.CodeBreaker_Pickup.Size = new System.Drawing.Size(254, 66);
            this.CodeBreaker_Pickup.TabIndex = 0;
            this.CodeBreaker_Pickup.Text = "Code Breaker";
            this.CodeBreaker_Pickup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CodeBreaker_Pickup.Click += new System.EventHandler(this.CodeBreaker_Pickup_Click);
            // 
            // CodeBreakerStart
            // 
            this.CodeBreakerStart.Location = new System.Drawing.Point(50, 87);
            this.CodeBreakerStart.Name = "CodeBreakerStart";
            this.CodeBreakerStart.Size = new System.Drawing.Size(121, 23);
            this.CodeBreakerStart.TabIndex = 8;
            this.CodeBreakerStart.Text = "Start";
            this.CodeBreakerStart.UseVisualStyleBackColor = true;
            this.CodeBreakerStart.Click += new System.EventHandler(this.CodeBreakerStart_Click_1);
            // 
            // TetrisOption
            // 
            this.TetrisOption.BackColor = System.Drawing.SystemColors.Control;
            this.TetrisOption.CausesValidation = false;
            this.TetrisOption.Controls.Add(this.Tetris_Start);
            this.TetrisOption.Location = new System.Drawing.Point(489, 211);
            this.TetrisOption.Name = "TetrisOption";
            this.TetrisOption.Size = new System.Drawing.Size(260, 53);
            this.TetrisOption.TabIndex = 15;
            // 
            // Tetris_Start
            // 
            this.Tetris_Start.Location = new System.Drawing.Point(70, 20);
            this.Tetris_Start.Name = "Tetris_Start";
            this.Tetris_Start.Size = new System.Drawing.Size(121, 23);
            this.Tetris_Start.TabIndex = 14;
            this.Tetris_Start.Text = "Start";
            this.Tetris_Start.UseVisualStyleBackColor = true;
            this.Tetris_Start.Click += new System.EventHandler(this.Tetris_Start_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel5.CausesValidation = false;
            this.panel5.Controls.Add(this.TetrisDown);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.Tetris_Pickup);
            this.panel5.Location = new System.Drawing.Point(489, 146);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 74);
            this.panel5.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(216, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 31);
            this.label5.TabIndex = 3;
            this.label5.Text = "/\\";
            // 
            // Tetris_Pickup
            // 
            this.Tetris_Pickup.Font = new System.Drawing.Font("Tahoma", 20F);
            this.Tetris_Pickup.ForeColor = System.Drawing.Color.White;
            this.Tetris_Pickup.Location = new System.Drawing.Point(3, 0);
            this.Tetris_Pickup.Name = "Tetris_Pickup";
            this.Tetris_Pickup.Size = new System.Drawing.Size(254, 64);
            this.Tetris_Pickup.TabIndex = 0;
            this.Tetris_Pickup.Text = "Tetris";
            this.Tetris_Pickup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Tetris_Pickup.Click += new System.EventHandler(this.Tetris_Pickup_Click);
            // 
            // CodeDown
            // 
            this.CodeDown.AutoSize = true;
            this.CodeDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeDown.ForeColor = System.Drawing.Color.White;
            this.CodeDown.Location = new System.Drawing.Point(209, 20);
            this.CodeDown.Name = "CodeDown";
            this.CodeDown.Size = new System.Drawing.Size(30, 31);
            this.CodeDown.TabIndex = 3;
            this.CodeDown.Text = "\\/";
            // 
            // TetrisDown
            // 
            this.TetrisDown.AutoSize = true;
            this.TetrisDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.TetrisDown.ForeColor = System.Drawing.Color.White;
            this.TetrisDown.Location = new System.Drawing.Point(216, 24);
            this.TetrisDown.Name = "TetrisDown";
            this.TetrisDown.Size = new System.Drawing.Size(30, 31);
            this.TetrisDown.TabIndex = 4;
            this.TetrisDown.Text = "\\/";
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.TetrisOption);
            this.Controls.Add(this.CodeBreakerOption);
            this.Controls.Add(this.NamePlate1);
            this.Controls.Add(this.NamePlate2);
            this.Controls.Add(this.NamePlate);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Don\'t-Sue Entertainment System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CodeBreakerOption.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TetrisOption.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label NamePlate;
        private System.Windows.Forms.Label NamePlate2;
        private System.Windows.Forms.Label NamePlate1;
        private System.Windows.Forms.Button CodeBreakerStart;
        public System.Windows.Forms.Panel CodeBreakerOption;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CodeBreaker_Pickup;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox CodeBreakerDificulty;
        public System.Windows.Forms.CheckBox ChalengeMode;
        public System.Windows.Forms.Panel TetrisOption;
        private System.Windows.Forms.Button Tetris_Start;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Tetris_Pickup;
        private System.Windows.Forms.Label TetrisDown;
        private System.Windows.Forms.Label CodeDown;
    }
}

