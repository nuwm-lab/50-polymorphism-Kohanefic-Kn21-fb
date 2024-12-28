using System;
using System.Text;

class FractionalLinearFunction
{
    protected double a1, a0, b1, b0;

    public virtual void SetCoefficients()
    {
        Console.WriteLine("Введіть коефіцієнти для чисельника (a1, a0):");
        a1 = Convert.ToDouble(Console.ReadLine());
        a0 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть коефіцієнти для знаменника (b1, b0):");
        b1 = Convert.ToDouble(Console.ReadLine());
        b0 = Convert.ToDouble(Console.ReadLine());
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
        if (denominator == 0)
        {
            throw new DivideByZeroException("Знаменник не може бути рівним нулю.");
        }
        return numerator / denominator;
    }
}

class FractionalQuadraticFunction : FractionalLinearFunction
{
    private double a2, b2;

    public override void SetCoefficients()
    {
        Console.WriteLine("Введіть коефіцієнти для чисельника (a2, a1, a0):");
        a2 = Convert.ToDouble(Console.ReadLine());
        a1 = Convert.ToDouble(Console.ReadLine());
        a0 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть коефіцієнти для знаменника (b2, b1, b0):");
        b2 = Convert.ToDouble(Console.ReadLine());
        b1 = Convert.ToDouble(Console.ReadLine());
        b0 = Convert.ToDouble(Console.ReadLine());
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
        if (denominator == 0)
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
        int userSelect;
        FractionalLinearFunction baseFunc = new FractionalLinearFunction();

        do
        {
            Console.WriteLine("Введіть '0', щоб працювати з дробово-лінійною функцією, або '1' -- з дробово-квадратичною функцією:");
            userSelect = Convert.ToInt32(Console.ReadLine());

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
                return;
            }

            baseFunc.SetCoefficients();
            baseFunc.DisplayCoefficients();

            Console.WriteLine("Введіть значення x для обчислення функції:");
            double x = Convert.ToDouble(Console.ReadLine());

            try
            {
                double result = baseFunc.Calculate(x);
                Console.WriteLine($"Значення функції в точці x = {x}: {result}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }

        } while (true);
    }
}
