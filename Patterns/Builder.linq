<Query Kind="Program" />

void Main()
{
	var director = new Director(new GameLaptopBuilder());
	director.ConstructLaptop();
	director.GetLaptop().Dump();

	var director2 = new Director(new OfficeLaptopBuilder());
	director2.ConstructLaptop();
	director2.GetLaptop().Dump();
}

class Laptop
{
	public string Processor { get; set; }
	public string Memory { get; set; }
	public string VideoCard { get; set; }
}

class Director
{
	private LaptopBuilder builder;
	
	public Director(LaptopBuilder builder) => this.builder = builder;	
	
	public void ConstructLaptop()
	{			
		builder			
			.SetProcessor()
			.SetMemory()
			.SetVideoCard();
	}

	public Laptop GetLaptop() => builder.GetLaptop();
}

abstract class LaptopBuilder
{
	protected Laptop laptop;
	
	public LaptopBuilder() => this.laptop = new Laptop();

	public abstract LaptopBuilder SetProcessor();

	public abstract LaptopBuilder SetMemory();

	public abstract LaptopBuilder SetVideoCard();

	public Laptop GetLaptop() => laptop;
}

class GameLaptopBuilder : LaptopBuilder
{
	public override LaptopBuilder SetProcessor()
	{
		laptop.Processor = "Gaming processor";
		return this;
	}

	public override LaptopBuilder SetMemory()
	{
		laptop.Memory = "Gaming memory";
		return this;
	}

	public override LaptopBuilder SetVideoCard()
	{
		laptop.VideoCard = "Gaming video card";
		return this;
	}
}

class OfficeLaptopBuilder : LaptopBuilder
{
	public override LaptopBuilder SetProcessor()
	{
		laptop.Processor = "Office processor";
		return this;
	}

	public override LaptopBuilder SetMemory()
	{
		laptop.Memory = "Office memory";
		return this;
	}

	public override LaptopBuilder SetVideoCard()
	{
		laptop.VideoCard = "Office video card";
		return this;
	}
}