using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vd11.Models;

namespace vd11.Service
{
    public interface IUser
    {
        Task Add(User user);
        bool Exit(int ID);
        Task Update(User user);
        Task Remove(int ID);
        Task<User> FindById(int ID);
        Task<List<User>> GetAll();
    }
}
