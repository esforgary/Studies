using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Algorithms
{
    internal class CondorceRule
    {
        // Метод для запуску алгоритму
        public static (string, int) StartAlgorithm(List<int> votings, List<List<string>> groups)
        {
            (string, int) result;
            Dictionary<string, int> winners = InitializationWinners(groups[0]);
            List<List<string>> pairs = CreatePairs(groups);

            for (int i = 0; i < pairs.Count(); i++)
            {
                List<List<string>> copyGroups = new List<List<string>>();
                foreach (List<string> group in groups)
                {
                    List<string> groupCopy = new List<string>(group.Count);
                    groupCopy.AddRange(group);
                    copyGroups.Add(groupCopy);
                }

                // Деякі кроки алгортму сожі із кроками алгоритмів першого та другого туру, тому тут відбувається виконання дій
                // з тих алгоритмів
                copyGroups = SecondRoundRule.RemoveItems(copyGroups, pairs[i][0], pairs[i][1]);
                List<string> firstRow = copyGroups.Select(g => g.First()).ToList();
                Dictionary<string, int> pointsOfOneGroup = FirstRoundRule.CountVoting(votings, firstRow);
                PlusWinn(winners, pointsOfOneGroup.OrderByDescending(kv => kv.Value).First().Key);
            }

            result.Item1 = winners.OrderByDescending(kv => kv.Value).First().Key;
            result.Item2 = winners[result.Item1];

            return result;
        }

        // Метод для створення пар
        public static List<List<string>> CreatePairs(List<List<string>> groups)
        {
            List<List<string>> pairs = new List<List<string>>();

            for (int i = 0; i < groups[0].Count; i++)
            {
                for (int j = i + 1; j < groups[0].Count; j++)
                {
                    List<string> pair = new List<string>() { groups[0][i], groups[0][j] };
                    pairs.Add(pair);
                }
            }

            return pairs;
        }

        // Метод для ініціалізації переможців
        public static Dictionary<string, int> InitializationWinners(List<string> options)
        {
            Dictionary<string, int> winners = new Dictionary<string, int>();

            foreach (var op in options)
            {
                winners.Add(op, 0);
            }

            return winners;
        }

        // Метод, який додає перемогу
        public static void PlusWinn(Dictionary<string, int> winners, string winner)
        {
            winners[winner]++;
        }
    }
}
