using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Algorithms
{
    internal class BoardRule
    {
        // Метод для запуску алгоритму
        public static (string, int) StartAlgorithm(List<int> votings, List<List<string>> groups)
        {
            (string, int) result;
            List<string> options = new List<string>();
            options.AddRange(groups[1]);
            Dictionary<string, int> points = CountPoints(options, groups, votings);

            result.Item1 = points.OrderByDescending(kv => kv.Value).First().Key;
            result.Item2 = points[result.Item1];

            return result;
        }

        // Метод для підрахунку очок
        public static Dictionary<string, int> CountPoints(List<string> options, List<List<string>> groups, List<int> votings)
        {
            Dictionary<string, int> points = new Dictionary<string, int>();
            int sum = 0;

            for (int i = 0; i < options.Count(); i++)
            {
                for (int j = 0; j < groups.Count(); j++)
                {
                    int ind = groups[j].IndexOf(options[i]);
                    sum += votings[j] * (groups[j].Count() - 1 - ind);
                }

                points.Add(options[i], sum);
                sum = 0;
            }

            return points;
        }
    }
}
