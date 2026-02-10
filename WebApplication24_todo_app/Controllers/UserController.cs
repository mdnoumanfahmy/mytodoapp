using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication24_todo_app.Models;

namespace WebApplication24_todo_app.Controllers
{
    public class UserController : Controller
    {
        public readonly MytodoappContext context;
        public UserController(MytodoappContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        // public IActionResult SignupSubmit(string name, string email, string password)
        public IActionResult SignupSubmit(User user)
        {
            //Debug.WriteLine(name);
            //Debug.WriteLine(email);
            //Debug.WriteLine(password);
            // Database Insertion Code
            //context.Users.Add(new User
            //{
            //    Name = name,
            //    Email = email,
            //    Password = password
            //});

            context.Users.Add(user);
            context.SaveChanges();

            TempData["message"] = "Signup successful";

            return RedirectToAction("Signup");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginSubmit(string email, string password)
        {
            Debug.WriteLine(email);
            Debug.WriteLine(password);

            // Login Logic
            //if(email == "mdrehan4all@gmail.com" && password == "abcd")
            //{
            //    // Set Cookie
            //    CookieOptions options = new CookieOptions
            //    {
            //        Expires = DateTime.Now.AddDays(7)
            //    };
            //    Response.Cookies.Append("email", email, options);

            //    return RedirectToAction("Panel");
            //}
            //else
            //{
            //    return RedirectToAction("Login");
            //}

            var exits = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if(exits != null)
            {
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7)
                };
                Response.Cookies.Append("email", email, options);

                return RedirectToAction("Panel");
            }
            else
            {
                TempData["message"] = "Something went wrong";
                return RedirectToAction("Login");
            }
        }
        public IActionResult Panel()
        {
            string cookieValue = Request.Cookies["email"];
            if (string.IsNullOrEmpty(cookieValue))
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("email");
            return RedirectToAction("Login");
        }
    }
}
