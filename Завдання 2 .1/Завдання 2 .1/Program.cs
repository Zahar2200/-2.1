using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        try
        {
            // Створюємо словник із ключами та значеннями
            Dictionary<string, int> data = new Dictionary<string, int>
            {
                {"A", 10}, {"B", 20}, {"C", 10}, {"D", 30}, {"E", 20}, {"F", 40}
            };

            // Знаходимо дублікати значень
            var grouped = data.GroupBy(x => x.Value)
                              .Where(g => g.Count() > 1)
                              .ToDictionary(g => g.Key, g => g.Select(x => x.Key).ToList());

            // Серіалізуємо в JSON
            string json = JsonConvert.SerializeObject(grouped, Formatting.Indented);

            // Отримуємо правильний шлях до файлу в папці з програмою
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "duplicates.json");
            File.WriteAllText(filePath, json);

            Console.WriteLine($"Результат збережено у файлі: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
