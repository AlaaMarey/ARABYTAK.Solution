using Arabytak.Core.Entities;
using Arabytak.Core.Repositories.Contract;
using ARABYTAK.APIS.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARABYTAK.APIS.Controllers
{
    public class ModelController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost("CreateModel")]
        public async Task<ActionResult> AddModel([FromForm] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest(new ApiResponse(400) );
            }

            var model = new Model
            {
                Name = name
                ,Id= Math.Abs(Guid.NewGuid().GetHashCode())
            };

            await _unitOfWork.Repository<Model>().AddAsync(model);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Model Created", modelId = model.Id });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteModel(int id)
        {
            var model = await _unitOfWork.Repository<Model>().GetAsync(id);
            if (model == null)
            {
                return NotFound(new ApiResponse(400));
            }

            _unitOfWork.Repository<Model>().DeleteAsync(model);
            await _unitOfWork.CompleteAsync();

            return Ok(new { message = "Deleted" });
        }
    }
}
