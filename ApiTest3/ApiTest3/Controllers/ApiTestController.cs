using ApiTest3.ApiModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest3.Controllers
{

    //attribute, which sets the base route for the controller to api/products
    [Route("api/[controller]")]

    //Attribute API controller and enables various behavior for the controller such as
    //automatic model validation and HTTP 400 responses.
    [ApiController]
    public class ApiTestController : ControllerBase
    {
        private readonly CsharpBdContext _context;

        public ApiTestController(CsharpBdContext context)
        {
            _context = context;
        }

        //The HttpGet attribute is used to specify that this endpoint should respond to GET requests.
        [HttpGet]

        //The method is named GetBeer
        //-----------------
        // The use of async and Task indicates that this method is
        // asynchronous and returns a Task object that can be awaited.
        public async Task<ActionResult<List<Beer>>> GetBeer()
        {
            return Ok(await _context.Beers.ToArrayAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Beer>> PostBeer(Beer newBeer)
        {

            var beer = new Beer()
            {
                Name = newBeer.Name,
                BrandId = newBeer.BrandId,
            };
            _context.Beers.Add(beer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBeer), new { id = beer.Id }, beer);
        }




    }
}
