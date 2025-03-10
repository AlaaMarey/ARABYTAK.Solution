using System.ComponentModel.DataAnnotations;

namespace ARABYTAK.APIS.DTOs
{
    public class InputNewCarDto :SpecNewCarDto
    {
        public List<IFormFile> Image { get; set; }
        [Required(ErrorMessage = "Brand is required.")]
        public string brand { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Condition is required.")]
        public string Condition { get; set; }
        [Required(ErrorMessage = "Dealership is required.")]
        public string dealership { get; set; }
        
    }
}
