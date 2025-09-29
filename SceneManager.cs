namespace VisualBook
{
    public class SceneManager
    {
        private GameService gameService;
        private EndingManager endingManager;

        public SceneManager(GameService gameService)
        {
            this.gameService = gameService;
            this.endingManager = new EndingManager(gameService);
        }

        public GameScene GetNextScene(string currentSceneKey, int choiceIndex)
        {
            var currentScene = gameService.GetScene(currentSceneKey);
            if (currentScene == null) return null;

            string nextSceneKey;
            switch (choiceIndex)
            {
                case 1: nextSceneKey = currentScene.Choice1NextScene; break;
                case 2: nextSceneKey = currentScene.Choice2NextScene; break;
                case 3: nextSceneKey = currentScene.Choice3NextScene; break;
                default: nextSceneKey = currentScene.Choice1NextScene; break;
            }

            if (nextSceneKey == "FinalEnding")
            {
                return CreateEndingScene();
            }

            return gameService.GetScene(nextSceneKey);
        }

        private GameScene CreateEndingScene()
        {
            string endingKey = endingManager.DetermineEnding();
            string endingText = endingManager.GetEndingText(endingKey);

            return new GameScene
            {
                SceneKey = "FinalEnding",
                Title = "Завершение дела",
                TextContent = endingText + "\n\nСпасибо за игру!",
                ImagePath = "images/ending.jpg",
                Choice1Text = "Начать новую игру",
                Choice2Text = "Выйти из игры",
                Choice3Text = "",
                Choice1NextScene = "Start",
                Choice2NextScene = "Exit",
                Choice3NextScene = ""
            };
        }

        public void ApplySceneEffects(string sceneKey, int choiceIndex)
        {
            var scene = gameService.GetScene(sceneKey);
            if (scene == null) return;

            int observation;
            int health;

            switch (choiceIndex)
            {
                case 1:
                    observation = scene.Choice1Observation;
                    health = scene.Choice1Health;
                    break;
                case 2:
                    observation = scene.Choice2Observation;
                    health = scene.Choice2Health;
                    break;
                case 3:
                    observation = scene.Choice3Observation;
                    health = scene.Choice3Health;
                    break;
                default:
                    observation = 0;
                    health = 0;
                    break;
            }

            string evidenceType = GetEvidenceTypeForScene(sceneKey, choiceIndex);
            gameService.ApplyChoiceEffects(observation, health, evidenceType);
        }

        private string GetEvidenceTypeForScene(string sceneKey, int choiceIndex)
        {
            if (sceneKey == "Forest1" && choiceIndex == 1) return "decoration";
            if (sceneKey == "BloodChoice" && choiceIndex == 1) return "blood";
            if (sceneKey == "BoneChoice" && choiceIndex == 1) return "bone";
            if (sceneKey == "Cabinet1" && choiceIndex == 1) return "blister";
            return "";
        }
    }
}