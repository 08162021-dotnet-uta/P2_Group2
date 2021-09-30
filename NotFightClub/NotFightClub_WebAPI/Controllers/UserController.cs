using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotFightClub_Data;
using NotFightClub_Logic.Interfaces;
using NotFightClub_Models.Models;
using NotFightClub_Models.ViewModels;
using Microsoft.Extensions.Logging;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotFightClub_WebAPI.Controllers
{

  [Route("api/[controller]")]
  public class UserController : Controller
  {
    private readonly P2_NotFightClubContext _context;

    private readonly ILogger<UserController> _logger;

    private readonly IRepository<ViewUserInfo, string> _ur;

    public UserController(IRepository<ViewUserInfo, string> ur, P2_NotFightClubContext context, ILogger<UserController> logger)
    {
      _ur = ur;
      _context = context;
      _logger = logger;
    }




    // GET: api/values
    [HttpGet]
    public IEnumerable<UserInfo> Get()
    {
      using (P2_NotFightClubContext entities = new P2_NotFightClubContext())
      {
        return entities.UserInfos.ToList();
      }
    }




    //Get 
    [HttpGet("/[action]/{email}")]
    public async Task<ActionResult<ViewUserInfo>> Login(string email)
    {
      if (!ModelState.IsValid) return BadRequest("Invalid data.");
      var loggedUser = await _ur.Read(email);

      _logger.LogInformation($"{loggedUser.UserName} logged in");

      return Ok(loggedUser);
    }

    // GET api/values/5
    [HttpGet("/users/{id}")]
    public async Task<ActionResult<UserInfo>> GetUserById(Guid id)
    {
      var user = await _context.UserInfos.FindAsync(id);
      return user;
    }



    // POST api/values
    [HttpPost("/[action]")]
    public async Task<ActionResult<ViewUserInfo>> Register([FromBody] ViewUserInfo viewUser)
    {
      if (!ModelState.IsValid) return BadRequest("Invalid data.");
      //call to repository to add user
      //return the result
      //Console.WriteLine(viewUser);
      var registeredUser = await _ur.Add(viewUser);

      _logger.LogInformation($"Registered New User with Username: {viewUser.UserName}");
      return Ok(registeredUser);
    }

    // // PUT api/values/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // 
    // }

    [HttpPut("/edit-profile/{id}")]
    public async Task<IActionResult> PutUsers(Guid id, [FromBody] UserInfo user)
    {
      if (id != user.UserId)
      {
        return BadRequest();
      }
      _logger.LogInformation($"Updating {user.UserName}'s profile");
      _context.Entry(user).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      _logger.LogInformation($"Updated details: Username: {user.UserName} || Email: {user.Email} || DOB: {user.Dob}");

      return NoContent();
    }

    // // DELETE api/values/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
    [HttpDelete("/users/{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
      var user = await _context.UserInfos.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }

      _context.UserInfos.Remove(user);
      await _context.SaveChangesAsync();

      _logger.LogInformation($"{user.UserName} deleted.");

      return NoContent();
    }

    private bool UserExists(Guid id)
    {
      return _context.UserInfos.Any(e => e.UserId == id);
    }
  }
}
