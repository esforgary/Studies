using Lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ToolsClasses
{
    internal class OutputInputClass
    {
        public static int InputCount(string textProposition)
        {
            int countInt = 0;
            Console.Write(textProposition);
            while (!int.TryParse(Console.ReadLine(), out countInt))
            {
                Console.WriteLine("A string cannot be converted to a number. Try again.");
            }

            return countInt;
        }

        public static void InputInformation(int countCriterion, List<Criterion> criterions)
        {
            for (int i = 0; i < countCriterion; i++)
            {
                Console.WriteLine($"\nEnter the criteria {i + 1}: ");

                int countCriteriaScale = InputCount("Enter the number of criteria scale: ");
                Criterion criterion = new Criterion();

                Console.WriteLine($"Enter the criteria scale {i + 1}: ");

                for (int j = 0; j < countCriteriaScale; j++)
                {
                    criterion.CriteriaScale.Add(Console.ReadLine());
                }

                criterions.Add(criterion);
            }
        }

        public static void OutputTable(List<List<int>> coefForTable, List<int[]> G, List<double> d1, List<double> d2, List<double> p1, List<double> p2, List<double> g1, List<double> g2, List<double> F1, List<double> F2, List<double> F, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine("Table:");
                for (int i = 0; i < coefForTable.Count(); i++)
                {
                    sw.WriteLine("{0,-30}{1,-10}{2,-10:N2}{3,-10:N2}{4,-10:N2}{5,-10:N2}{6,-10:N2}{7,-10:N2}{8,-10:N2}{9,-10:N2}", CreateStringIndex(coefForTable[i]), CreateStringG(G[i]), d1[i], d2[i], p1[i], p2[i], g1[i], g2[i], F1[i], F2[i], F[i]);
                }
            }
        }

        private static string CreateStringIndex(List<int> coef)
        {
            string result = "";
            foreach (var c in coef)
            {
                result += c.ToString() + "\t";
            }

            return result;
        }

        private static string CreateStringG(int[] G)
        {
            string result = "";
            if (G[0] == G[1])
            {
                result += G[0] + "\t";
            }
            else
            {
                result += G[0] + ", " + G[1] + "\t";
            }

            return result;
        }

        public static void OutputG(List<int[]> G, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine("Column G:");
                foreach (var g in G)
                {
                    sw.Write(CreateStringG(g));
                }
                sw.WriteLine("\n");
            }
        }
    }
}
