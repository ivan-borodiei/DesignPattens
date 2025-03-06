<Query Kind="Program" />

void Main()
{
	var requirements = "Web Application";
	var team = new SoftwareTeam();	
	var managerCommand = new ProjectManagerCommand(requirements, team);
	var customer = new Customer();
	customer.Add(managerCommand);
	
	customer.SignContract();
}

interface ICommand
{
	void Execute();
}

//command
class ProjectManagerCommand : ICommand
{
	private SoftwareTeam team;
	private string requirements;
	
	public ProjectManagerCommand(string requirements, SoftwareTeam team)
	{
		this.requirements = requirements;
		this.team = team;
	}
	
	public void Execute()
	{
		team.StartDevelopment(requirements);
	}
}

//Invoker
class Customer
{
	private List<ICommand> managerCommands = new List<ICommand>();

	public void Add(ICommand command) => managerCommands.Add(command);
	
	public void SignContract()
	{		
		managerCommands.ForEach(m => m.Execute());		
	}
}

//Receiver
class SoftwareTeam
{
	public void StartDevelopment(string requirements)
	{
		Console.WriteLine("Team started working on {0}", requirements);
	}
}