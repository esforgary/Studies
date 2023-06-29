using Lab2.Model;
using Lab2.ToolsClasses;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] objectOfInspection = new int[] { 1, 2, 1,	2, 2, 1, 2, 1, 2, 1, 2, 2, 1, 1, 2 };
            int countCriterion = OutputInputClass.InputCount("Enter the number of criteria: ");
            List<Criterion> criterions = new List<Criterion>();
            List<List<int>> coefForTable = new List<List<int>>();

            OutputInputClass.InputInformation(countCriterion, criterions);

            coefForTable = OperationsCriteria.ConvertListStringInt(OperationsCriteria.CreateTableAlternativ(criterions));
            
            ImplementationAlgorithm.StartAlgorithm(coefForTable, objectOfInspection);
        }
    }
}