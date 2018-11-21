using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilePondTest.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class FilesController : Controller
    {

        [HttpPost("Process")]
        public async Task<IActionResult> Post(IFormFile filepond)
        {

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await filepond.CopyToAsync(stream);
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { Success = true });
        }
    }
}