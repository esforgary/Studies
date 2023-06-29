using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab3_4
{
    public class ImplementationAlgorithm
    {
        private List<List<int>> alternatives;

        public ImplementationAlgorithm(List<List<int>> alternatives)
        {
            this.alternatives = alternatives;
        }

        //Метод, що запускає алгоритм
        public void StartAlgorithm(int numberAlternativ)
        {
            List<List<int[]>> setAlterFirstRefSit = CreateSetAlterFirstReferenceSituations(numberAlternativ);
            List<int[]> pairForCompare = CreatePairForCompare(numberAlternativ, CulcNumberPairCompare(numberAlternativ));          
            InputOutput.OutputSetAlterFirstReferenceSituations(setAlterFirstRefSit);
            InputOutput.OutputPairForCompare(pairForCompare);
            List<List<int[]>> chains = CreatChainAfterCompar(setAlterFirstRefSit, pairForCompare);
            InputOutput.OutputChains(chains);
            List<int[]> mainChain = CreateTheMainChain(chains);
            InputOutput.OutputChain(mainChain);
            InputOutput.OutputSingleOrdinalScale(mainChain);
            List<List<int[]>> vectorEstimatOnSOS = CreateVectorEstimates(mainChain);
            InputOutput.OutputVectorEstimates(vectorEstimatOnSOS);
        }

        // Метод для вирахування кількості порівняннь
        public int CulcNumberPairCompare(int countAlternatives)
        {
            return countAlternatives * (countAlternatives - 1) / 2;
        }

        // Метод для створення множини альтернатив першої опорної ситуації
        public List<List<int[]>> CreateSetAlterFirstReferenceSituations(int numberAlternativ)
        {
            List<List<int[]>> altFirstReferenceSituat = InitiolizationFirstRefSit(numberAlternativ);

            for (int i = 0; i < numberAlternativ; i++)
            {
                for (int j = 0; j < numberAlternativ; j++)
                {
                    altFirstReferenceSituat[i][j][i] = j + 1;
                }
            }

            return altFirstReferenceSituat;
        }

        // Метод для початкової ініціалізації множини альтернатив першої опорної ситуації
        public List<List<int[]>> InitiolizationFirstRefSit(int numberAlternativ)
        {
            List<List<int[]>> altFirstReferenceSituat = new List<List<int[]>>();

            for (int i = 0; i < numberAlternativ; i++)
            {
                altFirstReferenceSituat.Add(new List<int[]>());

                for (int j = 0; j < numberAlternativ; j++)
                {
                    altFirstReferenceSituat[i].Add(new int[numberAlternativ]);

                    for (int c = 0; c < numberAlternativ; c++)
                    {
                        altFirstReferenceSituat[i][j][c] = 1;
                    }
                }
            }

            return altFirstReferenceSituat;
        }

        // Метод, що генерує пари критеріїв, що будуть надалі порівнюватися
        public List<int[]> CreatePairForCompare(int numberAlternativ, int numberPairCompare)
        {
            List<int[]> pairs = new List<int[]>();

            for (int i = 1; i <= numberAlternativ - 1; i++)
            {
                for (int j = i + 1; j <= numberAlternativ; j++)
                {
                    pairs.Add(new int[] { i, j });
                }
            }

            if (pairs.Count != numberPairCompare)
            {
                throw new ArgumentException("Number of generated pairs does not match the expected number of pairs to compare.");
            }

            return pairs;
        }

        // Метод, що порівнює пари критеріїв, з подальшою побудовою відповідних ланцюжків та загального ланцюжка
        public List<List<int[]>> CreatChainAfterCompar(List<List<int[]>> setAlterFirstRefSit, List<int[]> pairForCompare)
        {
            List<List<int[]>> chains = new List<List<int[]>>();

            for (int i = 0; i < pairForCompare.Count(); i++)
            {
                chains.Add(CreateChain(setAlterFirstRefSit[pairForCompare[i][0] - 1], setAlterFirstRefSit[pairForCompare[i][1] - 1]));
            
            }

            return chains;
        }

        // Метод, що формує ланцюжок
        public List<int[]> CreateChain(List<int[]> firstAlt, List<int[]> secondAlt)
        {
            List<int[]> chain = new List<int[]>();
            int[,] matrCompare = ComparTwoAlter(firstAlt, secondAlt);

            chain.Add(firstAlt[0]);
            for (int i = 0; i < matrCompare.GetLength(0); i++)
            {
                if (matrCompare[i, 0] == 1)
                {
                    chain.Add(firstAlt[i + 1]);
                    chain.Add(secondAlt[i + 1]);
                }
                else
                {
                    chain.Add(secondAlt[i + 1]);
                    chain.Add(firstAlt[i + 1]);
                }
            }

            return chain;
        }

        // Метод, що порівнює два критерії
        public int[,] ComparTwoAlter(List<int[]> firstAlt, List<int[]> secondAlt)
        {
            int[,] comparMatrix = new int[firstAlt.Count() - 1, 2];
            int priority;

            Console.WriteLine("");
            for (int i = 1; i < firstAlt.Count(); i++)
            {
                 Console.Write($"Какая из альтернатив лучше {string.Join("", firstAlt[i])} или {string.Join("", secondAlt[i])}: ");

                while (!int.TryParse(Console.ReadLine(), out priority) && (priority != 0 || priority != 1)) 
                {
                    Console.WriteLine("Введено не число");
                }

                if (priority == 0)
                {
                    comparMatrix[i - 1, 0] = 1;
                    comparMatrix[i - 1 , 1] = 0;
                }
                else
                {
                    comparMatrix[i - 1, 0] = 0;
                    comparMatrix[i - 1, 1] = 1;
                }
            }

            return comparMatrix;
        }

        // Метод для, який будує загальний ланцюг
        public List<int[]> CreateTheMainChain(List<List<int[]>> chains)
        {
            List<int[]> mainChain = new List<int[]>();

            for (int j = 0; j < chains[0].Count(); j++)
            {
                for (int i = 0; i < chains.Count(); i++)
                {
                    if (!mainChain.Any(array => array.SequenceEqual(chains[i][j]))) 
                    {
                        mainChain.Add(chains[i][j]);
                    }
                }
            }

            return mainChain;
        }

        // Метод для створення векторних оцінок
        public List<List<int[]>> CreateVectorEstimates(List<int[]> mainChain)
        {
            List<List<int[]>> vectorEstimates = new List<List<int[]>>();
            List<int[]> startVectorsEstimates = CreateStartVectorEstimates();
            List<int[]> vectorEstimatesOnSOS = CreateVectorEstimatesOnSingleOrdinalScale(mainChain, startVectorsEstimates);
            List<int[]> sortedVectorEstimates = SortVectorEstimates(vectorEstimatesOnSOS);

            vectorEstimates.Add(startVectorsEstimates);
            vectorEstimates.Add(vectorEstimatesOnSOS);
            vectorEstimates.Add(sortedVectorEstimates);

            return vectorEstimates;
        }

        // Метод, який створю початкові векторні оцінки
        public List<int[]> CreateStartVectorEstimates()
        {
            List<int[]> startVectorsEstimates = new List<int[]>();

            for (int i = 0; i < alternatives.Count(); i++)
            {
                int[] vectEst = new int[alternatives.Count()];
                for (int j = 0; j < alternatives[i].Count(); j++)
                {
                    vectEst[j] = alternatives[i][j];
                }
                startVectorsEstimates.Add(vectEst);
            }

            return startVectorsEstimates;
        }

        // Метод, що формує векторні оцінки за ЄПШ
        public List<int[]> CreateVectorEstimatesOnSingleOrdinalScale(List<int[]> mainChain, List<int[]> startVectorsEstimates)
        {
            List<int[]> vectorEstimatesOnSOS = new List<int[]>();

            for (int i = 0; i < startVectorsEstimates.Count(); i++)
            {
                int[] vector = new int[startVectorsEstimates[0].Length];
                for (int j = 0; j < startVectorsEstimates[i].Length; j++)
                {
                    for (int c = 0; c < mainChain.Count(); c++)
                    {
                        if (startVectorsEstimates[i][j] == mainChain[c][j])
                        {
                            vector[j] = c + 1;
                            break;
                        }
                    }    
                }
                vectorEstimatesOnSOS.Add(vector);
            }

            return vectorEstimatesOnSOS;
        }
   
        // Метод для сорутвання векторних оцінок за зростанням
        public List<int[]> SortVectorEstimates(List<int[]> vectorEstimatesOnSOS)
        {
            List<int[]> sortedVectorEstimates = new List<int[]>();

            for (int i = 0; i < vectorEstimatesOnSOS.Count(); i++)
            {
                int[] vector = new int[vectorEstimatesOnSOS[i].Length];
                Array.Copy(vectorEstimatesOnSOS[i], vector, vectorEstimatesOnSOS[i].Length);
                Array.Sort(vector);
                sortedVectorEstimates.Add(vector);
            }

            return sortedVectorEstimates;
        }
    }
}
