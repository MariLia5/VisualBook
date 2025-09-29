using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VisualBook
{
    public class EnhancedMainForm : Form
    {
        private DetectiveGame game;
        private Button btnChoice1, btnChoice2, btnChoice3, btnNext, btnStatistics;
        private TextBox tbNovella;
        private PictureBox pbImage;
        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;

        public EnhancedMainForm()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(1200, 800);
            this.Text = "Детектив Майк Джонс: Охота на белого орла";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);

            menuStrip = new MenuStrip();
            CreateMenu();
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;

            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            statusStrip.Items.Add(statusLabel);
            this.Controls.Add(statusStrip);

            CreateControls();
            ArrangeControls();
        }

        private void CreateMenu()
        {
            var fileMenu = new ToolStripMenuItem("Файл");
            var gameMenu = new ToolStripMenuItem("Игра");
            var helpMenu = new ToolStripMenuItem("Помощь");

            var newGameItem = new ToolStripMenuItem("Новая игра", null, (s, e) => NewGame());
            var loadGameItem = new ToolStripMenuItem("Загрузить игру", null, (s, e) => LoadGame());
            var saveGameItem = new ToolStripMenuItem("Сохранить игру", null, (s, e) => SaveGame());
            var exitItem = new ToolStripMenuItem("Выход", null, (s, e) => ExitGame());

            // Исправлено: явное указание типа массива
            ToolStripItem[] fileItems = new ToolStripItem[] { newGameItem, loadGameItem, saveGameItem, new ToolStripSeparator(), exitItem };
            fileMenu.DropDownItems.AddRange(fileItems);

            var statsItem = new ToolStripMenuItem("Статистика", null, (s, e) => ShowStatistics());
            var hintsItem = new ToolStripMenuItem("Подсказки", null, (s, e) => ShowHints());

            ToolStripItem[] gameItems = new ToolStripItem[] { statsItem, hintsItem };
            gameMenu.DropDownItems.AddRange(gameItems);

            var aboutItem = new ToolStripMenuItem("О программе", null, (s, e) => ShowAbout());

            ToolStripItem[] helpItems = new ToolStripItem[] { aboutItem };
            helpMenu.DropDownItems.AddRange(helpItems);

            ToolStripItem[] mainItems = new ToolStripItem[] { fileMenu, gameMenu, helpMenu };
            menuStrip.Items.AddRange(mainItems);
        }

        private void CreateControls()
        {
            tbNovella = new TextBox()
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Arial", 11),
                BackColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D
            };

            pbImage = new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.Black
            };

            btnChoice1 = CreateChoiceButton();
            btnChoice2 = CreateChoiceButton();
            btnChoice3 = CreateChoiceButton();

            btnNext = new Button()
            {
                Text = "Далее →",
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnNext.FlatAppearance.BorderSize = 0;

            btnStatistics = new Button()
            {
                Text = "📊 Статистика",
                Font = new Font("Arial", 9),
                BackColor = Color.LightGray
            };

            btnChoice1.Click += ChoiceButton_Click;
            btnChoice2.Click += ChoiceButton_Click;
            btnChoice3.Click += ChoiceButton_Click;
            btnNext.Click += btnNext_Click;
            btnStatistics.Click += btnStatistics_Click;
        }

        private Button CreateChoiceButton()
        {
            return new Button()
            {
                Font = new Font("Arial", 10),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Height = 45,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
        }

        private void ArrangeControls()
        {
            int margin = 10;
            int imageWidth = 400;
            int textWidth = this.ClientSize.Width - imageWidth - margin * 3;
            int buttonHeight = 45;

            pbImage.Location = new Point(margin, menuStrip.Height + margin);
            pbImage.Size = new Size(imageWidth, 300);

            tbNovella.Location = new Point(imageWidth + margin * 2, menuStrip.Height + margin);
            tbNovella.Size = new Size(textWidth, 400);

            btnStatistics.Location = new Point(margin, pbImage.Bottom + margin);
            btnStatistics.Size = new Size(imageWidth, 30);

            int buttonY = tbNovella.Bottom + margin;
            btnChoice1.Location = new Point(tbNovella.Left, buttonY);
            btnChoice1.Size = new Size(textWidth, buttonHeight);

            btnChoice2.Location = new Point(tbNovella.Left, buttonY + buttonHeight + margin);
            btnChoice2.Size = new Size(textWidth, buttonHeight);

            btnChoice3.Location = new Point(tbNovella.Left, buttonY + (buttonHeight + margin) * 2);
            btnChoice3.Size = new Size(textWidth, buttonHeight);

            btnNext.Location = new Point(tbNovella.Left, buttonY);
            btnNext.Size = new Size(textWidth, buttonHeight);

            // Исправлено: явное указание типа массива
            Control[] controls = new Control[] {
                tbNovella, pbImage, btnChoice1, btnChoice2, btnChoice3, btnNext, btnStatistics
            };
            this.Controls.AddRange(controls);
        }

        private void InitializeGame()
        {
            game = new DetectiveGame();
            game.OnGameCompleted += (s, e) => ShowGameCompleted();
            LoadCurrentScene();
        }

        private void LoadCurrentScene()
        {
            var scene = game.GetCurrentScene();
            if (scene != null)
            {
                UpdateSceneDisplay(scene);
                UpdateStatusBar();
            }
        }

        private void UpdateSceneDisplay(GameScene scene)
        {
            tbNovella.Text = scene.TextContent;
            this.Text = $"{scene.Title} - Детектив Майк Джонс";

            LoadSceneImage(scene.ImagePath);
            SetupChoiceButtons(scene);
        }

        private void LoadSceneImage(string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    pbImage.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pbImage.Image = CreatePlaceholderImage("Изображение сцены");
                }
            }
            catch
            {
                pbImage.Image = CreatePlaceholderImage("Ошибка загрузки");
            }
        }

        private void SetupChoiceButtons(GameScene scene)
        {
            btnChoice1.Visible = btnChoice2.Visible = btnChoice3.Visible = btnNext.Visible = false;

            var choices = new[] { scene.Choice1Text, scene.Choice2Text, scene.Choice3Text };
            var buttons = new[] { btnChoice1, btnChoice2, btnChoice3 };

            int visibleButtons = 0;

            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(choices[i]))
                {
                    buttons[i].Text = $"{i + 1}. {choices[i]}";
                    buttons[i].Tag = i + 1;
                    buttons[i].Visible = true;
                    visibleButtons++;
                }
            }

            if (visibleButtons == 0 && !string.IsNullOrEmpty(scene.Choice1NextScene))
            {
                btnNext.Tag = 1;
                btnNext.Visible = true;
            }
        }

        private void ChoiceButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int choiceIndex = (int)button.Tag;

            game.MakeChoice(choiceIndex);
            LoadCurrentScene();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            game.MakeChoice(1);
            LoadCurrentScene();
        }

        private void UpdateStatusBar()
        {
            var stats = game.GetStatistics();
            var foundEvidence = stats.GetFoundEvidence();

            // Исправлено: Count - это свойство, а не метод
            int foundCount = foundEvidence.Count(e => e.Value);
            statusLabel.Text = $"❤️ Здоровье: {stats.HealthPoints} | 🔍 Наблюдательность: {stats.Observation} | 💼 Улики: {foundCount}/4";
        }

        private void ShowStatistics()
        {
            var stats = game.GetStatistics();
            MessageBox.Show(stats.GetStatisticsDisplay(), "Статистика детектива",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            ShowStatistics();
        }

        private void NewGame()
        {
            if (MessageBox.Show("Начать новую игру? Текущий прогресс будет потерян.", "Новая игра",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                game.NewGame();
                LoadCurrentScene();
            }
        }

        private void SaveGame()
        {
            game.SaveGame();
            MessageBox.Show("Игра успешно сохранена!", "Сохранение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadGame()
        {
            var saves = game.GetSaveGames();
            if (saves.Count == 0)
            {
                MessageBox.Show("Нет сохраненных игр.", "Загрузка",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var loadForm = new LoadGameForm(saves))
            {
                if (loadForm.ShowDialog() == DialogResult.OK && loadForm.SelectedSaveId.HasValue)
                {
                    if (game.LoadGame(loadForm.SelectedSaveId.Value))
                    {
                        LoadCurrentScene();
                        MessageBox.Show("Игра загружена успешно!", "Загрузка",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void ExitGame()
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ShowGameCompleted()
        {
            MessageBox.Show("Поздравляем! Вы завершили игру.\n\nХотите начать новую игру?", "Игра завершена",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            NewGame();
        }

        private void ShowHints()
        {
            MessageBox.Show("Подсказки по игре:\n\n• Внимательно читайте диалоги - они содержат важные clues\n• Собирайте все улики для лучшей концовки\n• Следите за здоровьем детектива\n• Сохраняйте игру регулярно", "Подсказки",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowAbout()
        {
            MessageBox.Show("Детектив Майк Джонс: Охота на белого орла\n\nВерсия 1.0\nРазработано на C# WinForms\n\nДетективная новелла с элементами визуальной ролевой игры.", "О программе",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Bitmap CreatePlaceholderImage(string text)
        {
            var bitmap = new Bitmap(400, 300);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.DarkSlateGray);
                using (var font = new Font("Arial", 14))
                using (var brush = new SolidBrush(Color.White))
                {
                    var size = g.MeasureString(text, font);
                    g.DrawString(text, font, brush,
                        new PointF((bitmap.Width - size.Width) / 2, (bitmap.Height - size.Height) / 2));
                }
            }
            return bitmap;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ArrangeControls();
        }
    }
}