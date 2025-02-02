﻿using Microsoft.AspNetCore.Mvc;
using NotFightClub_Logic.Interfaces;
using NotFightClub_Models.Models;
using NotFightClub_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotFightClub_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IRepository<ViewWeapon, int> _repo;

        public WeaponController(IRepository<ViewWeapon, int> repo)
        {
            _repo = repo;

        }
    // GET: api/<WeaponController>
    //[HttpGet]
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    //GET api/<WeaponController>/5
    [HttpGet("/Weapon/{id}")]
    public async Task<ActionResult<Weapon>> Get(int id)
    {
      ViewWeapon weapon = await _repo.Read(id);

      return Ok(weapon);
    }

    // POST api/<WeaponController>
    [HttpPost]
        public async Task<ActionResult<ViewWeapon>> Post([FromBody] ViewWeapon weapon)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid data.");
            ViewWeapon addedWeapon = await _repo.Add(weapon);
            return Ok(addedWeapon);
        }

        // PUT api/<WeaponController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<WeaponController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
