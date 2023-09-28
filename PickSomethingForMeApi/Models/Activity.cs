namespace PickSomethingForMeApi.Models;

public class Activity
{
    public int Id { get; set; }
    public string ActivityName { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
}
