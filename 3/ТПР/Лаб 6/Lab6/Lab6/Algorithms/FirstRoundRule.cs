using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab6.Algorithms
{
    internal class FirstRoundRule
    {
        // Метод для запуску алгоритму
        public static (string, int) StartAlgorithm(List<int> votings, List<List<string>> groups)
        {
            (string, int) result;
            List<string> firstRow = groups.Select(g => g.First()).ToList();
            Dictionary<string, int> numbersVotes = CountVoting(votings, firstRow);

            result.Item1 = numbersVotes.OrderByDescending(kv => kv.Value).First().Key;
            result.Item2 = numbersVotes[result.Item1];

            return result;
        }

        // Метод, який підраховує скільки голосів набрала кожна альтернатива у першому рядку
        public static Dictionary<string, int> CountVoting(List<int> votings, List<string> firstRow)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            int sum = 0;
            List<string> copyFirstRow = new List<string>();

            copyFirstRow.AddRange(firstRow);

            while (copyFirstRow.Count != 0)
            {
                if (copyFirstRow.Count() == 0)
                {
                    return result;
                }
                else
                {
                    List<int> indexes = firstRow.Select((element, index) => new { Element = element, Index = index })
                             .Where(x => x.Element == copyFirstRow[0])
                             .Select(x => x.Index)
                             .ToList();

                    foreach (int ind in indexes)
                    {
                        sum += votings[ind];
                    }

                    result.Add(copyFirstRow[0], sum);

                    sum = 0;
                    copyFirstRow.RemoveAll(item => item == result.LastOrDefault().Key);
                }
            }
                
            return result;
        }
    }
}
