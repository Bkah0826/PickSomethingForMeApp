namespace PickSomethingForMeApi.Models;

public class Room
{
    public int Id { get; set; }
    public string RoomName { get; set; }
    public List<User> Users { get; set; }
    public List<Activity> Activities { get; set; }
}
