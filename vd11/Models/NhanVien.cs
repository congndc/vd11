using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vd11.Models
{

    public enum ChuVu
    {
        Boss, Staff
    }
    public enum VeHuu
    {
        Rồi, Chưa
    }
    public enum GioiTinh
    {
        Nam, Nữ, ThứBa
    }

    public class NhanVien
    {
        
        public NhanVien()
        {
            CongTy = new HashSet<CongTy>();
        }
        [Key]
        public int NhanVienID { get; set; }
        [Column(TypeName ="ntext")]
        [Required(ErrorMessage = "Lỗi xin hay điền tên")]
        [DisplayName("Tên Nhân Viên")]
        public string TenNhanVien { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Lỗi xin hay điền lại")]
        [DisplayName("Năm Sinh")]
        public DateTime NamSinh { get; set; }
        [Required(ErrorMessage = "Lỗi xin hay điền lại")]
        [DisplayName("Giới Tính")]
        public GioiTinh GioiTinh { get; set; }
        [Required(ErrorMessage = "Lỗi xin hay điền lại")]
        [DisplayName("Chức Vụ")]
        public ChuVu? ChucVu { get; set; }
        [Required(ErrorMessage = "Lỗi xin hay điền lại")]
        [DisplayName("Về Hưu?")]
        public VeHuu VeHuu { get; set; }

        [DisplayName("Thâm Niên Làm")]
        public int ThamNienID { get; set; }
        public ICollection<CongTy> CongTy { get; set; }
        public virtual ThamNien ThamNien { get; set; }

    }
}
