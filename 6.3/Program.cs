using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    struct Team
    {
        public string Name { get; }
        public int[] Scores { get; }
        public int TotalScore { get; }
        public int Rank { get; set; }

        public Team(string name, int[] scores)
        {
            Name = name;
            Scores = scores;
            TotalScore = CalculateTotalScore(scores);
            Rank = 0;
        }

        private static int CalculateTotalScore(int[] scores)
        {
            return scores.Select((score, index) => score * (18 - index)).Sum();
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Команда: {Name}, Место: {Rank}, Общее количество баллов: {TotalScore}");
        }

        public void PrintParticipants()
        {
            Console.WriteLine($"Участники команды {Name}:");
            for (int i = 0; i < Scores.Length; i++)
            {
                Console.WriteLine($"Место: {Scores[i]}, Участник: {i + 1}");
            }
        }
    }

    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>
        {
            new Team("Команда A", new int[] { 1, 2, 3, 4, 5, 6 }),
            new Team("Команда B", new int[] { 2, 3, 4, 5, 6, 1 }),
            new Team("Команда C", new int[] { 3, 4, 5, 6, 1, 2 })
        };

        var sortedTeams = teams.OrderByDescending(t => t.TotalScore).ToList();

        List<Team> rankedTeams = new List<Team>();
        for (int i = 0; i < sortedTeams.Count; i++)
        {
            rankedTeams.Add(new Team(sortedTeams[i].Name, sortedTeams[i].Scores) { Rank = i + 1 });
        }

        foreach (var team in rankedTeams)
        {
            team.PrintDetails();
            team.PrintParticipants();
        }
    }
}
