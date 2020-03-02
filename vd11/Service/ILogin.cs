using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vd11.Models;

namespace vd11.Service
{
    public interface ILogin
    {
        Task Insert(User user);
        bool Login(string Email,string Password);
        Task<User> GetById(string Email);
    }
}
