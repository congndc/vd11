using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vd11.Models;

namespace vd11.Service
{
    public interface ICongTy
    {
        Task Add(CongTy congty);
        bool Exit(int ID);

        Task Update(CongTy congty);
        Task Remove(int ID);
        Task<CongTy> FindById(int ID);
        Task<List<CongTy>> GetAll();


    }
}
