using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Algorithms
{
    internal class SecondRoundRule
    {
        // Метод для початку алгоритму
        public static (string, int) StartAlgorithm(List<int> votings, List<List<string>> groups)
        {
            // Проходимо етапи першого раунду
            (string, int) result;
            List<string> firstRowFirstRound = groups.Select(g => g.First()).ToList();
            Dictionary<string, int> votesFirstRound = FirstRoundRule.CountVoting(votings, firstRowFirstRound);
            // Копіювання списку списків
            List<List<string>> copyGroups = new List<List<string>>();
            foreach (List<string> group in groups)
            {
                List<string> groupCopy = new List<string>(group.Count);
                groupCopy.AddRange(group);
                copyGroups.Add(groupCopy);
            }

            // Видаляємо не потрібні елементи та редагуємо дані для другого раунду
            votesFirstRound = votesFirstRound.OrderByDescending(kv => kv.Value).ToDictionary(kv => kv.Key, kv => kv.Value);
            copyGroups = RemoveItems(copyGroups, votesFirstRound.Keys.FirstOrDefault(), votesFirstRound.Keys.Skip(1).FirstOrDefault());

            // Проводимо другий раунд по логіці першого           
            List<string> firstRowSecondRound = copyGroups.Select(g => g.First()).ToList();
            Dictionary<string, int> votesSecondRound = FirstRoundRule.CountVoting(votings, firstRowSecondRound);

            // Записуємо результати
            result.Item1 = votesSecondRound.OrderByDescending(kv => kv.Value).First().Key;
            result.Item2 = votesSecondRound[result.Item1];

            return result;
        }

        // Метод тдля видалення усіх зайвих елементів, окрім елементів, які у першому турі набрали максимальну кількість голосів
        public static List<List<string>> RemoveItems(List<List<string>> groups, string firstEl, string secondEl)
        {
            foreach (var group in groups)
            {
                group.RemoveAll(item => item != firstEl && item != secondEl);
            }

            return groups;
        }
    }
}
