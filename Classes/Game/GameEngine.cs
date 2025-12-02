using Spectre.Console;
public class GameEngine
{
    // When naming private & private readonly fields, 
    // we usually give them names with an underscore in front of the sentence/name 
    // to tell others in the codebase, 
    // that it is a private or private readonly field/property

    /// <summary>
    /// Current game state (either true when running, or false when it is not running)
    /// </summary>
    private bool _isRunningState;
    /// <summary>
    /// This field, creates an object instance of the CommandProcessor class, and handles all commands available to the player
    /// </summary>
    private readonly CommandProcessor? _commands;
    /// <summary>
    /// This field, creates an object instance of the Player class, and handles all logic that has to do with the player.
    /// </summary>
    private readonly Player? _player;

    // the primary GameEngine constructor
    public GameEngine()
    {
        _commands = new CommandProcessor();
        _player = new Player("Hero");
    }

    /// <summary>
    /// This is the game's main loop.
    /// When this method is called externally outside of this GameEngine class, we set 
    /// the current running state to true. This method also uses Spectre Console for rendering and commandline userinput handling
    /// </summary>
    public void StartGame()
    {
        _isRunningState = true;
        // Use Spectre.Console's AnsiConsole class for rendering of markup
        AnsiConsole.MarkupLine("[green]Welcome to the KH MUD![/]");

        while (_isRunningState)
        {
            // step 1: render a visual que for the user to input text in the console.
            AnsiConsole.Markup("[blue]> [/]");
            // step 2: gather user input as text/string
            var userInput = Console.ReadLine();
            // step 3: check for empty or whitespaced text, if we get either as input, 
            // we simply continue the program.
            if (string.IsNullOrWhiteSpace(userInput))
            {
                continue;
            }
            // step 4: we process the input, and "return" the proper command as specified by the input
            // for instance: speak() this will let the player speak to a NPC etc.
            var result = _commands!.ProcessCommand(userInput, _player!);

            // validate the result text/string, if it is null or empty, we "feed" it back to the player.
            if (string.IsNullOrEmpty(result))
            {
                AnsiConsole.MarkupLine(result);
            }

            // step 5: handle exit of program.
            // check for "quit" or a key-combination "ex: cntrl+a, esc key"
            if (userInput.Equals("quit", StringComparison.InvariantCulture) || userInput.Equals("exit", StringComparison.InvariantCulture))
            {
                _isRunningState = false;
            }
            // secondary check, if line 68 does not default out of the loop.
            if (_isRunningState == false)
            {
                break;
            }
        }
    }
}