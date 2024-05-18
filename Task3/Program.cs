using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Team
{
    public string Name { get; private set; }
    public List<int> SportsmensRes { get; private set; }

    protected Team(string name, List<int> sportsmenRes)
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


public class WomenTeam : Team
{
    public WomenTeam(string name, List<int> sportsmenRes) : base(name, sportsmenRes) { }
}

public class MenTeam : Team
{
    public MenTeam(string name, List<int> sportsmenRes) : base(name, sportsmenRes) { }
}

class Program
{
    static void Main(string[] args)
    {
      
        var menTeams = new List<MenTeam>
        {
            new MenTeam("Team1", new List<int> { 1, 5, 7, 12, 13, 16 }),
            new MenTeam("Team2", new List<int> { 2, 6, 8, 11, 14, 17 }),
            new MenTeam("Team3", new List<int> { 2, 4, 9, 10, 15, 18 })
        };

        var womenTeams = new List<WomenTeam>
        {
            new WomenTeam("TeamA", new List<int> { 1, 2, 3, 4, 5, 6 }),
            new WomenTeam("TeamB", new List<int> { 2, 3, 4, 5, 6, 1 }),
            new WomenTeam("TeamC", new List<int> { 3, 4, 5, 6, 1, 2 })
        };

       
        menTeams.Sort((a, b) => b.CalculateScore().CompareTo(a.CalculateScore()));
        womenTeams.Sort((a, b) => b.CalculateScore().CompareTo(a.CalculateScore()));

        var topScoringMen = menTeams[0];
        var topScoringWomen = womenTeams[0];

       
        var overallWinner = topScoringMen.CalculateScore() > topScoringWomen.CalculateScore() ? topScoringMen : topScoringWomen;

        Console.WriteLine($"Overall Winner: {overallWinner.Name} with a total score of {overallWinner.CalculateScore()}");
    }
}
