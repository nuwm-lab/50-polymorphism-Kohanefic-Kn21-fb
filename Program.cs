using System;
using System.Text;

class FractionalLinearFunction
{
    protected double a1, a0, b1, b0;

    public virtual void SetCoefficients()
    {
        Console.WriteLine("Введіть коефіцієнти для чисельника (a1, a0):");
        a1 = ReadDouble("a1");
        a0 = ReadDouble("a0");

        Console.WriteLine("Введіть коефіцієнти для знаменника (b1, b0):");
        b1 = ReadDouble("b1");
        b0 = ReadDouble("b0");
    }

    public virtual void DisplayCoefficients()
    {
        Console.WriteLine($"Чисельник: {a1}x + {a0}");
        Console.WriteLine($"Знаменник: {b1}x + {b0}");
    }

    public virtual double Calculate(double x0)
    {
        double numerator = a1 * x0 + a0;
        double denominator = b1 * x0 + b0;
        if (Math.Abs(denominator) < 1e-10)
        {
            throw new DivideByZeroException("Знаменник не може бути рівним нулю.");
        }
        return numerator / denominator;
    }

    protected double ReadDouble(string name)
    {
        while (true)
        {
            Console.WriteLine($"Введіть значення {name}:");
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                return result;
            }
            Console.WriteLine("Некоректне значення, спробуйте ще раз.");
        }
    }
}

class FractionalQuadraticFunction : FractionalLinearFunction
{
    private double a2, b2;

    public override void SetCoefficients()
    {
        Console.WriteLine("Введіть коефіцієнти для чисельника (a2, a1, a0):");
        a2 = ReadDouble("a2");
        a1 = ReadDouble("a1");
        a0 = ReadDouble("a0");

        Console.WriteLine("Введіть коефіцієнти для знаменника (b2, b1, b0):");
        b2 = ReadDouble("b2");
        b1 = ReadDouble("b1");
        b0 = ReadDouble("b0");
    }

    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Чисельник: {a2}x^2 + {a1}x + {a0}");
        Console.WriteLine($"Знаменник: {b2}x^2 + {b1}x + {b0}");
    }

    public override double Calculate(double x0)
    {
        double numerator = a2 * x0 * x0 + a1 * x0 + a0;
        double denominator = b2 * x0 * x0 + b1 * x0 + b0;
        if (Math.Abs(denominator) < 1e-10)
        {
            throw new DivideByZeroException("Знаменник не може бути рівним нулю.");
        }
        return numerator / denominator;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        FractionalLinearFunction baseFunc;

        while (true)
        {
            Console.WriteLine("Введіть '0', щоб працювати з дробово-лінійною функцією, або '1' -- з дробово-квадратичною функцією. Введіть інше значення для виходу:");
            if (!int.TryParse(Console.ReadLine(), out int userSelect))
            {
                Console.WriteLine("Некоректний ввід. Завершення програми.");
                break;
            }

            if (userSelect == 0)
            {
                baseFunc = new FractionalLinearFunction();
            }
            else if (userSelect == 1)
            {
                baseFunc = new FractionalQuadraticFunction();
            }
            else
            {
                Console.WriteLine("Завершення програми.");
                break;
            }

            baseFunc.SetCoefficients();
            baseFunc.DisplayCoefficients();

            Console.WriteLine("Введіть значення x для обчислення функції:");
            if (double.TryParse(Console.ReadLine(), out double x))
            {
                try
                {
                    double result = baseFunc.Calculate(x);
                    Console.WriteLine($"Значення функції в точці x = {x}: {result}");
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Некоректне значення x.");
            }
        }
    }
}
