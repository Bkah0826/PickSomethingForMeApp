using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickSomethingForMeApi.Data;
using PickSomethingForMeApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PickSomethingForMeApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/UserController
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/UserController/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetUser(int id)
    {
        var user = await _context.Rooms.FindAsync(id);

        if (user == null)
        {
            return NotFound(); // creates 404 not found
        }

        return Ok(user);
    }


    // POST api/UserController
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }
    // PUT api/UserController/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/UserController/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
