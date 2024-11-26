using ComputerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerApi.Controllers//:D
{
    [Route("computer")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly ComputerContext computerContext;

        public ComputerController(ComputerContext computerContext)
        {
            this.computerContext = computerContext;
        }

        [HttpPost]
        public async Task<ActionResult<Comp>> Post(CreateCompDto createCompDto)
        {
            var comp = new Comp
            {
                Id = Guid.NewGuid(),
                Brand = createCompDto.Brand,
                Type = createCompDto.Type,
                Display = createCompDto.Display,
                Memory = createCompDto.Memory,
                OsId = createCompDto.OsId,
                CreatedTime = DateTime.Now
            };

            if (comp != null)
            {
                await computerContext.Computers.AddAsync(comp);
                await computerContext.SaveChangesAsync();
                return StatusCode(201, comp);
            }

            return BadRequest(new { messages = "Hiba az objektum megadásnál." });
        }

        [HttpGet]
        public async Task<ActionResult<Comp>> Get()
        {
            return Ok(await computerContext.Computers.Select(x => new { x.Brand, x.Type, x.Memory, x.Os.Name }).ToListAsync());

        }

        [HttpGet("numberOfComputers")]
        public async Task<ActionResult> GetNumberOfComputers()
        {
            var comps = await computerContext.Computers.ToListAsync();
            return Ok(new { message = "Sikeres lekérdezés", result = comps.Count });
        }

        [HttpGet("allWindowsOsComputer")]
        public async Task<ActionResult<Comp>> GetAllWindowsOsComputer()
        {
            return Ok(await computerContext.Computers.Where(x => x.Os.Name.Contains("linux")).Select(x => new { comp = x, osName = x.Os.Name }).ToListAsync());
        }

    }
}
