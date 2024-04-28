using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    abstract class Team
    {
        public string Name { get; set; }
        public int[] Scores { get; set; }

        public Team(string name, int[] scores)
        {
            Name = name;
            Scores = scores;
        }

        public int TotalScore => Scores.Select((score, index) => score * (6 - index)).Sum();
    }

    class WomenTeam : Team
    {
        public WomenTeam(string name, int[] scores) : base(name, scores) { }
    }

    class MenTeam : Team
    {
        public MenTeam(string name, int[] scores) : base(name, scores) { }
    }

    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>
        {
            new WomenTeam("Команда A", new int[] { 1, 2, 3, 4, 5, 6 }),
            new MenTeam("Команда B", new int[] { 2, 3, 4, 5, 6, 1 }),
            new WomenTeam("Команда C", new int[] { 3, 4, 5, 6, 1, 2 })
        };

        Team winningTeam = teams.OrderByDescending(t => t.TotalScore).First();

        Console.WriteLine($"Команда-победитель: {winningTeam.Name} с общим количеством баллов: {winningTeam.TotalScore}");
    }
}
