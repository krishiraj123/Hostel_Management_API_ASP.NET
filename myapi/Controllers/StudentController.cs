using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myapi.Data;

namespace myapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _studentRepository;
        private readonly IValidator<StudentAddEditModel> _addEditValidator;
        public StudentController(StudentRepository studentRepository,IValidator<StudentAddEditModel> addEditValidator) 
        {
            _studentRepository = studentRepository;
            _addEditValidator = addEditValidator;
        }

        [HttpGet]
        public IActionResult SelectAllStudent()
        {
            try
            {
                var res = _studentRepository.SelectAllStudent();

                if(res == null || !res.Any())
                {
                    return NotFound(new
                    {
                        Status = "Failure",
                        Message = "No students found"
                    });
                }
                return Ok(new
                {
                    Status = "Success",
                    Message = res
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Status = "Failure",
                    Message = "Internal server error",
                    Error = ex.Message
                });
            }
        }
    }
}
