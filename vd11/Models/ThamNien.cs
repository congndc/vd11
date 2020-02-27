using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace vd11.Models
{

    public enum ThamNienLam
    {
        
        
        Dưới1Năm = 1,
        Từ1NămĐến5Năm =2,
        Trên5Năm=5
    }
    public class ThamNien
    {
        public ThamNien()
        {
            CongTy = new HashSet<CongTy>();
            NhanVien = new HashSet<NhanVien>();
        }
       
       
        [Key]
        public int ThamNienID { get; set; }
        [DisplayName("Thâm Niên Làm")]
        public ThamNienLam ThamNienLam { get; set; }
        [DisplayName("Lương")]
        public decimal? Luong { get; set; }

        public ICollection<CongTy> CongTy { get; set; }
        public ICollection<NhanVien> NhanVien { get; set; }
    }
}
