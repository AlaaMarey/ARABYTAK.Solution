using Arabytak.Core.Entities;
using ARABYTAK.APIS.DTOs;
using AutoMapper;

namespace ARABYTAK.APIS.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Car, CarDto>()
                .ForMember(c => c.DealershipName, d => d.MapFrom(s => s.dealership.Name))
                .ForMember(c => c.brand, d => d.MapFrom(s => s.brand.Name))
                .ForMember(c => c.model, d => d.MapFrom(s => s.model.Name))
                .ForMember(c=>c.Id,d=>d.MapFrom(s=>s.Id))
              .ForMember(c => c.Url, d => d.MapFrom(s => s.Url.Select(u => new CarPictureDto { Url = u.PictureUrl }).ToList()))
            .ForMember(dest => dest.Url, opt => opt.MapFrom<PictureUrlResolver>());
            //.ForMember(c=>c.Url,d=>d.MapFrom(s=>s.Url.SelectMany(u=>u.PictureUrl )))
            CreateMap<SpecNewCar, SpecNewCarDto>().ReverseMap();
            CreateMap<SpecUsedCar, SpecUsedCarDto>().ReverseMap();
            CreateMap<SpecUsedCarDto,SpecUsedCar>().ReverseMap();
            CreateMap<CarPictureUrl, CarPictureDto>();
            CreateMap<Car, CarListDto>()
                .ForMember(c => c.DealershipName, d => d.MapFrom(s => s.dealership.Name))
                .ForMember(c => c.Price, d => d.MapFrom(s => s.Price))
                .ForMember(c => c.condition, d => d.MapFrom(s => s.condition))
                .ForMember(c=>c.CarName,d=>d.MapFrom(s=>$"{s.brand.Name} {s.model.Name}"))
                .ForMember(c => c.Url, d => d.MapFrom(s => s.Url.Select(u => new CarPictureDto { Url = u.PictureUrl }).ToList()))
            .ForMember(dest => dest.Url, opt => opt.MapFrom<PictureUrlResolver>());
            CreateMap<AdvertisementDto, Advertisement>()
                        .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                        .ForMember(dest => dest.SellerEmail, opt => opt.MapFrom(src => src.SellerEmail))
                        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))

                        // ربط السيارة بمعلومات العلامة التجارية والموديل
                        .ForMember(dest => dest.Car, opt => opt.MapFrom(src => new Car
                        {
                            model = new Model { Name = src.model ?? string.Empty },
                            brand = new Brand { Name = src.brand ?? string.Empty },
                            specUsedCar = new SpecUsedCar
                            {
                                ManufacturingYear = src.YearOfManufacture,
                                Mileage = src.Kilometers,
                                Transmission = src.Transmission,
                                Color = src.Color,
                                FuelType = src.Fuel,
                                City = src.Address
                            }
                        }))
                        .ForMember(dest => dest.planForAdvertisement, opt => opt.MapFrom(src => new AdPlan
                        {
                            planType = (PlanType)src.TypeOfPlan,
                            Price = src.PriceOfPlan,
                        }))
                        .ForPath(dest => dest.Car.Url, opt => opt.Ignore());// تجاهل رابط الصورة
            CreateMap<Advertisement, AdvertisementResponseDto>()
.ForMember(dest => dest.brand, opt => opt.MapFrom(src => src.Car.brand.Name))
.ForMember(dest => dest.model, opt => opt.MapFrom(src => src.Car.model.Name))
.ForMember(dest => dest.YearOfManufacture, opt => opt.MapFrom(src => src.Car.specUsedCar.ManufacturingYear))
.ForMember(dest => dest.Kilometers, opt => opt.MapFrom(src => src.Car.specUsedCar.Mileage))
.ForMember(dest => dest.Transmission, opt => opt.MapFrom(src => src.Car.specUsedCar.Transmission))
.ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Car.specUsedCar.Color))
.ForMember(dest => dest.Fuel, opt => opt.MapFrom(src => src.Car.specUsedCar.FuelType))
.ForMember(dest=>dest.Address,opt=>opt.MapFrom(src=>src.Car.specUsedCar.City))


