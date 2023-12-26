using ElectronicsDbApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsDbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly PartDbContext _dbContext;

        public PartController(PartDbContext partDbContext)
        {
            _dbContext = partDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Part>> GetParts()
        {
            return _dbContext.Parts;
        }

        [HttpGet("{partId:int}")]
        public async Task<ActionResult<Part>> GetById(int partId)
        {
            var part = await _dbContext.Parts.FindAsync(partId);
            return part;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Part part)
        {
            await _dbContext.Parts.AddAsync(part);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Part part)
        {
            _dbContext.Parts.Update(part);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{partId:int}")]
        public async Task<ActionResult> Delete(int partId)
        {
            var part = await _dbContext.Parts.FindAsync(partId);
            _dbContext.Parts.Remove(part);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
