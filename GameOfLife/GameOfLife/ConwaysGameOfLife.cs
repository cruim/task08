public class ConwaysGameOfLife : RuleSet
{
	public ConwaysGameOfLife(int[,] field, int maxX, int maxY)
		: base(field, maxX, maxY)
	{
	}

	protected override int[,] TickAlgorithm()
	{
		int[,] field2 = new int[_maxX, _maxY];

		// 23/3 - Conway's Game of Life
		// Первые два числа до слеша определяют условия существования клетки на следующей итерации
		// Второе число определяет условия рождения новой клетки 
		for (int y = 0; y < _maxY; y++)
		{
			for (int x = 0; x < _maxX; x++)
			{
				int neighbors = GetNumberOfNeighbors(x, y);
				if (neighbors == 3)
				{
					// рождение
					field2[x, y] = 1;
					continue;
				}

				if (neighbors == 2 || neighbors == 3)
				{
					// продолжает существовать
					field2[x, y] = _field[x, y];
					continue;
				}

				// смерть
				field2[x, y] = 0;
			}
		}

		return field2;
	}
}