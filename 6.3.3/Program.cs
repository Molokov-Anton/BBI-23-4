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

        public Team(string name, int[] scores)
        {
            Name = name;
            Scores = scores;
        }

        public int TotalScore => Scores.Select((score, index) => score * (6 - index)).Sum();
    }

    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>
        {
            new Team("Команда A", new int[] { 1, 2, 3, 4, 5, 6 }),
            new Team("Команда B", new int[] { 2, 3, 4, 5, 6, 1 }),
            new Team("Команда C", new int[] { 3, 4, 5, 6, 1, 2 })
        };

        Team winningTeam = teams.OrderByDescending(t => t.TotalScore).First();

        Console.WriteLine($"Команда-победитель: {winningTeam.Name} с общим количеством баллов: {winningTeam.TotalScore}");
    }
}
