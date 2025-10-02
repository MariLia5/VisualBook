// Form1.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VisualBook
{
    public partial class Form1 : Form
    {
        private Game game;
        private Panel choicePanel;
        private List<Button> choiceButtons;

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(850, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeGame();
        }

        private void InitializeGame()
        {
            game = new Game();
            InitializeChoicePanel();
            LoadScene(game.CurrentScene);
        }

        private void InitializeChoicePanel()
        {
            choicePanel = new Panel()
            {
                BackColor = this.BackColor, // ← совпадает с фоном формы → убирает "прямоугольник"
                Size = new Size(800, 120),
                Location = new Point(20, 480),
                Visible = false,
                BorderStyle = BorderStyle.None
            };

            choiceButtons = new List<Button>();
            this.Controls.Add(choicePanel);
        }

        private void LoadScene(string sceneFile)
        {
            tbNovella.Text = game.LoadSceneText(sceneFile);
            LoadImage(sceneFile);
            ShowChoicesForScene(sceneFile);
        }

        private void ShowChoicesForScene(string sceneFile)
        {
            HideChoicePanel();
            btnNext.Enabled = true;

            switch (sceneFile)
            {
                case "Forest1.txt":
                    ShowForest1Choices();
                    break;
                case "Forest2.txt":
                    ShowForest2Choices();
                    break;
                case "Forest2.1.txt":
                    ShowForest21Choices();
                    break;
                case "Forest2.2.txt":
                    ShowForest22Choices();
                    break;
                case "LuisaFonseca1.txt":
                    ShowLuisaFonsecaChoices();
                    break;
                case "Building.txt":
                    ShowBuildingChoices();
                    break;
                case "Fight1.txt":
                    ShowFight1Choices();
                    break;
                case "Fight2.txt":
                    ShowFight2Choices();
                    break;
                case "Fight3.txt":
                    ShowFight3Choices();
                    break;
                case "LowHP.txt":
                case "AllEvidence.txt":
                case "NOEvidence.txt":
                    btnNext.Enabled = true;
                    break;
                case "HighHP.txt":
                    btnNext.Enabled = true;
                    break;
            }
        }

        private void CreateChoiceButtons(List<string> choices, List<Action> actions)
        {
            foreach (var button in choiceButtons)
            {
                choicePanel.Controls.Remove(button);
                button.Dispose();
            }
            choiceButtons.Clear();

            int buttonHeight = 80;
            int buttonWidth = 380;
            int spacing = 10;
            int rows = (choices.Count + 1) / 2;
            int totalHeight = rows * (buttonHeight + spacing) - spacing;

            choicePanel.Size = new Size(800, totalHeight);

            for (int i = 0; i < choices.Count; i++)
            {
                int row = i / 2;
                int col = i % 2;

                int x = col == 0 ? spacing : (choicePanel.Width - buttonWidth - spacing);
                int y = row * (buttonHeight + spacing);

                Button choiceButton = new Button()
                {
                    Text = choices[i],
                    BackColor = Color.FromArgb(50, 50, 50),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    ForeColor = Color.White,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(x, y),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(10, 0, 10, 0),
                    Cursor = Cursors.Hand,
                    TabStop = false,
                    UseVisualStyleBackColor = false
                };

                choiceButton.FlatAppearance.BorderSize = 0;
                choiceButton.FlatAppearance.BorderColor = Color.FromArgb(50, 50, 50);
                choiceButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 60);
                choiceButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);

                choiceButton.MouseEnter += (s, e) => choiceButton.BackColor = Color.FromArgb(70, 70, 70);
                choiceButton.MouseLeave += (s, e) => choiceButton.BackColor = Color.FromArgb(50, 50, 50);

                int choiceIndex = i;
                choiceButton.Click += (s, e) =>
                {
                    actions[choiceIndex]();
                    HideChoicePanel();
                };

                choiceButtons.Add(choiceButton);
                choicePanel.Controls.Add(choiceButton);
            }

            choicePanel.Height = Math.Max(120, totalHeight);
        }

        private void ShowForest1Choices()
        {
            var choices = new List<string>
            {
                "1. Майк Джонс наклонился чтобы поднять украшение.\n«Хелен, говорила об эзотерических украшениях. Полагаю это украшение Паулы»",
                "2. Майк Джонс прошел мимо, решив не тратить время.\n«Давай Майк, не теряй время»"
            };

            var actions = new List<Action>
            {
                () => {
                    game.OnForest1Choice1();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                },
                () => {
                    game.OnForest1Choice2();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                }
            };

            CreateChoiceButtons(choices, actions);
            ShowChoicePanel();
        }

        private void ShowForest2Choices()
        {
            var choices = new List<string>
            {
                "1. Посмотреть на деревья у костра.",
                "2. Посмотреть на разбросанные предметы у костра.",
                "3. Не терять время."
            };

            var actions = new List<Action>
            {
                () => {
                    game.OnForest2Choice1();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                },
                () => {
                    game.OnForest2Choice2();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                },
                () => {
                    game.OnForest2Choice3();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                }
            };

            CreateChoiceButtons(choices, actions);
            ShowChoicePanel();
        }

        private void ShowForest21Choices()
        {
            var choices = new List<string>
            {
                "1.1 Взять кровь на проверку.",
                "1.2 Не брать кровь на проверку."
            };

            var actions = new List<Action>
            {
                () => {
                    game.OnForest21Choice1();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                },
                () => {
                    game.OnForest21Choice2();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                }
            };

            CreateChoiceButtons(choices, actions);
            ShowChoicePanel();
        }

        private void ShowForest22Choices()
        {
            var choices = new List<string>
            {
                "2.1 Взять кость на проверку.",
                "2.2 Не брать кость на проверку."
            };

            var actions = new List<Action>
            {
                () => {
                    game.OnForest22Choice1();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                },
                () => {
                    game.OnForest22Choice2();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                }
            };

            CreateChoiceButtons(choices, actions);
            ShowChoicePanel();
        }

        private void ShowLuisaFonsecaChoices()
        {
            var choices = new List<string>
            {
                "1. Спрятать блистер в карман.",
                "2. Выбросить блистер."
            };

            var actions = new List<Action>
            {
                () => {
                    game.OnLuisaFonsecaChoice1();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                },
                () => {
                    game.OnLuisaFonsecaChoice2();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                }
            };

            CreateChoiceButtons(choices, actions);
            ShowChoicePanel();
        }

        private void ShowBuildingChoices()
        {
            var choices = new List<string>
            {
                "1. Открыть смс.",
                "2. Отключить звук на телефоне."
            };

            var actions = new List<Action>
            {
                () => {
                    game.OnBuildingChoice1();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                },
                () => {
                    game.OnBuildingChoice2();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                }
            };

            CreateChoiceButtons(choices, actions);
            ShowChoicePanel();
        }

        private void ShowFight1Choices()
        {
            var choices = new List<string>
            {
                "1. Уклониться.",
                "2. Замахнуться кулаком в ответ."
            };

            var actions = new List<Action>
            {
                () => {
                    game.OnFight1Choice1();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                },
                () => {
                    game.OnFight1Choice2();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                }
            };

            CreateChoiceButtons(choices, actions);
            ShowChoicePanel();
        }

        private void ShowFight2Choices()
        {
            var choices = new List<string>
            {
                "1. Отскочить назад.",
                "2. Схватиться за палку сектанта."
            };

            var actions = new List<Action>
            {
                () => {
                    game.OnFight2Choice1();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                },
                () => {
                    game.OnFight2Choice2();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                }
            };

            CreateChoiceButtons(choices, actions);
            ShowChoicePanel();
        }

        private void ShowFight3Choices()
        {
            var choices = new List<string>
            {
                "1. Накинуться и бить.",
                "2. Отдышаться и ждать."
            };

            var actions = new List<Action>
            {
                () => {
                    game.OnFight3Choice1();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                },
                () => {
                    game.OnFight3Choice2();
                    this.BeginInvoke(new Action(() => LoadScene(game.CurrentScene)));
                }
            };

            CreateChoiceButtons(choices, actions);
            ShowChoicePanel();
        }

        private void ShowChoicePanel()
        {
            choicePanel.Visible = true;
            btnNext.Enabled = false;
        }

        private void HideChoicePanel()
        {
            choicePanel.Visible = false;
            btnNext.Enabled = true;
        }

        private void LoadImage(string sceneFile)
        {
            if (pbNovella.Image != null)
            {
                pbNovella.Image.Dispose();
                pbNovella.Image = null;
            }

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", game.GetImageFileName(sceneFile));

            try
            {
                if (File.Exists(imagePath))
                {
                    using (var tempImage = Image.FromFile(imagePath))
                    {
                        pbNovella.Image = new Bitmap(tempImage);
                    }
                }
                else
                {
                    CreatePlaceholderImage($"Изображение не найдено: {game.GetImageFileName(sceneFile)}");
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
            string nextScene = game.AdvanceToNextScene();
            if (nextScene != null)
            {
                LoadScene(nextScene);
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
                Size = new Size(350, 280),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(15, 15, 15),
                ForeColor = Color.White
            };

            Label titleLabel = new Label()
            {
                Text = "СТАТИСТИКА",
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 20)
            };

            TextBox statsTextBox = new TextBox()
            {
                Text = game.GetStatisticsText(),
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(15, 15, 15),
                BorderStyle = BorderStyle.None,
                Location = new Point(20, 60),
                Size = new Size(300, 150),
                Multiline = true,
                ReadOnly = true
            };

            Button okButton = new Button()
            {
                Text = "OK",
                BackColor = Color.SteelBlue,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                Size = new Size(80, 35),
                Location = new Point(135, 220)
            };

            okButton.Click += (s, e) => statsForm.Close();

            statsForm.Controls.Add(titleLabel);
            statsForm.Controls.Add(statsTextBox);
            statsForm.Controls.Add(okButton);
            statsForm.ShowDialog();
        }

        private void tbNovella_TextChanged(object sender, EventArgs e) { }
        private void pbNovella_Click(object sender, EventArgs e) { }
    }
}