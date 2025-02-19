namespace ARABYTAK.APIS.DTOs
{
    public class CarListDto
    {
        public string CarName { get; set; }
        public decimal Price { get; set; }
        public string condition { get; set; }
        public string DealershipName { get; set; }
        public List<CarPictureDto> Url { get; set; }
    }
}
