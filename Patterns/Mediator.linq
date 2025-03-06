<Query Kind="Program" />

//Dispatcher/Brain/TraficRegelator
void Main()
{
	var dispatcher = new Dispatcher();
	
	var plane = new Plane(dispatcher);
	var helicopter = new Helicopter(dispatcher);
	
	dispatcher.Plane = plane;
	dispatcher.Helicopter = helicopter;
	
	plane.SendMessage(Messages.EmergencyLanding);
}

class Messages
{
	public const string Approved = "Approved";
	public const string Rejected = "Rejected";	
	public const string EmergencyLanding = "EmergencyLanding";
	public const string LandingRequest = "LandingRequest";
	public const string TakeOffRequest = "TakeOffRequest";
}

interface IFlightDispatcher
{
	void SendMessage(string message, FlightUnit unit);
}

//mediator
class Dispatcher : IFlightDispatcher
{
	public FlightUnit Plane {get; set;}
	public FlightUnit Helicopter {get; set;}
	
	public void SendMessage(string message, FlightUnit unit)
	{
		switch (unit)
		{
			case Plane p: 
				if (message == Messages.EmergencyLanding)
				{
					Plane.Notify(Messages.Approved);
					Helicopter.Notify(Messages.LandingRequest + " " + Messages.Rejected);
				}
				else
				{
					Plane.Notify(Messages.Approved);
				}
				break;

			case Helicopter p:
				if (message == Messages.EmergencyLanding)
				{
					Helicopter.Notify(Messages.Approved);
					Plane.Notify(Messages.TakeOffRequest + " " + Messages.Rejected);
				}
				else
				{
					Helicopter.Notify(Messages.Approved);
				}
				break;
		}
	}
}

abstract class FlightUnit
{
	private IFlightDispatcher dispatcher;

	public FlightUnit(IFlightDispatcher dispatcher)
	{
		this.dispatcher = dispatcher;
	}

	public void SendMessage(string message)
	{
		Console.WriteLine("{0}: Messge to dispatcher - {1}",this.GetType().Name, message);
		dispatcher.SendMessage(message, this);		
	}

	public void Notify(string message)
	{
		Console.WriteLine("{0}: From dispatcher - {1}",this.GetType().Name, message);
	}
}

class Plane : FlightUnit
{
	public Plane(IFlightDispatcher dispatcher): base(dispatcher)
	{		
	}
}

class Helicopter : FlightUnit
{
	public Helicopter(IFlightDispatcher dispatcher) : base(dispatcher)
	{
	}
}
