﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotFightClub_WebAPI.Dtos;
using PusherServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotFightClub_Models.ViewModels;
using NotFightClub_Logic.Interfaces;
using NotFightClub_Data;
using NotFightClub_Models.Models;

namespace NotFightClub_WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TraitController : Controller
  {
    private readonly P2_NotFightClubContext _context;
    private readonly IRepository<ViewTrait, int> _repo;
    private readonly ILogger<UserController> _logger;


    public TraitController(IRepository<ViewTrait, int> repo, P2_NotFightClubContext context, ILogger<UserController> logger)
    {
      _repo = repo;
      _context = context;
      _logger = logger;

    }

    // GET: api/<TraitController>
    [HttpGet]
    public IEnumerable<Trait> Get()
    {
      using (P2_NotFightClubContext entities = new P2_NotFightClubContext())
      {
        return entities.Traits.ToList();
      }
    }

    // GET api/traits/5
    [HttpGet("/Trait/{id}")]
    public async Task<ActionResult<Trait>> GetTraitById(int id)
    {
      //var trait = await _context.Traits.FindAsync(id);
      ViewTrait trait = await _repo.Read(id);
      //return trait;
      return Ok(trait);
    }

    // POST api/<TraitController>
    [HttpPost]
    public async Task<ActionResult<ViewTrait>> Post([FromBody] ViewTrait viewTrait)
    {
      if (!ModelState.IsValid) return BadRequest("Invalid data.");
      //call to repository to add trait
      //return the result
      //Console.WriteLine(viewTrait);
      var newTrait = await _repo.Add(viewTrait);
      _logger.LogInformation($"Trait created: {newTrait.Description}");

      return Ok(newTrait);
    }
  }
}

