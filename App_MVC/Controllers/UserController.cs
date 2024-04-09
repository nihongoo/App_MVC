using App_Data.Models;
using App_Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace App_MVC.Controllers
{
    public class UserController : Controller
    {
        Sd18302Net104Context _context;
        ALLRepository<User> _userRepo;
        DbSet<User> _users;
        public UserController()
        {
            //khởi tạo dbcontext
            _context = new Sd18302Net104Context();
            //khởi tạo repo với 2 tham số dbset và dbcontext
            _users = _context.Users;
            _userRepo = new ALLRepository<User>(_users, _context);
        }

        // GetAll danh sách user
        public IActionResult Index(string name)
        {
            var loginData = HttpContext.Session.GetString("user");
            if (loginData == null)
            {
                ViewData["mes"] = "Bạn chưa đăng nhập hoặc phiên đăng nhập đã hết hạn";
            }
            else
            {
                ViewData["mes"] = $"Chào mừng bruh";
            }

            var userData = _userRepo.GetAll();
            if (string.IsNullOrEmpty(name))
            {
                return View(userData);
            }
            else
            {
                var searchData = _userRepo.GetAll().Where(x => x.FullName.Contains(name)).ToList();
                ViewData["count"] = searchData.Count;
                ViewBag.Count = searchData.Count;
                if (searchData.Count == 0)
                {
                    return View(userData);
                }
                else
                {
                    return View(searchData);
                }
            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            user.UserId = Guid.NewGuid();
            _userRepo.Create(user);
            //tạo user = tạo giỏ hàng mới
            var giohang = new GioHang()
            {
                CartId = user.UserId,
                UserId = user.UserId,
                CreationDate = DateTime.Now
            };
            _context.GioHangs.Add(giohang);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var updateUser = _userRepo.GetByID(id);
            return View(updateUser);
        }
        [HttpPost]
        public IActionResult EditUser(User user)
        {
            _userRepo.Update(user);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            _userRepo.Delete(id);
            return RedirectToAction("Index");
        }
        // Thông tin Details
        public IActionResult Details(Guid id)
        {
            var getUser = _userRepo.GetByID(id);
            return View(getUser);
        }
        public IActionResult Login()//Action này return View để mở view cho phép nhập thông tin đăng nhập
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string UserName, string PassWord)
        {
            var User = _userRepo.GetAll().FirstOrDefault(p => p.Username == UserName && p.Password == PassWord);
            if (User != null)
            {
                //TempData["Login"] = User.FullName;
                HttpContext.Session.SetString("user", User.UserId.ToString());
                var cartDetailCount = _users.Where(x=>x.UserId == User.UserId)
                .SelectMany(x=>x.GioHang)
                .SelectMany(x=>x.GioHangCTs)
                .Count();

                ViewBag.CartDetailCount = cartDetailCount;
                //var jsonData = JsonConvert.SerializeObject(User);
                if (User.Role == "User")
                {
                    return RedirectToAction("IndexU", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                return Content("Đăng nhập thất bại");
            }
        }
    }
}
