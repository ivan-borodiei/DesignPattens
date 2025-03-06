<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
</Query>

void Main()
{
	var game = new Game();

	for (int i = 0; i < 3; i++)
	{
		game.AddGoblin("sky");
	}
		
	UnitImageFactory.GetImages().Dump();
}

class Game
{
	public List<Goblin> Goblins = new List<Goblin>();

	public void AddGoblin(string name) => Goblins.Add(new Goblin(100));
}

class Unit
{
	public string Name { get; protected set; }
	public int Health { get; protected set; }
	public Image Image { get; protected set; }
}

//Flyweight
class Goblin : Unit
{
	public Goblin(int health)
	{
		Name = "Goblin";
		Health = health;
		Image = UnitImageFactory.GetGoblin();
	}
}

//Flyweight factory
class UnitImageFactory
{	
	static string Goblin => "Goblin";

	private static Dictionary<string, Image> images = new Dictionary<string, System.Drawing.Image>();

	public static Image GetGoblin()
	{				
		if (!images.ContainsKey(Goblin))
		{
			images.Add(Goblin, Image.FromFile(@"D:\MediaExamples\Image\193H -gif.gif"));
		}

		return images[Goblin];
	}

	public static Dictionary<string, Image> GetImages() => images;
}