using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;  
using System.Text;

namespace Lab2.ToolsClasses
{
    public static class ImplementationAlgorithm
    {
        static private double[] centre_first_clas;
        static private double[] centre_second_clas;
        static private List<int[]> G = new List<int[]>();
        static private List<double> d1 = new List<double>();
        static private List<double> d2 = new List<double>();
        static private List<double> p1 = new List<double>();
        static private List<double> p2 = new List<double>();
        static private List<double> g1 = new List<double>();
        static private List<double> g2 = new List<double>();
        static private List<double> F1 = new List<double>();
        static private List<double> F2 = new List<double>();
        static private List<double> F = new List<double>();
        static private int iteration = 0;

        // Початок алгоритма
        public static void StartAlgorithm(List<List<int>> coefForTable, int[] objectOfInspection)
        {
            InitializationG(G, coefForTable.Count);

            do
            {
                CalculateCentreClass(coefForTable, G, true, out centre_first_clas);
                CalculateCentreClass(coefForTable, G, false, out centre_second_clas);
                Calculate_d(centre_first_clas, coefForTable, out d1);
                Calculate_d(centre_second_clas, coefForTable, out d2);
                CalculateColomn_p(G, d1, d2, true, out p1);
                CalculateColomn_p(G, d1, d2, false, out p2);
                CalculateColomn_g(G, coefForTable, true, out g1);
                CalculateColomn_g(G, coefForTable, false, out g2);
                CulculateFWithIndex(g1, p1, out F1);
                CulculateFWithIndex(g2, p2, out F2);
                CulculateF(F1, F2, out F);
                OutputInputClass.OutputTable(coefForTable, G, d1, d2, p1, p2, g1, g2, F1, F2, F, "C:\\Users\\stass\\Desktop\\ХНУРЭ 3\\2\\ТПР\\Лаб 2\\Lab2\\result.txt");
                RewriteG(iteration, G, F, objectOfInspection, coefForTable);
                OutputInputClass.OutputG(G, "C:\\Users\\stass\\Desktop\\ХНУРЭ 3\\2\\ТПР\\Лаб 2\\Lab2\\result.txt");
                iteration++;
            }
            while (!Check_G_ForItteration(G));

            CalculateCentreClass(coefForTable, G, true, out centre_first_clas);
            CalculateCentreClass(coefForTable, G, false, out centre_second_clas);
            Calculate_d(centre_first_clas, coefForTable, out d1);
            Calculate_d(centre_second_clas, coefForTable, out d2);
            CalculateColomn_p(G, d1, d2, true, out p1);
            CalculateColomn_p(G, d1, d2, false, out p2);
            CalculateColomn_g(G, coefForTable, true, out g1);
            CalculateColomn_g(G, coefForTable, false, out g2);
            CulculateFWithIndex(g1, p1, out F1);
            CulculateFWithIndex(g2, p2, out F2);
            CulculateF(F1, F2, out F);
            OutputInputClass.OutputTable(coefForTable, G, d1, d2, p1, p2, g1, g2, F1, F2, F, "C:\\Users\\stass\\Desktop\\ХНУРЭ 3\\2\\ТПР\\Лаб 2\\Lab2\\result.txt");
            RewriteG(iteration, G, F, objectOfInspection, coefForTable);
        }

        private static void RewriteG(int iteration, List<int[]> G, List<double> F, int[] objectOfInspection, List<List<int>> coefForTable)
        {
            int indexMaxF = FindFirstMaxIndexInF(F);

            if (objectOfInspection[iteration] == 1)
            {
                for (int i = indexMaxF; i >= 0; i--)
                {
                    if (CheckElementsFromCoefForTable(coefForTable[indexMaxF], coefForTable[i]))
                    {
                        G[i] = new int[] { 1, 1 };
                    }
                }
            }
            if (objectOfInspection[iteration] == 2)
            {
                for (int i = indexMaxF; i < coefForTable.Count(); i++)
                {
                    if (CheckElementsFromCoefForTable(coefForTable[i], coefForTable[indexMaxF]))
                    {
                        G[i] = new int[] { 2, 2 };
                    }
                }
            }
        }

        private static int FindFirstMaxIndexInF(List<double> F)
        {
            return F.Select((x, i) => new { Value = x, Index = i }) 
                    .OrderByDescending(x => x.Value)
                    .First().Index;
        }


        private static bool Check_G_ForItteration(List<int[]> G)
        {
            return G.All(x => x[0] == x[1]);
        }
                

