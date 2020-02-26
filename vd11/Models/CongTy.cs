using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vd11.Models
{
    public class CongTy
    {
        [Key]
        public int CongTyID { get; set; }
        [Column(TypeName ="ntext")]
        [StringLength(50)]
        [DisplayName("Tên Công Ty")]
        public string TenCongTy { get; set; }
        [DisplayName("Tên Nhân Viên")]
        [Required(ErrorMessage = "Lỗi!!!")]
        public int? NhanVienID { get; set; }
        [Required(ErrorMessage = "Lỗi!!!")]
        [DisplayName("Thâm Niên Làm Việc")]
        public int? ThamNienID { get; set; }

        public virtual ThamNien ThamNien { get; set; }
        public virtual NhanVien NhanVien { get; set; }

    }
}
