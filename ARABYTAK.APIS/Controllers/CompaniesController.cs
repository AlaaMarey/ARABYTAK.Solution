using Arabytak.Core.Entities;
using Arabytak.Core.Repositories.Contract;
using ARABYTAK.APIS.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARABYTAK.APIS.Controllers
{

    public class CompaniesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompaniesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("RescueCompany")]
        public async Task<ActionResult<IReadOnlyList<RescueCompany>>> GetRescueCompany()
        {
            var RescueCompany = await _unitOfWork.Repository<RescueCompany>().GetAllAsync();
            return Ok(RescueCompany);

        }

        [HttpPost("Rescue")]
        public async Task<ActionResult> CreateRescueCompany([FromBody] RescueCompanyDto dto)
        {
            if (dto == null) return BadRequest("Invalid Data");

            var rescueCompany = new RescueCompany
            {
                Id = Math.Abs(Guid.NewGuid().GetHashCode()),
                Name = dto.Name,
                City = dto.City,
                Phone1 = dto.Phone1,
                Phone2 = dto.Phone2,
                Phone3 = dto.Phone3,
                Service1 = dto.Service1,
                Service2 = dto.Service2,
                Service3 = dto.Service3,
                Service4 = dto.Service4
            };

            await _unitOfWork.Repository<RescueCompany>().AddAsync(rescueCompany);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Rescue Company Created Successfully", rescueCompanyId = rescueCompany.Id });
        }

        [HttpPut("Rescue/{id}")]
        public async Task<ActionResult> UpdateRescueCompany(int id, [FromBody] RescueCompanyDto dto)
        {
            if (dto == null) return BadRequest("Invalid Data");

            var rescueCompany = await _unitOfWork.Repository<RescueCompany>().GetAsync(id);
            if (rescueCompany == null) return NotFound("Rescue Company Not Found");

            // تحديث البيانات
            rescueCompany.Name = dto.Name;
            rescueCompany.City = dto.City;
            rescueCompany.Phone1 = dto.Phone1;
            rescueCompany.Phone2 = dto.Phone2;
            rescueCompany.Phone3 = dto.Phone3;
            rescueCompany.Service1 = dto.Service1;
            rescueCompany.Service2 = dto.Service2;
            rescueCompany.Service3 = dto.Service3;
            rescueCompany.Service4 = dto.Service4;

            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Rescue Company Updated Successfully", rescueCompanyId = rescueCompany.Id });
        }

        [HttpDelete("Rescue/{id}")]
        public async Task<ActionResult> DeleteRescueCompany(int id)
        {
            var rescueCompany = await _unitOfWork.Repository<RescueCompany>().GetAsync(id);
            if (rescueCompany == null) return NotFound("Rescue Company Not Found");

            _unitOfWork.Repository<RescueCompany>().DeleteAsync(rescueCompany);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Rescue Company Deleted Successfully" });
        }

        [HttpGet("maintenance")]
        public async Task<ActionResult<IEnumerable<MaintenanceCenter>>> GetAllMaintenanceCenters()
        {
            var centers = await _unitOfWork.Repository<MaintenanceCenter>().GetAllAsync();
            return Ok(centers);
        }
        [HttpPost("maintenance")]
        public async Task<ActionResult> CreateMaintenanceCenter([FromBody] MaintenanceCenterDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name) || string.IsNullOrWhiteSpace(dto.AvailableServices))
                return BadRequest("Invalid Data");

            var maintenanceCenter = new MaintenanceCenter
            {
             
                Name = dto.Name,
                AvailableServices = dto.AvailableServices
            };

            await _unitOfWork.Repository<MaintenanceCenter>().AddAsync(maintenanceCenter);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Maintenance Center Created Successfully", maintenanceCenterId = maintenanceCenter.Id });
        }

        [HttpDelete("maintenance/{id}")]
        public async Task<ActionResult> DeleteMaintenanceCenter(int id)
        {
            var center = await _unitOfWork.Repository<MaintenanceCenter>().GetAsync(id);
            if (center == null) return NotFound("Maintenance Center Not Found");

            _unitOfWork.Repository<MaintenanceCenter>().DeleteAsync(center);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Maintenance Center Deleted Successfully" });
        }


        [HttpPost("CreateInsurance")]
        public async Task<ActionResult> CreateInsuranceCompany([FromBody] InsuranceCompanyDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest(new { message = "Invalid data" });
            }

            var insuranceCompany = new InsuranceCompany
            {
                Name = dto.Name
            };

            await _unitOfWork.Repository<InsuranceCompany>().AddAsync(insuranceCompany);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Insurance Company Created Successfully", insuranceCompanyId = insuranceCompany.Id });
        }

        [HttpDelete("DeleteInsurance/{id}")]
        public async Task<ActionResult> DeleteInsuranceCompany(int id)
        {
            var insuranceCompany = await _unitOfWork.Repository<InsuranceCompany>().GetAsync(id);
            if (insuranceCompany == null)
            {
                return NotFound(new { message = "Insurance Company Not Found" });
            }

            _unitOfWork.Repository<InsuranceCompany>().DeleteAsync(insuranceCompany);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Insurance Company Deleted Successfully" });
        }

        [HttpGet("GetAllInsurance")]
        public async Task<ActionResult> GetAllInsuranceCompanies()
        {
            var insuranceCompanies = await _unitOfWork.Repository<InsuranceCompany>().GetAllAsync();
            return Ok(insuranceCompanies);
        }





    }
}
