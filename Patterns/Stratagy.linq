<Query Kind="Program" />

void Main()
{
	var context = new Context(new SelectionSortAlgorithm());
	var result = context.Sort([4, 2, 6, 2]);
	result.Dump();
}

interface ISortable
{
	int[] Sort(int[] array);
}

class Context
{
	private ISortable sortingAlgorithm;
	public Context(ISortable sortingAlgorithm)
	{
		this.sortingAlgorithm = sortingAlgorithm;
	}

	public int[] Sort(int[] array) => sortingAlgorithm.Sort(array);
}

class SelectionSortAlgorithm : ISortable
{
	public int[] Sort(int[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			for (int j = i + 1; j < array.Length; j++)
			{
				if (array[j].CompareTo(array[i]) < 0)
				{
					int tmp = array[j];
					array[j] = array[i];
					array[i] = tmp;
				}
			}
		}
		
		return array;
	}
}

class BubbleSortAlgorithm : ISortable
{
	public int[] Sort(int[] array)
	{
		int n = array.Length;
		for (int i = 0; i < n - 1; i++)
		{
			for (int j = 0; j < n - i - 1; j++)
			{
				if (array[j] > array[j + 1])
				{					
					int temp = array[j];
					array[j] = array[j + 1];
					array[j + 1] = temp;
				}
			}
		}

		return array;
	}
}