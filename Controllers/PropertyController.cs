using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearSky.Data;
using ClearSky.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClearSky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController
    {
        private readonly DataContext _db;
        public PropertyController(DataContext db)
        {
            _db = db;

        }
        [HttpGet]
        public async Task<ActionResult<List<Property>>> GetRentableProperties()
        {
            var properties = await _db.Properties.Where(x => x.IsRentable).ToListAsync();
            return properties;
        }
    }
}