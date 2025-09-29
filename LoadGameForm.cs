using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VisualBook
{
    public class LoadGameForm : Form
    {
        public int? SelectedSaveId { get; private set; }
        private List<SaveGame> saves;

        public LoadGameForm(List<SaveGame> saves)
        {
            this.saves = saves;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(500, 400);
            this.Text = "Выберите сохранение";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            var label = new Label()
            {
                Text = "Доступные сохранения:",
                Location = new Point(20, 20),
                Size = new Size(200, 20)
            };

            var listBox = new ListBox()
            {
                Location = new Point(20, 50),
                Size = new Size(440, 250),
                Font = new Font("Arial", 10)
            };

            foreach (var save in saves)
            {
                listBox.Items.Add($"Сохранение {save.Id} - {save.SaveDate:dd.MM.yyyy HH:mm} - Здоровье: {save.HealthPoints}");
            }

            var btnLoad = new Button()
            {
                Text = "Загрузить",
                Location = new Point(300, 310),
                Size = new Size(80, 30),
                DialogResult = DialogResult.OK
            };

            var btnCancel = new Button()
            {
                Text = "Отмена",
                Location = new Point(390, 310),
                Size = new Size(80, 30),
                DialogResult = DialogResult.Cancel
            };

            btnLoad.Click += (s, e) =>
            {
                if (listBox.SelectedIndex >= 0)
                {
                    SelectedSaveId = saves[listBox.SelectedIndex].Id;
                }
                else
                {
                    MessageBox.Show("Выберите сохранение для загрузки.", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            this.Controls.AddRange(new Control[] { label, listBox, btnLoad, btnCancel });
        }
    }
}
