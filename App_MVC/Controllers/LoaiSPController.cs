using App_Data.Models;
using App_Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_MVC.Controllers
{
    public class LoaiSPController : Controller
    {
        Sd18302Net104Context _context;
        ALLRepository<LoaiSP> _LoaiSPRepo;
        DbSet<LoaiSP> _LoaiSPs;
        public LoaiSPController()
        {
            //khởi tạo dbcontext
            _context = new Sd18302Net104Context();
            //khởi tạo repo với 2 tham số dbset và dbcontext
            _LoaiSPs = _context.LoaiSPs;
            _LoaiSPRepo = new ALLRepository<LoaiSP>(_LoaiSPs, _context);
        }

        // GetAll danh sách LoaiSP
        public IActionResult Index()
        {
            var LoaiSPData = _LoaiSPRepo.GetAll();
            return View(LoaiSPData);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LoaiSP LoaiSP)
        {
            LoaiSP.TypeId = Guid.NewGuid();
            _LoaiSPRepo.Create(LoaiSP);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var updateLoaiSP = _LoaiSPRepo.GetByID(id);
            return View(updateLoaiSP);
        }
        public IActionResult EditLoaiSP(LoaiSP LoaiSP)
        {
            _LoaiSPRepo.Update(LoaiSP);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            _LoaiSPRepo.Delete(id);
            return RedirectToAction("Index");
        }
        // Thông tin Details
        public IActionResult Details(Guid id)
        {
            var getLoaiSP = _LoaiSPRepo.GetByID(id);
            return View(getLoaiSP);
        }

	}
}
