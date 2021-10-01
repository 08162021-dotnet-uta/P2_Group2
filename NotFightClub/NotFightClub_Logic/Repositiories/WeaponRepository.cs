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
    public class WeaponRepository : IRepository<ViewWeapon, int>
    {
        private readonly P2_NotFightClubContext _dbContext = new P2_NotFightClubContext();
        private readonly IMapper<Weapon, ViewWeapon> _mapper;

        public WeaponRepository(IMapper<Weapon, ViewWeapon> mapper)
        {
            _mapper = mapper;
        }
        public async Task<ViewWeapon> Add(ViewWeapon obj)
        {
            Weapon weapon = _mapper.ViewModelToModel(obj);
            _dbContext.Add(weapon);
            _dbContext.SaveChanges();

            Weapon addedWeapon = await _dbContext.Weapons.FromSqlInterpolated($"Select * from Weapon where description = {weapon.Description}").FirstOrDefaultAsync();
            return _mapper.ModelToViewModel(addedWeapon);
        }

        public async Task<ViewWeapon> Read(int obj)
        {
          Weapon weapon = await _dbContext.Weapons.FromSqlInterpolated($"select * from Weapon where WeaponId = {obj}").FirstOrDefaultAsync();

          return _mapper.ModelToViewModel(weapon);
    }

        public Task<List<ViewWeapon>> Read()
        {
            throw new NotImplementedException();
        }
    }
}
