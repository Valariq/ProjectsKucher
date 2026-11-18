
using System;

class Program
{
    static void SafeDivide(int x, int y)
    {
        try
        {
            int result = x / y;
            Console.WriteLine($"Результат {x} / {y} = {result}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Ошибка деления на 0: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Операция деления завершена (блок finally)");
        }
    }

    static void ProcessTransaction(int errorCode, int attempts)
    {
        int x = 1;
        int y = 0;

        try
        {
            int res = x / y;
            Console.WriteLine($"Результат операции: {res}");
        }
        catch (DivideByZeroException) when (attempts == 0)
        {
            Console.WriteLine("Фильтр 1: Попытки исчерпаны (attempts == 0)");
        }
        catch (DivideByZeroException ex) when (errorCode < 0)
        {
            Console.WriteLine($"Фильтр 2: Отрицательный код {errorCode}: {ex.Message}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Общий catch: {ex.Message}");
        }
    }

    static void CalculateSquareTryCatch(string input)
    {
        try
        {
            int val = int.Parse(input);
            Console.WriteLine($"Квадрат числа {val} = {val * val}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Некорректный формат числа");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Число выходит за допустимые пределы int");
        }
    }

    static void CalculateSquareTryParse(string input)
    {
        if (int.TryParse(input, out int val))
        {
            Console.WriteLine($"Квадрат числа {val} = {val * val}");
        }
        else
        {
            Console.WriteLine("Некорректный ввод (без исключения)");
        }
    }

    static void Main(string[] args)
    {


        SafeDivide(10, 2);
        Console.WriteLine();

        SafeDivide(10, 0);
        Console.WriteLine();

        ProcessTransaction(0, 0);
        Console.WriteLine();

        ProcessTransaction(-5, 3);
        Console.WriteLine();


        ProcessTransaction(10, 2);
        Console.WriteLine();


        CalculateSquareTryCatch("abc");
        CalculateSquareTryCatch("15");

        Console.WriteLine();



        CalculateSquareTryParse("abc");
        CalculateSquareTryParse("15");
    }
}
