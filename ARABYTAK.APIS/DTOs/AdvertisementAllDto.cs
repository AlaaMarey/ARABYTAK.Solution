namespace ARABYTAK.APIS.DTOs
{
    public class AdvertisementAllDto
    {
        public CarPictureDto Image { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public decimal Price { get; set; }
        public string ContactInfo { get; set; }
    }
}
