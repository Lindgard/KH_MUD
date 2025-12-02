public class QuitCommand : ICommand
{
    public string ExecuteCommand(string argument, Player player)
    {
        return "[yellow]Exiting game...[/]";
    }
}