﻿using ComputerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComputerApi.Controllers
{
    [Route("osystem")]
    [ApiController]
    public class OsController : ControllerBase
    {
        private readonly ComputerContext computerContext;
        public OsController(ComputerContext computerContext)
        {
            this.computerContext = computerContext;
        }

        [HttpPost]
        public async Task<ActionResult<OSystem>> Post(CreateOsDto createOsDto)
        {
            var os = new OSystem
            {
                Id = Guid.NewGuid(),
                Name = createOsDto.Name,
                CreatedTime = DateTime.Now
            };

            if (os != null)
            {
                await computerContext.OSystem.AddAsync(os);
                await computerContext.SaveChangesAsync();
                return StatusCode(201, os);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<OSystem>> Get()
        {
            return Ok(await computerContext.OSystem.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OSystem>> GetById(Guid id)
        {
            var os = await computerContext.OSystem.FirstOrDefaultAsync(o => o.Id == id);
            if (os != null)
            {
                return Ok(os);
            }

            return NotFound(new { message = "Nincs találat." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OSystem>> Put(UpdateOsDto updateOsDto, Guid id)
        {
            var existingOs = await computerContext.OSystem.FirstOrDefaultAsync(o => o.Id == id);

            if (existingOs != null)
            {
                existingOs.Name = updateOsDto.Name;
                computerContext.OSystem.Update(existingOs);
                await computerContext.SaveChangesAsync();
                return Ok(existingOs);
            }

            return NotFound(new { message = "Nincs találat." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var os = await computerContext.OSystem.FirstOrDefaultAsync(o => o.Id == id);

            if (os != null)
            {

                computerContext.OSystem.Remove(os);
                await computerContext.SaveChangesAsync();
                return Ok(new { message = "Sikeres törlés." });
            }

            return NotFound(new { message = "Nincs találat." });
        }

        [HttpGet("withAllComputer")]
        public async Task<ActionResult<OSystem>> GetWithAllComputer()
        {
            return Ok(await computerContext.OSystem.Include(o => o.Comps).ToListAsync());
        }

        [HttpGet("osOrderDescendant")]
        public async Task<ActionResult<OSystem>> GetOsOrderDescendant()
        {
            return Ok(await computerContext.OSystem.OrderByDescending(x => x.Name).ToListAsync());
        }

    }
}
