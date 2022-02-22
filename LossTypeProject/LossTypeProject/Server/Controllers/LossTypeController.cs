using LossTypeProject.Server.Interfaces;
using LossTypeProject.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace LossTypeProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LossTypeController : ControllerBase
    {
        private readonly ILossType _lossTypeService;

        public LossTypeController(ILossType lossTypeService)
        {
            _lossTypeService = lossTypeService;
        }

        [HttpGet]
        public async Task<List<LossType>> Get()
        {
            return await Task.FromResult(_lossTypeService.GetAllLossTypes());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            LossType lossType = _lossTypeService.GetLossTypeData(id);
            if (lossType != null)
            {
                return Ok(lossType);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(LossType lossType)
        {
            _lossTypeService.AddLossType(lossType);
        }

        [HttpPut]
        public void Put(LossType lossType)
        {
            _lossTypeService.UpdateLossType(lossType);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _lossTypeService.DeleteLossType(id);
            return Ok();
        }
    }

   
}
