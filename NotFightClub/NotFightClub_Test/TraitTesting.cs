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
    public class TraitTesting
    {
        [Fact]
        public void MappertoModel()
        {
            //Arrange
            ViewTrait c = new ViewTrait();
            c.Description = "Brave";
            c.TraitId = 1;

            IMapper<Trait, ViewTrait> _mapper = new TraitMapper();
            //Act
            Trait c1 = _mapper.ViewModelToModel(c);
            //Assert
            Assert.Contains("Brave", c1.Description);
            Assert.Equal(1, c1.TraitId);

        }

        [Fact]
        public void MappertoViewModel()
        {
            //Arrange
            Trait c = new Trait();
            c.Description = "Brave";
            c.TraitId = 1;

            IMapper<Trait, ViewTrait> _mapper = new TraitMapper();
            //Act
            ViewTrait c1 = _mapper.ModelToViewModel(c);
            //Assert
            Assert.Contains("Brave", c1.Description);
            Assert.Equal(1, c1.TraitId);

        }



    }
}
