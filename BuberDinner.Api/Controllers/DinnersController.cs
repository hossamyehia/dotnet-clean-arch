using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("[controller]")]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult GetAllDinners()
    {
        return Ok(new[] { "Dinner1", "Dinner2", "Dinner3" });
    }
}
