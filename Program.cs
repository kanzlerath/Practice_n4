using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class IntArray : IEnumerable<int>
{
    private int[] array;
    public int Length => array.Length;

    public IntArray(int length)
    {
        if (length < 0) throw new ArgumentException("Длина не может быть отрицательной!");
        array = new int[length];
    }

    public int this[int index]
    {
        get => array[index];
        set => array[index] = value;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return ((IEnumerable<int>)array).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return array.GetEnumerator();
    }

    public override string ToString()
    {
        return "[" + String.Join(", ", array) + "]";
    }
}

class Program
{
    static void Main()
    {
        // Задание 1
        Console.WriteLine("Задание 1: LINQ to Object с месяцами");
        string[] months = { "June", "July", "May", "December", "January", "February", "March", "April", "August", "September", "October", "November" };
        int n = 4;
        // Запрос, выбирающий месяцы с длиной строки равной n
        var monthsWithLengthN = months.Where(m => m.Length == n);
        Console.WriteLine("Месяцы длины " + n + ": " + String.Join(", ", monthsWithLengthN));

        // Запрос, возвращающий только летние и зимние месяцы
        var summerWinterMonths = months.Where(m => m == "June" || m == "July" || m == "August" || m == "December" || m == "January" || m == "February");
        Console.WriteLine("Летние и зимние месяцы: " + String.Join(", ", summerWinterMonths));

        // Запрос вывода месяцев в алфавитном порядке
        var monthsAlphabetical = months.OrderBy(m => m);
        Console.WriteLine("Месяцы в алфавитном порядке: " + String.Join(", ", monthsAlphabetical));

        // Запрос, подсчитывающий месяцы, содержащие букву 'u' и длиной имени не менее 4-х
        var monthsWithU = months.Where(m => m.Contains('u') && m.Length >= 4);
        Console.WriteLine("Месяцы с буквой 'u' и длиной не менее 4 символов: " + String.Join(", ", monthsWithU));
        

        // Задание 2 и 3
        Console.WriteLine("\nЗадание 2 и 3: Класс IntArray и List<IntArray>");
        List<IntArray> listOfArrays = new List<IntArray>();
        // Заполнение массивов
        listOfArrays.Add(new IntArray(5) { [0] = 1, [1] = 3, [2] = 5, [3] = 7, [4] = 9 });
        listOfArrays.Add(new IntArray(5) { [0] = 2, [1] = 4, [2] = 6, [3] = 2, [4] = 4 });
        listOfArrays.Add(new IntArray(3) { [0] = 8, [1] = 100, [2] = 6});


        // Задание 4
        Console.WriteLine("\nЗадание 4: LINQ запросы с IntArray");
        var evenArrays = listOfArrays.Where(a => a.Length > 0 && a.All(e => e % 2 == 0));
        Console.WriteLine("Массивы только с четными элементами: " + String.Join(", ", evenArrays.Select(a => a.ToString())));

        var arrayWithMaxSum = listOfArrays.OrderByDescending(a => a.Sum()).FirstOrDefault();
        Console.WriteLine("Массив с наибольшей суммой элементов: " + arrayWithMaxSum);

        var arrayWithMinLength = listOfArrays.OrderBy(a => a.Length).FirstOrDefault();
        Console.WriteLine("Массив с минимальным количеством элементов: " + arrayWithMinLength);

        int value = 5;
        var countWithValue = listOfArrays.Count(a => a.Contains(value));
        Console.WriteLine("Количество массивов, содержащих значение " + value + ": " + countWithValue);

        // Количество равных по количеству элементов массивов
        var groups = listOfArrays.GroupBy(a => a.Length).ToDictionary(g => g.Key, g => g.Count());
        bool hasEqualLengthArrays = groups.Any(g => g.Value > 1);

        if (hasEqualLengthArrays)
        {
            Console.WriteLine("Количество массивов с одинаковым количеством элементов:");
            foreach (var group in groups.Where(g => g.Value > 1))
            {
                Console.WriteLine($"Длина {group.Key}: {group.Value} массив(ов)");
            }
        }
        else
        {
            Console.WriteLine("Количество массивов с одинаковым количеством элементов: 0");
        }


        var orderedByFirstElement = listOfArrays.OrderBy(a => a.Length > 0 ? a[0] : 0).Select(a => a.ToString());
        Console.WriteLine("Упорядоченный массив массивов по первому элементу: " + String.Join(", ", orderedByFirstElement));
    }
}

