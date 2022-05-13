using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Google.Cloud.Storage.V1;
using Google.Apis.Storage.v1.Data;
using Accounting_WebApi.Contracts;
using AutoMapper;
using Accounting_WebApi.Entities.DataTransferObjects.Create;
using System.Net.Http.Headers;
using Accounting_WebApi.Entities.DataTransferObjects.View;
using Accounting_WebApi.Entities.Models;

namespace Accounting_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public StaffController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper, IWebHostEnvironment _webHostEnvironment)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            webHostEnvironment = _webHostEnvironment;
        }
        private string UploadedFile(StaffCreateRepo model)
        {
            string? uniqueFileName = null;

            if (model.Pic != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Resources/Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Pic.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Pic.CopyTo(fileStream);
                }
            }
#pragma warning disable CS8603 // Possible null reference return.
            return uniqueFileName;
#pragma warning restore CS8603 // Possible null reference return.
        }
        [HttpPost]
        public IActionResult CreateStaff([FromBody] StaffCreateRepo staff)
        {
            try
            {
                string uniqueFileName = UploadedFile(staff);
                if (staff is null)
                {
                    _logger.LogError("staff sent by you is null");
                    return BadRequest("staff object is null");
                }

                var staffEntity = _mapper.Map<Staffs>(staff);
                staffEntity.Pic = uniqueFileName;
                _repository.staff.CreateStaffs(staffEntity);
                _repository.save();

                var createdstaff = _mapper.Map<StaffViewRepo>(staffEntity);
                return CreatedAtRoute("StaffId", new { Id = createdstaff.Id }, createdstaff);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside Createstaff action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
