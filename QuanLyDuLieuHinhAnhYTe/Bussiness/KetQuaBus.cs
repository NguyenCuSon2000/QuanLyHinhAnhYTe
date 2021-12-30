using QuanLyDuLieuHinhAnhYTe.DataAccess;
using QuanLyDuLieuHinhAnhYTe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuLieuHinhAnhYTe.Bussiness
{
    public class KetQuaBus
    {
        KetQuaDAL KetQuaDAL = new KetQuaDAL();

        public KetQua GetKetQua(int pageIndex, int pageSize)
        {
            KetQua spList = KetQuaDAL.GetKetQua(pageIndex, pageSize);
            return spList;
        }

        public KetQua GetKetQuaByMaBN(int maBenhNhan, int pageIndex, int pageSize)
        {
            KetQua spList = KetQuaDAL.GetKetQuaByMaBN(maBenhNhan, pageIndex, pageSize);
            return spList;
        }

        public string ThemKetQua(KetQua b)
        {
            return KetQuaDAL.ThemKetQua(b);
        }
        public string XoaKetQua(string id)
        {
            return KetQuaDAL.XoaKetQua(id);
        }
        public string SuaKetQua(KetQua b)
        {
            return KetQuaDAL.SuaKetQua(b);
        }

        public List<KetQua> TimKiemKetQua(string hoTen)
        {
            return KetQuaDAL.SearchKetQua(hoTen);
        }
    }
}