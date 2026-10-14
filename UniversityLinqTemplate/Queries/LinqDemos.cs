using System;
using System.Collections.Generic;
using System.Text;
using UniversityLinqTemplate.Data;
using Microsoft.EntityFrameworkCore;

namespace UniversityLinqTemplate.Queries
{
    public static class LinqDemos
    {
        // 1. Фильтрация и Сортировка (Where, OrderBy)
        public static void DemoFilteringAndSorting(UniversityContext db)
        {
            Console.WriteLine("\n=== 1. Студенты старше 19 лет, отсортированные по фамилии ===");

            // Method Syntax:
            var result = db.Students
                .Where(s => s.Age > 19)
                .OrderBy(s => s.LastName)
                .ToList();

            /* Query Syntax (эквивалент):
            var result = (from s in db.Students
                          where s.Age > 19
                          orderby s.LastName
                          select s).ToList();
            */

            foreach (var s in result)
                Console.WriteLine($"{s.LastName} {s.FirstName}, Возраст: {s.Age}");
        }

        // 2. Проекция (Select) и анонимные типы
        public static void DemoProjection(UniversityContext db)
        {
            Console.WriteLine("\n=== 2. Проекция: Только ФИО и название группы ===");

            // Method Syntax:
            var result = db.Students
                .Include(s => s.Group)
                .Select(s => new
                {
                    FullName = $"{s.LastName} {s.FirstName}",
                    GroupName = s.Group != null ? s.Group.Name : "Без группы"
                })
                .ToList();

            /* Query Syntax (эквивалент):
            var result = (from s in db.Students
                          select new
                          {
                              FullName = s.LastName + " " + s.FirstName,
                              GroupName = s.Group.Name
                          }).ToList();
            */

            foreach (var item in result)
                Console.WriteLine($"{item.FullName} -> {item.GroupName}");
        }

        // 3. Агрегатные функции (Count, Average, Min, Max)
        public static void DemoAggregations(UniversityContext db)
        {
            Console.WriteLine("\n=== 3. Агрегатные вычисления ===");

            int totalStudents = db.Students.Count();
            double avgScore = db.Grades.Average(g => g.Score);
            int maxScore = db.Grades.Max(g => g.Score);

            Console.WriteLine($"Всего студентов: {totalStudents}");
            Console.WriteLine($"Средний балл по университету: {avgScore:F2}");
            Console.WriteLine($"Максимальная оценка: {maxScore}");
        }

        // 4. Группировка (GroupBy)
        public static void DemoGrouping(UniversityContext db)
        {
            Console.WriteLine("\n=== 4. Группировка: Количество студентов по курсам групп ===");

            // Method Syntax:
            var groupSummary = db.Students
                .GroupBy(s => s.Group!.CourseNumber)
                .Select(g => new
                {
                    CourseNum = g.Key,
                    Count = g.Count()
                })
                .OrderBy(g => g.CourseNum)
                .ToList();

            /* Query Syntax (эквивалент):
            var groupSummary = (from s in db.Students
                                group s by s.Group.CourseNumber into g
                                orderby g.Key
                                select new
                                {
                                    CourseNum = g.Key,
                                    Count = g.Count()
                                }).ToList();
            */

            foreach (var item in groupSummary)
                Console.WriteLine($"Курс обучения: {item.CourseNum} | Студентов: {item.Count}");
        }

        // 5. Связи и Объединения (Include / Join)
        public static void DemoJoinsAndIncludes(UniversityContext db)
        {
            Console.WriteLine("\n=== 5. Студенты и их оценки по предметам (Include) ===");

            var studentsWithGrades = db.Students
                .Include(s => s.Grades)
                    .ThenInclude(g => g.Course)
                .ToList();

            foreach (var s in studentsWithGrades)
            {
                Console.WriteLine($"\nСтудент: {s.LastName} {s.FirstName}");
                if (!s.Grades.Any())
                {
                    Console.WriteLine("  (Оценок пока нет)");
                    continue;
                }

                foreach (var grade in s.Grades)
                    Console.WriteLine($"  - {grade.Course?.Title}: {grade.Score} (от {grade.Date:dd.MM.yyyy})");
            }
        }
    }
}
