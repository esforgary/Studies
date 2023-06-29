using Lab6.Algorithms;

namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countAlternatives = InputOutput.InputCount("Введите количество альтернатив: ");
            int countGroups = InputOutput.InputCount("Введите количество групп: ");
            List<int> votings = new List<int>();
            List<List<string>> groups = InputOutput.InputVotingProfile(countAlternatives, countGroups, out votings);
            (string, int) resultFirstRoundRule = FirstRoundRule.StartAlgorithm(votings, groups);
            (string, int) resultSecondRoundRule = SecondRoundRule.StartAlgorithm(votings, groups);
            (string, int) resultBoardRule = BoardRule.StartAlgorithm(votings, groups);
            (string, int) resultCondorceRule = CondorceRule.StartAlgorithm(votings, groups);

            InputOutput.OutputVotingProfile(votings, groups);
            Console.WriteLine($"\nРезультат действия правила первого тура: {resultFirstRoundRule.Item1} = {resultFirstRoundRule.Item2}");
            Console.WriteLine($"\nРезультат действия правила второго тура: {resultSecondRoundRule.Item1} = {resultSecondRoundRule.Item2}");
            Console.WriteLine($"\nРезультат действия правила Борда: {resultBoardRule.Item1} = {resultBoardRule.Item2}");
            Console.WriteLine($"\nРезультат действия правила Кондорсе: {resultCondorceRule.Item1} = {resultCondorceRule.Item2}");

        }
    }
}