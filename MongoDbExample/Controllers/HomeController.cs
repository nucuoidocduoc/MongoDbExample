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
            return Ok(students);
        }
    }
}
