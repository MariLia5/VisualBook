using System.Collections.Generic;
using System.Linq;
using System;

uusing System;
using System.Collections.Generic;
using System.Linq;

namespace VisualBook
{
    public class DetectiveGame
    {
        private GameService gameService;
        private SceneManager sceneManager;
        private string currentSceneKey;

        public DetectiveGame()
        {
            gameService = new GameService();
            sceneManager = new SceneManager(gameService);
            currentSceneKey = "Start";
        }

        public GameScene GetCurrentScene()
        {
            return gameService.GetScene(currentSceneKey);
        }

        public void MakeChoice(int choiceIndex)
        {
            var currentScene = GetCurrentScene();
            if (currentScene == null) return;

            sceneManager.ApplySceneEffects(currentSceneKey, choiceIndex);

            var nextScene = sceneManager.GetNextScene(currentSceneKey, choiceIndex);
            if (nextScene != null)
            {
                currentSceneKey = nextScene.SceneKey;
            }

            CheckGameEndConditions();
        }

        private void CheckGameEndConditions()
        {
            var stats = gameService.GetStatistics();

            if (stats.HealthPoints <= 0)
            {
                currentSceneKey = "Ending1_1";
            }

            if (currentSceneKey.Contains("Ending"))
            {
                OnGameCompleted?.Invoke(this, EventArgs.Empty);
            }
        }

        public void SaveGame()
        {
            gameService.SaveGame(currentSceneKey);
        }

        public bool LoadGame(int saveId)
        {
            if (gameService.LoadGame(saveId))
            {
                var saves = gameService.GetSaveGames();
                var save = saves.FirstOrDefault(s => s.Id == saveId);
                if (save != null)
                {
                    currentSceneKey = save.CurrentScene;
                    return true;
                }
            }
            return false;
        }

        public void NewGame()
        {
            gameService.ResetGame();
            currentSceneKey = "Start";
        }

        public PlayerStatistics GetStatistics()
        {
            return gameService.GetStatistics();
        }

        public List<SaveGame> GetSaveGames()
        {
            return gameService.GetSaveGames();
        }

        public event EventHandler OnGameCompleted;
    }
}