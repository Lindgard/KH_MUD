public class LookCommand : ICommand
{
    public string ExecuteCommand(string argument, Player player)
    {
        return "[blue]You look around. It's very quiet and dark..[/]";
    }
}