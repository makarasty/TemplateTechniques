using System;

public abstract class Operation
{
	public abstract double Calculate(double a, double b);

	protected virtual void Log(double a, double b, double result, string operation)
	{
		Console.WriteLine($"{a} {operation} {b} = {result}");
	}

	protected virtual void Validate(double a, double b)
	{
		if (b == 0 && this is Divide)
		{
			throw new DivideByZeroException("Ділення на нуль неможливе.");
		}
	}
}

public class Sum : Operation
{
	public override double Calculate(double a, double b)
	{
		double result = a + b;
		Log(a, b, result, "+");
		return result;
	}

	protected override void Log(double a, double b, double result, string operation)
	{
		Console.WriteLine($"Сума: {a} + {b} = {result}");
	}
}

public class Multiply : Operation
{
	public override double Calculate(double a, double b)
	{
		double result = a * b;
		Log(a, b, result, "*");
		return result;
	}
}

public class Divide : Operation
{
	public override double Calculate(double a, double b)
	{
		Validate(a, b);
		double result = a / b;
		Log(a, b, result, "/");
		return result;
	}
}

public class Program
{
	public static void Main(string[] args)
	{
		Operation sumOperation = new Sum();
		Operation multiplyOperation = new Multiply();
		Operation divideOperation = new Divide();

		sumOperation.Calculate(1, 2);
		multiplyOperation.Calculate(3, 4);
		divideOperation.Calculate(10, 2);

		try
		{
			divideOperation.Calculate(10, 0);
		}
		catch (DivideByZeroException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
