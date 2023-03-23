using _2080600068_TranDuyAnh_BigSchool.Models;
using _2080600068_TranDuyAnh_BigSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2080600068_TranDuyAnh_BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingCourses = _dbContext.Courses
                .Include(c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now);

            var viewModel = new CourseViewModel
            {
                UpcommingCourses = upcomingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }
    }
} //Trang 50