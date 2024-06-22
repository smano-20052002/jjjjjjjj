using LXP.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LXP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialTypeController : BaseController
    {
        private readonly IMaterialTypeServices _materialTypeServices;

        public MaterialTypeController(IMaterialTypeServices materialTypeServices)
        {
            _materialTypeServices = materialTypeServices;
        }

        [HttpGet("/lxp/course/materialtype")]
        public IActionResult GetAllMaterialType()
        {
            return Ok(CreateSuccessResponse(_materialTypeServices.GetAllMaterialType()));
        }
    }
}
