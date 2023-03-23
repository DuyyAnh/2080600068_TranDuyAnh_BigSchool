using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2080600068_TranDuyAnh_BigSchool.Models
{
    public class Course
    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; }
        public ApplicationUser Lecturer { get; set; }
        [Required]
        public string LecturerId { get; set; }
        [Required(ErrorMessage ="Tên phòng không được để Trống")]
        [StringLength(255)]
        public string Place { get; set; }
        public DateTime DateTime { get; set; }
        public Category Category { get; set; }
        [Required]
        public byte CategoryId { get; set; }
        public bool isShowGoing = false;
        public bool isShowFollow = true;
    }
}