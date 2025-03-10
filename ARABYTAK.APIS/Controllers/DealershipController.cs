using Arabytak.Core.Entities;
using Arabytak.Core.Repositories.Contract;
using ARABYTAK.APIS.DTOs;
using ARABYTAK.APIS.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARABYTAK.APIS.Controllers
{
  
    public class DealershipController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public DealershipController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<ActionResult> CreateDealership(DealershipDto dto)
        {
            if (dto == null)  return BadRequest( new ApiResponse(400,"Invalid Data"));
            var dealership = new Dealership
            {
                Id = Math.Abs(Guid.NewGuid().GetHashCode()),
                Name = dto.Name,
                Phone1 = dto.Phone1,
                Phone2 = dto.Phone2,
                Phone3 = dto.Phone3,
                Facebook = dto.Facebook,
                Instagram = dto.Instagram,
                WhatsApp1 = dto.WhatsApp1,
                Branch1 = dto.Branches.ElementAtOrDefault(0),
                Branch2 = dto.Branches.ElementAtOrDefault(1),
                Branch3 = dto.Branches.ElementAtOrDefault(2)
            };
            await _unitOfWork.Repository<Dealership>().AddAsync(dealership);
            await _unitOfWork.CompleteAsync();
            return Ok(new { message ="Dealership created successfully" });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDealership(int id, DealershipDto dto)
        {
            if (dto == null)
                return BadRequest(new ApiResponse(400,"Invalid Data"));

            var dealership = await _unitOfWork.Repository<Dealership>().GetAsync(id);
            if (dealership == null)
                return NotFound(new ApiResponse(404,"Dealership not found"));

          
            dealership.Name = dto.Name;
            dealership.Phone1 = dto.Phone1;
            dealership.Phone2 = dto.Phone2;
            dealership.Phone3 = dto.Phone3;
            dealership.Facebook = dto.Facebook;
            dealership.Instagram = dto.Instagram;
            dealership.WhatsApp1 = dto.WhatsApp1;
            dealership.Branch1 = dto.Branches.ElementAtOrDefault(0);
            dealership.Branch2 = dto.Branches.ElementAtOrDefault(1);
            dealership.Branch3 = dto.Branches.ElementAtOrDefault(2);

            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Dealership Updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDealership(int id)
        {
            var dealership = await _unitOfWork.Repository<Dealership>().GetAsync(id);
            if (dealership == null)
                return NotFound(new ApiResponse(404, "Dealership not found"));

            _unitOfWork.Repository<Dealership>().DeleteAsync(dealership);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message= "Dealership deleted successfully" });
        }

        [HttpGet("GetAllDealership")]
        public async Task<ActionResult<IReadOnlyList<Dealership>>> GetDealerShip()
        {
            var dealerships = await _unitOfWork.Repository<Dealership>().GetAllAsync();
            return Ok(dealerships);
        }
    }
}
