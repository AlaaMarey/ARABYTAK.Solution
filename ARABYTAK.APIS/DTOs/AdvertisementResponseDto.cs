namespace ARABYTAK.APIS.DTOs
{
    public class AdvertisementResponseDto
    {
        public List<CarPictureDto> Url { get; set; }

        public string brand { get; set; }
        public string model { get; set; }
        public string? Description { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public decimal Price { get; set; }
        public int YearOfManufacture { get; set; }
        public decimal Kilometers { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public string Fuel { get; set; }

    }
}
