using Arabytak.Core.Entities;
using ARABYTAK.APIS.DTOs;
using AutoMapper;

namespace ARABYTAK.APIS.Helpers
{
    public class PictureUrlResolver : IValueResolver<Car, CarDto, List<CarPictureDto>>,
                                       IValueResolver<Car,CarListDto, List<CarPictureDto>>
    {
        private readonly IConfiguration _configuration;

        public PictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CarPictureDto> Resolve(Car source, CarDto destination, List<CarPictureDto> destMember, ResolutionContext context)
        {


            return GetCarPicture(source);
        }

        public List<CarPictureDto> Resolve(Car source, CarListDto destination, List<CarPictureDto> destMember, ResolutionContext context)
        {
            return GetCarPicture(source);
        }
        private List<CarPictureDto> GetCarPicture(Car source) 
        {
            if (source.Url != null && source.Url.Any())
            {
                return source.Url.Select(s => new CarPictureDto
                {
                    Url = $"{_configuration["ApiBaseUrl"]}/{s.PictureUrl.TrimStart('/')}"
                }).ToList();
            }
            return new List<CarPictureDto>();
        }
    }
}
