<Query Kind="Program" />

void Main()
{
	var validationHandler = new ValidationHandler();
	var authorizationHandler = new AuthorizationRequestHandler(validationHandler);
	var authenticationHandler = new AuthenticationRequestHandler(authorizationHandler);

	authenticationHandler.Handle("Admin").Dump();
}

abstract class RequestHandler
{
	protected RequestHandler nextHandler;

	public RequestHandler()
	{
	}

	public RequestHandler(RequestHandler handler)
	{
		this.nextHandler = handler;
	}

	public virtual bool Handle(string name)
	{		
		if (nextHandler == null)
		{
			return true;
		}

		return nextHandler.Handle(name);
	}
}

class AuthenticationRequestHandler : RequestHandler
{
	public AuthenticationRequestHandler() : base() { }

	public AuthenticationRequestHandler(RequestHandler handler) : base(handler)
	{
	}

	public override bool Handle(string name)
	{
		if (name.Contains("Admin") || name.Contains("Manager") || name.Contains("User"))
		{
			Console.WriteLine("Request handler {0} handled request: {1}", GetType(), true);
			return base.Handle(name);
		}

		Console.WriteLine("Request handler {0} handled request: {1}", GetType(), false);
		return false;
	}
}

class AuthorizationRequestHandler : RequestHandler
{
	public AuthorizationRequestHandler() : base() { }

	public AuthorizationRequestHandler(RequestHandler handler) : base(handler)
	{
	}

	public override bool Handle(string name)
	{
		if (name.Contains("Admin") || name.Contains("Manager"))
		{
			Console.WriteLine("Request handler {0} handled request: {1}", GetType(), true);
			return base.Handle(name);
		}

		Console.WriteLine("Request handler {0} handled request: {1}", GetType(), false);
		return false;
	}
}

class ValidationHandler : RequestHandler
{
	public ValidationHandler() : base() { }

	public ValidationHandler(RequestHandler handler) : base(handler)
	{
	}

	public override bool Handle(string name)
	{
		if (name == "Admin")
		{
			Console.WriteLine("Request handler {0} handled request: {1}", GetType(), true);
			return base.Handle(name);
		}

		Console.WriteLine("Request handler {0} handled request: {1}", GetType(), false);
		return false;
	}
}