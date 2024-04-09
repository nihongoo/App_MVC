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
				//return RedirectToAction("Login","User");
				return NotFound("Chưa đăng nhập");
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
			return View();
		}

		// POST: GioHangCTController/Edit/5
		public ActionResult Edit(Guid cartDetailId, int newQuantity)
		{
			var loginData = HttpContext.Session.GetString("user");
			var cartDT = _context.GioHangCTs.Find(cartDetailId);
			var kho = _context.SanPhams.FirstOrDefault(x=>x.ProductId == cartDT.ProductId);
			if (kho.Quantity + cartDT.Quantity >= newQuantity)
			{
				if (loginData == null)
				{
					return NotFound("Chưa đăng nhập, gmak");
				}
				else
				{
					var a = _gioHangCTRepo.GetByID(cartDetailId);
					a.Quantity = newQuantity;
					if (newQuantity > cartDT.Quantity)
					{
						kho.Quantity -= newQuantity;
                        _context.SanPhams.Update(kho);
                    }
					else if (newQuantity < cartDT.Quantity)
					{
						kho.Quantity += newQuantity;
                        _context.SanPhams.Update(kho);
                    }

                    _context.GioHangCTs.Update(a);
					_context.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			else
			{
				return Content("Sản phẩm này đã hết hàng");
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
