public class Room
{
    public string? Id { get; }
    public string? RoomName { get; }
    public string? Description { get; }
    public Dictionary<string, string>? ExitsInRoom { get; }

    public Room(string id, string roomName, string description)
    {
        Id = id;
        RoomName = roomName;
        Description = description;
        ExitsInRoom = new Dictionary<string, string>();
    }
}