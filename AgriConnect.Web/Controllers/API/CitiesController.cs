using AgriConnect.Shared;
using AgriConnect.Web.Data;
using AgriConnect.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgriConnect.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly DataContext dataContext;

        public CitiesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await this.dataContext.Cities.ToListAsync());
        }
        //[HttpGet]
        //public IActionResult GetCities()
        //{
        //    return Ok(this.dataContext.Cities.ToList());
        //}
        [HttpPost]
        public async Task<IActionResult> PostCity([FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            try
            {
                this.dataContext.Cities.Add(city);
            await this.dataContext.SaveChangesAsync();
            return Ok(city);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una ciudad con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity([FromRoute] int id, [FromBody] City city)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            if (id != city.Id)
            {
                return BadRequest();
            }
            try
            {
                this.dataContext.Cities.Update(city);
                await this.dataContext.SaveChangesAsync();
                return Ok(city);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una ciudad con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var city = await this.dataContext.Cities.FirstOrDefaultAsync(x => x.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            this.dataContext.Cities.Remove(city);
            await this.dataContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
