using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using myapi.Data;
using myapi.Models;

namespace myapi.Controllers
{
    [Route("apiv1/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly ComplaintsRepository _complaintsRepository;
        private readonly IValidator<ComplainUpdateStatusModel> _complaintsValidator;
        private readonly IValidator<ComplainAddEditModel> _complainAddEditValidator;

        public ComplaintsController(ComplaintsRepository complaintsRepository,
            IValidator<ComplainUpdateStatusModel> complaintsValidator,
            IValidator<ComplainAddEditModel> complainAddEditValidator)
        {
            _complaintsRepository = complaintsRepository;
            _complaintsValidator = complaintsValidator;
            _complainAddEditValidator = complainAddEditValidator;
        }

        [HttpGet("AllComplaints")]
        public IActionResult GetAllComplaints()
        {
            try
            {
                var complaints = _complaintsRepository.GetAllComplaints();

                if (complaints == null || !complaints.Any())
                {
                    return NotFound(new
                    {
                        Status = "Failure",
                        Message = "No data found"
                    });
                }

                return Ok(new
                {
                    Status = "Success",
                    Data = complaints
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

        [HttpGet("ResolvedComplaints")]
        public IActionResult GetResolvedComplaints()
        {
            return GetComplaints(_complaintsRepository.GetResolvedComplaints(), "resolved");
        }

        [HttpGet("UnResolvedComplaints")]
        public IActionResult GetUnResolvedComplaints()
        {
            return GetComplaints(_complaintsRepository.GetUnResolvedComplaints(), "unresolved");
        }

        private IActionResult GetComplaints(IEnumerable<object> complaints, string type)
        {
            try
            {
                if (complaints == null || !complaints.Any())
                {
                    return NotFound(new
                    {
                        Status = "Failure",
                        Message = $"No {type} complaints found"
                    });
                }

                return Ok(new
                {
                    Status = "Success",
                    Data = complaints
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

        [HttpPost("HostelUpdateComplaintsStatus/{id}")]
        public IActionResult UpdateComplaintsStatus(int id, [FromBody] ComplainUpdateStatusModel cm)
        {
            try
            {
                var validateRes = _complaintsValidator.Validate(cm);

                if (!validateRes.IsValid)
                {
                    return BadRequest(new
                    {
                        Status = "Failure",
                        Errors = validateRes.Errors.Select(e => e.ErrorMessage)
                    });
                }

                var res = _complaintsRepository.UpdateComplainsStatus(id, cm);

                if (res)
                {
                    return Ok(new
                    {
                        Status = "Success",
                        Message = "Complaint updated successfully"
                    });
                }

                return BadRequest(new
                {
                    Status = "Failure",
                    Message = "Failed to update status"
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

        [HttpPost("StudentAddComplain")]
        public IActionResult StudentComplainAdd([FromBody] ComplainAddEditModel cm)
        {
            try
            {
                var validateRes = _complainAddEditValidator.Validate(cm);

                if (!validateRes.IsValid)
                {
                    return BadRequest(new
                    {
                        Status = "Failure",
                        Errors = validateRes.Errors.Select(e => e.ErrorMessage)
                    });
                }

                var res = _complaintsRepository.ComplaintsAdd(cm);

                if (res)
                {
                    return Ok(new
                    {
                        Status = "Success",
                        Message = "Complaint added successfully"
                    });
                }

                return BadRequest(new
                {
                    Status = "Failure",
                    Message = "Failed to add complaint"
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

        [HttpPost("StudentUpdateComplain/{id}")]
        public IActionResult StudentComplainAddEdit(int id, [FromBody] ComplainAddEditModel cm)
        {
            try
            {
                var validateRes = _complainAddEditValidator.Validate(cm);

                if (!validateRes.IsValid)
                {
                    return BadRequest(new
                    {
                        Status = "Failure",
                        Errors = validateRes.Errors.Select(e => e.ErrorMessage)
                    });
                }

                var res = _complaintsRepository.ComplaintsUpdate(id, cm);

                if (res)
                {
                    return Ok(new
                    {
                        Status = "Success",
                        Message = "Complaint updated successfully"
                    });
                }

                return BadRequest(new
                {
                    Status = "Failure",
                    Message = "Failed to update complaint"
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

        [HttpDelete("/StudentDeleteComplaint/{id}")]
        public IActionResult StudentDeleteComplaint(int id)
        {
            try
            {
                var complaints = _complaintsRepository.StudentDeleteComplaint(id);

                if (!complaints)
                {
                    return BadRequest(new
                    {
                        Status = "Failure",
                        Message = "Failed to delete complaint",
                    });
                }

                return Ok(new
                {
                    Status = "Success",
                    Message = "Complaint deeleted successfully"
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
