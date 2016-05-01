using System;
using System.Text;

namespace GameOfLife
{
	public static class ConsoleEx
	{
		public static string TryReadLine()
		{
			StringBuilder builder = new StringBuilder();

			for (; ; )
			{
				ConsoleKeyInfo info = Console.ReadKey(true);

				switch (info.Key)
				{
					case ConsoleKey.Enter:
						Console.WriteLine();
						return builder.ToString();
					case ConsoleKey.Escape:
						return null;

					default:
						Console.Write(info.KeyChar);
						builder.Append(info.KeyChar);
						break;
				}
			}
		}
	}
}
