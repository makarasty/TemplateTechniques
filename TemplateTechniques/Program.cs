public abstract class Operation
{
	public virtual float Calculate(float a, float b)
	{
		ValidateInputs(a, b);

		float result = DoCalculation(a, b);

		LogOperation(a, b, result);

		return result;
	}

	protected abstract float DoCalculation(float a, float b);

	protected virtual void ValidateInputs(float a, float b) { }

	protected virtual void LogOperation(float a, float b, float result)
	{
		Console.WriteLine($"{a} {GetOperationSymbol()} {b} = {result}");
	}

	protected abstract string GetOperationSymbol();
}

public class Sum : Operation
{
	protected override float DoCalculation(float a, float b) => a + b;

	protected override string GetOperationSymbol() => "+";
}

public class Multiply : Operation
{
	protected override float DoCalculation(float a, float b) => a * b;

	protected override string GetOperationSymbol() => "*";
}

public class Divide : Operation
{
	protected override void ValidateInputs(float a, float b)
	{
		if (b == 0)
		{
			throw new DivideByZeroException("Ділення на нуль не можна");
		}
	}

	protected override float DoCalculation(float a, float b)
	{
		return a / b;
	}

	protected override string GetOperationSymbol() => "/";
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
