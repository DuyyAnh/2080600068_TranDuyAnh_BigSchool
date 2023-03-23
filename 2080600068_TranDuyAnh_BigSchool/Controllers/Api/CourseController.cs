using _2080600068_TranDuyAnh_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Mvc.HttpDeleteAttribute;

namespace _2080600068_TranDuyAnh_BigSchool.Controllers.Api
{
    public class CourseController : ApiController
    {
        // GET: Course
        public ApplicationDbContext _dbContext { get; set; }
        // GET: Courses
        public CourseController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var course = _dbContext.Courses.Single(c => c.Id == id && c.LecturerId == userId);
            if (course.IsCanceled)
                return NotFound();
            course.IsCanceled = true;
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}