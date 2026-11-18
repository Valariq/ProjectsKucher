using System;

class StackUnwindDemo
{
    public static void Run()
    {
        try
        {
            Console.WriteLine("Main: начало");
            ServiceLevel();
            Console.WriteLine("Main: конец");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"[Catch в Main]: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("[Finally в Main]");
        }
    }

    static void ServiceLevel()
    {
        try
        {
            DataLevel();
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"[Catch в ServiceLevel]: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("[Finally в ServiceLevel]");
        }
    }

    static void DataLevel()
    {
        try
        {
            int x = 10, y = 0;
            int z = x / y;
        }
        finally
        {
            Console.WriteLine("[Finally в DataLevel]");
        }
    }
}

public class InsufficientFundsException : Exception
{
    public decimal Balance { get; }
    public decimal TargetAmount { get; }

    public InsufficientFundsException(string msg, decimal balance, decimal amount)
        : base(msg)
    {
        Balance = balance;
        TargetAmount = amount;
    }
}

public class InvalidTransactionException : ArgumentException
{
    public decimal Amount { get; }

    public InvalidTransactionException(string msg, decimal amount)
        : base(msg)
    {
        Amount = amount;
    }
}

public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initial)
    {
        Balance = initial;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidTransactionException("Сумма должна быть больше 0!", amount);

        if (amount > Balance)
            throw new InsufficientFundsException("Недостаточно средств на счете!", Balance, amount);

        Balance -= amount;
    }
}

public class UserValidationException : ArgumentException
{
    public string FieldName { get; }
    public object AttemptedValue { get; }

    public UserValidationException(string message, string fieldName, object value)
        : base(message)
    {
        FieldName = fieldName;
        AttemptedValue = value;
    }
}

public class UserService
{
    public static void ProcessRegistration(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new UserValidationException("Имя не может быть пустым!", nameof(name), name);

        if (age < 18)
            throw new UserValidationException("Возраст должен быть от 18 лет!", nameof(age), age);

        Console.WriteLine($"Пользователь {name} зарегистрирован.");
    }
}

class Program
{
    static void Main()
    {
        StackUnwindDemo.Run();


        BankAccount account = new BankAccount(1000);

        try
        {
            account.Withdraw(1500);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine($"Баланс: {ex.Balance}");
            Console.WriteLine($"Требуемая сумма: {ex.TargetAmount}");
        }
        catch (InvalidTransactionException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine($"Сумма: {ex.Amount}");
        }

        try
        {
            UserService.ProcessRegistration("", 16);
        }
        catch (UserValidationException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine($"Ошибочное поле: {ex.FieldName}");
            Console.WriteLine($"Переданное значение: {ex.AttemptedValue}");
        }
    }
}