using System;
using System.Collections.Generic;
using System.Text;
using UniversityLinqTemplate.Models;

namespace UniversityLinqTemplate.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UniversityContext context)
        {
           // удаляем старые данные из БД для перезаписи
           context.Database.EnsureDeleted();
           // перезаписываем новые данные
           context.Database.EnsureCreated();

            // 1. Создаем группы
            var group1 = new Group { Name = "ИТ-101", CourseNumber = 1 };
            var group2 = new Group { Name = "ПИ-201", CourseNumber = 2 };
            var group3 = new Group { Name = "ИБ-301", CourseNumber = 3 };
            context.Groups.AddRange(group1, group2, group3);

            // 2. Создаем курсы (предметы)
            var csharp = new Course { Title = "Программирование C#", Credits = 5 };
            var databases = new Course { Title = "Базы данных и LINQ", Credits = 4 };
            var math = new Course { Title = "Высшая математика", Credits = 3 };
            context.Courses.AddRange(csharp, databases, math);

            // 3. Создаем студентов
            var s1 = new Student { FirstName = "Алексей", LastName = "Смирнов", Age = 19, Group = group1 };
            var s2 = new Student { FirstName = "Мария", LastName = "Иванова", Age = 20, Group = group2 };
            var s3 = new Student { FirstName = "Дмитрий", LastName = "Кузнецов", Age = 21, Group = group3 };
            var s4 = new Student { FirstName = "Елена", LastName = "Попова", Age = 18, Group = group1 };
            var s5 = new Student { FirstName = "Иван", LastName = "Васильев", Age = 20, Group = group2 };
            context.Students.AddRange(s1, s2, s3, s4, s5);

            // 4. Добавляем оценки
            context.Grades.AddRange(
                new Grade { Student = s1, Course = csharp, Score = 5, Date = DateTime.Now.AddDays(-10) },
                new Grade { Student = s1, Course = databases, Score = 4, Date = DateTime.Now.AddDays(-5) },
                new Grade { Student = s2, Course = csharp, Score = 4, Date = DateTime.Now.AddDays(-12) },
                new Grade { Student = s2, Course = databases, Score = 5, Date = DateTime.Now.AddDays(-3) },
                new Grade { Student = s3, Course = math, Score = 3, Date = DateTime.Now.AddDays(-15) },
                new Grade { Student = s3, Course = databases, Score = 4, Date = DateTime.Now.AddDays(-2) },
                new Grade { Student = s4, Course = csharp, Score = 5, Date = DateTime.Now.AddDays(-8) },
                new Grade { Student = s5, Course = math, Score = 2, Date = DateTime.Now.AddDays(-20) }
            );

            context.SaveChanges();
        }
    }
}
