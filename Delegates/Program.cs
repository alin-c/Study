using System;
using static System.Console; // since C# 6; allows using a member directly

namespace Delegates {
	// 1. declare a delegate type
	delegate void PrintDelegate(int value); // first delegate for one usage scenario
	delegate int MathOp(int a, int b); // second delegate for another usage scenario

	class Program {
		// 2-1. declare methods with matching signatures
		static void PrintLow(int value) {
			WriteLine($"{value} - Low");
		}

		static void PrintHigh(int value) {
			WriteLine($"{value} - High");
		}

		// 2-2. declare methods for the second usage scenario
		static int Add(int x, int y) {
			return x + y;
		}

		static int Subtract(int x, int y) {
			return x - y;
		}

		static void Calculate(int a, int b, MathOp f) {
			WriteLine(f(a, b));
		}

		static void Main() {
			// 3-1. declare a delegate variable
			PrintDelegate printDelegate;

			Random random = new Random();
			int randomValue = random.Next(100);

			// separator
			WriteLine("---- first scenario ----");

			// 4-1. initialize the delegate variable
			printDelegate = randomValue < 50 ? new PrintDelegate(PrintLow) : new PrintDelegate(PrintHigh);

			// 5-1. execute (invoke) the delegate
			printDelegate(randomValue);

			// separator
			WriteLine("---- second scenario ----");

			// 3-2. method calls in second scenario
			// - calls with method parameter
			Calculate(3, 4, Add);
			Calculate(7, 9, Subtract);
			// - call with inline delegate
			Calculate(5, 3, delegate (int a, int b) { return a * a + b * b; });
			// - call with lambda expression
			Calculate(2, 4, (x, y) => x - y);
		}
	}
}
