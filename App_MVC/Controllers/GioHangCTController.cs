using App_Data.Models;
using App_Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace App_MVC.Controllers
{
    public class GioHangCTController : Controller
    {
        Sd18302Net104Context _context;
        ALLRepository<GioHangCT> _gioHangCTRepo;
        DbSet<GioHangCT> _gioHangCT;
        public GioHangCTController()
        {
            _context = new Sd18302Net104Context();
            //khởi tạo repo với 2 tham số dbset và dbcontext
            _gioHangCT = _context.GioHangCTs;
            _gioHangCTRepo = new ALLRepository<GioHangCT>(_gioHangCT, _context);
        }
        // GET: GioHangCTController
        public ActionResult Index()
        {
            var gioHangCTData = from ghct in _gioHangCT
                                join sp in _context.SanPhams
                                on ghct.ProductId equals sp.ProductId
                                select new GioHangCT
                                {
                                    CartDetailId = ghct.CartDetailId,
                                    CartId = ghct.CartId,
                                    ProductId = ghct.ProductId,
                                    Quantity = ghct.Quantity,
                                    SanPham = sp
                                };
			var loginData = HttpContext.Session.GetString("user");
			if (loginData == null)
			{
				return RedirectToAction("Login","User");
			}
            else
            {
                var data = gioHangCTData.Where(x => x.CartId.ToString() == loginData);
                return View(data);
            }
        }

        // GET: GioHangCTController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // POST: GioHangCTController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GioHangCT gioHangCT)
        {
            //gioHangCT.CartDetailId = Guid.NewGuid();
            //gioHangCT.Quantity = 1;
            //gioHangCT.CartId = (Guid)ViewData["idgh"];
            //gioHangCT.ProductId = (Guid)ViewData["idsp"];
            //_gioHangCTRepo.Create(gioHangCT);
            //return RedirectToAction("SanPhanU", "Sanpham");
            return View();
        }
        // GET: GioHangCTController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GioHangCTController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GioHangCTController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GioHangCTController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
