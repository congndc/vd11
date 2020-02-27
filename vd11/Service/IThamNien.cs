using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vd11.Models;

namespace vd11.Service
{
    public interface IThamNien
    {
        Task Add(ThamNien thamnien);
        bool Exit(int ID);

        Task Update(ThamNien thamnien);
        Task Remove(int ID);
        Task<ThamNien> FindById(int ID);
        Task<List<ThamNien>> GetAll();
    }
}
