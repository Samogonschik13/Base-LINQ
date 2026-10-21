using System;
using System.Linq;
using ColonyLinq.Models;

namespace ColonyLinq.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UniversityContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Buildings.Any()) return;

            // 1. Здания
            var b1 = new Building { Name = "Купол Альфа", Type = "Жилой", Condition = 85 };
            var b2 = new Building { Name = "Реактор Марс-1", Type = "Промышленный", Condition = 45 };
            var b3 = new Building { Name = "Лаборатория Кюри", Type = "Научный", Condition = 92 };
            context.Buildings.AddRange(b1, b2, b3);

            // 2. Колонисты
            var col1 = new Colonist { FullName = "Игорь Волков", Profession = "Инженер", CyclesLived = 45, Building = b1 };
            var col2 = new Colonist { FullName = "Элина Стрельцова", Profession = "Геолог", CyclesLived = 32, Building = b2 };
            var col3 = new Colonist { FullName = "Марк Астров", Profession = "Ботаник", CyclesLived = 50, Building = b1 };
            var col4 = new Colonist { FullName = "Дария Новак", Profession = "Медик", CyclesLived = 28, Building = b3 };
            context.Colonists.AddRange(col1, col2, col3, col4);

            // 3. Вылазки
            var exp1 = new Expedition { Target = "Поиск водяного льда", Status = "Успешна", Commander = col2 };
            var exp2 = new Expedition { Target = "Разведка каньона", Status = "Провалена", Commander = col1 };
            var exp3 = new Expedition { Target = "Сбор кристаллов", Status = "Успешна", Commander = col3 };
            context.Expeditions.AddRange(exp1, exp2, exp3);

            // 4. Ресурсы
            context.Resources.AddRange(
                new Resource { Name = "Водяной лёд", ResourceType = "Вода", Quantity = 500, Expedition = exp1 },
                new Resource { Name = "Железная руда", ResourceType = "Металл", Quantity = 120, Expedition = exp1 },
                new Resource { Name = "Энергоячейки", ResourceType = "Энергия", Quantity = 30, Expedition = exp2 },
                new Resource { Name = "Красные кристаллы", ResourceType = "Минералы", Quantity = 80, Expedition = exp3 }
            );

            context.SaveChanges();
        }
    }
}