<Query Kind="Program" />

void Main()
{
	var factory = new ModernFurnitureFactory();
	var chair = factory.CreateChair();
	var table = factory.CreateTable();

	Console.WriteLine("Chair created: {0}",chair);
	Console.WriteLine("Table created: {0}",table);		
}

interface IFurnitureFactory
{
	IChair CreateChair();
	ITable CreateTable();
}

interface IChair
{
}

interface ITable
{
}


class ModernFurnitureFactory : IFurnitureFactory
{
	public IChair CreateChair() => new ModernChair();

	public ITable CreateTable() => new ModernTable();
}

class ModernChair : IChair
{
	public override string ToString() => "Modern chair";
}

class ModernTable : ITable
{
	public override string ToString() => "Modern table";
}
