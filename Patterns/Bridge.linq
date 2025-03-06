<Query Kind="Program" />

// Figure + LineStyle/Color is a good fit for this pattern as well

void Main()
{
	var car = new Car();
	car.Drive();
}

class Car
{
	private Engine engine = new GasolineEngine();

	public void Drive()
	{
		engine.Start();
		Run();
		engine.Stop();
	}
	
	private void Run() => Console.WriteLine("Driving.");
}

abstract class Engine
{
	public abstract void Start();
	public abstract void Stop();
}

class GasolineEngine : Engine
{
	public override void Start()
	{
		Console.WriteLine("Start engine.");
	}

	public override void Stop()
	{
		Console.WriteLine("Stop engine.");
	}
}
