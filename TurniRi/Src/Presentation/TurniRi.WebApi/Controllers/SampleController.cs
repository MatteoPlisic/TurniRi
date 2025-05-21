using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SampleController : ControllerBase
{
    [HttpGet("hello")]
    public IActionResult GetHello()
    {
        return Ok("Hello, world!");
    }
}