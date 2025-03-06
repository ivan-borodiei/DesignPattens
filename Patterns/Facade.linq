<Query Kind="Program" />

void Main()
{
	var converter = new VideoConverter();
	converter.ConvertVideo("FilePath");
}

class VideoConverter
{
	private Config config = new Config();
	private VideoProcessor processor = new VideoProcessor();
	private VideoPublisher publisher = new VideoPublisher();

	public void ConvertVideo(string filePath)
	{
		var sampleRate = config.GetSetting("SampleRate");
		var bitRate = config.GetSetting("BitRate");
		var resultExtension = config.GetSetting("ResultExtension");

		var outputFile = processor.Convert(filePath, sampleRate, bitRate, resultExtension);
		publisher.Publish(outputFile);
	}
}

class Config
{
	public string GetSetting(string name)
	{
		Console.WriteLine("Setting {0} has been read", name);
		return "Some value";
	}
}

class VideoProcessor
{
	public string Convert(string filePath, string sampleRate, string bitRate, string outputExtension)
	{
		Console.WriteLine("Video has been converted");
		return "Result file";
	}
}

class VideoPublisher
{
	public void Publish(string filePath)
	{
		Console.WriteLine("Video has been published");		
	}
}