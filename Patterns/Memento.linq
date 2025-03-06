<Query Kind="Program" />

void Main()
{
	var controller = new Controller();
		
	controller.F5();
	controller.Play();
	controller.Play();	
	controller.Play();
	controller.F9();
	controller.Play();
	controller.Play();
}

class GameMemento
{
	private readonly int health;
	private readonly int scores;

	public GameMemento(int health, int scores)
	{
		this.health = health;
		this.scores = scores;
	}

	public (int Health, int Score) GetState()
	{
		return (health, scores);
	}
}

// originator
class GameOriginator
{
	private int health = 100;
	private int scores = 0;

	public void Play()
	{
		Console.WriteLine("Health: {0}, Scores: {1}", health, scores);

		health--;
		scores++;
	}

	public GameMemento SaveGame() => new GameMemento(health, scores);

	public void LoadGame(GameMemento gameMemento)
	{
		health = gameMemento.GetState().Health;
		scores = gameMemento.GetState().Score;
	}
}

// careteker
class Controller
{
	private Stack<GameMemento> quickSaves = new Stack<GameMemento>();
	private GameOriginator game = new GameOriginator();

	public void Play() => game.Play();

	public void F5() => quickSaves.Push(game.SaveGame());
	
	public void F9() => game.LoadGame(quickSaves.Peek());
}