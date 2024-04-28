using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    abstract class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int MissedLessons { get; set; }

        public Student(string name, int score, int missedLessons)
        {
            Name = name;
            Score = score;
            MissedLessons = missedLessons;
        }

        public abstract void PrintInfo();
    }

    class ComputerScienceStudent : Student
    {
        public ComputerScienceStudent(string name, int score, int missedLessons) : base(name, score, missedLessons) { }

        public override void PrintInfo()
        {
            Console.WriteLine($"{Name} - пропустил {MissedLessons} занятий по информатике");
        }
    }

    class MathStudent : Student
    {
        public MathStudent(string name, int score, int missedLessons) : base(name, score, missedLessons) { }

        public override void PrintInfo()
        {
            Console.WriteLine($"{Name} - пропустил {MissedLessons} занятий по математике");
        }
    }

    static void Main(string[] args)
    {
        List<Student> computerScienceStudents = new List<Student>
        {
            new ComputerScienceStudent("Алексей", 2, 5),
            new ComputerScienceStudent("Иван", 3, 3),
            new ComputerScienceStudent("Мария", 2, 5),
            new ComputerScienceStudent("Сергей", 4, 2),
            new ComputerScienceStudent("Анна", 5, 1),
            new ComputerScienceStudent("Дмитрий", 2, 4)
        };

        List<Student> mathStudents = new List<Student>
        {
            new MathStudent("Алексей", 2, 5),
            new MathStudent("Иван", 3, 3),
            new MathStudent("Мария", 2, 5),
            new MathStudent("Сергей", 4, 2),
            new MathStudent("Анна", 5, 1),
            new MathStudent("Дмитрий", 2, 4)
        };

       
        List<Student> failedComputerScienceStudents = computerScienceStudents.FindAll(s => s.Score == 2);
        List<Student> failedMathStudents = mathStudents.FindAll(s => s.Score == 2);

       
        failedComputerScienceStudents.Sort((x, y) => y.MissedLessons.CompareTo(x.MissedLessons));
        failedMathStudents.Sort((x, y) => y.MissedLessons.CompareTo(x.MissedLessons));

        Console.WriteLine("Студенты, не сдавшие информатику:");
        foreach (var student in failedComputerScienceStudents)
        {
            student.PrintInfo();
        }

        Console.WriteLine("\nСтуденты, не сдавшие математику:");
        foreach (var student in failedMathStudents)
        {
            student.PrintInfo();
        }
    }
}
