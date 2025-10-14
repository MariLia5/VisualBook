using System.Drawing;
using System.Windows.Forms;

namespace VisualBook
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnNext;
        private Button btnStatistics;
        private Button btnExit;
        private TextBox tbNovella;
        private PictureBox pbNovella;
        private Panel choicePanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnNext = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tbNovella = new System.Windows.Forms.TextBox();
            this.pbNovella = new System.Windows.Forms.PictureBox();
            this.choicePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbNovella)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(20, 396);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(150, 40);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnStatistics.ForeColor = System.Drawing.Color.White;
            this.btnStatistics.Location = new System.Drawing.Point(20, 326);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(150, 40);
            this.btnStatistics.TabIndex = 1;
            this.btnStatistics.Text = "Статистика";
            this.btnStatistics.UseVisualStyleBackColor = false;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(12, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 40);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // tbNovella
            // 
            this.tbNovella.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tbNovella.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNovella.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbNovella.ForeColor = System.Drawing.Color.White;
            this.tbNovella.Location = new System.Drawing.Point(212, 12);
            this.tbNovella.Multiline = true;
            this.tbNovella.Name = "tbNovella";
            this.tbNovella.ReadOnly = true;
            this.tbNovella.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNovella.Size = new System.Drawing.Size(681, 424);
            this.tbNovella.TabIndex = 3;
            this.tbNovella.TextChanged += new System.EventHandler(this.tbNovella_TextChanged);
            // 
            // pbNovella
            // 
            this.pbNovella.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pbNovella.Location = new System.Drawing.Point(919, 12);
            this.pbNovella.Name = "pbNovella";
            this.pbNovella.Size = new System.Drawing.Size(381, 424);
            this.pbNovella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNovella.TabIndex = 4;
            this.pbNovella.TabStop = false;
            this.pbNovella.Click += new System.EventHandler(this.pbNovella_Click);
            // 
            // choicePanel
            // 
            this.choicePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.choicePanel.Location = new System.Drawing.Point(212, 480);
            this.choicePanel.Name = "choicePanel";
            this.choicePanel.Size = new System.Drawing.Size(1088, 120);
            this.choicePanel.TabIndex = 5;
            this.choicePanel.Visible = false;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1342, 686);
            this.Controls.Add(this.choicePanel);
            this.Controls.Add(this.pbNovella);
            this.Controls.Add(this.tbNovella);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnNext);
            this.MinimumSize = new System.Drawing.Size(850, 650);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Детектив Майк Джонс";
            ((System.ComponentModel.ISupportInitialize)(this.pbNovella)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}