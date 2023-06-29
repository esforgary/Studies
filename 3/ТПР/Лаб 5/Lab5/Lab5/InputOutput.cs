using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class InputOutput
    {
        // Метод для введення кілскості
        public static double InputCount(string textProposition)
        {
            Console.Write(textProposition);
            return InputIntNumber();
        }

        // Метод для введення числа
        public static double InputIntNumber()
        {
            double number;
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Строка не может быть преобразована в число. Попробуйте еще раз");
            }

            return number;
        }

        // Метод для запису альтернатив та критеріїв
        public static double[,] InputInformayion(int count)
        {
            double[,] inf = new double[count, count];

            InitializationMainDiagonal(ref inf);

            for (int i = 0; i < inf.GetLength(0); i++)
            {
                for (int j = 0; j < inf.GetLength(1); j++)
                {
                    if (inf[i, j] == 0)
                    {
                        int[] numbers = new int[] { -9, -7, -5, -3, 3, 5, 7, 9 };
                        Random rand = new Random();
                        int randomIndex = rand.Next(0, numbers.Length);                        
                        double number = numbers[randomIndex];

                        if (number > 0)
                        {
                            inf[i, j] = number;
                            inf[j, i] = 1 / number;
                        }
                        else
                        {
                            inf[i, j] = 1 / Math.Abs(number);
                            inf[j, i] = Math.Abs(number);
                        }
                    }
                }
            }

            return inf;
        }

        // Метод для ініціалізації головної діагоналі
        public static void InitializationMainDiagonal(ref double[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                matr[i, i] = 1;
            }
        }

        // Метод для виводу матриці порівнянь та векторів разом
        public static void OutputMatrComperAndVectors(double[,] matrComper, List<double> eigenvector, List<double> vectorWeight)
        {
            for (int i = 0; i < matrComper.GetLength(0); i++)
            {
                for (int j = 0; j < matrComper.GetLength(1) + 2; j++)
                {
                    if (j == matrComper.GetLength(1))
                    {
                        Console.Write($"\t{Math.Round(eigenvector[i],2)}\t");
                    }
                    else if (j == matrComper.GetLength(1) + 1)
                    {
                        Console.Write($"\t{Math.Round(vectorWeight[i],2)}\t");
                    }
                    else
                    {
                        Console.Write($"\t{Math.Round(matrComper[i, j], 2)}\t");
                    }
                }
                Console.WriteLine();
            }

        }
    
        // Метод для виводу показників якості
        public static void OutputQualityIndicators(List<double> qualityIndicators)
        {
            Console.WriteLine("Показатели качества: ");
            for (int i = 0; i < qualityIndicators.Count(); i++)
            {
                Console.WriteLine($"C{i + 1} = {Math.Round(qualityIndicators[i], 2)}");
            }
        }
    }
}
