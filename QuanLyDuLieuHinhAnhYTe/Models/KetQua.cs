

namespace QuanLyDuLieuHinhAnhYTe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KetQua")]
    public partial class KetQua
    {
        [Key]
        public int MaKetQua { get; set; }

        public int MaBenhNhan { get; set; }
        public string HoTen { get; set; }

        public int LanChup { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        [StringLength(100)]
        public string MucDich { get; set; }

        [StringLength(100)]
        public string KyThuat { get; set; }
       
        [StringLength(100)]
        public string KetLuan { get; set; }

        public KetQua() { }
        public KetQua(int maKetQua,int maBenhNhan,string hoTen, int lanChup, string hinhAnh, string mucDich, string kyThuat, string ketLuan)
        {
            this.MaKetQua = maKetQua;
            this.MaBenhNhan = maBenhNhan;
            this.HoTen = hoTen;
            this.LanChup = lanChup;
            this.HinhAnh = hinhAnh;
            this.MucDich = mucDich;
            this.KyThuat = kyThuat;
            this.KetLuan = ketLuan;
        }
        public List<KetQua> KetQuas { get; set; }

        [StringLength(50)]
        public string totalCount { get; set; }


    }
}