using QuanLyDuLieuHinhAnhYTe.Bussiness;
using QuanLyDuLieuHinhAnhYTe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuLieuHinhAnhYTe.Controllers
{
    public class QuanLyKetQuaController : Controller
    {
        KetQuaBus ketQuaBus = new KetQuaBus();
        // GET: QuanLyKetQua
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetBenhNhan()
        {
            BenhNhanBus benhNhanBus = new BenhNhanBus();
            List<BenhNhan> ll = benhNhanBus.GetAllBenhNhan();
            return Json(ll, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Paging and searching
        /// </summary>
        /// <param name="pageIndex"> current page</param>
        /// <param name="pageSize"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetKetQua(int pageIndex, int pageSize)
        {
            KetQua spl = ketQuaBus.GetKetQua(pageIndex, pageSize);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Upload(string MaKetQua)
        {
            List<string> l = new List<string>();
            string path = Server.MapPath("~/img/KetQua/" + MaKetQua + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFileBase pf = Request.Files[key];
                pf.SaveAs(path + pf.FileName);
                l.Add(pf.FileName);
            }
            return Json(l, JsonRequestBehavior.AllowGet);
        }
 
        [HttpGet]
        public ActionResult Insert()
        {
            return View("Insert");
        }

        [HttpPost]
        public JsonResult Insert(KetQua s)
        {
            string res = ketQuaBus.ThemKetQua(s);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(KetQua b)
        {
            string res = ketQuaBus.SuaKetQua(b);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(string id)
        {
            string st = ketQuaBus.XoaKetQua(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Search(string tensp)
        {
            if (tensp == "")
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<KetQua> lsp = ketQuaBus.TimKiemKetQua(tensp);
                return Json(lsp, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Detail(int maBenhNhan)
        {
            Session.Add("maBenhNhan", maBenhNhan);
            return View();
        }

   
        public JsonResult GetKetQuaByMaBN(int pageIndex, int pageSize)
        {
            if (Session["maBenhNhan"] == null)
            {
                Session.Add("maBenhNhan", 1);
            }
            KetQua kq = ketQuaBus.GetKetQuaByMaBN(Convert.ToInt32(Session["maBenhNhan"].ToString()), pageIndex, pageSize);
            return Json(kq, JsonRequestBehavior.AllowGet);
        }
    }
}