    using Arabytak.Core.Entities;

namespace ARABYTAK.APIS.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }  
        public string CarName { get; set; }
        public string status { get; set; }
        public decimal Price { get; set; }
        public string condition { get; set; }
        public string DealershipName { get; set; }
       
       // public int? BrandId { get; set; }
        public string brand { get; set; }
       // public int? ModelId { get; set; }
        
        public string model { get; set; }
        public object Specifications { get; set; }
       // public int CarPictureUrlId { get; set; }
        public List<CarPictureDto> Url { get; set; }
    }
}
