using Microsoft.AspNetCore.Mvc;
using paint_the_wall.src.Models;
using paint_the_wall.src.Services;
using paint_the_wall.src.Views;


namespace paint_the_wall.src.Controllers
{
    [ApiController]
    [Route("api/v1/paint")]
    public class PaintController : ControllerBase
    {

        [HttpPost()]
        public IActionResult Calculate([FromBody] LivingRoom livingRoom)
        {
            if (!livingRoom.Valid()) return BadRequest(new InvalidModelView(livingRoom.Messages));

            return Ok(new Calculate().CalculateCanOfPaint(livingRoom));

        }
    }



}