using NotFightClub_Logic.Interfaces;
using NotFightClub_Logic.Mappers;
using NotFightClub_Models.Models;
using NotFightClub_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NotFightClub_Test
{
    public class WeaponTesting
    {

        [Fact]
        public void MappertoModel()
        {
            //Arrange
            ViewWeapon c = new ViewWeapon();
            c.Description = "a screw";
            c.WeaponId = 1;

            IMapper<Weapon, ViewWeapon> _mapper = new WeaponMapper();
            //Act
            Weapon c1 = _mapper.ViewModelToModel(c);
            //Assert
            Assert.Contains("Brave", c1.Description);
            Assert.Equal(1, c1.WeaponId);

        }

        [Fact]
        public void MappertoViewModel()
        {
            //Arrange
            Weapon c = new Weapon();
            c.Description = "a screw";
            c.WeaponId = 1;

            IMapper<Weapon, ViewWeapon> _mapper = new WeaponMapper();
            //Act
            ViewWeapon c1 = _mapper.ModelToViewModel(c);
            //Assert
            Assert.Contains("Brave", c1.Description);
            Assert.Equal(1, c1.WeaponId);

        }
    }
}
