<Query Kind="Program" />

void Main()
{
	var numbers = new Numbers(2, 4, 6, 2, 3, 5, 6, 1);
			
	foreach (var number in numbers)
	{
		Console.WriteLine(number);	
	}
}

class Numbers : IEnumerable<int>
{
	private int[] numbers;
	public Numbers(params int[] numbers)
	{
		this.numbers = numbers;
	}

	public IEnumerator<int> GetEnumerator()
	{
		return new ReverseOrderNumerator(numbers);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

class ReverseOrderNumerator : IEnumerator<int>
{
	private int[] numbers;
	private int index = -1;
	public int Current
	{
		get
		{
			if (index < 0 || index > (numbers.Count() - 1))
			{
				throw new InvalidOperationException("Enumerator is out of bounds.");
			}

			return numbers[index];
		}
	}

	object IEnumerator.Current => Current;

	public ReverseOrderNumerator(int[] numbers)
	{
		this.numbers = numbers.OrderByDescending(i => i).ToArray();
	}

	public void Dispose()
	{
		Reset();
	}

	public bool MoveNext()
	{
		index++;
		return index < numbers.Length;
	}

	public void Reset()
	{
		index = -1;
	}
}
