namespace QuanLyDuLieuHinhAnhYTe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BenhNhan")]
    public partial class BenhNhan
    {
        [Key]
        public int MaBenhNhan { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        public string NamSinh { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        [StringLength(500)]
        public string DanToc { get; set; }

        [StringLength(50)]
        public string MaSoBHXH_BHYT { get; set; }

        [StringLength(50)]
        public string DonViCongTac { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        public string VaoVien { get; set; }
        public string RaVien { get; set; }

        [StringLength(100)]
        public string ChanDoanVaoVien { get; set; }

        [StringLength(100)]
        public string ChanDoanRaVien { get; set; }

        [StringLength(100)]
        public string TomTatBenhAn { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        public BenhNhan() { }
        public BenhNhan(int maBenhNhan, string hoTen, string namSinh, string gioiTinh, string danToc, string maSoBHXH_BHYT,string donViCongTac, string diaChi, string vaoVien, string raVien, string chanDoanVaoVien, string chanDoanRaVien, string tomTatBenhAn,string hinhAnh, string ghiChu)
        {
            this.MaBenhNhan = maBenhNhan;
            this.HoTen = hoTen;
            this.NamSinh = namSinh;
            this.GioiTinh = gioiTinh;
            this.DanToc = danToc;
            this.MaSoBHXH_BHYT = maSoBHXH_BHYT;
            this.DonViCongTac = donViCongTac;
            this.DiaChi = diaChi;
            this.VaoVien = vaoVien;
            this.RaVien = raVien;
            this.ChanDoanVaoVien = chanDoanVaoVien;
            this.ChanDoanRaVien = chanDoanRaVien;
            this.TomTatBenhAn = tomTatBenhAn;
            this.HinhAnh = hinhAnh;
            this.GhiChu = ghiChu;
        }

        public List<BenhNhan> BenhNhans { get; set; }

        [StringLength(50)]
        public string totalCount { get; set; }
    }
}