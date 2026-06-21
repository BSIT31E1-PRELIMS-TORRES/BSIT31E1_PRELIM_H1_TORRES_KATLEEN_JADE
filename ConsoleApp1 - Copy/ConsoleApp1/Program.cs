using System;
using System.Collections.Generic;
using System.Linq;

class student
{
    public string student_name { get; set; }
    public List<double> grades { get; set; }

    public double averageGrade()
    {
        return grades.Average();
    }

    public double highestGrade()
    {
        return grades.Max();
    }
}

class Program
{
    static List<student> studentLis = new List<student>();

    static void Main()
    {
        bool menu = true;

        while (menu)
        {
            Console.WriteLine();
            Console.WriteLine("===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Compute Average Grade");
            Console.WriteLine("4. Find Highest Grade");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==========================");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    addStudent();
                    break;

                case "2":
                    viewStudent();
                    break;

                case "3":
                    average();
                    break;

                case "4":
                    findHighest();
                    break;

                case "5":
                    Console.WriteLine("Exiting program...");
                    Console.WriteLine("Goodbye!");
                    menu = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void addStudent()
    {
        Console.Write("Enter student name: ");
        string student_name = Console.ReadLine();

        List<double> grades = new List<double>();

        Console.Write("Enter grade 1: ");
        grades.Add(double.Parse(Console.ReadLine()));

        Console.Write("Enter grade 2: ");
        grades.Add(double.Parse(Console.ReadLine()));

        Console.Write("Enter grade 3: ");
        grades.Add(double.Parse(Console.ReadLine()));

        studentLis.Add(new student
        {
            student_name = student_name,
            grades = grades
        });

        Console.WriteLine("Student added successfully!");
    }

    static void viewStudent()
    {
        if (studentLis.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        Console.WriteLine();

        foreach (var studentList in studentLis)
        {
            Console.WriteLine($"Name: {studentList.student_name}");
            Console.WriteLine($"Grades: {string.Join(", ", studentList.grades)}");
            Console.WriteLine($"Average: {studentList.averageGrade():F2}");
            Console.WriteLine();
        }
    }

    static void average()
    {
        Console.WriteLine("===== CLASS AVERAGE =====");

        if (studentLis.Count == 0)
        {
            Console.WriteLine("Overall Average Grade: 0.00");
            return;
        }

        double classAverage = studentLis.Average(s => s.averageGrade());

        Console.WriteLine($"Overall Average Grade: {classAverage:F2}");
    }

    static void findHighest()
    {
        Console.WriteLine("===== HIGHEST GRADE =====");

        if (studentLis.Count == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        student topStudent = studentLis
            .OrderByDescending(s => s.highestGrade())
            .First();

        Console.WriteLine($"Top Student: {topStudent.student_name}");
        Console.WriteLine($"Highest Grade: {topStudent.highestGrade():F0}");
    }
}
