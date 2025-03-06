<Query Kind="Program" />

void Main()
{
	var army = new Army();
	var salary = army.GetSalary();
	
	Console.WriteLine("Total army salary: {0}", salary);
}

interface IArmyComponent
{
	int GetSalary();
}

class Army : IArmyComponent
{		
	private List<IArmyComponent> armyUnits = new List<IArmyComponent>()
	{		
		new Commander(100),
		new Brigade(),
		new Brigade()	
	};
	
	public int GetSalary()
	{
		return armyUnits.Sum(b => b.GetSalary());
	}
}

class Brigade : IArmyComponent
{	
	private List<IArmyComponent> armyUnits = new List<IArmyComponent>()
	{
		new Commander(10),
		new Soldier(),
		new Soldier(),
		new Soldier()
	};
	
	public int GetSalary()
	{
		return armyUnits.Sum(b => b.GetSalary());
	}
}

class Commander : IArmyComponent
{	
	private int salary;
	public int GetSalary() => salary;
	public Commander(int salary)
	{
		this.salary = salary;
	}
}

class Soldier : IArmyComponent
{	
	public int GetSalary()
	{
		return 1;
	}
}