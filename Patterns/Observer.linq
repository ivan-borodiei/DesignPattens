<Query Kind="Program" />

void Main()
{
	var magazine = new DriveSport();
	var person1 = new Person("Ivan");
	var person2 = new Person("Oleksandr");

	magazine.Subscribe(person1);
	magazine.Subscribe(person2);
	
	magazine.Notify();
	
	magazine.UnSubscribe(person1);
	magazine.Notify();
}

//Subscriber
interface IObserver
{
	void Notify(string message);
}

class Person : IObserver
{
	private string name;
	public Person(string name)
	{
		this.name = name;
	}
	
	public void Notify(string message)
	{
		Console.WriteLine("{0} can take new number of magazine: {1}", name, message);
	}
}

//Publisher
abstract class Magazine
{
	public string Name { get; set; }

	private IList<Person> persons = new List<Person>();

	public void Subscribe(Person observer)
	{
		persons.Add(observer);
	}

	public void UnSubscribe(Person observer)
	{
		persons.Remove(observer);
	}

	public void Notify()
	{
		foreach (Person p in persons)
			p.Notify(GetType().Name);
	}
}

class DriveSport : Magazine
{
	public DriveSport()
	{
		Name = "DriveSport";
	}
}