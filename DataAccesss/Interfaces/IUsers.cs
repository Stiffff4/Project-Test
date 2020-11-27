using System;
using System.Collections.Generic;
using DataAccesss.Models;

namespace DataAccesss.Interfaces
{
    public interface IUsers
    {
        public void Create(Users user);
        public bool IsUserValid(Users user);
        public List<Users> GetUserList(string username);
        public void Update(Users user);
    }
}