using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using QuanLyDuLieuHinhAnhYTe.Models;
using QuanLyDuLieuHinhAnhYTe.Bussiness;

namespace QuanLyDuLieuHinhAnhYTe.Controllers
{
    public class QuanLyBenhNhanController : Controller
    {
        BenhNhanBus benhNhanBus = new BenhNhanBus();
        // GET: QuanLyBenhNhan
        public ActionResult Index()
        {
            return View("Index");
        }

        /// <summary>
        /// Paging and searching
        /// </summary>
        /// <param name="pageIndex"> current page</param>
        /// <param name="pageSize"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetBenhNhan(int pageIndex, int pageSize)
        {
            BenhNhan spl = benhNhanBus.GetBenhNhan(pageIndex, pageSize);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Upload(string MaBenhNhan)
        {
            List<string> l = new List<string>();
            string path = Server.MapPath("~/img/BenhNhan/" + MaBenhNhan + "/");
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
        // GET: QuanLyBenhNhan
        public ActionResult Insert()
        {
            return View("Insert");
        }

        [HttpPost]
        public JsonResult Insert(BenhNhan s)
        {
            string res = benhNhanBus.ThemBenhNhan(s);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(BenhNhan b)
        {
            string res = benhNhanBus.SuaBenhNhan(b);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(string id)
        {
            string st = benhNhanBus.XoaBenhNhan(id);
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
                List<BenhNhan> lsp = benhNhanBus.TimKiemBenhNhan(tensp);
                return Json(lsp, JsonRequestBehavior.AllowGet);
            }
        }
    }
}