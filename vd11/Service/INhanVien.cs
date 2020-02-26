using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vd11.Models;

namespace vd11.Service
{
    public interface INhanVien
    {
        Task Add(NhanVien nhanvien);
        bool Exit(int ID);
        Task Update(NhanVien nhanvien);
        Task Remove(int ID);
        Task<NhanVien> FindById(int ID);
        Task<List<NhanVien>> GetAll();
    }
}
