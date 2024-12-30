using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using myapi.Data;

namespace myapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _studentRepository;
        private readonly IValidator<StudentAddEditModel> _addEditValidator;
        private readonly IValidator<StudentLoginModel> _loginValidator;
        public StudentController(StudentRepository studentRepository,
            IValidator<StudentAddEditModel> addEditValidator,
            IValidator<StudentLoginModel> loginValidator)
        {
            _studentRepository = studentRepository;
            _addEditValidator = addEditValidator;
            _loginValidator = loginValidator;
        }

        [HttpGet("/getStudent")]
        public IActionResult SelectAllStudent()
        {
            try
            {
                var res = _studentRepository.SelectAllStudent();

                if (res == null || !res.Any())
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
                    Data = res,
                    Message = "students found"
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

        [HttpGet("/getStudent/{id}")]
        public IActionResult GetStudentID(int id)
        {
            try
            {
                var res = _studentRepository.SelectAllStudent();

                if (res == null || !res.Any())
                {
                    return NotFound(new
                    {
                        Status = "Failure",
                        Message = "No student found"
                    });
                }
                return Ok(new
                {
                    Status = "Success",
                    Data = res,
                    Message = "student found"
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

        [HttpPost("studentLogin")]
        public IActionResult StudentLogin([FromBody] StudentLoginModel sm)
        {
            try
            {
                var validateRes = _loginValidator.Validate(sm);

                if (validateRes.IsValid)
                {

                    return BadRequest(new
                    {
                        Status = "Failure",
                        Errors = validateRes.Errors.Select(e => e.ErrorMessage)
                    });
                }

                var isLoginSuccessful = _studentRepository.StudentLogin(sm);

                if (isLoginSuccessful)
                {
                    return Ok(new
                    {
                        Status = "Success",
                        Message = "Login successful"
                    });
                }

                return Unauthorized(new
                {
                    Status = "Failure",
                    Message = "Invalid username or password"
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
