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
            var sessionData = HttpContext.Session.GetString("user");
            if (sessionData == null)
            {
                ViewData["mes"] = "Bạn chưa đăng nhập hoặc phiên đăng nhập đã hết hạn";
            }
            else
            {
                ViewData["mes"] = $"Chào mừng {sessionData} đến với unfinished square integer";
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
                var jsonData = JsonConvert.SerializeObject(User);
                HttpContext.Session.SetString("user", jsonData);
                return RedirectToAction("Create", "GioHang");
            }
            else
            {
                return Content("Đăng nhập thất bại");
            }
        }
    }
}
