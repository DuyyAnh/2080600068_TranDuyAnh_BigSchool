using _2080600068_TranDuyAnh_BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using _2080600068_TranDuyAnh_BigSchool.DTOs;

namespace _2080600068_TranDuyAnh_BigSchool.Controllers
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Followings
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
                 return BadRequest("Hãy đăng nhập trước!!");
            Following find = _dbContext.Followings.FirstOrDefault(p => p.FollowerId == userId && p.FolloweeId == followingDto.FolloweeId);
            if (find == null)
            {
                var follwing = new Following
                {
                    FollowerId = userId,
                    FolloweeId = followingDto.FolloweeId
                };
                _dbContext.Followings.Add(follwing);
                _dbContext.SaveChanges();
            }
            else
                _dbContext.Followings.Remove(find);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}