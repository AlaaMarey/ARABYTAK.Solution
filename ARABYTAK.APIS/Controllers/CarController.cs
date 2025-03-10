using Arabytak.Core.Entities;
using Arabytak.Core.Repositories.Contract;
using Arabytak.Core.Specification.CarSpecification;
using ARABYTAK.APIS.DTOs;
using ARABYTAK.APIS.Errors;
using ARABYTAK.APIS.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ARABYTAK.APIS.Controllers
{

    public class CarController : BaseApiController
    {
        // private readonly IGenericRepository<Car> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Brand> _brandRepo;
        private readonly IGenericRepository<Dealership> _dealRepo;
        private readonly IGenericRepository<RescueCompany> _rescueRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CarController(/*IGenericRepository<Car> genericRepository*/ IMapper mapper
            /*IGenericRepository<Brand> brandRepo*/ /*IGenericRepository<Dealership> dealRepo*/
            /*IGenericRepository<RescueCompany> RescueRepo*/ , IUnitOfWork unitOfWork)
        {
            // _genericRepository = genericRepository;

            _mapper = mapper;
            //brandRepo = brandRepo;
            //dealRepo = dealRepo;
            // _rescueRepo = RescueRepo;
            _unitOfWork = unitOfWork;
        }

        //public async Task<ActionResult<IReadOnlyList<CarDto>>> GetCarsBySearchAndPagination([FromQuery] CarSpecParams SpecParams)
        //{
        //    var spec =new CarWithBrandAndCategoryAndPicUrlAndSpecSpecification(SpecParams);
        //    var cars=await _genericRepository.GetAllWithSpecAsync(spec);
        //    var data = _mapper.Map<IReadOnlyList<Car>,IReadOnlyList<CarDto>>(cars);
        //    foreach (var carDto in data)
        //    {
        //        var car = cars.FirstOrDefault(c => c.Id == carDto.Id);
        //        if (car != null)
        //        {
        //            // إضافة اسم السيارة (Brand + Model)
        //            carDto.CarName = $"{car.brand.Name} {car.model.Name}".Trim();

        //            // تحديد المواصفات بناءً على الحالة
        //            if (car.status == Status.New && car.specNewCar != null)
        //            {
        //                carDto.Specifications = _mapper.Map<SpecNewCarDto>(car.specNewCar);
        //            }
        //            else if (car.status == Status.Used && car.specUsedCar != null)
        //            {
        //                carDto.Specifications = _mapper.Map<SpecUsedCarDto>(car.specUsedCar);
        //            }
        //        }
        //    }

        //    var countSpec = new CarWithFilterationForCountSpec(SpecParams);
        //    var count= await _genericRepository.GetCountAsync(countSpec);
        //    return Ok(new Pagination<CarDto>(SpecParams.PageSize, SpecParams.PageIndex, count,data));

        //}



        [HttpGet("{status}/{CarId}")]
        public async Task<ActionResult<CarDto>> GetCarDetails(int CarId, [FromQuery] Status status)
        {
            var spec = new CarWithBrandAndCategoryAndPicUrlAndSpecSpecification(CarId, status);
            var car = await _unitOfWork.Repository<Car>().GetByIdWithSpecAsync(spec);
            if (car == null)
            {
                return NotFound();
            }
            var carDto = _mapper.Map<Car, CarDto>(car);
            carDto.CarName = $"{car.brand.Name} {car.model.Name}";
            if (status == Status.New)
            {
                var specDto = _mapper.Map<SpecNewCar, SpecNewCarDto>(car.specNewCar);
                carDto.Specifications = specDto;
            }
            else if (status == Status.Used)
            {
                var specDto = _mapper.Map<SpecUsedCar, SpecUsedCarDto>(car.specUsedCar);
                carDto.Specifications = specDto;
            }
            // carDto.DealershipName = car.dealership.Name;

            return Ok(carDto);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{status}")]

        public async Task<ActionResult<CarListDto>> GetListOfCar([FromQuery] Status status)
        {

            var spec = new CarWithBrandAndCategoryAndPicUrlAndSpecSpecification(status);
            var car = await _unitOfWork.Repository<Car>().GetAllWithSpecAsync(spec);
            if (car == null)
            {
                return NotFound();
            }
            var carsDto = _mapper.Map<IReadOnlyList<Car>, IReadOnlyList<CarListDto>>(car);
            return Ok(carsDto);

        }

    
    
        [HttpGet("RescueCompany")]
        public async Task<ActionResult<IReadOnlyList<RescueCompany>>> GetRescueCompany()
        {
            var RescueCompany = await _unitOfWork.Repository<RescueCompany>().GetAllAsync();
            return Ok(RescueCompany);

        }




        [HttpPost("CreateNewCar")]
        public async Task<ActionResult> CreateNewCar([FromForm] InputNewCarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // البحث عن البراند والموديل والمعرض
            var brand = await _unitOfWork.Repository<Brand>().FindAsync(b => b.Name == carDto.brand);
            var model = await _unitOfWork.Repository<Model>().FindAsync(m => m.Name == carDto.Model);
            var dealership = await _unitOfWork.Repository<Dealership>().FindAsync(d => d.Name == carDto.dealership);


            if (brand == null || model == null || dealership == null)
                return BadRequest(new { message = "Brand, Model, or Dealership does not exist." });

            // إنشاء مواصفات السيارة
            var newCarSpec = new SpecNewCar
            {
                Gears = carDto.Gears,
                Fuel = carDto.Fuel,
                FuelEfficiency = carDto.FuelEfficiency,
                Acceleration = carDto.Acceleration,
                Drivetrain = carDto.Drivetrain,
                AssemblyCountry = carDto.AssemblyCountry,
                Color = carDto.Color,
                GroundClearance = carDto.GroundClearance,
                Height = carDto.Height,
                HorsePower = carDto.HorsePower,
                Length = carDto.Length,
                OriginCountry = carDto.OriginCountry,
                Seats = carDto.Seats,
                TopSpeed = carDto.TopSpeed,
                Transmission = carDto.Transmission,
                TrunkSize = carDto.TrunkSize,
                Wheelbase = carDto.Wheelbase,
                Width = carDto.Width,
                Year = carDto.Year
            };

            // إنشاء كائن السيارة
            var newCar = _mapper.Map<Car>(carDto);
            newCar.Id = Guid.NewGuid().GetHashCode(); // لضمان رقم فريد
            newCar.BrandId = brand.Id;
            newCar.ModelId = model.Id;
            newCar.DealershipId = dealership.Id;
            newCar.specNewCar = newCarSpec;

            await _unitOfWork.Repository<Car>().AddAsync(newCar);
            await _unitOfWork.CompleteAsync();

            // رفع الصور
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Car");
            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            var imageUrls = new List<CarPictureUrl>();
            foreach (var image in carDto.Image)
            {
                if (image != null && image.Length > 0)
                {
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                    string filePath = Path.Combine(uploadFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    imageUrls.Add(new CarPictureUrl { PictureUrl = $"/images/Car/{fileName}" });
                }
            }

            newCar.Url = imageUrls;
            _unitOfWork.Repository<Car>().UpdateAsync(newCar);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = " New Car created successfully" });
        }


        [HttpPost("CreateUsedCar")]
        public async Task<ActionResult> CreateUsedCar([FromForm] InputUsedCarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // البحث عن البراند والموديل والمعرض
            var brand = await _unitOfWork.Repository<Brand>().FindAsync(b => b.Name == carDto.brand);
            var model = await _unitOfWork.Repository<Model>().FindAsync(m => m.Name == carDto.Model);
            var dealership = await _unitOfWork.Repository<Dealership>().FindAsync(d => d.Name == carDto.dealership);


            if (brand == null || model == null || dealership == null)
                return BadRequest(new { message = "Brand, Model, or Dealership does not exist." });

            // إنشاء مواصفات السيارة
            var usedCarSpec = new SpecUsedCar
            {
                City = carDto.City,
                Description = carDto.Description,
                Color = carDto.Color,
                FuelType = carDto.FuelType,
                ManufacturingYear = carDto.ManufacturingYear,
                Mileage = carDto.Mileage,
                Transmission = carDto.Transmission,
            };

            // إنشاء كائن السيارة
            var newCar = _mapper.Map<Car>(carDto);
            newCar.Id = Guid.NewGuid().GetHashCode(); // لضمان رقم فريد
            newCar.BrandId = brand.Id;
            newCar.ModelId = model.Id;
            newCar.DealershipId = dealership.Id;
            newCar.specUsedCar = usedCarSpec;

            await _unitOfWork.Repository<Car>().AddAsync(newCar);
            await _unitOfWork.CompleteAsync();

            // رفع الصور
            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Car");
            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            var imageUrls = new List<CarPictureUrl>();
            foreach (var image in carDto.Image)
            {
                if (image != null && image.Length > 0)
                {
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                    string filePath = Path.Combine(uploadFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    imageUrls.Add(new CarPictureUrl { PictureUrl = $"/images/Car/{fileName}" });
                }
            }

            newCar.Url = imageUrls;
            _unitOfWork.Repository<Car>().UpdateAsync(newCar);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Used Car created successfully" });
        }

        [HttpPut("new/{id}")]
        public async Task<IActionResult> UpdateNewCar(int id, [FromForm] InputNewCarDto carDto)
        {
            var spec = new CarWithBrandAndCategoryAndPicUrlAndSpecSpecification(id);
            var car = await _unitOfWork.Repository<Car>().GetByIdWithSpecAsync(spec);

            if (car == null)
            {
                return NotFound(new { message = "Car Not Fount" });
            }

            // تحديث البيانات الأساسية
            car.Price = carDto.Price;

            if (!Enum.TryParse(carDto.Condition, true, out Condition condition))
                return BadRequest(new { message = "حالة السيارة غير صحيحة." });

            car.condition = condition;

            // البحث عن البراند والموديل
            var brand = await _unitOfWork.Repository<Brand>().FindAsync(b => b.Name == carDto.brand);
            var model = await _unitOfWork.Repository<Model>().FindAsync(m => m.Name == carDto.Model);

            if (brand == null || model == null)
            {
                return BadRequest(new { message = "Brand أو Model غير موجود." });
            }

            car.BrandId = brand.Id;
            car.ModelId = model.Id;

            // تحديث المواصفات الجديدة
            if (car.specNewCar == null)
                car.specNewCar = new SpecNewCar();

            car.specNewCar.Gears = carDto.Gears;
            car.specNewCar.Year = carDto.Year;
            car.specNewCar.FuelEfficiency = carDto.FuelEfficiency;
            car.specNewCar.TopSpeed = carDto.TopSpeed;
            car.specNewCar.OriginCountry = carDto.OriginCountry;
            car.specNewCar.AssemblyCountry = carDto.AssemblyCountry;
            car.specNewCar.Acceleration = carDto.Acceleration;
            car.specNewCar.Length = carDto.Length;
            car.specNewCar.Width = carDto.Width;
            car.specNewCar.Height = carDto.Height;
            car.specNewCar.GroundClearance = carDto.GroundClearance;
            car.specNewCar.Wheelbase = carDto.Wheelbase;
            car.specNewCar.TrunkSize = carDto.TrunkSize;
            car.specNewCar.Seats = carDto.Seats;
            car.specNewCar.Drivetrain = carDto.Drivetrain;
            car.specNewCar.Fuel = carDto.Fuel;
            car.specNewCar.HorsePower = carDto.HorsePower;
            car.specNewCar.Transmission = carDto.Transmission;
            car.specNewCar.Color = carDto.Color;

            await UpdateCarImages(car, carDto.Image);

            _unitOfWork.Repository<Car>().UpdateAsync(car);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Update Car Completed Scussefully " });
        }



        [HttpPut("used/{id}")]
        public async Task<IActionResult> UpdateUsedCar(int id, [FromForm] InputUsedCarDto carDto)
        {
            var spec = new CarWithBrandAndCategoryAndPicUrlAndSpecSpecification(id);
            var car = await _unitOfWork.Repository<Car>().GetByIdWithSpecAsync(spec);

            if (car == null)
            {
                return NotFound(new { message = "السيارة غير موجودة." });
            }

            // تحديث البيانات الأساسية
            car.Price = carDto.Price;

            if (!Enum.TryParse(carDto.Condition, true, out Condition condition))
                return BadRequest(new { message = "حالة السيارة غير صحيحة." });

            car.condition = condition;

            var brand = await _unitOfWork.Repository<Brand>().FindAsync(b => b.Name == carDto.brand);
            var model = await _unitOfWork.Repository<Model>().FindAsync(m => m.Name == carDto.Model);

            if (brand == null || model == null)
            {
                return BadRequest(new { message = "Brand أو Model غير موجود." });
            }

            car.BrandId = brand.Id;
            car.ModelId = model.Id;

            if (car.specUsedCar == null)
                car.specUsedCar = new SpecUsedCar();

            car.specUsedCar.City = carDto.City;
            car.specUsedCar.FuelType = carDto.FuelType;
            car.specUsedCar.Transmission = carDto.Transmission;
            car.specUsedCar.Color = carDto.Color;
            car.specUsedCar.ManufacturingYear = carDto.ManufacturingYear;
            car.specUsedCar.Description = carDto.Description;
            car.specUsedCar.Mileage = carDto.Mileage;

            await UpdateCarImages(car, carDto.Image);

            _unitOfWork.Repository<Car>().UpdateAsync(car);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "تم تحديث بيانات السيارة المستعملة والمواصفات والصور بنجاح." });
        }


        private async Task UpdateCarImages(Car car, List<IFormFile> images)
        {
            if (images != null && images.Count > 0)
            {
                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Car");

              
                foreach (var oldImage in car.Url)
                {
                    string oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldImage.PictureUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }
                car.Url.Clear();

                var newImageUrls = new List<CarPictureUrl>();

                foreach (var image in images)
                {
                    if (image != null && image.Length > 0)
                    {
                        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                        string filePath = Path.Combine(uploadFolder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(stream);
                        }

                        newImageUrls.Add(new CarPictureUrl { PictureUrl = $"/images/Car/{fileName}" });
                    }
                }

                car.Url = newImageUrls;
            }
        }

        [HttpDelete("new/{id}")]
        public async Task<IActionResult> DeleteNewCar(int id)
        {
            var spec = new CarWithBrandAndCategoryAndPicUrlAndSpecSpecification(id, Status.New);
            var car = await _unitOfWork.Repository<Car>().GetByIdWithSpecAsync(spec);

            if (car == null || car.specNewCar == null)
            {
                return NotFound(new { message = "السيارة الجديدة غير موجودة." });
            }

            // 🔹 حذف الصور من المجلد
            if (car.Url != null && car.Url.Any())
            {
                foreach (var image in car.Url)
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", image.PictureUrl.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }

           
            _unitOfWork.Repository<SpecNewCar>().DeleteAsync(car.specNewCar);

       
            _unitOfWork.Repository<Car>().DeleteAsync(car);

            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "تم حذف السيارة الجديدة وجميع بياناتها بنجاح." });
        }
        [HttpDelete("used/{id}")]
        public async Task<IActionResult> DeleteUsedCar(int id)
        {
            var spec = new CarWithBrandAndCategoryAndPicUrlAndSpecSpecification(id, Status.Used);
            var car = await _unitOfWork.Repository<Car>().GetByIdWithSpecAsync(spec);

            if (car == null || car.specUsedCar == null)
            {
                return NotFound(new { message = "السيارة المستعملة غير موجودة." });
            }

        
            if (car.Url != null && car.Url.Any())
            {
                foreach (var image in car.Url)
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", image.PictureUrl.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }

        
            _unitOfWork.Repository<SpecUsedCar>().DeleteAsync(car.specUsedCar);

            _unitOfWork.Repository<Car>().DeleteAsync(car);

            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "تم حذف السيارة المستعملة وجميع بياناتها بنجاح." });
        }




    }






}





