using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace GameOfLife
{
	class AlternativeModel
	{
		const char cellIcon = '@';
		static int maxX = 70;
		static int maxY = 35;
		static int[,] field = new int[maxX, maxY];

		public static void DrawField()
		{



			Console.CursorLeft = 0;
			Console.CursorTop = 7;

			for (int y = 0; y < maxY; y++)
			{
				for (int x = 0; x < maxX; x++)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write(field[x, y] == 1 ? cellIcon : 'o');
				}

				Console.WriteLine();
			}
		}

		public static void Logica()
		{
			Console.Clear();
			Start start = new Start();
			start.StartPr();

			Console.SetWindowSize(maxX + 10, maxY + 10);
			Console.SetWindowPosition(0, 0);

			// Рандомная инициализация позиции
			Random r = new Random((int) DateTime.Now.Ticks);
			for (int x = 0; x < maxX; x++)
			{
				for (int y = 0; y < maxY; y++)
				{
					field[x, y] = r.Next(0, 1 + 1);
				}
			}


			RuleSet ruleSet = new AlternativeConwaysGameOfLife(field, maxX, maxY);
			var suspend = new ManualResetEvent(true);
			Thread waitEnter = new Thread(() =>
			{
				for (int i = 0; i < 5000; i++)
				{
					suspend.WaitOne(Timeout.Infinite);
					DrawField();

					ruleSet.Tick();
				}
			});

			waitEnter.Start();
			bool working = true;
			// Меню взаимодействия с процессом во время запуска игры

			while (true)
			{
				var cki = Console.ReadKey();

				if (cki.Key == ConsoleKey.M)
				{

					waitEnter.Abort();
					Console.Clear();
					start.StartApp();
				}  
				//if (cki.Key == ConsoleKey.S)
				//{
				//	Model model = new Model();
				//	FileStream fs = File.Create("save.dat");
				//	BinaryFormatter bf = new BinaryFormatter();
				//	bf.Serialize(fs, model);
				//	fs.Close();
				//}
				if (cki.Key == ConsoleKey.Escape)
					Environment.Exit(0);
				if (cki.Key == ConsoleKey.Spacebar)
				{
					if (working)
					{
						suspend.Reset(); // приостановка на следующей итерации цикла
					}
					else
					{
						suspend.Set(); // возобновление
					}
					working ^= true;
				}
			}
		}
	}
}