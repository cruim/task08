using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameOfLife
{
	public class Start
	{
		public void StartPr()
		{
			string s = "Игра Жизни";
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition((Console.WindowWidth - s.Length)/2, Console.CursorTop);
			Console.WriteLine(s);
			Console.WriteLine(new string('☻', 80));
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Для запуска игры нажмите Enter, Для паузы/возобновления игры используйте\n" +
			                  "Spacebar, Для сохранения игры нажмите S, Для возвращения в Меню нажмите M\n" +
			                  "Для выхода из программы нажмите Esq");
		}

		public void StartApp()
		{
			Console.Clear();
			StartPr();
			while (true)
			{
				var cki = Console.ReadKey(intercept: true);
					// не реагирует на ввод символов, не определенных в условных конструкциях
				if (cki.Key == ConsoleKey.Enter)
				{
					SortOfGame.Select();
				}

				if (cki.Key == ConsoleKey.Escape)
					Environment.Exit(0);
			}
		}
	}
}


