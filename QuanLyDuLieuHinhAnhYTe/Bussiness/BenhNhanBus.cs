using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyDuLieuHinhAnhYTe.DataAccess;
using QuanLyDuLieuHinhAnhYTe.Models;

namespace QuanLyDuLieuHinhAnhYTe.Bussiness
{
    public class BenhNhanBus
    {
        BenhNhanDAL benhNhanDAL = new BenhNhanDAL();

        public BenhNhan GetBenhNhan(int pageIndex, int pageSize)
        {
            BenhNhan spList = benhNhanDAL.GetBenhNhan(pageIndex, pageSize);
            return spList;
        }

        public List<BenhNhan> GetAllBenhNhan()
        {
            List<BenhNhan> list = benhNhanDAL.GetAllBenhNhan();
            return list;
        }


        public string ThemBenhNhan(BenhNhan b)
        {
            return benhNhanDAL.ThemBenhNhan(b);
        }
        public string XoaBenhNhan(string id)
        {
            return benhNhanDAL.XoaBenhNhan(id);
        }
        public string SuaBenhNhan(BenhNhan b)
        {
            return benhNhanDAL.SuaBenhNhan(b);
        }

        public List<BenhNhan> TimKiemBenhNhan(string hoTen)
        {
            return benhNhanDAL.SearchBenhNhan(hoTen);
        }
    }
}