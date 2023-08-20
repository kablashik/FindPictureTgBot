using picture_finder_k_bot;

class Program
{
    static void Main(string[] args)
    {
        var token = Environment.GetEnvironmentVariable("FIND_PICT_BOT_TOKEN");
        var bot = new Bot(token);
        bot.CreateCommands();
        bot.StartReceiving();
        Console.ReadLine();
    }
}

public static class CustomBotCommands
{
    public const string START = "/start";
    public const string ABOUT = "/about";
}