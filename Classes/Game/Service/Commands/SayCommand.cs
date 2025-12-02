public class SayCommand : ICommand
{
    public string ExecuteCommand(string argument, Player player)
    {
        if (string.IsNullOrWhiteSpace(argument))
        {
            return "[green]What would you like to say?[/]";
        }
        return $"[green]{player.Name}[/] [blue]says:[/] [green]{argument}[/]";
    }
}