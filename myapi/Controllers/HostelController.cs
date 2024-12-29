using Microsoft.AspNetCore.Mvc;
using myapi.Models;
using myapi.Data;
using FluentValidation;

[Route("apiv1/[controller]")]
[ApiController]
public class HostelsController : ControllerBase
{
    private readonly HostelRepository _hostelRepository;
    private readonly IValidator<HostelLoginModel> _loginValidator;
    private readonly IValidator<HostelUpdatePasswordModel> _updatePasswordValidator;

    public HostelsController(HostelRepository hostelRepository,
        IValidator<HostelLoginModel> loginValidator,
        IValidator<HostelUpdatePasswordModel> updatePasswordValidator)
    {
        _hostelRepository = hostelRepository;
        _loginValidator = loginValidator;
        _updatePasswordValidator = updatePasswordValidator;
    }

    [HttpGet("GetAll")]
    public IActionResult HostelSelectAll()
    {
        try
        {
            var hostels = _hostelRepository.GetAllHostels();

            if (hostels == null || !hostels.Any())
            {
                return NotFound(new
                {
                    Status = "Failure",
                    Message = "No hostels found"
                });
            }

            return Ok(new
            {
                Status = "Success",
                Data = hostels
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

    [HttpPost("HostelLogin")]
    public IActionResult HostelLogin([FromBody] HostelLoginModel hm)
    {
        try
        {
            var validateRes = _loginValidator.Validate(hm);

            if (!validateRes.IsValid)
            {
                return BadRequest(new
                {
                    Status = "Failure",
                    Errors = validateRes.Errors.Select(e => e.ErrorMessage)
                });
            }

            var isLoginSuccessful = _hostelRepository.HostelLogin(hm);

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

    [HttpPost("UpdatePassword")]
    public IActionResult HostelUpdatePassword([FromBody] HostelUpdatePasswordModel hm)
    {
        var validateRes = _updatePasswordValidator.Validate(hm);

        if (!validateRes.IsValid)
        {
            return BadRequest(new
            {
                Status = "Failure",
                Errors = validateRes.Errors.Select(e => e.ErrorMessage)
            });
        }

        var res = _hostelRepository.UpdateHostelPassword(hm);

        if (res)
        {
            return Ok(new
            {
                Status = "Success",
                Message = "Password updated successfully"
            });
        }

        return BadRequest(new
        {
            Status = "Failure",
            Message = "Invalid password"
        });
    }
}
