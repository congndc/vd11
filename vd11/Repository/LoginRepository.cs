using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vd11.Context;
using vd11.Models;
using vd11.Service;

namespace vd11.Repository
{
    public class LoginRepository : ILogin
    {
       

        private NewContext newContext;
        public LoginRepository(NewContext _newContext)
        {
            newContext = _newContext;
        }
        public async Task Insert(User user)
        {
            newContext.User.Add(user);
            await newContext.SaveChangesAsync();

        }
        public bool Login(string Email, string Password)
        {
            var re = newContext.User.Count(c => c.Email == Email && c.Password == Password);
            if (re > 0)
                return true;
            else return false;
        }
        public async Task<User> GetById(string Email)
        {
            return await newContext.User.FindAsync(Email);
        }
    }
}
