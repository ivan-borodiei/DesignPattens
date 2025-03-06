<Query Kind="Program" />

void Main()
{
	var instance_1 = Singleton.Instance;
	var instance_2 = Singleton.Instance;
	
	instance_1.Equals(instance_2).Dump();
}

class Singleton
{
	private static Singleton instance;

	public static Singleton Instance => instance ??= new Singleton();
	
	private Singleton()
	{		
	}
}
