using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace VisualBook
{
    public class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(300, 200);
            this.Text = "Детектив Майк Джонс";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var label = new Label()
            {
                Text = "Добро пожаловать в игру!\nВыберите действие:",
                Location = new Point(20, 20),
                Size = new Size(250, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var btnNewGame = new Button()
            {
                Text = "Новая игра",
                Location = new Point(50, 80),
                Size = new Size(200, 30)
            };

            var btnLoadGame = new Button()
            {
                Text = "Загрузить игру",
                Location = new Point(50, 120),
                Size = new Size(200, 30)
            };

            btnNewGame.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            btnLoadGame.Click += (s, e) =>
            {
                var db = new Database();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    var command = new SQLiteCommand("SELECT COUNT(*) FROM SaveGames", connection);
                    var count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Нет сохраненных игр!", "Загрузка",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            };

            this.Controls.AddRange(new Control[] { label, btnNewGame, btnLoadGame });
        }
    }
}
