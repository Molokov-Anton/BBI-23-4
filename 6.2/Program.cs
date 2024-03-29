using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    struct Competitor
    {
        public string Surname { get; set; }
        public int[] Scores { get; set; }

        public Competitor(string surname, int[] scores)
        {
            Surname = surname;
            Scores = scores;
        }

        public int TotalScore => Scores.Sum();
    }

    static void Main(string[] args)
    {
        List<Competitor> competitors = new List<Competitor>
        {
            new Competitor("Иванов", new int[] { 8, 9 }),
            new Competitor("Петров", new int[] { 7, 8 }),
            new Competitor("Сидоров", new int[] { 9, 8 }),
            new Competitor("Кузнецов", new int[] { 8, 7 }),
            new Competitor("Смирнов", new int[] { 7, 9 })
        };

        competitors.Sort((x, y) => y.TotalScore.CompareTo(x.TotalScore));

        // Вывод результатов
        for (int i = 0; i < competitors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {competitors[i].Surname} - {competitors[i].TotalScore} баллов");
        }
    }
}
