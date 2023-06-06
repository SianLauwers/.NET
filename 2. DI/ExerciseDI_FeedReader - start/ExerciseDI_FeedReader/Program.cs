using ExerciseDI_FeedReader;

internal class Program
{
	private static void Main(string[] args)
	{
		FeedService servicePodcast = new FeedService();
		string feed = servicePodcast.GetFeed();

		Console.WriteLine(feed);
		Console.ReadLine();
	}
}