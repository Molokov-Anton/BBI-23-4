using System;
using System.Linq;

class Program
{
    class Competitor
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

    abstract class Diving
    {
        public string DisciplineName { get; set; }
        public Competitor[] Competitors { get; set; }

        public Diving(string disciplineName, Competitor[] competitors)
        {
            DisciplineName = disciplineName;
            Competitors = competitors;
        }

        public void PrintResults()
        {
            Console.WriteLine($"Результаты {DisciplineName}:");
            for (int i = 0; i < Competitors.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Competitors[i].Surname} - {Competitors[i].TotalScore} баллов");
            }
        }
    }

    class Diving3m : Diving
    {
        public Diving3m(Competitor[] competitors) : base("Прыжки в воду с 3м", competitors) { }
    }

    class Diving5m : Diving
    {
        public Diving5m(Competitor[] competitors) : base("Прыжки в воду с 5м", competitors) { }
    }

    static void Main(string[] args)
    {
        Competitor[] competitors = new Competitor[]
        {
            new Competitor("Иванов", new int[] { 8, 9 }),
            new Competitor("Петров", new int[] { 7, 8 }),
            new Competitor("Сидоров", new int[] { 9, 8 }),
            new Competitor("Кузнецов", new int[] { 8, 7 }),
            new Competitor("Смирнов", new int[] { 7, 9 })
        };

        Diving3m diving3m = new Diving3m(competitors);
        Diving5m diving5m = new Diving5m(competitors);

        diving3m.PrintResults();
        Console.WriteLine();
        diving5m.PrintResults();
    }
}

