using QuanLyDuLieuHinhAnhYTe.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyDuLieuHinhAnhYTe.DataAccess
{
    public class KetQuaDAL
    {
        DataHelper dc = new DataHelper();

        public List<KetQua> ToList(DataTable dt)
        {
            List<KetQua> l = new List<KetQua>();
            foreach (DataRow dr in dt.Rows)
            {
                KetQua s = new KetQua();
                s.MaKetQua = Convert.ToInt32(dr[0]);
                s.MaBenhNhan = Convert.ToInt32(dr[1]);
                s.LanChup = Convert.ToInt32(dr[2]);
                s.HinhAnh = Convert.ToString(dr[3]);
                s.MucDich = Convert.ToString(dr[4]);
                s.KyThuat = Convert.ToString(dr[5]);
                s.KetLuan = Convert.ToString(dr[6]);
                l.Add(s);
            }
            return l;
        }


        public KetQua GetKetQuaByMaBN(int maBenhNhan, int pageIndex, int pageSize)
        {
            KetQua kq = new KetQua();
            List<KetQua> l = new List<KetQua>();
            SqlDataReader dr = dc.StoreReaders("GetKetQuaByMaBN", maBenhNhan, pageIndex, pageSize);
            while (dr.Read())
            {
                KetQua s = new KetQua(
                    int.Parse(dr[0].ToString()),
                    int.Parse(dr[1].ToString()),
                    dr[2].ToString(),
                    int.Parse(dr[3].ToString()),
                    dr[4].ToString(),
                    dr[5].ToString(),
                    dr[6].ToString(),
                    dr[7].ToString()
                  );
                l.Add(s);
            }
            kq.KetQuas = l;
            dr.NextResult();
            while (dr.Read())
            {
                kq.totalCount = dr["totalCount"].ToString();
            }
            return kq;
        }



        public KetQua GetKetQua(int pageIndex, int pageSize)
        {
            KetQua spl = new KetQua();
            List<KetQua> l = new List<KetQua>();
            SqlDataReader dr = dc.StoreReaders("GetKetQuas", pageIndex, pageSize);
            while (dr.Read())
            {
                KetQua s = new KetQua(
                    int.Parse(dr[0].ToString()),
                    int.Parse(dr[1].ToString()),
                    dr[2].ToString(),
                    int.Parse(dr[3].ToString()),
                    dr[4].ToString(),
                    dr[5].ToString(),
                    dr[6].ToString(),
                    dr[7].ToString()
                  );
                l.Add(s);
            }
            spl.KetQuas = l;
            dr.NextResult();
            while (dr.Read())
            {
                spl.totalCount = dr["totalCount"].ToString();
            }
            return spl;
        }

        public string ThemKetQua(KetQua sp)
        {
            string sql = "INSERT into KetQua values(N'" + sp.MaBenhNhan + "','" + sp.LanChup + "',N'" + sp.HinhAnh + "',N'" + sp.MucDich + "',N'" + sp.KyThuat + "',N'" + sp.KetLuan + "')";

            return dc.ExcuteNonQuery(sql);
        }

        public string XoaKetQua(string id)
        {
            string st = "delete from KetQua where MaKetQua='" + id + "'";
            return dc.ExcuteNonQuery(st);

        }
        public string SuaKetQua(KetQua s)
        {
            string st = "Update KetQua SET MaBenhNhan=N'" + s.MaBenhNhan + "', LanChup='" + s.LanChup + "', HinhAnh=N'" + s.HinhAnh + "',MucDich=N'" + s.MucDich + "', KyThuat=N'" + s.KyThuat + "', KetLuan = N'" + s.KetLuan + "' WHERE MaKetQua='" + s.MaKetQua + "'";
            return dc.ExcuteNonQuery(st);
        }

        public List<KetQua> SearchKetQua(string ketLuan) 
        {
            string st;
            st = "select * from KetQua where KetLuan like N'%" + ketLuan + "%'";
            DataTable dt = dc.GetDataTable(st);
            return ToList(dt);
        }
    }
}