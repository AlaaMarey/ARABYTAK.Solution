using Arabytak.Core.Entities;
using ARABYTAK.APIS.DTOs;
using AutoMapper;

namespace ARABYTAK.APIS.Helpers
{
    public class PictureUrlResolver : IValueResolver<Car, CarDto, List<CarPictureDto>>
    {
        private readonly IConfiguration _configuration;

        public PictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CarPictureDto> Resolve(Car source, CarDto destination, List<CarPictureDto> destMember, ResolutionContext context)
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
