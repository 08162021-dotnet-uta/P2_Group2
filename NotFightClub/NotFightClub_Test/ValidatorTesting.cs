using NotFightClub_Logic;
using NotFightClub_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NotFightClub_Test
{
    public class ValidatorTesting
    {
      

        [Theory]
        [InlineData("string", true)]
        [InlineData("abc", false)]
        [InlineData("password", true)]
        public void ShouldValidatePasswordIsAcceptableLength(string str, bool result)
        {
            //arrange
            IValidator _valid = new Validation();
            //actdat
            var sut = _valid.WordItem(str);
            //assert
            Assert.Equal(result, sut);
        }

        [Fact]
      

        public void ShouldValidateAgeGreaterThan13()
        {
            //arrange
            DateTime d1 = new DateTime(2021, 01, 15);
            DateTime d2 = new DateTime(1996, 12, 15);
            DateTime d3 = new DateTime(2008, 09, 30);

            IValidator _valid = new Validation();
            //act
            var sut = _valid.DateItem(d1);
            var sut2 = _valid.DateItem(d2);
            var sut3 = _valid.DateItem(d3);

            //assert
            Assert.False(sut);
            Assert.True(sut);
            Assert.True(sut);


        }

        //[Fact]
        //public void ShouldValidateUsernameIsUnique()
        //{

        //}


    }
}
