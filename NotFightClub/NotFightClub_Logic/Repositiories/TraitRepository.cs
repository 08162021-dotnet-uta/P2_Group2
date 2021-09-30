using Microsoft.EntityFrameworkCore;
using NotFightClub_Data;
using NotFightClub_Logic.Interfaces;
using NotFightClub_Models.Models;
using NotFightClub_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotFightClub_Logic.Repositiories
{
  public class TraitRepository : IRepository<ViewTrait, int>
  {
    private readonly P2_NotFightClubContext _dbContext = new P2_NotFightClubContext();
    private readonly IMapper<Trait, ViewTrait> _mapper;

    public TraitRepository(IMapper<Trait, ViewTrait> mapper)
    {
      _mapper = mapper;
    }


    public async Task<ViewTrait> Add(ViewTrait viewTrait)
    {
      //check if the trait already exists if so decline the entry ( implement later)
      //convert to Trait with Mapper class
      Trait trait = _mapper.ViewModelToModel(viewTrait);
      //add to the db
      _dbContext.Database.ExecuteSqlInterpolated($"Insert into Trait(Description) values({trait.Description})");
      //save changes
      _dbContext.SaveChanges();
      //read trait back from the db
      Trait newTrait = await _dbContext.Traits.FromSqlInterpolated($"select * from Trait where Description = {trait.Description}").FirstOrDefaultAsync();

      return _mapper.ModelToViewModel(newTrait);
    }


        public async Task<ViewTrait> Read(int id)
        {

          Trait trait = await _dbContext.Traits.FromSqlInterpolated($"select * from Trait where TraitId = {id}").FirstOrDefaultAsync();

          return _mapper.ModelToViewModel(trait);
        }   



        public async Task<List<ViewTrait>> Read()
        {

            List<Trait> traits = await _dbContext.Traits.ToListAsync();
            return _mapper.ModelToViewModel(traits);

        }
  }// end of class 
}// end of 