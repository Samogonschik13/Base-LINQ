using Microsoft.EntityFrameworkCore;
using UniversityLinqTemplate.Models;

namespace UniversityLinqTemplate.Data
{
    public class UniversityContext : DbContext
    {
        // Регистрируем наши новые таблицы
        public DbSet<Building> Buildings => Set<Building>();
        public DbSet<Colonist> Colonists => Set<Colonist>();
        public DbSet<Expedition> Expeditions => Set<Expedition>();
        public DbSet<Resource> Resources => Set<Resource>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // База теперь будет называться colony.db
            optionsBuilder.UseSqlite("Data Source=colony.db");
        }
    }
}