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
    public class NhanVienRepository:INhanVien
    {
        private NewContext newContext;
        public NhanVienRepository(NewContext _newContext)
        {
            newContext = _newContext;
        }

        public async Task Add(NhanVien nhanvien)
        {
            newContext.Add(nhanvien);
            await newContext.SaveChangesAsync();
        }

        public bool Exit(int ID)
        {
            NhanVien nhanvien = newContext.NhanVien.Find(ID);
            if (nhanvien != null)
                return true;
            else return false;
        }

        public async Task<NhanVien> FindById(int ID)
        {
            NhanVien nhanvien = await newContext.NhanVien.FindAsync(ID);
            return nhanvien;
        }

        public async Task<List<NhanVien>> GetAll()
        {
            return await newContext.NhanVien.ToListAsync();
        }

        public async Task Remove(int ID)
        {
            NhanVien nhanvien = await newContext.NhanVien.FindAsync(ID);
            newContext.Remove(nhanvien);
            await newContext.SaveChangesAsync();
        }

        public async Task Update(NhanVien nhanvien)
        {
            NhanVien newnhanvien = await newContext.NhanVien.FindAsync(nhanvien.NhanVienID);
            newnhanvien = nhanvien;
            await newContext.SaveChangesAsync();
        }
    }
}
