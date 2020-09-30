using Mammothcode.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mammothcode.AdminService.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class GetCourseModel:PageModel 
    {
        public string CourseName { get; set; }
        public int? Status { get; set; }
    }
}
