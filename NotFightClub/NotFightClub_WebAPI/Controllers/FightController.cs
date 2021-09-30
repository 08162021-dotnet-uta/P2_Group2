using Microsoft.AspNetCore.Mvc;
using NotFightClub_Data;
using NotFightClub_Logic.Interfaces;
using NotFightClub_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotFightClub_WebAPI.Controllers
{
  [Route("api")]
  [ApiController]
  public class FightController : Controller
  {
    private readonly P2_NotFightClubContext _context;


    private readonly IRepository<ViewFight, int> _fr;

    public FightController(IRepository<ViewFight, int> fr, P2_NotFightClubContext context)
    {
      _fr = fr;
      _context = context;
    }

    [HttpGet("/fight/{id}")]
    public async Task<ActionResult<ViewFight>> Get(int id)
    {
      ViewFight fight = await _fr.Read(id);
      return Ok(fight);
    }

    [HttpGet]
    public async Task<ActionResult<List<ViewFight>>> Get()
    {
      List<ViewFight> fights = await _fr.Read();
      return Ok(fights);
    }

    [HttpGet("/[Controller]/[action]")]
    public async Task<ActionResult<List<ViewFight>>> All()
    {
      List<ViewFight> fights = await _fr.Read();
      return Ok(fights);

    }
  }
}
