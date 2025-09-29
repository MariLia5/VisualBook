using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System;

uusing System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;

namespace VisualBook
{
    public class GameService
    {
        private Database database;
        private PlayerStatistics statistics;

        public GameService()
        {
            database = new Database();
            statistics = new PlayerStatistics();
        }

        public GameScene GetScene(string sceneKey)
        {
            using (var connection = database.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM GameScenes WHERE SceneKey = @SceneKey";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SceneKey", sceneKey);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new GameScene
                            {
                                SceneKey = reader["SceneKey"].ToString(),
                                Title = reader["Title"].ToString(),
                                TextContent = reader["TextContent"].ToString(),
                                ImagePath = reader["ImagePath"].ToString(),
                                Choice1Text = reader["Choice1Text"].ToString(),
                                Choice2Text = reader["Choice2Text"].ToString(),
                                Choice3Text = reader["Choice3Text"].ToString(),
                                Choice1NextScene = reader["Choice1NextScene"].ToString(),
                                Choice2NextScene = reader["Choice2NextScene"].ToString(),
                                Choice3NextScene = reader["Choice3NextScene"].ToString(),
                                Choice1Observation = Convert.ToInt32(reader["Choice1Observation"]),
                                Choice2Observation = Convert.ToInt32(reader["Choice2Observation"]),
                                Choice3Observation = Convert.ToInt32(reader["Choice3Observation"]),
                                Choice1Health = Convert.ToInt32(reader["Choice1Health"]),
                                Choice2Health = Convert.ToInt32(reader["Choice2Health"]),
                                Choice3Health = Convert.ToInt32(reader["Choice3Health"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void SaveGame(string currentScene)
        {
            using (var connection = database.GetConnection())
            {
                connection.Open();

                string query = @"
                    INSERT INTO SaveGames 
                    (PlayerName, HealthPoints, Observation, EvidenceDecoration, EvidenceBlood, EvidenceBone, EvidenceBlister, CurrentScene)
                    VALUES (@PlayerName, @HealthPoints, @Observation, @EvidenceDecoration, @EvidenceBlood, @EvidenceBone, @EvidenceBlister, @CurrentScene)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlayerName", "Детектив Майк Джонс");
                    command.Parameters.AddWithValue("@HealthPoints", statistics.HealthPoints);
                    command.Parameters.AddWithValue("@Observation", statistics.Observation);
                    command.Parameters.AddWithValue("@EvidenceDecoration", statistics.EvidenceDecoration);
                    command.Parameters.AddWithValue("@EvidenceBlood", statistics.EvidenceBlood);
                    command.Parameters.AddWithValue("@EvidenceBone", statistics.EvidenceBone);
                    command.Parameters.AddWithValue("@EvidenceBlister", statistics.EvidenceBlister);
                    command.Parameters.AddWithValue("@CurrentScene", currentScene);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<SaveGame> GetSaveGames()
        {
            var saves = new List<SaveGame>();

            using (var connection = database.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM SaveGames ORDER BY SaveDate DESC";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        saves.Add(new SaveGame
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PlayerName = reader["PlayerName"].ToString(),
                            HealthPoints = Convert.ToInt32(reader["HealthPoints"]),
                            Observation = Convert.ToInt32(reader["Observation"]),
                            EvidenceDecoration = Convert.ToInt32(reader["EvidenceDecoration"]),
                            EvidenceBlood = Convert.ToInt32(reader["EvidenceBlood"]),
                            EvidenceBone = Convert.ToInt32(reader["EvidenceBone"]),
                            EvidenceBlister = Convert.ToInt32(reader["EvidenceBlister"]),
                            CurrentScene = reader["CurrentScene"].ToString(),
                            SaveDate = Convert.ToDateTime(reader["SaveDate"])
                        });
                    }
                }
            }
            return saves;
        }

        public bool LoadGame(int saveId)
        {
            using (var connection = database.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM SaveGames WHERE Id = @Id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", saveId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            statistics.HealthPoints = Convert.ToInt32(reader["HealthPoints"]);
                            statistics.Observation = Convert.ToInt32(reader["Observation"]);
                            statistics.EvidenceDecoration = Convert.ToInt32(reader["EvidenceDecoration"]);
                            statistics.EvidenceBlood = Convert.ToInt32(reader["EvidenceBlood"]);
                            statistics.EvidenceBone = Convert.ToInt32(reader["EvidenceBone"]);
                            statistics.EvidenceBlister = Convert.ToInt32(reader["EvidenceBlister"]);

                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void ApplyChoiceEffects(int observation, int health, string evidenceType)
        {
            if (observation != 0)
            {
                statistics.Observation += observation;
            }

            if (health != 0)
            {
                statistics.HealthPoints += health;
            }

            switch (evidenceType)
            {
                case "decoration": statistics.EvidenceDecoration = 1; break;
                case "blood": statistics.EvidenceBlood = 1; break;
                case "bone": statistics.EvidenceBone = 1; break;
                case "blister": statistics.EvidenceBlister = 1; break;
            }
        }

        public PlayerStatistics GetStatistics()
        {
            return statistics;
        }

        public void ResetGame()
        {
            statistics.Reset();
        }

        public Image LoadImage(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                return Image.FromFile(imagePath);
            }
            return CreatePlaceholderImage();
        }

        private Bitmap CreatePlaceholderImage()
        {
            var bitmap = new Bitmap(400, 300);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.DarkGray);
                using (var font = new Font("Arial", 16))
                using (var brush = new SolidBrush(Color.White))
                {
                    g.DrawString("Изображение\nне найдено", font, brush, new PointF(50, 120));
                }
            }
            return bitmap;
        }
    }
}