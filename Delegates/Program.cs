using System;
using static System.Console; // since C# 6; allows using a member directly

namespace Delegates {
	// 1. declare a delegate type
	delegate void PrintDelegate(int value);

	class Program {
		// 2. declare methods with matching signatures
		static void PrintLow(int value) {
			WriteLine($"{value} - Low");
		}

		static void PrintHigh(int value) {
			WriteLine($"{value} - High");
		}

		static void Main() {
			// 3. declare a delegate variable
			PrintDelegate printDelegate;

			Random random = new Random();
			int randomValue = random.Next(100);

			// 4. instantiate the variable
			printDelegate = randomValue < 50 ? new PrintDelegate(PrintLow) : new PrintDelegate(PrintHigh);

			// 5. execute (invoke) the delagate
			printDelegate(randomValue);
		}
	}
}
