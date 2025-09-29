namespace VisualBook
{
    public class GameScene
    {
        public string SceneKey { get; set; }
        public string Title { get; set; }
        public string TextContent { get; set; }
        public string ImagePath { get; set; }
        public string Choice1Text { get; set; }
        public string Choice2Text { get; set; }
        public string Choice3Text { get; set; }
        public string Choice1NextScene { get; set; }
        public string Choice2NextScene { get; set; }
        public string Choice3NextScene { get; set; }
        public int Choice1Observation { get; set; }
        public int Choice2Observation { get; set; }
        public int Choice3Observation { get; set; }
        public int Choice1Health { get; set; }
        public int Choice2Health { get; set; }
        public int Choice3Health { get; set; }
    }
}