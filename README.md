Отлично! Сейчас подготовлю обновленный README.md под вашу тему "Инопланетная колония". Вот полностью переработанная версия:

---

# 📖 README.md

```markdown
# 🪐 Инопланетная колония: LINQ & Entity Framework Core

Учебный проект: система управления данными инопланетной колонии на базе LINQ и Entity Framework Core с SQLite.

## 📋 Описание проекта

Данный проект представляет собой адаптацию шаблона для освоения технологии LINQ в связке с ORM Entity Framework Core и встраиваемой базой данных SQLite. Проект реализует предметную область **"Инопланетная колония"** и демонстрирует работу с 4 связанными сущностями через 5 типов LINQ-запросов.

Проект разработан для локального запуска на ПК: он не требует установки MS SQL Server, создания локальных служб или ручного наката миграций. База данных создается и наполняется автоматически при первом старте.

---

## 🏗 Архитектура и структура проекта

```
ColonyLinq/
│
├── Models/                 # Слой сущностей (Таблицы БД)
│   ├── Building.cs             # Здания колонии (Купола, реакторы, лаборатории)
│   ├── Colonist.cs             # Колонисты (связь со зданием и вылазками)
│   ├── Expedition.cs           # Экспедиции за пределы базы
│   └── Resource.cs             # Добытые ресурсы (связь с экспедицией)
│
├── Data/                   # Слой доступа к данным
│   ├── UniversityContext.cs    # Контекст БД (настройка подключения к SQLite)
│   └── DbInitializer.cs        # Первичная генерация БД и сидирование данными
│
├── Queries/                # Слой бизнес-логики и запросов
│   └── LinqDemos.cs          # Коллекция типовых LINQ-запросов (5 категорий)
│
├── Program.cs              # Точка входа: вызов инициализации и запуск демонстраций
├── .gitignore              # Исключение временных папок (bin, obj, .vs) и файла БД
├── colony.db               # Файл базы данных SQLite (создается автоматически)
└── README.md               # Документация и инструкция
```

---

## 🚀 Быстрый запуск

1. **Склонируйте репозиторий:**
   ```bash
   git clone https://github.com/Samogonschik13/Base-LINQ.git
   ```

2. **Откройте решение в Visual Studio:**
   - Найдите файл `ColonyLinq.slnx` (или `.sln`) и откройте его.

3. **Запустите проект:**
   - Нажмите комбинацию `Ctrl + F5` (Запуск без отладки).

4. **Что произойдет автоматически:**
   - Проверится наличие базы SQLite и создастся файл `colony.db` в папке сборки.
   - База наполнится начальными тестовыми данными (здания, колонисты, экспедиции, ресурсы).
   - Выполнятся 5 категорий LINQ-запросов и выведут результат в консоль.

---

## 📊 Модели данных (Таблицы БД)

### 🏢 Building (Здание)
Представляет собой инфраструктурный объект колонии.
```csharp
public class Building
{
    public int Id { get; set; }
    public string Name { get; set; }        // "Купол Альфа", "Реактор Марс-1"
    public string Type { get; set; }        // Жилой, Промышленный, Научный
    public int Condition { get; set; }      // Износ от 0 до 100%
    
    public List<Colonist> Colonists { get; set; } // Связь: в здании живет много колонистов
}
```

### 👨‍🚀 Colonist (Колонист)
Житель колонии, который работает в здании и участвует в экспедициях.
```csharp
public class Colonist
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Profession { get; set; }  // Инженер, Геолог, Ботаник, Медик
    public int CyclesLived { get; set; }    // Возраст в циклах (аналог лет)
    
    public int BuildingId { get; set; }
    public Building? Building { get; set; } // Связь со зданием
    
    public List<Expedition> Expeditions { get; set; } // Связь с экспедициями
}
```

### 🚀 Expedition (Экспедиция)
Запись о вылазке колонистов за пределы базы.
```csharp
public class Expedition
{
    public int Id { get; set; }
    public string Target { get; set; }      // Цель: "Поиск водяного льда"
    public string Status { get; set; }      // Успешна, Провалена, В процессе
    
    public int CommanderId { get; set; }
    public Colonist? Commander { get; set; } // Связь с командиром
    
    public List<Resource> Resources { get; set; } // Связь с добытыми ресурсами
}
```

### 💎 Resource (Ресурс)
Добытые материалы из экспедиций.
```csharp
public class Resource
{
    public int Id { get; set; }
    public string Name { get; set; }        // "Водяной лёд", "Железная руда"
    public string ResourceType { get; set; } // Вода, Металл, Энергия, Минералы
    public int Quantity { get; set; }       // Количество единиц
    
    public int ExpeditionId { get; set; }
    public Expedition? Expedition { get; set; } // Связь с экспедицией
}
```

---

## 🔍 Примеры LINQ-запросов

### 1. Фильтрация и сортировка (`Where`, `OrderBy`)
Найти все здания с износом больше 50%, отсортированные по убыванию износа:
```csharp
var damagedBuildings = db.Buildings
    .Where(b => b.Condition > 50)
    .OrderByDescending(b => b.Condition)
    .ToList();
```

### 2. Проекция (`Select`)
Вывести карточки колонистов с названием их здания:
```csharp
var colonistCards = db.Colonists
    .Include(c => c.Building)
    .Select(c => new
    {
        ColonistName = c.FullName,
        Profession = c.Profession,
        BuildingName = c.Building?.Name ?? "Без здания"
    })
    .ToList();
```

### 3. Агрегатные функции (`Count`, `Sum`, `Average`)
Посчитать общую статистику по ресурсам:
```csharp
int totalTypes = db.Resources.Count();
int totalQuantity = db.Resources.Sum(r => r.Quantity);
double avgQuantity = db.Resources.Average(r => r.Quantity);
```

### 4. Группировка (`GroupBy`)
Сгруппировать колонистов по профессиям:
```csharp
var professionStats = db.Colonists
    .GroupBy(c => c.Profession)
    .Select(g => new
    {
        Profession = g.Key,
        Count = g.Count()
    })
    .OrderByDescending(g => g.Count)
    .ToList();
```

### 5. Жадная загрузка связей (`Include`, `ThenInclude`)
Загрузить экспедиции с командирами и добытыми ресурсами:
```csharp
var expeditions = db.Expeditions
    .Include(e => e.Commander)
    .Include(e => e.Resources)
    .ToList();
```

---

## Часто возникающие вопросы (FAQ)

* **Где физически создается файл базы данных?**  
  В папке с исполняемым файлом: `bin/Debug/net.../university.db`.
* **Чем открыть базу данных SQLite для проверки?**  
  Используйте бесплатную программу [DB Browser for SQLite](https://sqlitebrowser.org/). В ней можно открыть созданный `.db` файл и увидеть структуру таблиц и сырые строки.
* **Ошибка: `SQLite Error 1: no such table...`**  
  Вы изменили модели, но база осталась старой. Удалите файл `university.db` из папки `bin/Debug/net...` или раскомментируйте `context.Database.EnsureDeleted()` в `DbInitializer.cs`.
```
