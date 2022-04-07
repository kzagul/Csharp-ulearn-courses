using System;
using System.Linq;

namespace Clones
{
	class Program
	{
		static void Main(string[] args)
		{
			var n = (Console.ReadLine() ?? "")
				.Split().Select(int.Parse).First(); //если не пустая строка -> по пробелам

			var clones = new CloneVersionSystem();
			for (int i = 0; i < n; i++)
			{
				var query = Console.ReadLine();
				if (query == null) continue;
				var result = clones.Execute(query);
				if (result != null)
					Console.WriteLine(result);
			}
		}
	}
}
