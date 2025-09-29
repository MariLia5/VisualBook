using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VisualBook
{
    public partial class StartForm : Form
    {
        private Button btnStart;
        private Button btnExit;
        private Label label1;
        private PictureBox pictureBox1;

        public StartForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnStart = new Button();
            this.btnExit = new Button();
            this.label1 = new Label();
            this.pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(40, 120);
            this.label1.Name = "label1";
            this.label1.Size = new Size(260, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Детектив Майк Джонс";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;

            // btnStart
            this.btnStart.BackColor = Color.SteelBlue;
            this.btnStart.FlatStyle = FlatStyle.Flat;
            this.btnStart.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.btnStart.ForeColor = Color.White;
            this.btnStart.Location = new Point(70, 170);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new Size(200, 40);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Начать игру";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new EventHandler(this.btnStart_Click);

            // btnExit
            this.btnExit.BackColor = Color.FromArgb(64, 64, 64);
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.btnExit.ForeColor = Color.White;
            this.btnExit.Location = new Point(70, 220);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(200, 40);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);

            // pictureBox1
            this.pictureBox1.Location = new Point(70, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(200, 80);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;

            // Загружаем Start.jpg
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string imagePath = Path.Combine(basePath, "images", "Start.jpg");

                if (File.Exists(imagePath))
                {
                    this.pictureBox1.Image = Image.FromFile(imagePath);
                }
                else
                {
                    CreatePlaceholderImage("Start.jpg не найден");
                }
            }
            catch (Exception ex)
            {
                CreatePlaceholderImage($"Ошибка: {ex.Message}");
            }

            // StartForm
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(15, 15, 15);
            this.ClientSize = new Size(350, 280);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Детектив Майк Джонс";
            ((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CreatePlaceholderImage(string text)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(30, 30, 30));
                using (Font font = new Font("Arial", 10))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(text, font, Brushes.White,
                                new RectangleF(0, 0, bmp.Width, bmp.Height), sf);
                }
            }
            pictureBox1.Image = bmp;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form1 gameForm = new Form1();
            this.Hide();
            gameForm.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}