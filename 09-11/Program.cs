
using System;

public class Money
{
    public int Rubles { get; private set; }
    public int Kopeks { get; private set; }

    private long TotalKopeks => (long)Rubles * 100 + Kopeks;

    public Money(int rubles, int kopeks)
    {
        Normalize((long)rubles * 100 + kopeks);
    }

    private Money(long total)
    {
        Normalize(total);
    }

    private void Normalize(long total)
    {
        Rubles = (int)(total / 100);
        Kopeks = (int)(total % 100);

        if (Kopeks < 0)
        {
            Rubles--;
            Kopeks += 100;
        }
    }

    public static Money operator +(Money a, Money b)
    {
        return new Money(a.TotalKopeks + b.TotalKopeks);
    }

    public static Money operator -(Money a, Money b)
    {
        return new Money(a.TotalKopeks - b.TotalKopeks);
    }

    public static Money operator +(Money a, int rubles)
    {
        return new Money(a.TotalKopeks + (long)rubles * 100);
    }

    public static bool operator >(Money a, Money b)
    {
        return a.TotalKopeks > b.TotalKopeks;
    }

    public static bool operator <(Money a, Money b)
    {
        return a.TotalKopeks < b.TotalKopeks;
    }

    public static bool operator ==(Money a, Money b)
    {
        if (ReferenceEquals(a, b))
            return true;

        if (a is null || b is null)
            return false;

        return a.TotalKopeks == b.TotalKopeks;
    }

    public static bool operator !=(Money a, Money b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        return obj is Money other && this == other;
    }

    public override int GetHashCode()
    {
        return TotalKopeks.GetHashCode();
    }

    public static bool operator true(Money m)
    {
        return m != null && m.TotalKopeks > 0;
    }

    public static bool operator false(Money m)
    {
        return m == null || m.TotalKopeks <= 0;
    }

    public static bool operator !(Money m)
    {
        return m == null || m.TotalKopeks <= 0;
    }

    public static explicit operator long(Money m)
    {
        return m.TotalKopeks;
    }

    public static implicit operator Money(long total)
    {
        return new Money(total);
    }

    public static explicit operator CurrencyRecord(Money m)
    {
        return new CurrencyRecord
        {
            Code = "RUB",
            Amount = m.Rubles + m.Kopeks / 100m
        };
    }

    public static explicit operator Money(CurrencyRecord cr)
    {
        long total = (long)Math.Round(
            cr.Amount * 100m,
            MidpointRounding.AwayFromZero
        );

        return new Money(total);
    }

    public override string ToString()
    {
        return $"{Rubles} руб. {Kopeks:D2} коп.";
    }
}

public class CurrencyRecord
{
    public string Code { get; set; }
    public decimal Amount { get; set; }
}

public class AccountBalance
{
    private static int counter = 0;

    public int Id { get; }

    public decimal TotalBalance { get; protected set; }

    public AccountBalance(decimal balance)
    {
        Id = ++counter;
        TotalBalance = balance;
    }

    protected AccountBalance(int id, decimal balance)
    {
        Id = id;
        TotalBalance = balance;
    }

    public static AccountBalance operator +(AccountBalance a, decimal amount)
    {
        return new AccountBalance(
            a.Id,
            a.TotalBalance + amount
        );
    }

    public static AccountBalance operator +(AccountBalance a, AccountBalance other)
    {
        return new AccountBalance(
            a.Id,
            a.TotalBalance + other.TotalBalance
        );
    }

    public static AccountBalance operator ++(AccountBalance a)
    {
        return new AccountBalance(
            a.Id,
            a.TotalBalance + 1m
        );
    }

    public override string ToString()
    {
        return $"ID: {Id}, Баланс: {TotalBalance}";
    }
}

public class PremiumAccount : AccountBalance
{
    public PremiumAccount(decimal balance) : base(balance)
    {
    }

    private PremiumAccount(int id, decimal balance) : base(id, balance)
    {
    }

    public static PremiumAccount operator +(PremiumAccount a, decimal amount)
    {
        decimal cashback = amount * 0.05m;

        return new PremiumAccount(
            a.Id,
            a.TotalBalance + amount + cashback
        );
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("========== ЗАДАНИЕ 1 ==========");

        Money m1 = new Money(150, 80);
        Money m2 = new Money(50, 40);

        Money sum = m1 + m2;
        Money difference = m1 - m2;
        Money plusInt = m1 + 100;

        Console.WriteLine($"m1 = {m1}");
        Console.WriteLine($"m2 = {m2}");
        Console.WriteLine($"Сумма: {sum}");
        Console.WriteLine($"Разность: {difference}");
        Console.WriteLine($"Плюс 100 рублей: {plusInt}");

        if (m1 > m2)
            Console.WriteLine("m1 больше m2");

        if (m1 == m2)
            Console.WriteLine("m1 равно m2");

        if (m1 != m2)
            Console.WriteLine("m1 не равно m2");

        if (m1)
            Console.WriteLine("Счет m1 активен");

        if (!difference)
            Console.WriteLine("Баланс отрицательный или равен нулю");

        Console.WriteLine("\n========== ЗАДАНИЕ 2 ==========");

        Money m = 12550L;

        Console.WriteLine($"Money: {m}");

        long allKopeks = (long)m;

        Console.WriteLine($"Все копейки: {allKopeks}");

        CurrencyRecord cr = (CurrencyRecord)m;

        Console.WriteLine($"Валюта: {cr.Code}");
        Console.WriteLine($"Сумма: {cr.Amount}");

        Money fromCr = (Money)cr;

        Console.WriteLine($"Обратно в Money: {fromCr}");

        Console.WriteLine("\n========== ЗАДАНИЕ 3 ==========");

        AccountBalance acc = new AccountBalance(1000m);

        Console.WriteLine($"Начальный Id: {acc.Id}");
        Console.WriteLine($"Начальный баланс: {acc.TotalBalance}");

        for (int i = 0; i < 10000; i++)
        {
            acc += 10m;
        }

        Console.WriteLine($"Итоговый Id: {acc.Id}");
        Console.WriteLine($"Итоговый баланс: {acc.TotalBalance}");

        PremiumAccount prem = new PremiumAccount(500m);

        Console.WriteLine($"\nНачальный баланс Premium: {prem.TotalBalance}");

        prem += 100m;

        Console.WriteLine($"Баланс после пополнения: {prem.TotalBalance}");

        ++acc;

        Console.WriteLine($"Баланс после ++: {acc.TotalBalance}");
    }
}
