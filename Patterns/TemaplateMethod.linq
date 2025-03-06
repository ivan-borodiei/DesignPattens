<Query Kind="Program" />

void Main()
{
	var document = new HtmlDocument();
	document.BuildDocument();
}

abstract class Document
{
	public void BuildDocument()
	{
		CreateHeader();
		CreateBody();
		CreateFooter();
	}
	
	private void CreateHeader()
	{
		Console.WriteLine("Header created!");
	}
	
	protected abstract void CreateBody();
	
	protected abstract void CreateFooter();
}

class HtmlDocument : Document
{
	protected override void CreateBody()
	{
		Console.WriteLine("Body created!");
	}

	protected override void CreateFooter()
	{
		Console.WriteLine("Footer created!");
	}
}

