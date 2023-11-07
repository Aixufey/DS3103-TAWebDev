using Microsoft.AspNetCore.Mvc;
namespace imdb.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MovieImageController : ControllerBase
{
    private readonly IWebHostEnvironment hosting;

    public MovieImageController(IWebHostEnvironment _hosting)
    {
        hosting = _hosting;
    }

    [HttpPost]
    public async Task<IActionResult> PostImage(IFormFile file)
    {
        try
        {
            string wwwrootPath = hosting.WebRootPath;
            string absolutePath = Path.Combine($"{wwwrootPath}/images/{file.FileName}");

            // Stream reader in C# include path and creation of image object
            await using (var fileStream = new FileStream(absolutePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return Ok();
        }
        catch
        {
            return StatusCode(500);
        }
    }
}
