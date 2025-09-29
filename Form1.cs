using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VisualBook
{
    public partial class Form1 : Form
    {
        private List<string> textFiles;
        private int currentFileIndex;
        private int observationStat; // Статистика наблюдательности

        // Элементы для выбора
        private Panel choicePanel;
        private Button choice1Button;
        private Button choice2Button;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string scenePath = Path.Combine(basePath, "scene");

            textFiles = new List<string>
            {
                Path.Combine(scenePath, "Start.txt"),
                Path.Combine(scenePath, "Cabinet.txt"),
                Path.Combine(scenePath, "JermaineO'Malley1.txt"),
                Path.Combine(scenePath, "HelenSmith.txt"),
                Path.Combine(scenePath, "DukeFrancis.txt"),
                Path.Combine(scenePath, "Forest1.txt"), // Новая сцена с выбором
                Path.Combine(scenePath, "Forest2.txt"), // Следующая сцена
                Path.Combine(scenePath, "JermaineO'Malley2.txt"),
                Path.Combine(scenePath, "SeanParker.txt"),
                Path.Combine(scenePath, "JessicaJohnson.txt")
            };

            currentFileIndex = 0;
            observationStat = 0;

            InitializeChoicePanel();
            LoadCurrentFile();
        }

        private void InitializeChoicePanel()
        {
            // Панель для кнопок выбора
            choicePanel = new Panel()
            {
                BackColor = Color.FromArgb(30, 30, 30),
                Size = new Size(800, 100),
                Location = new Point(20, 480),
                Visible = false
            };

            // Первый вариант выбора
            choice1Button = new Button()
            {
                Text = "Майк Джонс наклонился чтобы поднять украшение.\n«Хелен, говорила об эзотерических украшениях. Полагаю это украшение Паулы»",
                BackColor = Color.FromArgb(50, 50, 50),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular),
                ForeColor = Color.White,
                Size = new Size(380, 80),
                Location = new Point(10, 10),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Второй вариант выбора
            choice2Button = new Button()
            {
                Text = "Майк Джонс прошел мимо, решив не тратить время.\n«Давай Майк, не теряй время»",
                BackColor = Color.FromArgb(50, 50, 50),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular),
                ForeColor = Color.White,
                Size = new Size(380, 80),
                Location = new Point(400, 10),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Обработчики событий
            choice1Button.Click += (s, e) => MakeChoice(1);
            choice2Button.Click += (s, e) => MakeChoice(2);

            // Добавляем кнопки на панель
            choicePanel.Controls.Add(choice1Button);
            choicePanel.Controls.Add(choice2Button);

            // Добавляем панель на форму
            this.Controls.Add(choicePanel);
        }

        private void LoadCurrentFile()
        {
            if (currentFileIndex < textFiles.Count)
            {
                string filePath = textFiles[currentFileIndex];
                if (File.Exists(filePath))
                {
                    try
                    {
                        string text = File.ReadAllText(filePath, System.Text.Encoding.UTF8);
                        tbNovella.Text = text;
                        LoadImage();

                        // Показываем панель выбора только для Forest1.txt
                        if (Path.GetFileName(filePath) == "Forest1.txt")
                        {
                            ShowChoicePanel();
                        }
                        else
                        {
                            HideChoicePanel();
                        }
                    }
                    catch (Exception ex)
                    {
                        tbNovella.Text = $"Ошибка чтения файла: {ex.Message}";
                    }
                }
                else
                {
                    tbNovella.Text = $"Файл {Path.GetFileName(filePath)} не найден!\nПуть: {filePath}";
                }
            }
            else
            {
                tbNovella.Text = "Конец истории. Спасибо за игру!";
                btnNext.Enabled = false;
            }
        }

        private void ShowChoicePanel()
        {
            choicePanel.Visible = true;
            btnNext.Enabled = false; // Отключаем кнопку "Далее" во время выбора
        }

        private void HideChoicePanel()
        {
            choicePanel.Visible = false;
            btnNext.Enabled = true; // Включаем кнопку "Далее"
        }

        private void MakeChoice(int choice)
        {
            // Обработка выбора
            if (choice == 1)
            {
                observationStat += 1; // +1 к наблюдательности
            }
            // choice == 2 - ничего не добавляем

            // Переходим к следующей сцене (Forest2.txt)
            currentFileIndex++;
            HideChoicePanel();
            LoadCurrentFile();
        }

        private void LoadImage()
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(textFiles[currentFileIndex]);
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = Path.Combine(basePath, "images", fileNameWithoutExtension + ".jpg");

            try
            {
                if (File.Exists(imagePath))
                {
                    pbNovella.Image = Image.FromFile(imagePath);
                }
                else
                {
                    CreatePlaceholderImage($"Изображение не найдено: {fileNameWithoutExtension}.jpg");
                }
            }
            catch (Exception ex)
            {
                CreatePlaceholderImage($"Ошибка загрузки: {ex.Message}");
            }
        }

        private void CreatePlaceholderImage(string text)
        {
            Bitmap bmp = new Bitmap(pbNovella.Width, pbNovella.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(30, 30, 30));
                using (Font font = new Font("Arial", 12))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(text, font, Brushes.White,
                                new RectangleF(10, 10, bmp.Width - 20, bmp.Height - 20), sf);
                }
            }
            pbNovella.Image = bmp;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentFileIndex++;
            if (currentFileIndex < textFiles.Count)
            {
                LoadCurrentFile();
            }
            else
            {
                tbNovella.Text = "Конец истории. Спасибо за игру!";
                btnNext.Enabled = false;
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            ShowStatisticsDialog();
        }

        private void ShowStatisticsDialog()
        {
            Form statsForm = new Form()
            {
                Text = "СТАТИСТИКА",
                Size = new Size(400, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(15, 15, 15),
                ForeColor = Color.White
            };

            // Заголовок
            Label titleLabel = new Label()
            {
                Text = "СТАТИСТИКА",
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 20)
            };

            // Текст статистики
            Label statsLabel = new Label()
            {
                Text = GetStatisticsText(),
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular),
                ForeColor = Color.White,
                Location = new Point(20, 60),
                Size = new Size(340, 150),
                TextAlign = ContentAlignment.TopLeft
            };

            // Кнопка OK
            Button okButton = new Button()
            {
                Text = "OK",
                BackColor = Color.SteelBlue,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(100, 35),
                Location = new Point(140, 220),
                DialogResult = DialogResult.OK
            };

            okButton.Click += (s, e) => statsForm.Close();

            // Добавляем элементы на форму
            statsForm.Controls.Add(titleLabel);
            statsForm.Controls.Add(statsLabel);
            statsForm.Controls.Add(okButton);

            // Показываем диалог
            statsForm.ShowDialog();
        }

        private string GetStatisticsText()
        {
            int health = CalculateHealth();

            return "Базовые характеристики:\n\n" +
                   $"Имя: Майк Джонс\n" +
                   $"Должность: частный детектив,\nбывший сотрудник ФБР\n" +
                   $"ХП: {health}\n" +
                   $"Наблюдательность: {observationStat}";
        }

        private int CalculateHealth()
        {
            return 5 + (currentFileIndex / 2);
        }

        private void tbNovella_TextChanged(object sender, EventArgs e) { }
        private void pbNovella_Click(object sender, EventArgs e) { }
    }
}