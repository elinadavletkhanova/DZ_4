using latypova_4.Enums;

namespace latypova_4.Structs
{
    public struct Grandpa
    {
        public string Name;
        public Grumpiness GrumpinessLevel;
        public string[] Phrases;
        public int StrikeCount;

        public Grandpa(string name, Grumpiness grumpinessLevel, string[] phrases)
        {
            Name = name;
            GrumpinessLevel = grumpinessLevel;
            Phrases = phrases;
            StrikeCount = 0;
        }

        /// <summary>Считает количество плохих фраз у деда, обновляет счётчик ругательств</summary>
        /// <param name="grandpa">Ссылка на объект одного из дедов, чьи фразы проверяются</param>
        /// <param name="badPhrases">Массив запрещенных и плохих слов</param>
        /// <returns>Возвращает количество сказанных плохих фраз или слов</returns>
        public static int GrandmaBlows(ref Grandpa grandpa, params string[] badPhrases)
        {
            int countBlows = 0;

            foreach (string phrase in grandpa.Phrases)
            {
                foreach (string badPhrase in badPhrases)
                {
                    if (phrase.Contains(badPhrase))
                    {
                        countBlows++;
                    }
                }
            }

            grandpa.StrikeCount = countBlows;

            return countBlows;
        }
    }
}