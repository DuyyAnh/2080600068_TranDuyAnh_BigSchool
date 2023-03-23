using _2080600068_TranDuyAnh_BigSchool.DTOs;
using _2080600068_TranDuyAnh_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2080600068_TranDuyAnh_BigSchool.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(Course courseDTO)
        {
            var userID = User.Identity.GetUserId();
            if (userID == null)
                return BadRequest("Hãy đăng nhập trước!!");
            Attendance find = _dbContext.Attendances.FirstOrDefault(p => p.AttendeeId == userID && p.CourseId == courseDTO.Id);
            var attendance = new Attendance
            {
                CourseId = courseDTO.Id,
                AttendeeId = userID
            };
            if (find == null)
                _dbContext.Attendances.Add(attendance);
            else
                _dbContext.Attendances.Remove(find);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
