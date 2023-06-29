namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double countCriteria = InputOutput.InputCount("Введите количество критериев: ");
            double countAlternatives = InputOutput.InputCount("Введите количество альтернатив: ");

            Algorithm.StartAlgorithm(countCriteria, countAlternatives);
        }
    }
}