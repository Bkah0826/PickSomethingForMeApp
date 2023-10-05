using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickSomethingForMeApi.Data;
using PickSomethingForMeApi.Models;

namespace PickSomethingForMeApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RoomController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET: api/RoomController
    /// <summary>
    /// Gets A list of all rooms
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
    {
        var rooms = await _context.Rooms.ToListAsync();
        return Ok(rooms); // OK is status 200 ok
    }

    // GET api/RoomController/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRoom(int id)
    {
        var room = await _context.Rooms.FindAsync(id);

        if (room == null)
        {
            return NotFound(); // creates 404 not found
        }

        return Ok(room);
    }

    // POST api/RoomController
    [HttpPost("CreateRoomAndUser")]
    public async Task<ActionResult<RoomAndUserRequest>> CreateRoomAndUser([FromBody] RoomAndUserRequest request)
    {

        // Validate request and process accordingly
        if (request == null)
        {
            return BadRequest("Invalid request. Please provide a valid request body.");
        }
        //Create Room
        var room = new Room
        {
            RoomName = request.RoomName,
            Users = new List<User>(),
            Activities = new List<Activity>()
        };
        //Create User and add room
        var user = new User {
            UserName = request.UserName,
        };

        room.Users.Add(user);
        user.Room = room;

        _context.Rooms.Add(room);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();


        return CreatedAtAction(nameof(GetRoom), new { id = room.Id }, room); //Status 201 Create response 
    }

    // PUT api/RoomController/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(int id, Room room)
    {
        if (id != room.Id)
        {
            return BadRequest();
        }

        _context.Entry(room).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RoomExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent(); // Status 204 nocontent
    }
    // DELETE api/RoomController/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return NotFound();
        }
        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    private bool RoomExists(int id)
    {
        return _context.Rooms.Any(e => e.Id == id);
    }
}
 