        private static void InitializationG(List<int[]> G, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    G.Add(new int[2] { 1, 1 });
                }
                else if (i == count - 1)
                {
                    G.Add(new int[2] { 2, 2 });
                }
                else
                {
                    G.Add(new int[2] { 1, 2 });
                }
            }
        }


        private static void CalculateCentreClass(List<List<int>> coefForTable, List<int[]> G, bool typeClase, out double[] centre_clas)
        {
            List<List<int>> GroupForRecalculationCentre = new List<List<int>>();
            centre_clas = new double[coefForTable[0].Count()];

            if (typeClase)
            {
                FindGroup(ref GroupForRecalculationCentre, coefForTable, 0);
            }
            if (!typeClase)
            {
                FindGroup(ref GroupForRecalculationCentre, coefForTable, G.Count() - 1);
            }

            for (int j = 0; j < GroupForRecalculationCentre[0].Count(); j++)
            {
                for (int i = 0; i < GroupForRecalculationCentre.Count(); i++)
                {
                    centre_clas[j] += GroupForRecalculationCentre[i][j];
                }

                centre_clas[j] = centre_clas[j] / GroupForRecalculationCentre.Count();
            }
        }


        private static void FindGroup(ref List<List<int>> GroupForRecalculationCentre, List<List<int>> coefForTable, int index)
        {
            for (int i = 0; i < G.Count(); i++)
            {
                if (G[i][0] == G[index][0] && G[i][1] == G[index][1])
                {
                    GroupForRecalculationCentre.Add(coefForTable[i]);
                }
            }
        }


        private static void Calculate_d(double[] centre_clas, List<List<int>> coefForTable, out List<double> d)
        {
            d = new List<double>();
            double sumDifference = 0;

            for (int i = 0; i < coefForTable.Count(); i++)
            {
                for (int j = 0; j < coefForTable[i].Count(); j++)
                {
                    sumDifference += Math.Abs(coefForTable[i][j] - centre_clas[j]);
                }
                d.Add(sumDifference);
                sumDifference = 0;
            }         
        }

        private static void CalculateColomn_p(List<int[]> G, List<double> d1, List<double> d2, bool typeClase, out List<double> p)
        {
            p = new List<double>();
            double D = FindD(d1, d2);

            if (typeClase)
            {
                CreateColmnP(1, 0, G, d1, d2, p, D);
            }
            if (!typeClase)
            {
                CreateColmnP(0, 1, G, d2, d1, p, D);
            }
        }

        private static double FindD(List<double> d1, List<double> d2)
        {
            return Math.Max(d1.Max(), d2.Max());
        }
                
        private static double Calculate_p(double D, double d_ind_p_which_calc, double d_from_another_column)
        {
            return (D - d_ind_p_which_calc) / ((2 * D) - d_ind_p_which_calc - d_from_another_column);
        }

        private static void CreateColmnP(int index1, int index2, List<int[]> G, List<double> d_first, List<double> d_second, List<double> p, double D)
        {
            for (int i = 0; i < G.Count(); i++)
            {
                if (G[i][0] == 1 & G[i][1] == 1)
                {
                    p.Add(index1);
                }
                else if (G[i][0] == 2 & G[i][1] == 2)
                {
                    p.Add(index2);
                }
                else
                {
                    p.Add(Calculate_p(D, d_first[i], d_second[i]));
                }
            }
        }

        private static void CalculateColomn_g(List<int[]> G, List<List<int>> coefForTable, bool typeClase, out List<double> g)
        {
            g = new List<double>();
            List<int> indexElmentsWhichWeWork = new List<int>();

            Check_G_ForColmn_g(G, g, indexElmentsWhichWeWork);

            if (typeClase)
            {
                CreateColomn_g(coefForTable, g, indexElmentsWhichWeWork, typeClase);
            }
            if (!typeClase)
            {
                CreateColomn_g(coefForTable, g, Enumerable.Reverse(indexElmentsWhichWeWork).ToList(), typeClase);
            }
            
        }

        private static void Check_G_ForColmn_g(List<int[]> G, List<double> g, List<int> indexElmentsWhichWeWork)
        {
            for (int i = 0; i < G.Count(); i++) 
            {
                if (G[i][0] == G[i][1])
                {
                    g.Add(0);
                }
                else
                {
                    g.Add(-1);
                    indexElmentsWhichWeWork.Add(i);
                }
            }
        }

        private static bool CheckElementsFromCoefForTable(List<int> element1, List<int> element2)
        {
            return element1.Zip(element2, (x, y) => x >= y).All(x => x);
        }

        private static int Culculate_g(int index, List<int> indexElmentsWhichWeWork, List<List<int>> coefForTable, bool typeClase)
        {
            int counter = 0;
            for (int j = index - 1; j >= 0; j--)
            {
                if (typeClase)
                {
                    if (CheckElementsFromCoefForTable(coefForTable[indexElmentsWhichWeWork[index]], coefForTable[indexElmentsWhichWeWork[j]]))
                    {
                        counter++;
                    }
                }
                if (!typeClase)
                {
                    if (CheckElementsFromCoefForTable(coefForTable[indexElmentsWhichWeWork[j]], coefForTable[indexElmentsWhichWeWork[index]])) 
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private static void CreateColomn_g(List<List<int>> coefForTable, List<double> g, List<int> indexElmentsWhichWeWork, bool typeClase)
        {
            for (int i = 0; i < indexElmentsWhichWeWork.Count(); i++)
            {
                if (i == 0)
                {
                    g[indexElmentsWhichWeWork[i]] = 0;
                }
                else
                {
                    g[indexElmentsWhichWeWork[i]] = Culculate_g(i, indexElmentsWhichWeWork, coefForTable, typeClase);
                }
            }
        }

        private static void CulculateFWithIndex(List<double> g, List<double> p, out List<double> FWithIndex)
        {
            FWithIndex = new List<double>();

            for (int i = 0; i < g.Count(); i++)
            {
                FWithIndex.Add(p[i] * g[i]);
            }
        }

        private static void CulculateF(List<double> F1, List<double> F2, out List<double> F)
        {
            F = new List<double>();

            for (int i = 0; i < F1.Count(); i++)
            {
                F.Add(F1[i] + F2[i]);
            }
        }
    }
}