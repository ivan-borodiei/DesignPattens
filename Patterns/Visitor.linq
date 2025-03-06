<Query Kind="Program" />

void Main()
{
	var buildings = new IBuilding[]
	{
		new House(),
		new Office()
	};
	
	foreach (var building in buildings)
	{
		building.Accept(new ElectricitySystemVisitor());
	}	
}

// element
interface IBuilding
{
	void Accept(IVisitor visitor);
}

class House : IBuilding
{
	public void Accept(IVisitor visitor)
	{
		visitor.VisitHouse(this);
	}
}

class Office : IBuilding
{
	public void Accept(IVisitor visitor)
	{
		visitor.VisitOffice(this);
	}
}

//Visitor
interface IVisitor
{
	void VisitHouse(House house);
	void VisitOffice(Office office);			
}

class ElectricitySystemVisitor : IVisitor
{
	public void VisitHouse(House house)
	{
		Console.WriteLine("House has been checked by electric!");
	}

	public void VisitOffice(Office office)
	{
		Console.WriteLine("Office has been checked by electric!");
	}
}

class PlumperSystemVisitor : IVisitor
{
	public void VisitHouse(House house)
	{
		Console.WriteLine("House has been checked by plumper!");
	}

	public void VisitOffice(Office office)
	{
		Console.WriteLine("Office has been checked by plumper!");
	}
}