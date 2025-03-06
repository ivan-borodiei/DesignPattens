<Query Kind="Program">
  <NuGetReference>System.Runtime.Caching</NuGetReference>
  <Namespace>System.Runtime.Caching</Namespace>
</Query>

void Main()
{
	var config = new ConfigProxy();
	var setting = config.GetSetting("SettingName");	
	setting.Dump("Result");

	setting = config.GetSetting("SettingName");
	setting.Dump("Result");

}

interface IConfig
{
	string GetSetting(string name);
}

class Config : IConfig
{
	public string GetSetting(string name)
	{
		Console.WriteLine("Reading real data...");
		return "RealData";
	}
}

class ConfigProxy : IConfig
{
	private CacheItemPolicy cachePolicy => new CacheItemPolicy() { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10) };
	private MemoryCache cache = MemoryCache.Default;

	private IConfig config = new Config();

	public string GetSetting(string name)
	{
		Console.WriteLine("Reading cached data...");
		var value = cache.Get(name) as string;		
		if (value == null)
		{
			value = config.GetSetting(name);
			cache.Add(name, value, cachePolicy);
		}
				
		return  value;
	}	
}
