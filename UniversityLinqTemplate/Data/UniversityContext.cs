using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityLinqTemplate.Models;

namespace UniversityLinqTemplate.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Grade> Grades => Set<Grade>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // База данных сохранится в локальный файл university.db в папке программы
            optionsBuilder.UseSqlite("Data Source=university.db");
        }
    }
}
