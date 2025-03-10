using Arabytak.Core.Entities;
using Arabytak.Core.Repositories.Contract;
using ARABYTAK.APIS.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARABYTAK.APIS.Controllers
{
  
    public class BrandController :BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<Brand>>> GetBrand()
        {
            var brands = await _unitOfWork.Repository<Brand>().GetAllAsync();
            return Ok(brands);
        }
        [HttpPost("CreateBrand")]
        public async Task<IActionResult> AddBrand([FromForm] string name, [FromForm] IFormFile imageFile)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest(new { message = "يجب إدخال اسم البراند." });
            }

            string imageUrl = null;

            // التحقق من أن هناك صورة مرفوعة
            if (imageFile != null && imageFile.Length > 0)
            {
                // تحديد مسار حفظ الصورة
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Brand");

                // التأكد من أن المجلد موجود، وإذا لم يكن موجودًا يتم إنشاؤه
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // إنشاء اسم ملف فريد
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                string filePath = Path.Combine(uploadsFolder, fileName);

                // حفظ الصورة في السيرفر
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // تخزين الرابط للوصول إلى الصورة
                imageUrl = $"/images/Brand/{fileName}";
            }

            
            var brand = new Brand
            {
                Id = Guid.NewGuid().GetHashCode(),
                Name = name,
                PictureUrl = imageUrl 
            };

            await _unitOfWork.Repository<Brand>().AddAsync(brand);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "تمت إضافة البراند بنجاح!", brandId = brand.Id, imageUrl });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, [FromForm] string? name, [FromForm] IFormFile? imageFile)
        {
            var brand = await _unitOfWork.Repository<Brand>().GetAsync(id);
            if (brand == null)
            {
                return NotFound(new ApiResponse(404,"Brand Not Found") );
            }

        
            if (!string.IsNullOrWhiteSpace(name))
            {
                brand.Name = name;
            }

          
            if (imageFile != null && imageFile.Length > 0)
            {
            
                if (!string.IsNullOrEmpty(brand.PictureUrl))
                {
                    string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", brand.PictureUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Brand");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                brand.PictureUrl = $"/images/brands/{fileName}"; 
            }

            _unitOfWork.Repository<Brand>().UpdateAsync(brand);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Brand Update Sucssefully"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _unitOfWork.Repository<Brand>().GetAsync(id);
            if (brand == null)
            {
                return NotFound(new ApiResponse(404, "Brand Not Found"));
            }

            // حذف الصورة من السيرفر إذا كانت موجودة
            if (!string.IsNullOrEmpty(brand.PictureUrl))
            {
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", brand.PictureUrl.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _unitOfWork.Repository<Brand>().DeleteAsync(brand);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Brand Is Deleted" });
        }






    }
}
