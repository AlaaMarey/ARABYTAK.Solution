using Arabytak.Core.Entities;
using Arabytak.Core.Repositories.Contract;
using Arabytak.Core.Specification.AdvertisementSpec;
using Arabytak.Repository.Data;
using ARABYTAK.APIS.DTOs;
using ARABYTAK.APIS.Errors;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARABYTAK.APIS.Controllers
{

    public class AdvertisementController : BaseApiController
    {
        private readonly ArabytakContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AdvertisementController(ArabytakContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpPost("create")]
        public async Task<ActionResult> CreateAdvertisement([FromForm] AdvertisementDto advertisementDto)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiResponse(400));
           

            
            var brand = await _unitOfWork.Repository<Brand>()
                        .FindAsync(b => b.Name == advertisementDto.brand);

            if (brand == null)
            {
                brand = new Brand { Name = advertisementDto.brand };
                await _unitOfWork.Repository<Brand>().AddAsync(brand);
                await _unitOfWork.CompleteAsync();
            }

            var model = await _unitOfWork.Repository<Model>()
                        .FindAsync(m => m.Name == advertisementDto.model);

            if (model == null)
            {
                model = new Model { Name = advertisementDto.model }; 
                await _unitOfWork.Repository<Model>().AddAsync(model);
                await _unitOfWork.CompleteAsync();
            }

            
            var advertisement = _mapper.Map<Advertisement>(advertisementDto);
            advertisement.Car.BrandId = brand.Id;
            advertisement.Car.ModelId = model.Id;
            advertisement.Car.brand = brand;  // avoid create new object
            advertisement.Car.model = model; 

            
            var planPrices = new Dictionary<PlanType, decimal>
{
    { PlanType.Weekly,  500 },
    { PlanType.Monthly, 1000 },
    { PlanType.Yearly,  10000 }
};

            if (planPrices.TryGetValue(advertisementDto.TypeOfPlan, out decimal price))
            {
                advertisement.Price = price;
            }
            else
            {
                return BadRequest(new { message = "Invalid advertisement plan type" });
            }

            //  Save Image
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/advertisementImg");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var imageUrls = new List<CarPictureUrl>();
            foreach (var image in advertisementDto.Image)
            {
                if (image != null && image.Length > 0)
                {
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                    string filePath = Path.Combine(uploadFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    imageUrls.Add(new CarPictureUrl { PictureUrl = $"/images/advertisementImg/{fileName}" });
                }
            }

            advertisement.Car.Url = imageUrls;

            
            await _unitOfWork.Repository<Advertisement>().AddAsync(advertisement);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Advertisement created successfully" });
        }




        [HttpGet("{AdvId}")]
        public async Task<ActionResult<AdvertisementResponseDto>> GetAdvertisementDetails(int AdvId)
        {
            var spec = new AdvWithTablesSpec(AdvId);
            var Adv = await _unitOfWork.Repository<Advertisement>().GetByIdWithSpecAsync(spec);
            if (Adv == null)
            {
                return NotFound(new { message = "Advertisement not found" });
            }
            var AdvDto = _mapper.Map<Advertisement, AdvertisementResponseDto>(Adv);
            return Ok(AdvDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdvertisement(int id, [FromBody] AdvertisementUpdateDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(new ApiResponse(400));
            var spec =  new AdvWithTablesSpec(id);
            var Adv= await _unitOfWork.Repository<Advertisement>().GetByIdWithSpecAsync(spec);
            if (Adv == null) return NotFound( new ApiResponse(404));
             _mapper.Map(updateDto,Adv);
            _unitOfWork.Repository<Advertisement>().UpdateAsync(Adv);
            await _unitOfWork.CompleteAsync();
            return Ok(new { message = "Advertisement updated successfully" });
        }
        [HttpDelete("{id}")]
      
        public async Task<ActionResult> DeleteAdvertisement(int id)
        {
            var spec = new AdvWithTablesSpec(id);
            var adv = await _unitOfWork.Repository<Advertisement>().GetByIdWithSpecAsync(spec);

            if (adv == null) return NotFound(new ApiResponse(404));

            // Get All Data have Relation with Advertisement
            var car = adv.Car;
            var images = car?.Url;  // قائمة الصور المرتبطة

            // حذف الصور المرتبطة
            if (images != null)
            {
                foreach (var image in images)
                {
                     _unitOfWork.Repository<CarPictureUrl>().DeleteAsync(image);
                }
            }

           
            if (car != null)
            {
                 _unitOfWork.Repository<Car>().DeleteAsync(car);
            }

             _unitOfWork.Repository<Advertisement>().DeleteAsync(adv);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Advertisement and related data deleted successfully" });
        }
        [HttpGet("AllAdv")]
        public async Task<ActionResult<IReadOnlyList<AdvertisementAllDto>>>GetAllAdvertisement()
        {
            var spec = new AdvWithTablesSpec();
            var Adv=await _unitOfWork.Repository<Advertisement>().GetAllWithSpecAsync(spec);
            if (Adv == null) return NotFound(new ApiResponse(404));
            var AdvDto=_mapper.Map<IReadOnlyList<Advertisement>,IReadOnlyList<AdvertisementAllDto>>(Adv);
            return Ok(AdvDto);

        }





    }

}
