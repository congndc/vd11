using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vd11.Context;
using vd11.Models;
using vd11.Service;

namespace vd11.Repository
{
    public class CongTyRepository: ICongTy
    {
        private NewContext newContext;
        public CongTyRepository(NewContext _newContext)
        {
            newContext = _newContext;

        }

        public async Task Add(CongTy congty)
        {
            newContext.Add(congty);
            await newContext.SaveChangesAsync();
        }

        public bool Exit(int ID)
        {
            CongTy congty = newContext.CongTy.Find(ID);
            if (congty != null)
                return true;
            else return false;
        }

        public async Task<CongTy> FindById(int ID)
        {
            CongTy congty = await newContext.CongTy.FindAsync(ID);
            return congty;
        }

        public async Task<List<CongTy>> GetAll()
        {
            return await newContext.CongTy.ToListAsync();
        }

        public async Task Remove(int ID)
        {
            CongTy congty = await newContext.CongTy.FindAsync(ID);
            newContext.Remove(congty);
            await newContext.SaveChangesAsync();
        }

        public async Task Update(CongTy congty)
        {
            CongTy newcongty = await newContext.CongTy.FindAsync(congty.CongTyID);
            newcongty = congty;
            await newContext.SaveChangesAsync();
        }
    }
}
