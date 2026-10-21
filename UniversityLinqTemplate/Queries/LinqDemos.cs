using System;
using System.Linq;
using UniversityLinqTemplate.Data;
using Microsoft.EntityFrameworkCore;

namespace UniversityLinqTemplate.Queries
{
    public static class LinqDemos
    {
        // 1. Фильтрация и Сортировка (Where, OrderBy)
        public static void DemoFilteringAndSorting(UniversityContext db)
        {
            Console.WriteLine("\n=== 1. Здания с износом > 50%, отсортированные по убыванию износа ===");
            var result = db.Buildings
                .Where(b => b.Condition > 50)
                .OrderByDescending(b => b.Condition)
                .ToList();

            foreach (var b in result)
                Console.WriteLine($"{b.Name} ({b.Type}) - Износ: {b.Condition}%");
        }

        // 2. Проекция (Select) и анонимные типы
        public static void DemoProjection(UniversityContext db)
        {
            Console.WriteLine("\n=== 2. Проекция: Колонисты и их здания ===");
            var result = db.Colonists
                .Include(c => c.Building)
                .Select(c => new
                {
                    ColonistName = c.FullName,
                    Profession = c.Profession,
                    BuildingName = c.Building != null ? c.Building.Name : "Без здания"
                })
                .ToList();

            foreach (var item in result)
                Console.WriteLine($"{item.ColonistName} ({item.Profession}) -> {item.BuildingName}");
        }

        // 3. Агрегатные функции (Count, Sum, Average)
        public static void DemoAggregations(UniversityContext db)
        {
            Console.WriteLine("\n=== 3. Агрегатные вычисления по ресурсам ===");
            int totalTypes = db.Resources.Count();
            int totalQuantity = db.Resources.Sum(r => r.Quantity);
            double avgQuantity = db.Resources.Average(r => r.Quantity);

            Console.WriteLine($"Всего видов ресурсов: {totalTypes}");
            Console.WriteLine($"Общее количество добычи: {totalQuantity} ед.");
            Console.WriteLine($"Среднее количество с вылазки: {avgQuantity:F2} ед.");
        }

        // 4. Группировка (GroupBy)
        public static void DemoGrouping(UniversityContext db)
        {
            Console.WriteLine("\n=== 4. Группировка: Количество колонистов по профессиям ===");
            var groupSummary = db.Colonists
                .GroupBy(c => c.Profession)
                .Select(g => new
                {
                    Profession = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .ToList();

            foreach (var item in groupSummary)
                Console.WriteLine($"Профессия: {item.Profession} | Колонистов: {item.Count}");
        }

        // 5. Связи и Объединения (Include / ThenInclude)
        public static void DemoJoinsAndIncludes(UniversityContext db)
        {
            Console.WriteLine("\n=== 5. Вылазки с их командирами и добытыми ресурсами ===");
            var expeditions = db.Expeditions
                .Include(e => e.Commander)
                .Include(e => e.Resources)
                .ToList();

            foreach (var e in expeditions)
            {
                Console.WriteLine($"\nВылазка: {e.Target} (Статус: {e.Status})");
                Console.WriteLine($"  Командир: {e.Commander?.FullName}");

                if (!e.Resources.Any())
                {
                    Console.WriteLine("  (Ресурсы не добыты)");
                    continue;
                }
                foreach (var r in e.Resources)
                    Console.WriteLine($"  - {r.Name} ({r.ResourceType}): {r.Quantity} ед.");
            }
        }
    }
}