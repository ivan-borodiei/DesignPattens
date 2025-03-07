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
	public string Name { get; set; } = "My House";
	
	public void Accept(IVisitor visitor)
	{
		visitor.VisitHouse(this);
	}
}

class Office : IBuilding
{
	public string Name { get; set; } = "My Office";
	
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
		Console.WriteLine($"House {house.Name} has been checked by electric!");
	}

	public void VisitOffice(Office office)
	{
		Console.WriteLine($"Office: {office.Name} has been checked by electric!");
	}
}

class PlumperSystemVisitor : IVisitor
{
	public void VisitHouse(House house)
	{
		Console.WriteLine($"House {house.Name} has been checked by plumper!");
	}

	public void VisitOffice(Office office)
	{
		Console.WriteLine($"Office {office.Name} has been checked by plumper!");
	}
}