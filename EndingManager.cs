using System.Linq;

namespace VisualBook
{
    public class EndingManager
    {
        private GameService gameService;

        public EndingManager(GameService gameService)
        {
            this.gameService = gameService;
        }

        public string DetermineEnding()
        {
            var stats = gameService.GetStatistics();

            if (stats.HealthPoints <= 2)
            {
                return "Ending1_1";
            }

            var evidence = stats.GetFoundEvidence();
            int foundEvidenceCount = evidence.Count(e => e.Value);

            bool hasMotherEvidence = stats.EvidenceBlister == 1;
            bool hasSectEvidence = stats.EvidenceDecoration == 1 ||
                                  stats.EvidenceBlood == 1 ||
                                  stats.EvidenceBone == 1;

            if (foundEvidenceCount == 4)
            {
                return "Ending2_1";
            }
            else if (foundEvidenceCount == 0)
            {
                return "Ending2_2";
            }
            else if (hasMotherEvidence && !hasSectEvidence)
            {
                return "Ending2_4";
            }
            else if (hasSectEvidence && !hasMotherEvidence)
            {
                return "Ending2_3";
            }
            else
            {
                return "Ending2_1";
            }
        }

        public string GetEndingText(string endingKey)
        {
            switch (endingKey)
            {
                case "Ending1_1": return GetEnding1_1Text();
                case "Ending1_2": return GetEnding1_2Text();
                case "Ending2_1": return GetEnding2_1Text();
                case "Ending2_2": return GetEnding2_2Text();
                case "Ending2_3": return GetEnding2_3Text();
                case "Ending2_4": return GetEnding2_4Text();
                default: return "Концовка не определена.";
            }
        }

        private string GetEnding1_1Text()
        {
            return @"Майк Джонс лежал в грязи, голову раскалывала боль. Дождь продолжал литься как из ведра, пропитывая его до костей...
        
Секта «Дети Леса» мнили себя потомками викингов и по преданию, чтобы спасти богов и вернуть их к жизни необходимо белого орла окрасить в красный цвет кровью...

Над Паулой была совершена пытка...
Белый орленок стал кровавым...
Детектива ждала аналогичная участь.";
        }

        private string GetEnding1_2Text()
        {
            return @"Майк чувствовал тяжесть в ногах, каждая мышца тела протестовала против движения. Он устал от драки, от преследования, от этого кошмара. Но он знал, что не может ослабеть сейчас...
        
В комнате была Паула. Она стояла около стола с топорами, ее белые волосы ярко выделялись на фоне темной комнаты. Она смотрела на Майка, ее глаза были полны страха и недоумения.";
        }

        private string GetEnding2_1Text()
        {
            return @"Майк Джонс стоял перед судом, его тело было напряжено. Он держал в руках досье, которое он собрал за последние недели...
        
Он смог доказать вину секты. Он доказал вину ее матери.
Правда восторжествовала, и преступники понесли заслуженное наказание.";
        }

        private string GetEnding2_2Text()
        {
            return @"Майк Джонс стоял перед судом, его тело было напряжено. Он держал в руках досье, которое он собрал за последние недели, но сейчас оно казалось пустым...
        
Детектив проиграл.
Над Паулой была совершена пытка...
Белый орленок стал кровавым...";
        }

        private string GetEnding2_3Text()
        {
            return @"Майк Джонс стоял перед судом. Он держал в руках досье, которое он собрал за последние недели...
        
Он смог доказать вину секты, но не мог доказать вину ее матери.
Позже выяснилось, что Паула переехала в другой город и оборвала связь с матерью.";
        }

        private string GetEnding2_4Text()
        {
            return @"Майк Джонс стоял перед судом. Он держал в руках досье, которое он собрал за последние недели...
        
Майк Джонс доказал не вину секты. Он доказал вину ее матери.
Позже выяснилось, что Паула переехала в другой город и оборвала связь с матерью.
        
Но секта «Дети Леса» продолжала свою деятельность...";
        }
    }
}