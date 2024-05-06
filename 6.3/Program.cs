using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    public string Name { get; set; }
    public List<int> SportsmensRes { get; set; }

    public Team(string name, List<int> sportsmenRes)
    {
        Name = name;
        SportsmensRes = sportsmenRes;
    }

    public int CalculateScore()
    {
        int score = 0;
        foreach (var place in SportsmensRes)
        {
            switch (place)
            {
                case 1:
                    score += 5;
                    break;
                case 2:
                    score += 4;
                    break;
                case 3:
                    score += 3;
                    break;
                case 4:
                    score += 2;
                    break;
                case 5:
                    score += 1;
                    break;
            }
        }
        return score;
    }

    public int CountFirstPlace()
    {
        return SportsmensRes.Count(place => place == 1);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>
        {
            new Team("Team1", new List<int> {  1,  5,  7,  12,  13,  16 }),
            new Team("Team2", new List<int> {  2,  6,  8,  11,  14,  17 }),
            new Team("Team3", new List<int> {  2,  4,  9,  10,  15,  18 })
        };

        Team winner = null;
        int maxScore = 0;
        int maxFirstPlace = 0;

        foreach (var team in teams)
        {
            int teamScore = team.CalculateScore();
            int teamFirstPlace = team.CountFirstPlace();
            if (teamScore > maxScore || (teamScore == maxScore && teamFirstPlace > maxFirstPlace))
            {
                maxScore = teamScore;
                maxFirstPlace = teamFirstPlace;
                winner = team;
            }
        }

        Console.WriteLine($"Победитель: {winner.Name} с общим количеством баллов: {maxScore}");
    }
}

