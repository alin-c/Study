using System;

namespace Interfaces {
	// 1. declare the interface
	interface IInfo {
		string DisplayMessage();
		void WriteLog(string text);
	}

	interface IInfo2 {
		string DisplayMessage();
	}

	// 2. declare a class that implements the interface
	// - each interface member must be implemented non-statically
	class Program : IInfo, IInfo2 {
		public string DisplayMessage() {
			Console.WriteLine("DisplayMessage() is called");
			return "Done";
		}

		public void WriteLog(string text) {
			Console.WriteLine($"WriteLog() is called; arg is: {text}");
		}

		// explicit interfce member implementation
		string IInfo2.DisplayMessage() {
			Console.WriteLine("IInfo2.DisplayMessage() is called");
			return "Done too well";
		}

		static void Main() {
			Program program = new Program();

			// call the implemented methods
			program.DisplayMessage();
			program.WriteLog("stuff is written");

			// access the interface as an object
			IInfo info = (IInfo)program;
			info.DisplayMessage();
			info.WriteLog("second try");

			// alternative syntax for accessing as object
			IInfo info2 = program as IInfo;
			info2.DisplayMessage();
			info2.WriteLog("third try");

			// call the explicit implementation
			// this is allowed only through a reference for the interface
			IInfo2 info21 = program;
			Console.WriteLine(info21.DisplayMessage());
		}
	}
}
