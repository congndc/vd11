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
    public class ThamNienRepository: IThamNien
    {
        private NewContext newContext;
        public ThamNienRepository(NewContext _newContext)
        {
            newContext = _newContext;
        }

        public async Task Add(ThamNien thamnien)
        {
            newContext.Add(thamnien);
            await newContext.SaveChangesAsync();
        }

        public bool Exit(int ID)
        {
            ThamNien thamnien = newContext.ThamNien.Find(ID);
            if (thamnien != null)
                return true;
            else return false;
        }

        public async Task<ThamNien> FindById(int ID)
        {
            ThamNien thamnien = await newContext.ThamNien.FindAsync(ID);
            return thamnien;
        }

        public async Task<List<ThamNien>> GetAll()
        {
            return await newContext.ThamNien.ToListAsync();
        }

        public async Task Remove(int ID)
        {
            ThamNien thamnien = await newContext.ThamNien.FindAsync(ID);
             newContext.Remove(thamnien);
            await newContext.SaveChangesAsync();
        }

        public async Task Update(ThamNien thamnien)
        {
            ThamNien newthamnien = await newContext.ThamNien.FindAsync(thamnien.ThamNienID);
            newthamnien = thamnien;
            await newContext.SaveChangesAsync();
        }
    }
}
