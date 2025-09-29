using System.Collections.Generic;
using System.Linq;

namespace VisualBook
{
    public class PlayerStatistics
    {
        public int HealthPoints { get; set; } = 5;
        public int Observation { get; set; } = 0;
        public int EvidenceDecoration { get; set; } = 0;
        public int EvidenceBlood { get; set; } = 0;
        public int EvidenceBone { get; set; } = 0;
        public int EvidenceBlister { get; set; } = 0;

        public Dictionary<string, bool> GetFoundEvidence()
        {
            return new Dictionary<string, bool>
            {
                { "Украшение", EvidenceDecoration == 1 },
                { "Кровь", EvidenceBlood == 1 },
                { "Кость", EvidenceBone == 1 },
                { "Блистер", EvidenceBlister == 1 }
            };
        }

        public string GetStatisticsDisplay()
        {
            var foundEvidence = GetFoundEvidence();

            string stats = $"=== СТАТИСТИКА ДЕТЕКТИВА ===\n\n" +
                          $"❤️ Здоровье: {HealthPoints}\n" +
                          $"🔍 Наблюдательность: {Observation}\n\n" +
                          $"=== СОБРАННЫЕ УЛИКИ ===\n";

            foreach (var evidence in foundEvidence)
            {
                if (evidence.Value)
                {
                    string evidenceSymbol = GetEvidenceSymbol(evidence.Key);
                    stats += $"{evidenceSymbol} {evidence.Key}: Найдено\n";
                }
            }

            if (foundEvidence.All(e => !e.Value))
            {
                stats += "Улики еще не найдены\n";
            }

            return stats;
        }

        private string GetEvidenceSymbol(string evidenceName)
        {
            switch (evidenceName)
            {
                case "Украшение": return "📿";
                case "Кровь": return "🩸";
                case "Кость": return "🦴";
                case "Блистер": return "💊";
                default: return "🔍";
            }
        }

        public void Reset()
        {
            HealthPoints = 5;
            Observation = 0;
            EvidenceDecoration = 0;
            EvidenceBlood = 0;
            EvidenceBone = 0;
            EvidenceBlister = 0;
        }
    }
}