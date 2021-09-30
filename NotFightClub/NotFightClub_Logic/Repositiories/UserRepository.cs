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
    public class UserRepository : IRepository<ViewUserInfo, string>
    {
        private readonly P2_NotFightClubContext _dbContext = new P2_NotFightClubContext();
        private readonly IMapper<UserInfo, ViewUserInfo> _mapper;

        public UserRepository(IMapper<UserInfo, ViewUserInfo> mapper)
        {
            _mapper = mapper;
        }

        public async Task<ViewUserInfo> Add(ViewUserInfo viewUser)
        {
            //check if the user already exists if so decline the entry ( implement later)
            //convert to UserInfo with Mapper class
            UserInfo user = _mapper.ViewModelToModel(viewUser);
            //add to the db
            _dbContext.Database.ExecuteSqlInterpolated($"Insert into UserInfo(UserName, PWord, Email, DOB) values({user.UserName},{user.Pword},{user.Email},{user.Dob})");
            //save changes
            _dbContext.SaveChanges();
            //read user back from the db
            UserInfo registeredUser =  await _dbContext.UserInfos.FromSqlInterpolated($"select * from UserInfo where UserName = {user.UserName} and PWord ={user.Pword}").FirstOrDefaultAsync();

           return _mapper.ModelToViewModel(registeredUser);
        }

        public async Task<ViewUserInfo> Read(string email)
        {
          UserInfo loggedUser =  await _dbContext.UserInfos.FromSqlInterpolated($"select * from UserInfo where email = {email}").FirstOrDefaultAsync();
            
                return _mapper.ModelToViewModel(loggedUser);
            
        }

        public Task<ViewUserInfo> Read(int obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ViewUserInfo>> Read()
        {
            throw new NotImplementedException();
        }

        
    }

    
}
