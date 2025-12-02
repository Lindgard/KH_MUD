public class CommandProcessor
{
    /// <summary>
    /// a key-value pairing of a set of commands(string) and the command to execute(seperate command class. ex: LookCommand)
    /// </summary>
    private readonly Dictionary<string, ICommand>? _commands;

    public CommandProcessor()
    {
        // we initalize our _commands Dictionary, and give it keys that correspond with our currently created commands
        _commands = new Dictionary<string, ICommand>(StringComparer.OrdinalIgnoreCase)
        {
            {"look", new LookCommand()},
            {"say", new SayCommand()},
            {"quit", new QuitCommand()}
        };
    }

    /// <summary>
    /// Process any command avaiable, defined by user input
    /// </summary>
    /// <param name="input">the user input</param>
    /// <param name="player">the player currently playing</param>
    /// <returns>a string representation of the current command being processed</returns>
    public string ProcessCommand(string input, Player player)
    {
        return "";
    }
}