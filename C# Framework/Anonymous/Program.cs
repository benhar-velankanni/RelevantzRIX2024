using System.Buffers;
using System.Diagnostics.CodeAnalysis;
 
public delegate int MyDelegate1(int a);
public class AnonymousFunction
{
	public static int sum(int a)
	{
		return a + a;
	}
	public int mul(int a)
	{
		return a * a;
	}
	public int div(int a)
	{
		return a / a;
	}

	public static void Operations()
	{
		MyDelegate1 mc = delegate (int x)//ananonymous function
		{
			Console.WriteLine("Output from Anonymous Function: {0}", x);
			return x;
		};

		Console.WriteLine(mc(50));

		mc = new MyDelegate1(sum);

		Console.WriteLine(mc(50));
	}
}
class Program
{
	static void Main(string[] args)
	{
		AnonymousFunction.Operations();
	}
}
 