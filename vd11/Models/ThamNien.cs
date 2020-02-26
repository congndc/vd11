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
        
        Dưới_Một_Năm =1 ,
        TừHaiNămĐến5Năm =2-5,
        Trên5Năm=5-10
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
        [DisplayName("Thâm Niên Làm Việc")]
        public ThamNienLam ThamNienLam { get; set; }
        [DisplayName("Lương")]
        public decimal? Luong { get; set; }

        public ICollection<CongTy> CongTy { get; set; }
        public ICollection<NhanVien> NhanVien { get; set; }
    }
}
