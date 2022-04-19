using Microsoft.AspNetCore.Mvc;
using MongoDbExample.Entities;
using MongoDbExample.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDbExample.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly StudentService _studentService;
        public HomeController(StudentService service)
        {
            _studentService = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Index()
        {
            var students = await _studentService.GetAllAsync();
            var studentName = "Nguyen Trong Phuong";
            var studentName1 = "Nguyen Trong Phuong1";
            var studentName2 = "Nguyen Trong Phuong2";
            return Ok(students);
        }
    }
}
