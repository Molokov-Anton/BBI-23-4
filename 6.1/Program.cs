using System;
using System.Collections.Generic;

class Program
{
    struct Student
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

        // Фильтрация студентов с оценкой 2
        List<Student> failedStudents = new List<Student>();
        foreach (var student in students)
        {
            if (student.Score == 2)
            {
                failedStudents.Add(student);
            }
        }

        // Сортировка по количеству пропущенных занятий в порядке убывания
        failedStudents.Sort((x, y) => y.MissedLessons.CompareTo(x.MissedLessons));

        // Вывод результатов
        foreach (var student in failedStudents)
        {
            Console.WriteLine($"{student.Name} - пропустил {student.MissedLessons} занятий");
        }
    }
}
