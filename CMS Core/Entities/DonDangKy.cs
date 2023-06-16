using CMS_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Entities
{
    public class DonDangKy : BaseEntity
    {
        public int PhatTuId { get; set; }
        public PhatTu PhatTu { get; set; }
        public TrangThaiDon TrangThaiDon { get; set; }
        public DateTime NgayGuiDon { get; set; }
        public DateTime NgaySuLy { get; set; }
        public int? NguoiSuLyId { get; set; }
        public int? DaoTrangId { get; set; }
        public DaoTrang? DaoTrang { get; set; }
    }
}
