using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace VisualBook
{
    public class Database
    {
        private const string DatabaseFile = "detective_game.db";
        private string connectionString;

        public Database()
        {
            connectionString = $"Data Source={DatabaseFile};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!File.Exists(DatabaseFile))
            {
                SQLiteConnection.CreateFile(DatabaseFile);
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Таблица для сохранения игры
                string saveGameTable = @"
                    CREATE TABLE IF NOT EXISTS SaveGames (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        PlayerName TEXT,
                        HealthPoints INTEGER DEFAULT 5,
                        Observation INTEGER DEFAULT 0,
                        EvidenceDecoration INTEGER DEFAULT 0,
                        EvidenceBlood INTEGER DEFAULT 0,
                        EvidenceBone INTEGER DEFAULT 0,
                        EvidenceBlister INTEGER DEFAULT 0,
                        CurrentScene TEXT DEFAULT 'Start',
                        SaveDate DATETIME DEFAULT CURRENT_TIMESTAMP
                    )";

                // Таблица для сцен игры
                string scenesTable = @"
                    CREATE TABLE IF NOT EXISTS GameScenes (
                        SceneKey TEXT PRIMARY KEY,
                        Title TEXT,
                        TextContent TEXT,
                        ImagePath TEXT,
                        Choice1Text TEXT,
                        Choice2Text TEXT,
                        Choice3Text TEXT,
                        Choice1NextScene TEXT,
                        Choice2NextScene TEXT,
                        Choice3NextScene TEXT,
                        Choice1Observation INTEGER DEFAULT 0,
                        Choice2Observation INTEGER DEFAULT 0,
                        Choice3Observation INTEGER DEFAULT 0,
                        Choice1Health INTEGER DEFAULT 0,
                        Choice2Health INTEGER DEFAULT 0,
                        Choice3Health INTEGER DEFAULT 0
                    )";

                using (var command = new SQLiteCommand(saveGameTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(scenesTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Заполняем сцены игры (упрощенная версия)
                InsertGameScenes(connection);
            }
        }

        private void InsertGameScenes(SQLiteConnection connection)
        {
            // Базовая реализация - нужно добавить полный список сцен
            // Пока добавим только стартовую сцену
            var scenes = new List<GameScene>
            {
                new GameScene
                {
                    SceneKey = "Start",
                    Title = "Детектив Майк Джонс: Охота на белого орла",
                    TextContent = "Начало игры...",
                    ImagePath = "images/start.jpg",
                    Choice1Text = "Начать расследование",
                    Choice2Text = "Просмотреть характеристики",
                    Choice3Text = "",
                    Choice1NextScene = "Cabinet1",
                    Choice2NextScene = "StatisticsView",
                    Choice3NextScene = ""
                }
            };

            // Добавьте остальные сцены по аналогии
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}