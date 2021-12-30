using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using QuanLyDuLieuHinhAnhYTe.Models;

namespace QuanLyDuLieuHinhAnhYTe.DataAccess
{
    public class BenhNhanDAL
    {
        DataHelper dc = new DataHelper();

        public List<BenhNhan> ToList(DataTable dt)
        {
            List<BenhNhan> l = new List<BenhNhan>();
            foreach (DataRow dr in dt.Rows)
            {
                BenhNhan s = new BenhNhan();
                s.MaBenhNhan = Convert.ToInt32(dr[0]);
                s.HoTen = Convert.ToString(dr[1]);
                s.NamSinh = Convert.ToString(dr[2]);
                s.GioiTinh = Convert.ToString(dr[3]);
                s.DanToc = Convert.ToString(dr[4]);
                s.MaSoBHXH_BHYT = Convert.ToString(dr[5]);
                s.DonViCongTac = Convert.ToString(dr[6]);
                s.DiaChi = Convert.ToString(dr[7]);
                s.VaoVien = Convert.ToString(dr[8]);
                s.RaVien = Convert.ToString(dr[9]);
                s.ChanDoanVaoVien = Convert.ToString(dr[10]);
                s.ChanDoanRaVien = Convert.ToString(dr[11]);
                s.TomTatBenhAn = Convert.ToString(dr[12]);
                s.HinhAnh = Convert.ToString(dr[13]);
                s.GhiChu = Convert.ToString(dr[14]);
                l.Add(s);
            }
            return l;
        }

        public List<BenhNhan> GetAllBenhNhan()
        {
            DataTable dt = dc.GetDataTable("Select * from BenhNhan");
            return ToList(dt);
        }
        public BenhNhan GetBenhNhan(int pageIndex, int pageSize)
        {
            BenhNhan spl = new BenhNhan();
            List<BenhNhan> l = new List<BenhNhan>();
            SqlDataReader dr = dc.StoreReaders("GetBenhNhans", pageIndex, pageSize);
            while (dr.Read())
            {
                BenhNhan s = new BenhNhan(
                    int.Parse(dr[0].ToString()), 
                    dr[1].ToString(),
                    dr[2].ToString(), 
                    dr[3].ToString(),
                    dr[4].ToString(), 
                    dr[5].ToString(),
                    dr[6].ToString(),
                    dr[7].ToString(),
                    dr[8].ToString(),
                    dr[9].ToString(),
                    dr[10].ToString(),
                    dr[11].ToString(),
                    dr[12].ToString(),
                    dr[13].ToString(),
                    dr[14].ToString()
                  );
                l.Add(s);
            }
            spl.BenhNhans = l;
            dr.NextResult();
            while (dr.Read())
            {
                spl.totalCount = dr["totalCount"].ToString();
            }
            return spl;
        }


        //public BenhNhan GetChiTietBenhNhan(int id)
        //{
        //    string sqlselect = "select * from BenhNhan where MaBenhNhan ='" + id + "'";
        //    BenhNhan spl = new BenhNhan();
        //    List<BenhNhan> l = new List<BenhNhan>();
        //    SqlDataReader dr = dc.ExecuteReader(sqlselect);
        //    while (dr.Read())
        //    {
        //        BenhNhan s = new BenhNhan(
        //            int.Parse(dr[0].ToString()),
        //            dr[1].ToString(),
        //            dr[2].ToString(),
        //            dr[3].ToString(),
        //            dr[4].ToString(),
        //            dr[5].ToString(),
        //            dr[6].ToString(),
        //            dr[7].ToString(),
        //            dr[8].ToString(),
        //            dr[9].ToString(),
        //            dr[10].ToString(),
        //            dr[11].ToString(),
        //            dr[12].ToString(),
        //            dr[13].ToString(),
        //            dr[14].ToString()
        //          );
        //        l.Add(s);
        //    }
        //    spl.BenhNhans = l;
        //    dr.NextResult();
        //    return spl;
        //}


        public string ThemBenhNhan(BenhNhan sp)
        {
            string sql = "INSERT into BenhNhan values(N'" + sp.HoTen + "','" + sp.NamSinh + "',N'" + sp.GioiTinh + "',N'" + sp.DanToc + "','" + sp.MaSoBHXH_BHYT + "',N'" + sp.DonViCongTac + "',N'" + sp.DiaChi + "',N'" + sp.VaoVien + "',N'" + sp.RaVien + "',N'" + sp.ChanDoanVaoVien + "',N'" + sp.ChanDoanRaVien + "',N'" + sp.TomTatBenhAn + "',N'" + sp.HinhAnh + "',N'" + sp.GhiChu + "')";

            return dc.ExcuteNonQuery(sql);
        }

        public string XoaBenhNhan(string id)
        {
            string st = "delete from BenhNhan where MaBenhNhan='" + id + "'";
            return dc.ExcuteNonQuery(st);

        }
        public string SuaBenhNhan(BenhNhan s)
        {
            string st = "Update BenhNhan SET HoTen=N'" + s.HoTen + "', NamSinh='" + s.NamSinh + "', GioiTinh=N'" + s.GioiTinh + "',DanToc=N'" + s.DanToc + "', MaSoBHXH_BHYT='" + s.MaSoBHXH_BHYT + "', DonViCongTac = N'" +  s.DonViCongTac + "', DiaChi = N'" + s.DiaChi + "', VaoVien = N'" + s.VaoVien + "', RaVien = N'" +   s.RaVien + "', ChanDoanVaoVien = N'" + s.ChanDoanVaoVien + "', ChanDoanRaVien = N'" + s.ChanDoanRaVien + "', TomTatBenhAn = N'" +  s.TomTatBenhAn + "', HinhAnh = '" + s.HinhAnh + "', GhiChu = N'" + s.GhiChu + "' WHERE MaBenhNhan='" + s.MaBenhNhan + "'";
            return dc.ExcuteNonQuery(st);
        }

        public List<BenhNhan> SearchBenhNhan(string hoTen) // Search Admin
        {
            string st;
            st = "select * from BenhNhan where HoTen like N'%" + hoTen + "%'";
            DataTable dt = dc.GetDataTable(st);
            return ToList(dt);
        }
    }
}