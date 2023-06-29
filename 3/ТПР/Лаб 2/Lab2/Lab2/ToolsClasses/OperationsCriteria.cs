using Lab2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ToolsClasses
{
    public static class OperationsCriteria
    {
      
        public static List<string> CreateTableAlternativ(List<Criterion> criterions, int currentLevel = 0, string currentCoef = "")
        {
            List<string> coefResult = new List<string>();

            if (currentLevel >= criterions.Count)
            {
                coefResult.Add(currentCoef);
                return (coefResult);
            }

            foreach (var scale in criterions[currentLevel].CriteriaScale)
            {
                var subIntResult = CreateTableAlternativ(criterions, currentLevel + 1, currentCoef + criterions[currentLevel].CriteriaScale.IndexOf(scale) + " |");
                coefResult.AddRange(subIntResult);
            }
            return (coefResult);
        }
        
        public static List<List<int>> ConvertListStringInt(List<string> coefForTable)
        {
            List<List<int>> intCoefForTable = new List<List<int>>();

            foreach (var cof in coefForTable)
            {
                List<int> numbers = new List<int>();
                string[] numbersArr = cof.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var n in numbersArr)
                {
                    numbers.Add(Convert.ToInt32(n) + 1);
                }
                intCoefForTable.Add(numbers);
            }
            return intCoefForTable;
        }

    }
}
