//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace GameOfLife
//{
//	class OpenOldGame
//	{
//		const char cellIcon = '°';
//		static int maxX = 70;
//		static int maxY = 35;
//		static int[,] field = new int[maxX, maxY];

//		public static void DrawField()
//		{
//			Console.CursorLeft = 5;
//			Console.CursorTop = 7;

//			for (int y = 0; y < maxY; y++)
//			{
//				for (int x = 0; x < maxX; x++)
//				{
//					Console.ForegroundColor = ConsoleColor.Green;
//					Console.Write(field[x, y] == 1 ? cellIcon : ' ');
//				}

//				Console.WriteLine();
//			}
//		}

//		public void OpenGame()
//		{
//		Console.SetWindowSize(maxX, maxY + 10);
//		Console.SetWindowPosition(0, 0);

//		// Random initial positions
//		//Random r = new Random((int)DateTime.Now.Ticks);
//		//for (int x = 0; x < maxX; x++)
//		//{
//		//	for (int y = 0; y < maxY; y++)
//		//	{
//		//		field[x, y] = r.Next(0, 1 + 1);
//		//	}
//		//}
//		Model model = new Model();
//		FileStream fs = File.Create("save.dat");
//		BinaryFormatter bf = new BinaryFormatter();
//		bf.Serialize(fs, model);
//		fs.Close();
//		fs = File.OpenRead("test.dat");
//		BinaryFormatter bf = new BinaryFormatter();
//		Test testFile = (Test)bf.Deserialize(fs);
//		fs.Close();

//		// Instantiate the desired concrete RuleSet in this Strategy pattern.
//		RuleSet ruleSet = new ConwaysGameOfLife(field, maxX, maxY);
//		var suspend = new ManualResetEvent(true);
//		Thread waitEnter = new Thread(() =>
//		{
//			for (int i = 0; i < 5000; i++)
//			{
//				suspend.WaitOne(Timeout.Infinite);
//				DrawField();

//				ruleSet.Tick();
//			}
//		});
//		waitEnter.Start();
//		bool working = true;
//		while (true)
//		{
//			var cki = Console.ReadKey();

//			if (cki.Key == ConsoleKey.M)
//			{
//				Start start = new Start();
//				waitEnter.Abort();
//				Console.Clear();
//				start.StartPr();
//				Model.Logica();
//			}  
//		if (cki.Key == ConsoleKey.S)
//			{
//				Model model = new Model();
//				FileStream fs = File.Create("save.dat");
//				BinaryFormatter bf = new BinaryFormatter();
//				bf.Serialize(fs, model);
//				fs.Close();
//			}
//			if (cki.Key == ConsoleKey.Escape)
//				Environment.Exit(0);
//			if (cki.Key == ConsoleKey.Spacebar)
//			{
//				if (working)
//				{
//					suspend.Reset(); // приостановка на следующей итерации цикла
//				}
//				else
//				{
//					suspend.Set(); // возобновление
//				}
//				working ^= true;
//			}
//			//Model model = new Model();
//			//FileStream fs = File.Create("test.dat");
//			//BinaryFormatter bf = new BinaryFormatter();
//			//bf.Serialize(fs, model);
//			//fs.Close();
//		}
//		}
//	}
//}
