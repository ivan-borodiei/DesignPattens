<Query Kind="Program" />

void Main()
{	
	var car = new Car();
	car.Start();
}

class Car
{
	private IStartEngineSystem startEngineSystem;

	public Car()
	{
		//this.startEngineSystem = new StartEngineWithKeySystem();
		this.startEngineSystem = new StartEngineWithButtonAdapter();
	}
	
	public void Start()
	{
		startEngineSystem.Start();
	}
}

interface IStartEngineSystem
{
	void Start();
}

class StartEngineWithKeySystem : IStartEngineSystem
{
	public void Start()
	{
		Console.WriteLine("Start Engine With Key System");
	}
}

//Adaptee
class StartEngineWithButtonSystem
{
	public void StartSystem()
	{
		Console.WriteLine("Start Engine With Button System");
	}
}

//Adapter
class StartEngineWithButtonAdapter : IStartEngineSystem
{
	private StartEngineWithButtonSystem startEngineSystem;
	
	public StartEngineWithButtonAdapter(): this(new StartEngineWithButtonSystem())	
	{		
	}

	public StartEngineWithButtonAdapter(StartEngineWithButtonSystem startEngineSystem)
	{
		this.startEngineSystem = startEngineSystem;
	}

	public void Start()
	{
		startEngineSystem.StartSystem();
	}
}
