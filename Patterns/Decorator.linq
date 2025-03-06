<Query Kind="Program" />

// Config might better fit for chain of responsibility pattern, but send message via different senders (sms, email, slack) is better choise for Decorator pattern.
// - Decorator should not stop processing
// - Chain of responsibility can stop a chain

void Main()
{
	var config = new Config("Environment, Database");
	var setting = config.GetSetting("ASPNETCORE_ENVIRONMENT");
	
	setting.Dump();		
}

interface IConfigReader
{
	string GetSetting(string name);
}

//component
class Config: IConfigReader
{
	private IConfigReader configReader;
	
	public Config(string configNames)
	{		
		InitConfig(configNames);
	}
	
	private void InitConfig(string configNames)
	{
		var configs = configNames
			.Split(',', options: StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
			.Reverse();
		
		foreach (var config in configs)
		{
			switch (config)	
			{
				case "Environment": 
					configReader = new EnvironmentConfigReader(configReader);
					break;
				case "Database":
					configReader = new DatabaseConfigReader(configReader);
					break;
				default:
					throw new InvalidOperationException($"Unknown config: {config}");
			}
		}
	}
	
	public string GetSetting(string name) => configReader.GetSetting(name);	
}

//decorator
abstract class ConfigReader: IConfigReader
{
	private IConfigReader fallbackConfigReader;
	
	public ConfigReader(IConfigReader reader)
	{
		fallbackConfigReader = reader;	
	}

	protected abstract string ReadSetting(string name);	
	
	public string GetSetting(string name)
	{
		var settingValue = ReadSetting(name);

		Console.WriteLine("Source: {0}, Setting name: {1} value: {2}", GetType().Name, name, settingValue);
		
		if (settingValue == null)
		{						
			return fallbackConfigReader?.GetSetting(name);
		}
		 
		return settingValue;
	}	
}

//concrete decorator
class EnvironmentConfigReader : ConfigReader
{
	public EnvironmentConfigReader(IConfigReader reader): base(reader)
	{		
	}

	protected override string ReadSetting(string name) => Environment.GetEnvironmentVariable(name);	
}

//concrete decorator
class DatabaseConfigReader : ConfigReader
{
	public DatabaseConfigReader(IConfigReader reader) : base(reader)
	{
	}

	protected override string ReadSetting(string name) => ReadFromDatabase(name);	
	
	private string ReadFromDatabase(string name) => "Database value";
}