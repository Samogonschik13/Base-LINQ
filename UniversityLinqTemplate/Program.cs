using System;
using UniversityLinqTemplate.Data;
using UniversityLinqTemplate.Queries;

using var db = new UniversityContext();
DbInitializer.Initialize(db);

LinqDemos.DemoFilteringAndSorting(db);
LinqDemos.DemoProjection(db);
LinqDemos.DemoAggregations(db);
LinqDemos.DemoGrouping(db);
LinqDemos.DemoJoinsAndIncludes(db);

Console.WriteLine("\nНажмите любую клавишу для выхода...");
Console.ReadKey();