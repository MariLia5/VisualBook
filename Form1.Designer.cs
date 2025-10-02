using System.Drawing;
using System.Windows.Forms;
using System;

namespace VisualBook
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox tbNovella;
        private PictureBox pbNovella;
        private Button btnNext;
        private Button btnStatistics;

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
            this.tbNovella = new System.Windows.Forms.TextBox();
            this.pbNovella = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbNovella)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNovella
            // 
            this.tbNovella.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tbNovella.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNovella.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNovella.ForeColor = System.Drawing.Color.White;
            this.tbNovella.Location = new System.Drawing.Point(155, 14);
            this.tbNovella.Multiline = true;
            this.tbNovella.Name = "tbNovella";
            this.tbNovella.ReadOnly = true;
            this.tbNovella.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNovella.Size = new System.Drawing.Size(636, 438);
            this.tbNovella.TabIndex = 0;
            this.tbNovella.TextChanged += new System.EventHandler(this.tbNovella_TextChanged);
            // 
            // pbNovella
            // 
            this.pbNovella.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pbNovella.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbNovella.Location = new System.Drawing.Point(852, 12);
            this.pbNovella.Name = "pbNovella";
            this.pbNovella.Size = new System.Drawing.Size(400, 450);
            this.pbNovella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNovella.TabIndex = 1;
            this.pbNovella.TabStop = false;
            this.pbNovella.Click += new System.EventHandler(this.pbNovella_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(12, 422);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 40);
            this.btnNext.TabIndex = 2;
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
            this.btnStatistics.Location = new System.Drawing.Point(12, 6);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(120, 40);
            this.btnStatistics.TabIndex = 3;
            this.btnStatistics.Text = "Статистика";
            this.btnStatistics.UseVisualStyleBackColor = false;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1360, 642);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pbNovella);
            this.Controls.Add(this.tbNovella);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form1";
            this.Text = "Детектив Майк Джонс: Охота на белого орла";
            ((System.ComponentModel.ISupportInitialize)(this.pbNovella)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}