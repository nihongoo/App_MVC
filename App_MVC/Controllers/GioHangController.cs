using App_Data.Models;
using App_Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace App_MVC.Controllers
{
	public class GioHangController : Controller
	{
        Sd18302Net104Context _context;
        ALLRepository<GioHang> _gioHangRepo;
        DbSet<GioHang> _gioHang;
        public GioHangController()
        {
            //khởi tạo dbcontext
            _context = new Sd18302Net104Context();
            //khởi tạo repo với 2 tham số dbset và dbcontext
            _gioHang = _context.GioHangs;
            _gioHangRepo = new ALLRepository<GioHang>(_gioHang, _context);
        }

        // GET: GioHangController
        public ActionResult Index()
		{
			var gioHangData = _gioHangRepo.GetAll();
			return View(gioHangData);
		}


		// POST: GioHangController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
        public ActionResult Create(GioHang gioHang)
        {
            try
            {
                if (HttpContext.Session.Keys.Contains("user"))
                {
                    var jsonData = HttpContext.Session.GetString("user");
                    var userData = JsonConvert.DeserializeObject<User>(jsonData);
                    if(userData.GioHang==null)
                    {
                        gioHang.CartId = Guid.NewGuid();
                        gioHang.UserId = userData.UserId;
                        gioHang.CreationDate = DateTime.Now;
                        _gioHangRepo.Create(gioHang);

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return RedirectToAction("Create", "GioHangCT");
                    }
                }
                else
                {
                    return Content("It's too late to apologize");
                }
            }
            catch (Exception ex)
            {
                // Log exception
                return Content("An error occurred while creating the shopping cart: " + ex.Message);
            }
        }

        // GET: GioHangController/Edit/5
        public ActionResult Detail(Guid id)
		{
			var a = _gioHang.Find(id);
			return View(a);
		}


		// POST: GioHangController/Delete/5
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
