
using System;

public class MathOperations
{
    public static double SafeDivide(double a, double b)
    {
        try
        {
            if (b == 0)
                throw new DivideByZeroException("Деление на ноль невозможно.");

            double result = a / b;
            Console.WriteLine($"Результат деления: {result}");
            return result;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
        finally
        {
            Console.WriteLine("Операция деления завершена");
        }
    }
}

public class AccountProcessor
{
    public static void ProcessTransaction(int status, int amount)
    {
        try
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Сумма не может быть отрицательной.");

            if (status < 0)
                throw new Exception("Неверный статус транзакции.");

            Console.WriteLine($"Транзакция успешно обработана. Сумма: {amount}");
        }
        catch (ArgumentOutOfRangeException ex) when (amount < -1000)
        {
            Console.WriteLine("Критически недопустимая сумма!");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка диапазона аргументов: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
        }
    }
}

public class UserRegistration
{
    public static void RegisterUser(string name, int age)
    {
        if (name == null || name.Length < 2)
            throw new ArgumentException("Длина имени меньше 2 символов");

        if (age < 18)
            throw new ArgumentOutOfRangeException(nameof(age), "Возраст должен быть не менее 18 лет.");

        Console.WriteLine($"Пользователь {name} успешно зарегистрирован.");
    }
}

class Program
{
    static void Main(string[] args)
    {

        try
        {
            double res1 = MathOperations.SafeDivide(10, 2);
            double res2 = MathOperations.SafeDivide(5, 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Внешний перехват: {ex.Message}");
        }


        AccountProcessor.ProcessTransaction(1, 500);
        AccountProcessor.ProcessTransaction(1, -500);
        AccountProcessor.ProcessTransaction(1, -1500);
        AccountProcessor.ProcessTransaction(-1, 100);



        try
        {
            try
            {
                UserRegistration.RegisterUser("A", 25);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[Локальный лог]: {ex.Message}");
                throw;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Глобальный лог]: {ex.StackTrace}");
        }

        Console.WriteLine("\nПрограмма завершена.");
    }
}
