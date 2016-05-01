using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
	public class SortOfGame
	{
		
		public static void Select()
		{Start start = new Start();
			var elems = new[]
			{
				new Element("Стандартная игра") {Command = Model.Logica},
				new Element("Альтернативная игра") {Command = AlternativeModel.Logica},
				new Element("Вернуться в главное меню") {Command = start.StartApp},
				new Element("    \nExit\n    ") {Command = ExitCommandHandler}
			};

			Menu menu = new Menu(elems);


			while (true)
			{
				menu.Draw();
				switch (Console.ReadKey(true).Key)
				{
					case ConsoleKey.UpArrow:
						menu.SelectPrev();
						break;
					case ConsoleKey.DownArrow:
						menu.SelectNext();
						break;
					case ConsoleKey.Enter:
						menu.ExecuteSelected();
						break;
					default:
					{
						Console.ReadKey(intercept: true);
						break;
					}
				}
			}
		}

		private static void ExitCommandHandler()
	{
		Environment.Exit(0);
	}

}

	public delegate void CommandHandler();

class Menu
{
	public Element[] Elements { get; set; }
	public int Index { get; set; }

	public Menu(Element[] elems)
	{
		this.Index = 0;
		this.Elements = elems;
		Elements[Index].IsSelected = true;
	}

	public void Draw()
	{
		Console.Clear();
		foreach (var element in Elements)
		{
			element.Print();
		}
	}

	public void SelectNext()
	{
		if (Index == Elements.Length - 1) return;
		Elements[Index].IsSelected = false;
		Elements[++Index].IsSelected = true;
	}

	public void SelectPrev()
	{
		if (Index == 0) return;
		Elements[Index].IsSelected = false;
		Elements[--Index].IsSelected = true;
	}

	public void ExecuteSelected()
	{
		Elements[Index].Execute();
	}

	
}

	public class Element
{
	public string Text { get; set; }
	public ConsoleColor SelectedForeColor { get; set; }
	public ConsoleColor SelectedBackColor { get; set; }
	public bool IsSelected { get; set; }
	public CommandHandler Command;

	public Element(string text)
	{
		this.Text = text;
		this.SelectedForeColor = ConsoleColor.Blue;
		this.SelectedBackColor = ConsoleColor.Red;
		this.IsSelected = false;
	}

	public void Print()
	{
		if (this.IsSelected)
		{
			Console.BackgroundColor = this.SelectedBackColor;
			Console.ForegroundColor = this.SelectedForeColor;
		}
		Console.WriteLine(this.Text);
		Console.ResetColor();
	}

	public void Execute()
	{
		if (Command == null) return;
		Command.Invoke();
	}
}
	}

