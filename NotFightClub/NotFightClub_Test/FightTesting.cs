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
    public class FightTesting
    {
        [Fact]
        public void MappertoModel()
        {
            //Arrange
            ViewFight c = new ViewFight();
            c.Winner = 3;
            c.Loser = 2;
            c.Result= "ungoing";
            c.Weather= 0;
            c.Date = new DateTime();
            c.Location = 9;
            c.FightId = 5;
           

            IMapper<Fight, ViewFight> _mapper = new FightMapper();
            //Act
            Fight c1 = _mapper.ViewModelToModel(c);
            //Assert
            Assert.Equal("ungoing", c1.Result);
            Assert.Equal(3, c1.Winner);
            Assert.Equal(2, c1.Loser);
            Assert.Equal(0, c1.Weather);
            Assert.NotNull(c1);
            Assert.IsNotType<ViewFight>(c1);

        }

        [Fact]
        public void MappertoViewModel()
        {
            //Arrange
            Fight c = new Fight();
            c.Winner = 3;
            c.Loser = 2;
            c.Result = "ungoing";
            c.Weather = 0;
            c.Date = new DateTime();
            c.Location = 9;
            c.FightId = 5;


            IMapper<Fight, ViewFight> _mapper = new FightMapper();
            //Act
            ViewFight c1 = _mapper.ModelToViewModel(c);
            //Assert
            Assert.Equal("ungoing", c1.Result);
            Assert.Equal(3, c1.Winner);
            Assert.Equal(2, c1.Loser);
            Assert.Equal(0, c1.Weather);
            Assert.NotNull(c1);
            Assert.IsNotType<Fight>(c1);

        }

        [Fact]
        public void MappertoViewModelList()
        {
            //Arrange
            Weather w = new Weather();
            w.Description = "sunny";
            w.WeatherId = 0;

            Location l = new Location();
            l.Location1 = "hilltop";
            l.LocationId = 0;
            
            Fight c = new Fight();
            c.Winner = 3;
            c.Loser = 2;
            c.Result = "ungoing";
            c.Weather = 0;
            c.WeatherNavigation = w;
            c.FightId = 5;

            Fight c2 = new Fight();
            c2.Winner = 4;
            c2.Loser = 3;
            c2.Result = "tie";
            c2.Location= 0;
            c2.LocationNavigation = l;
            c2.FightId = 6;

            List<Fight> fights = new List<Fight>() { c, c2 };

            IMapper<Fight, ViewFight> _mapper = new FightMapper();
            //Act
            List<ViewFight> c1 = _mapper.ModelToViewModel(fights);
            //Assert
            Assert.Equal("tie", c1[1].Result);
            Assert.Equal(2, c1.Count);
            Assert.Equal("sunny", c1[0].WeatherNavigation);
            Assert.Equal("hilltop", c1[1].LocationNavigation);
            Assert.NotNull(c1);
            Assert.NotEqual(c1[0].FightId, c1[1].FightId);
            Assert.IsNotType<Fight>(c1);

        }
    }
}
