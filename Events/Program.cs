using System;

namespace learn {
	// 1. declare a delegate type; system events use EventHandler
	delegate void Handler(int number);

	// 2. the publisher: publishes an event, so that other classes can be notified when the event occurs
	class Incrementer {
		const int limit = 500;

		// 3. creates and publishes an event
		public event Handler CountedABlock;

		// 4. method during whose execution the event will be raised
		public void DoCount() {
			for (int i = 0; i < limit; i++) {
				if (i % 21 == 0 && CountedABlock != null) {
					CountedABlock(i);
				} else {
					Console.WriteLine($"{i,3}");
				}
			}
		}
	}

	// subscriber
	class Blocks {
		public int BlocksCount { get; private set; }

		public Blocks(Incrementer incrementer) {
			BlocksCount = 0;
			// 5. registers to be notified when the event occurs
			// multiple methods can be registered
			// each method must match the delegate signature
			incrementer.CountedABlock += ShowMessage;
			incrementer.CountedABlock += ShowAnotherMessage;
		}

		void ShowMessage(int num) {
			BlocksCount++;
			Console.WriteLine($"{num,3} hit: {num}");
		}

		void ShowAnotherMessage(int num) {
			Console.WriteLine("-------------");
		}
	}

	class Program {
		static void Main() {
			Incrementer incrementer = new Incrementer();
			Blocks blocks = new Blocks(incrementer);

			incrementer.DoCount();
			Console.WriteLine($"-------------\nTotal hits: {blocks.BlocksCount}");
		}
	}

}