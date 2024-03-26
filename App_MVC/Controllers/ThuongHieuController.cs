using App_Data.Models;
using App_Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace App_MVC.Controllers
{
    public class ThuongHieuController : Controller
    {
        Sd18302Net104Context _context;
        ALLRepository<ThuongHieu> _ThuongHieuRepo;
        DbSet<ThuongHieu> _ThuongHieus;
        public ThuongHieuController()
        {
            //khởi tạo dbcontext
            _context = new Sd18302Net104Context();
            //khởi tạo repo với 2 tham số dbset và dbcontext
            _ThuongHieus = _context.ThuongHieus;
            _ThuongHieuRepo = new ALLRepository<ThuongHieu>(_ThuongHieus, _context);
        }

        // GetAll danh sách ThuongHieu
        public IActionResult Index()
        {
            var ThuongHieuData = _ThuongHieuRepo.GetAll();
            return View(ThuongHieuData);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ThuongHieu ThuongHieu)
        {
            ThuongHieu.BrandId = Guid.NewGuid();
            _ThuongHieuRepo.Create(ThuongHieu);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var updateThuongHieu = _ThuongHieuRepo.GetByID(id);
            return View(updateThuongHieu);
        }
        [HttpPost]
        public IActionResult EditThuongHieu(ThuongHieu ThuongHieu)
        {
            _ThuongHieuRepo.Update(ThuongHieu);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            _ThuongHieuRepo.Delete(id);
            return RedirectToAction("Index");
        }
        // Thông tin Details
        public IActionResult Details(Guid id)
        {
            var getThuongHieu = _ThuongHieuRepo.GetByID(id);
            return View(getThuongHieu);
        }
    }
}
