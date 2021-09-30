using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotFightClub_Logic.Interfaces;
using NotFightClub_Models.ViewModels;
using NotFightClub_Models.Models;

namespace NotFightClub_Logic.Repositiories
{
  public class FighterRepository : IRepository<ViewFighter, int>
  {
    public Task<ViewFighter> Add(ViewFighter obj)
    {
      throw new NotImplementedException();
    }

    public Task<ViewFighter> Read(int obj)
    {
      throw new NotImplementedException();
    }

    public Task<List<ViewFighter>> Read()
    {
      throw new NotImplementedException();
    }
  }
}