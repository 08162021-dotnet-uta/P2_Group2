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
  public class FighterRepository : IRepository<ViewFighter, int>
  {
    private readonly P2_NotFightClubContext _dbContext = new P2_NotFightClubContext();
    private readonly IMapper<Fighter, ViewFighter> _mapper;

    public FighterRepository(IMapper<Fighter, ViewFighter> mapper)
    {
      _mapper = mapper;
    }

    public Task<ViewFighter> Add(ViewFighter obj)
    {
      throw new NotImplementedException();
    }

    public Task<ViewFighter> Read(int obj)
    {
      throw new NotImplementedException();
    }

    public async Task<List<ViewFighter>> Read()
    {
      List<Fighter> fighters = await _dbContext.Fighters.ToListAsync();
      return _mapper.ModelToViewModel(fighters);
    }
  }
}