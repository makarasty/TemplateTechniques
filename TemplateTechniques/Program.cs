using System;

public abstract class Operation
{
	public abstract double Calculate(double a, double b);

	protected virtual void LogOperation(double a, double b, double result)
	{
		Console.WriteLine($"{a} and {b} result in {result}");
	}

	protected virtual void ValidateArguments(double a, double b)
	{
	}
}

public class Sum : Operation
{
	public override double Calculate(double a, double b)
	{
		double result = a + b;
		LogOperation(a, b, result);
		return result;
	}

	protected override void LogOperation(double a, double b, double result)
	{
		Console.WriteLine($"{a} + {b} = {result}");
	}
}

public class Multiply : Operation
{
	public override double Calculate(double a, double b)
	{
		double result = a * b;
		LogOperation(a, b, result);
		return result;
	}

	protected override void LogOperation(double a, double b, double result)
	{
		Console.WriteLine($"{a} * {b} = {result}");
	}
}

public class Divide : Operation
{
	public override double Calculate(double a, double b)
	{
		ValidateArguments(a, b);
		double result = a / b;
		LogOperation(a, b, result);
		return result;
	}

	protected override void ValidateArguments(double a, double b)
	{
		if (b == 0)
		{
			throw new ArgumentException("На нуль ділити не можна!");
		}
	}

	protected override void LogOperation(double a, double b, double result)
	{
		Console.WriteLine($"{a} / {b} = {result}");
	}
}

class Program
{
	static void Main(string[] args)
	{
		Operation add = new Sum();
		add.Calculate(1, 2);

		Operation multiply = new Multiply();
		multiply.Calculate(3, 4);

		Operation divide = new Divide();
		try
		{
			divide.Calculate(10, 0);
		}
		catch (ArgumentException ex)
		{
			Console.WriteLine(ex.Message);
		}

		divide.Calculate(10, 2);
	}
}
