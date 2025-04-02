using System;

class Day
{
    public int DayNumber { get; }

    public Day(int dayNumber)
    {
        if (dayNumber < 1 || dayNumber > 31)
            throw new ArgumentOutOfRangeException(nameof(dayNumber), "День має бути в діапазоні 1-31");

        DayNumber = dayNumber;
        Console.WriteLine($"[Day] Створено день: {DayNumber}");
    }

    public override string ToString() => $"День: {DayNumber}";

    public override bool Equals(object obj) => obj is Day other && DayNumber == other.DayNumber;

    public override int GetHashCode() => DayNumber.GetHashCode();
}

class Month
{
    public int MonthNumber { get; }

    public Month(int monthNumber)
    {
        if (monthNumber < 1 || monthNumber > 12)
            throw new ArgumentOutOfRangeException(nameof(monthNumber), "Місяць має бути в діапазоні 1-12");

        MonthNumber = monthNumber;
        Console.WriteLine($"[Month] Створено місяць: {MonthNumber}");
    }

    public override string ToString() => $"Місяць: {MonthNumber}";

    public override bool Equals(object obj) => obj is Month other && MonthNumber == other.MonthNumber;

    public override int GetHashCode() => MonthNumber.GetHashCode();
}

class Year
{
    public int YearNumber { get; }

    public Year(int yearNumber)
    {
        if (yearNumber < 1)
            throw new ArgumentOutOfRangeException(nameof(yearNumber), "Рік має бути додатним числом");

        YearNumber = yearNumber;
        Console.WriteLine($"[Year] Створено рік: {YearNumber}");
    }

    public void SetDate(int day, int month)
    {
        Console.WriteLine($"[Year] Встановлення дати: {day}.{month}.{YearNumber}");
    }

    public void PrintDayOfWeek(int day, int month)
    {
        DateTime date = new DateTime(YearNumber, month, day);
        Console.WriteLine($"[Year] День тижня для {day}.{month}.{YearNumber}: {date.DayOfWeek}");
    }

    public void CalculateInterval(DateTime start, DateTime end)
    {
        TimeSpan interval = end - start;
        int days = interval.Days;
        int months = (end.Year - start.Year) * 12 + end.Month - start.Month;

        Console.WriteLine($"[Year] Часовий проміжок: {days} днів, {months} місяців");
    }

    public override string ToString() => $"Рік: {YearNumber}";

    public override bool Equals(object obj) => obj is Year other && YearNumber == other.YearNumber;

    public override int GetHashCode() => YearNumber.GetHashCode();
}

class Program
{
    static void Main()
    {
        Year year = new Year(2025);
        year.SetDate(1, 4);
        year.PrintDayOfWeek(1, 4);

        DateTime startDate = new DateTime(2024, 1, 1);
        DateTime endDate = new DateTime(2025, 4, 1);
        year.CalculateInterval(startDate, endDate);
    }
}
