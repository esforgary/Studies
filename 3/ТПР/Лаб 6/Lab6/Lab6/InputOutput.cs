using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class InputOutput
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
                Console.WriteLine("Строка не может быть преобразована в число. Попробуйте еще раз.");
            }

            return number;
        }

        // Метод для введеня профілю голосування (тобто ми задаємо скільки людей за який варіант проголосувало)
        public static List<List<string>> InputVotingProfile(double countAlternatives, double countGroups, out List<int> votings)
        {
            List<List<string>> groups = new List<List<string>>();
            votings = new List<int>();

            for (int i = 0; i < countGroups; i++)
            {
                int countVoiting = InputCount("Введите количество голосов, отданных за первую группу: ");
                List<string> group = InputGroup(countAlternatives);

                votings.Add(countVoiting);
                groups.Add(group);
            }

            return groups;
        }

        // Метод для введення групи алтернатив
        public static List<string> InputGroup(double countAlternatives)
        {
            List<string> group = new List<string>();

            Console.WriteLine("Войти в группу: ");
            for (int i = 0; i < countAlternatives; i++)
            {
                group.Add(Console.ReadLine());
            }

            return group;
        }

        // Метод, що виводить профіль голосування
        public static void OutputVotingProfile(List<int> votings, List<List<string>> groups)
        {
            Console.WriteLine("\nПрофиль для голосования: ");
            for (int i = 0; i < groups.Count(); i++)
            {
                Console.Write($"{votings[i]} \t");
                for (int j = 0; j < groups[i].Count(); j++)
                {
                    Console.Write($"{groups[i][j]} \t");
                }
                Console.WriteLine();
            }
        }
    }
}
