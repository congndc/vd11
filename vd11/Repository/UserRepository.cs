using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using vd11.Context;
using vd11.Models;
using vd11.Service;

namespace vd11.Repository
{
    public class UserRepository :IUser
    {
        private NewContext newContext;
        public UserRepository(NewContext _newContext)
        {
            newContext = _newContext;
        }

        public async Task Add(User user)
        {
            newContext.User.Add(user);
            await newContext.SaveChangesAsync();
        }

        public bool Exit(int ID)
        {
            User user = newContext.User.Find(ID);
            if (user != null)
                return true;
            else return false;
        }

        public async Task<User> FindById(int ID)
        {
            User user = await newContext.User.FindAsync(ID);
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await newContext.User.ToListAsync();
        }

        public async Task Remove(int ID)
        {
            User user = await newContext.User.FindAsync(ID);
            newContext.Remove(user);
            await newContext.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            User newUser = await newContext.User.FindAsync(user.UserID);
            newUser = user;
            await newContext.SaveChangesAsync();
        }
    }
}
