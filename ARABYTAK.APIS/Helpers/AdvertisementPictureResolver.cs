using Arabytak.Core.Entities;
using ARABYTAK.APIS.DTOs;
using AutoMapper;

namespace ARABYTAK.APIS.Helpers
{
    public class AdvertisementPictureResolver : IValueResolver<Advertisement, AdvertisementDto, List<CarPictureDto>>
    {
        private readonly IConfiguration _configuration;

        public AdvertisementPictureResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<CarPictureDto> Resolve(Advertisement source, AdvertisementDto destination, List<CarPictureDto> destMember, ResolutionContext context)
        {
            if(source.Car.Url!=null&&source.Car.Url.Any())
            {
                return source.Car.Url.Select(p => new CarPictureDto
                {
                    Url = $"{_configuration["ApiBaseUrl"]}/{p.PictureUrl.TrimStart('/')}"
                }).ToList();
            };
            return new List<CarPictureDto>();
        }
    }
}
