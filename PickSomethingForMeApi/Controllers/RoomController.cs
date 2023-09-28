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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
    {
        var rooms = await _context.Rooms.ToListAsync();
        return Ok(rooms); // OK is status 200 ok
    }

    // GET api/RoomController/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/RoomController
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/RoomController/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/RoomController/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
