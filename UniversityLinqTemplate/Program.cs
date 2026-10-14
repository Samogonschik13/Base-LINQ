using UniversityLinqTemplate.Data;
using UniversityLinqTemplate.Queries;

Console.Title = "LINQ Template - University Edition";

using (var db = new UniversityContext())
{
    Console.WriteLine("Инициализация базы данных SQLite...");
    DbInitializer.Initialize(db);
    Console.WriteLine("База данных готова к работе!");

    // Запуск примеров LINQ
    LinqDemos.DemoFilteringAndSorting(db);
    LinqDemos.DemoProjection(db);
    LinqDemos.DemoAggregations(db);
    LinqDemos.DemoGrouping(db);
    LinqDemos.DemoJoinsAndIncludes(db);
}

Console.WriteLine("\n\nНажмите любую клавишу для завершения...");
Console.ReadKey();