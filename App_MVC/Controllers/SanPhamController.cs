using App_Data.Models;
using App_Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App_MVC.Controllers
{
    public class SanPhamController : Controller
    {
        Sd18302Net104Context _context;
        ALLRepository<SanPham> _proRepo;
        DbSet<SanPham> _product;
        public SanPhamController()
        {
            //khởi tạo dbcontext
            _context = new Sd18302Net104Context();
            //khởi tạo repo với 2 tham số dbset và dbcontext
            _product = _context.SanPhams;
            _proRepo = new ALLRepository<SanPham>(_product, _context);
        }

        // GetAll danh sách SanPham
        public IActionResult Index()
        {
            //var SanPhamData = _proRepo.GetAll();
            //return View(SanPhamData);
            var SanPhamData = from sp in _context.SanPhams
                              join lsp in _context.LoaiSPs
                              on sp.ProductTypeId equals lsp.TypeId
                              join th in _context.ThuongHieus
                              on sp.BrandId equals th.BrandId
                              select new SanPham
                              {
                                  ProductId = sp.ProductId,
                                  Name = sp.Name,
                                  Price = sp.Price,
                                  ProductTypeId = lsp.TypeId,
                                  BrandId = th.BrandId,
                                  Material = sp.Material,
                                  ImportDate = sp.ImportDate,
                                  Image = sp.Image,
                                  Quantity = sp.Quantity,
                                  LoaiSP = lsp,
                                  ThuongHieu = th
                              };
            return View(SanPhamData);
        }
        public IActionResult Create()
        {
            GetThuongHieu(Guid.Empty);
            GetLoaiSP(Guid.Empty);
            return View();
        }
        [HttpPost]
        public IActionResult CreateSanPham(SanPham sanPham, IFormFile img)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", img.FileName);
                //thực hiện việc sao chép phai phai đc chọn vào thư mục root
                var stream = new FileStream(path, FileMode.Create);
                //thực hiện viêc sao chép ảnh vào thư mục root
                img.CopyTo(stream);

                sanPham.ProductId = Guid.NewGuid();
                sanPham.Image = img.FileName;
                _proRepo.Create(sanPham);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
            return Content(ex.Message);
            }

        }

        public IActionResult Edit(Guid id)
        {
            GetThuongHieu(Guid.Empty);
            GetLoaiSP(Guid.Empty);
            var updateSanPham = _proRepo.GetByID(id);
            return View(updateSanPham);
        }
        [HttpPost]
        public IActionResult EditSanPham(SanPham SanPham)
        {
            _proRepo.Update(SanPham);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            _proRepo.Delete(id);
            return RedirectToAction("Index");
        }
        // Thông tin Details
        public IActionResult Details(Guid id)
        {
            var getSanPham = _proRepo.GetByID(id);
            return View(getSanPham);
        }
        public void GetLoaiSP(Guid selected)
        {
            var loaiSPList = _context.LoaiSPs.ToList();
            SelectList listItems = new SelectList(loaiSPList, "TypeId", "TypeName", selected);
            ViewBag.SelectedList = listItems;
        }
        public void GetThuongHieu(Guid selected)
        {
            var thuongHieus = _context.ThuongHieus.ToList();
            SelectList listItems = new SelectList(thuongHieus, "BrandId", "Name", selected);
            ViewBag.BrandList = listItems;
        }
    }
}
