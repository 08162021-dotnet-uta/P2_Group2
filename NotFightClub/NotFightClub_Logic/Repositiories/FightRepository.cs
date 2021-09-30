using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotFightClub_Logic.Interfaces;
using NotFightClub_Models.ViewModels;
using NotFightClub_Models.Models;
using NotFightClub_Data;
using Microsoft.EntityFrameworkCore;

namespace NotFightClub_Logic.Repositiories
{
  public class FightRepository : IRepository<ViewFight, int>
  {
    private readonly P2_NotFightClubContext _dbContext = new P2_NotFightClubContext();
    private readonly IMapper<Fight, ViewFight> _mapper;

    public FightRepository(IMapper<Fight, ViewFight> mapper)
    {
      _mapper = mapper;
    }

    public Task<ViewFight> Add(ViewFight obj)
    {
      throw new NotImplementedException();
    }

    public async Task<ViewFight> Read(int obj)
    {
      Fight fight = await Task.Run(() => _dbContext.Fights.Find(obj));

      return _mapper.ModelToViewModel(fight);
    }

    public async Task<List<ViewFight>> Read()
    {

      List<Fight> fights = await _dbContext.Fights.Include("WeatherNavigation").Include("LocationNavigation").Include("LoserNavigation").Include("WinnerNavigation").ToListAsync();

      return _mapper.ModelToViewModel(fights);
    }
  }
}
