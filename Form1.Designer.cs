namespace VisualBook
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.tbNovella = new System.Windows.Forms.TextBox();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.bntChoice1 = new System.Windows.Forms.Button();
            this.bntChoice2 = new System.Windows.Forms.Button();
            this.bntChoice3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(462, 21);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(374, 457);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // tbNovella
            // 
            this.tbNovella.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNovella.Location = new System.Drawing.Point(123, 21);
            this.tbNovella.Multiline = true;
            this.tbNovella.Name = "tbNovella";
            this.tbNovella.Size = new System.Drawing.Size(342, 457);
            this.tbNovella.TabIndex = 1;
            this.tbNovella.TextChanged += new System.EventHandler(this.tbNovella_TextChanged);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Location = new System.Drawing.Point(12, 377);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(91, 34);
            this.btnStatistics.TabIndex = 2;
            this.btnStatistics.Text = "Статистика";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(12, 444);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(91, 34);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Читать далее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // bntChoice1
            // 
            this.bntChoice1.Location = new System.Drawing.Point(123, 484);
            this.bntChoice1.Name = "bntChoice1";
            this.bntChoice1.Size = new System.Drawing.Size(91, 34);
            this.bntChoice1.TabIndex = 4;
            this.bntChoice1.Text = "Выбрать 1";
            this.bntChoice1.UseVisualStyleBackColor = true;
            // 
            // bntChoice2
            // 
            this.bntChoice2.Location = new System.Drawing.Point(123, 524);
            this.bntChoice2.Name = "bntChoice2";
            this.bntChoice2.Size = new System.Drawing.Size(91, 34);
            this.bntChoice2.TabIndex = 5;
            this.bntChoice2.Text = "Выбрать 2";
            this.bntChoice2.UseVisualStyleBackColor = true;
            // 
            // bntChoice3
            // 
            this.bntChoice3.Location = new System.Drawing.Point(123, 564);
            this.bntChoice3.Name = "bntChoice3";
            this.bntChoice3.Size = new System.Drawing.Size(91, 34);
            this.bntChoice3.TabIndex = 6;
            this.bntChoice3.Text = "Выбрать 2";
            this.bntChoice3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 655);
            this.Controls.Add(this.bntChoice3);
            this.Controls.Add(this.bntChoice2);
            this.Controls.Add(this.bntChoice1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.tbNovella);
            this.Controls.Add(this.pbImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.TextBox tbNovella;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button bntChoice1;
        private System.Windows.Forms.Button bntChoice2;
        private System.Windows.Forms.Button bntChoice3;
    }
}

