using System;

namespace VisualBook
{
    public class SaveGame
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int HealthPoints { get; set; }
        public int Observation { get; set; }
        public int EvidenceDecoration { get; set; }
        public int EvidenceBlood { get; set; }
        public int EvidenceBone { get; set; }
        public int EvidenceBlister { get; set; }
        public string CurrentScene { get; set; }
        public DateTime SaveDate { get; set; }
    }
}