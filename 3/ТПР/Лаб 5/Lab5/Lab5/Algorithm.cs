using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Algorithm
    {
        // Метод початку алгоритму
        public static void StartAlgorithm(double countCriteria, double countAlternatives)
        {
            double[,] matrCriterias = InputOutput.InputInformayion(Convert.ToInt32(countCriteria));
            List<double> eigenvectorCriterias = CreateEigenvector(matrCriterias);
            List<double> vectorWeightCriterias = CreateVectorWeight(eigenvectorCriterias);

            Console.WriteLine("\nМатрица сравнения критериев с векторами: ");
            InputOutput.OutputMatrComperAndVectors(matrCriterias, eigenvectorCriterias, vectorWeightCriterias);
                                   
            List<double[,]> matricesAlternatives = new List<double[,]>();
            List<List<double>> eigenvectorsCriteriasOfAlter = new List<List<double>>();
            List<List<double>> vectorsWeightCriteriasOfAlter = new List<List<double>>();
            for (int i = 0; i < countCriteria; i++)
            {
                matricesAlternatives.Add(InputOutput.InputInformayion(Convert.ToInt32(countAlternatives)));
                eigenvectorsCriteriasOfAlter.Add(CreateEigenvector(matricesAlternatives[i]));
                vectorsWeightCriteriasOfAlter.Add(CreateVectorWeight(eigenvectorsCriteriasOfAlter[i]));
            }

            Console.WriteLine("\nМатрица сравнения альтернатив с векторами: ");
            for (int i = 0; i < countCriteria; i++)
            {
                Console.WriteLine($"Относительно критерия C{i + 1}");
                InputOutput.OutputMatrComperAndVectors(matricesAlternatives[i], eigenvectorsCriteriasOfAlter[i], vectorsWeightCriteriasOfAlter[i]);
                Console.WriteLine();
            }


            // Блок у якому вираховується та виводиться показник якості для альтернатив
            List<double> qualityIndicators = CountQualityIndicators(vectorWeightCriterias, vectorsWeightCriteriasOfAlter);
            InputOutput.OutputQualityIndicators(qualityIndicators);
        }

        // Метод, який рахує власні вектори
        public static List<double> CreateEigenvector(double[,] matrInform)
        {
            List<double> eigenvector = new List<double>();
            double product = 1;

            for (int i = 0; i < matrInform.GetLength(0); i++)
            {
                for (int j = 0; j < matrInform.GetLength(1); j++)
                {
                    product *= matrInform[i,j];
                }
                eigenvector.Add(Math.Pow(product, ((double)1 / matrInform.GetLength(1))));
                product = 1;
            }

            return eigenvector;
        }

        // Метод, який рахує вагу векторів
        public static List<double> CreateVectorWeight(List<double> eigenvector)
        {
            List<double> vectorWeight = new List<double>();
            double sumEigenvector = eigenvector.Sum();

            for (int i = 0; i < eigenvector.Count(); i++)
            {
                vectorWeight.Add(eigenvector[i] / sumEigenvector);
            }

            return vectorWeight;
        }

        // Метод для підрахунку показників якості
        public static List<double> CountQualityIndicators(List<double> vectorWeightCriterias, List<List<double>> vectorsWeightCriteriasOfAlter)
        {
            List<double> qualityIndicators = new List<double>();
            double sum = 0;

            for (int j = 0; j < vectorsWeightCriteriasOfAlter[0].Count(); j++)
            {
                for (int i = 0; i < vectorsWeightCriteriasOfAlter.Count(); i++)
                {
                    sum += vectorWeightCriterias[i] * vectorsWeightCriteriasOfAlter[i][j];
                }
                qualityIndicators.Add(sum);
                sum = 0;
            }

            return qualityIndicators;
        }
    }
}
