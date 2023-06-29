namespace Lab3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\stass\\Desktop\\ХНУРЭ 3\\2\\ТПР\\Лаб 3-4\\criterian.txt";
            
            List<List<int>> alternatives = InputOutput.InputAlternatives(filePath);
            ImplementationAlgorithm alg = new ImplementationAlgorithm(alternatives);

            InputOutput.OutputCriterionDescriptionAlternatives(alternatives);
            alg.StartAlgorithm(alternatives[0].Count());
        }
    }
}