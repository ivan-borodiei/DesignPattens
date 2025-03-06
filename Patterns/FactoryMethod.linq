<Query Kind="Program" />

void Main()
{
	Console.WriteLine("App: Launched with ConcreteCreatorA.");
	var creatorA = new ConcreteCreatorA();
	creatorA.SomeOperation();

	Console.WriteLine("");

	Console.WriteLine("App: Launched with ConcreteCreatorB.");
	var creatorB = new ConcreteCreatorB();
	creatorB.SomeOperation();
}

// Product interface
interface IProduct
{
	void Operation();
}

// Concrete Product A
class ConcreteProductA : IProduct
{
	public void Operation()
	{
		Console.WriteLine("ConcreteProductA operation.");
	}
}

// Concrete Product B
class ConcreteProductB : IProduct
{
	public void Operation()
	{
		Console.WriteLine("ConcreteProductB operation.");
	}
}

// Creator abstract class
abstract class Creator
{
	// Factory Method
	public abstract IProduct FactoryMethod();

	public void SomeOperation()
	{
		// Call the factory method to create a product object.
		IProduct product = FactoryMethod();
		// Use the product.
		product.Operation();
	}
}

// Concrete Creator A
class ConcreteCreatorA : Creator
{
	public override IProduct FactoryMethod()
	{
		return new ConcreteProductA();
	}
}

// Concrete Creator B
class ConcreteCreatorB : Creator
{
	public override IProduct FactoryMethod()
	{
		return new ConcreteProductB();
	}
}