.ForMember(dest => dest.Url, opt => opt.MapFrom(s =>
    s.Car.Url.Select(p => new CarPictureDto { Url = p.PictureUrl }).ToList()));


            CreateMap<AdvertisementUpdateDto, Advertisement>()
    .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
    .ForMember(dest => dest.SellerEmail, opt => opt.MapFrom(src => src.SellerEmail))
    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))

    // تحديث بيانات السيارة بدلاً من إنشائها من جديد
    .ForMember(dest => dest.Car, opt => opt.MapFrom((src, dest) =>
    {
        if (dest.Car == null) dest.Car = new Car();

        dest.Car.model ??= new Model();
        dest.Car.brand ??= new Brand();
        dest.Car.specUsedCar ??= new SpecUsedCar();

        dest.Car.model.Name = src.model ?? dest.Car.model.Name;
        dest.Car.brand.Name = src.brand ?? dest.Car.brand.Name;
        dest.Car.specUsedCar.ManufacturingYear = src.YearOfManufacture;
        dest.Car.specUsedCar.Mileage = src.Kilometers;
        dest.Car.specUsedCar.Transmission = src.Transmission;
        dest.Car.specUsedCar.Color = src.Color;
        dest.Car.specUsedCar.FuelType = src.Fuel;
        dest.Car.specUsedCar.City = src.Address;

        return dest.Car;
    }));




            CreateMap<Advertisement,AdvertisementAllDto>()
                .ForMember(dest => dest.brand, opt => opt.MapFrom(src => src.Car.brand.Name))
                .ForMember(dest => dest.model, opt => opt.MapFrom(src => src.Car.model.Name))
                .ForMember(dest=>dest.Price,opt=>opt.MapFrom(src=>src.Price))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src =>
     src.Car.Url.Select(url => new CarPictureDto { Url = url.PictureUrl }).FirstOrDefault()));

            CreateMap<InputNewCarDto, Car>()
    .ForMember(dest => dest.Id, opt => opt.Ignore()) // يتم توليده تلقائيًا
    .ForMember(dest => dest.BrandId, opt => opt.Ignore()) // يتم تحديده داخل الـ Controller
    .ForMember(dest => dest.ModelId, opt => opt.Ignore())
    .ForMember(dest => dest.DealershipId, opt => opt.Ignore())
     .ForMember(dest => dest.dealership, opt => opt.Ignore())
     .ForMember(dest => dest.brand, opt => opt.Ignore()) // تجاهل التعيين التلقائي لـ Brand
    .ForMember(dest => dest.model, opt => opt.Ignore()) // تجاهل التعيين التلقائي لـ Model
    .ForMember(dest => dest.specNewCar, opt => opt.MapFrom(src => new SpecNewCar
    {
        Gears = src.Gears,
        Fuel = src.Fuel,
        FuelEfficiency = src.FuelEfficiency,
        Acceleration = src.Acceleration,
        Drivetrain = src.Drivetrain,
        AssemblyCountry = src.AssemblyCountry,
        Color = src.Color,
        GroundClearance = src.GroundClearance,
        Height = src.Height,
        HorsePower = src.HorsePower,
        Length = src.Length,
        OriginCountry = src.OriginCountry,
        Seats = src.Seats,
        TopSpeed = src.TopSpeed,
        Transmission = src.Transmission,
        TrunkSize = src.TrunkSize,
        Wheelbase = src.Wheelbase,
        Width = src.Width,
        Year = src.Year
    }))
    .ForMember(dest => dest.Url, opt => opt.Ignore()); // يتم تحديد الصور داخل الـ Controller

            CreateMap<InputUsedCarDto, Car>()
   .ForMember(dest => dest.Id, opt => opt.Ignore()) // يتم توليده تلقائيًا
   .ForMember(dest => dest.BrandId, opt => opt.Ignore()) // يتم تحديده داخل الـ Controller
   .ForMember(dest => dest.ModelId, opt => opt.Ignore())
   .ForMember(dest => dest.DealershipId, opt => opt.Ignore())
    .ForMember(dest => dest.dealership, opt => opt.Ignore())
    .ForMember(dest => dest.brand, opt => opt.Ignore()) // تجاهل التعيين التلقائي لـ Brand
   .ForMember(dest => dest.model, opt => opt.Ignore()) // تجاهل التعيين التلقائي لـ Model
   .ForMember(dest => dest.specUsedCar, opt => opt.MapFrom(src => new SpecUsedCar
   {
      City = src.City,
      Description   = src.Description,
      Color = src.Color,
      FuelType= src.FuelType,
      ManufacturingYear = src.ManufacturingYear,
      Mileage=src.Mileage,
      Transmission=src.Transmission,
   }))
   .ForMember(dest => dest.Url, opt => opt.Ignore());




        }


    }
    }

