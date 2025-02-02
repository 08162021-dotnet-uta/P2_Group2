﻿using Microsoft.EntityFrameworkCore;
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
    public class CharacterRepository: IRepository<ViewCharacter, int>
    {
        private readonly P2_NotFightClubContext _dbContext = new P2_NotFightClubContext();
        private readonly IMapper<Character, ViewCharacter> _mapper;

        public CharacterRepository(IMapper<Character, ViewCharacter> mapper)
        {
            _mapper = mapper;
        }
        public async Task<ViewCharacter> Add(ViewCharacter viewCharacter)
        {
            Character character = _mapper.ViewModelToModel(viewCharacter);
            //add to the db
            //_dbContext.Database.ExecuteSqlInterpolated($"Insert into Character(name, baseform, traitId, weaponId, userId) values({character.Name},{character.Baseform},{character.TraitId},{character.WeaponId}, {character.UserId})");
            _dbContext.Add(character);
            //save changes
            _dbContext.SaveChanges();
            //read user back from the db
            Character createdCharacter = await _dbContext.Characters.FromSqlInterpolated($"select * from Character where UserId = {character.UserId} and name = {character.Name} and baseform = {character.Baseform}").FirstOrDefaultAsync();
            
            return _mapper.ModelToViewModel(createdCharacter);
        }

        public async Task<ViewCharacter> Read(int id)
        {
          //this will not work because userId is not an integer
            Character selectedCharacter = await _dbContext.Characters.FromSqlInterpolated($"select * from Character where CharacterId = {id}").FirstOrDefaultAsync();
            
            return _mapper.ModelToViewModel(selectedCharacter);
        }

        public Task<List<ViewCharacter>> Read()
        {
            throw new NotImplementedException();
        }
        
    }
}
