using System.Text.Json;

public class VideoGamesDeserializer : IVideoGamesDeserializer
{
	private readonly IUserInteractor _userInteractor;

	public VideoGamesDeserializer(IUserInteractor userInteractor)
	{
		_userInteractor = userInteractor;
	}

	public List<VideoGame> DeserializeFrom(
		string fileName, string fileContents)
	{
		try
		{
			return JsonSerializer.Deserialize<List<VideoGame>>(fileContents);
		}
		catch (JsonException ex)
		{

			_userInteractor.PrintError($"JSON in the {fileName} was not " +
				$"in the valid format. JSON body:");
			_userInteractor.PrintError(fileContents);


			throw new JsonException($"{ex.Message} The file is{fileName}", ex);
		}
	}
}
