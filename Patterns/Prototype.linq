<Query Kind="Program" />

void Main()
{
	var person = new Person()
	{
		Name = "Ivan",
		Age = 40,
		Address = new Address() { City = "Kyiv" }
	};
	person.Dump();

	var clone = (Person)person.Clone();
	clone.Dump();

	person.Address.Equals(clone.Address).Dump();
}

class Person : ICloneable
{
	public string Name { get; set; }
	public int Age { get; set; }
	public Address Address { get; set; }

	public object Clone()
	{
		var clone = (Person)this.MemberwiseClone();		
		clone.Address = Address.CloneAddress();
		return clone;
	}
}

class Address : ICloneable
{
	public string City { get; set; }

	public object Clone() => this.MemberwiseClone();

	public Address CloneAddress() => (Address)Clone();
}
