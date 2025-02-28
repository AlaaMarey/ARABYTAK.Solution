using System.ComponentModel.DataAnnotations;

namespace ARABYTAK.APIS.DTOs
{
    public class AdvertisementUpdateDto
    {
        [Required(ErrorMessage = "Brand is required.")]
        public string brand { get; set; }
        [Required(ErrorMessage = "Model is required.")]
        public string model { get; set; }
        [Required(ErrorMessage = "Year of manufacture is required.")]
        public int YearOfManufacture { get; set; }
        [Required(ErrorMessage = "Kilometers must be specified.")]

        public decimal Kilometers { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Transmission type is required.")]
        public string Transmission { get; set; }
        [Required(ErrorMessage = "Car color is required.")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Fuel type is required.")]
        public string Fuel { get; set; }
        [Required(ErrorMessage = "Car price must be specified.")]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]

        public decimal Price { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Seller email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string SellerEmail { get; set; }
        [Required(ErrorMessage = "Contact information is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string ContactInfo { get; set; }
    }
}
