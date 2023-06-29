using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_4
{
    public class InputOutput
    {
        // Метод для введення кілскості
        public static int InputCount(string textProposition)
        {
            Console.Write(textProposition);
            return InputIntNumber();
        }

        // Метод для введення числа
        public static int InputIntNumber()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("A string cannot be converted to a number. Try again.");
            }
            
            return number;
        }

        // Метод для запису альтернатив
        public static List<List<int>> InputAlternatives(string filePath)
        {
            List<List<int>> alternatives = new List<List<int>>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                List<int> alternative = new List<int>();
                string[] values = line.Split(' ');
                foreach (string value in values)               
                {
                    alternative.Add(int.Parse(value));
                }
                alternatives.Add(alternative);
            }

            return alternatives;
        }

        // Метод для виводу критеріального опису альтернатив
        public static void OutputCriterionDescriptionAlternatives(List<List<int>> alternatives)
        {
            Console.WriteLine("\nКритериальное описание альтернатив: ");
            for (int i = 0; i < alternatives.Count(); i++)
            {
                for (int j = 0; j < alternatives[i].Count(); j++)
                {
                    Console.Write($"\t {alternatives[i][j]}");
                }
                Console.WriteLine("");
            }
        }

        // Метод для виведення множини першої опорної ситуації
        public static void OutputSetAlterFirstReferenceSituations(List<List<int[]>> altFirstReferenceSituat)
        {
            Console.WriteLine("\nМножество альтернатив первого опорного места: ");
            for (int i = 0; i < altFirstReferenceSituat.Count(); i++)
            {
                Console.Write($"K{i + 1}: ");
                for (int j = 0; j < altFirstReferenceSituat[i].Count(); j++)
                {
                    Console.Write("\t");
                    for (int c = 0; c < altFirstReferenceSituat[i][j].Count(); c++)
                    {
                        Console.Write(altFirstReferenceSituat[i][j][c]);
                    }
                }
                Console.WriteLine();
            }
        }

        // Метод для виводу пар критеріїв, що будуть надалі порівнюватися
        public static void OutputPairForCompare(List<int[]> pairForCompare)
        {
            Console.WriteLine("\nПары критериев для сравнения: ");
            for (int i = 0; i < pairForCompare.Count(); i++)
            {
                Console.Write("\t");
                for (int j = 0; j < pairForCompare[i].Count(); j++)
                {
                    Console.Write($"K{pairForCompare[i][j]}");
                }
            }
        }

        // Метод для виводу ланцюжків
        public static void OutputChains(List<List<int[]>> chains)
        {
            Console.WriteLine("\nВсе цепочки: ");

            for (int i = 0; i < chains.Count(); i++)
            {
                OutputChain(chains[i]);
                Console.WriteLine();
            }
        }

        // Метод для виводу ланцюжка
        public static void OutputChain(List<int[]> chain)
        {
            for (int i = 0; i < chain.Count(); i++)
            {
                Console.Write(string.Join("", chain[i]) + " ");
            }
        }
        
        // Метод для виводу єдиної порядкової шкали
        public static void OutputSingleOrdinalScale(List<int[]> mainChain)
        {
            Console.WriteLine("\n\nОдинарная порядковая шкала: ");
            OutputChain(mainChain);
            Console.WriteLine();
            for (int i = 0; i < mainChain.Count(); i++)
            {
                Console.Write($" {i + 1} ");
            }
        }

        // Метод для виводу векторних оцінок
        public static void OutputVectorEstimates(List<List<int[]>> vectorEstimates)
        {
            Console.WriteLine("\n\nВекторные оценки альтернатив: ");
            for (int i = 0; i < vectorEstimates.Count(); i++)
            {
                OutputChain(vectorEstimates[i]);
                Console.WriteLine();
            }
        }
    }
}
