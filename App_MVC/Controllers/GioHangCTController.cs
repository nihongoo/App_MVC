using App_Data.Models;
using App_Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var a = _gioHangCTRepo.GetAll();
            return View(a);
        }

        // GET: GioHangCTController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GioHangCTController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GioHangCTController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
