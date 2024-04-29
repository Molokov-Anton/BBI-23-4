using System;
using System.Collections.Generic;

class Program
{
    struct Student
    {
        public string Name { get; }
        public int Score { get; }
        public int MissedLessons { get; }

        public Student(string name, int score, int missedLessons)
        {
            Name = name;
            Score = score;
            MissedLessons = missedLessons;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"{Name} - пропустил {MissedLessons} занятий");
        }
    }

    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student("Алексей", 2, 5),
            new Student("Иван", 3, 3),
            new Student("Мария", 2, 5),
            new Student("Сергей", 4, 2),
            new Student("Анна", 5, 1),
            new Student("Дмитрий", 2, 4)
        };

        
        List<Student> failedStudents = new List<Student>();
        foreach (var student in students)
        {
            if (student.Score == 2)
            {
                failedStudents.Add(student);
            }
        }

        
        failedStudents.Sort((x, y) => y.MissedLessons.CompareTo(x.MissedLessons));

        
        foreach (var student in failedStudents)
        {
            student.PrintDetails();
        }
    }
}
