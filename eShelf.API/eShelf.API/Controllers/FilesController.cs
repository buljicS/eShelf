using eShelf.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShelf.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileServices _fileServices;

        public FilesController(FileServices fileServices)
        {
            _fileServices = fileServices;
        }

        [HttpPost("upload-new-book")]
        public async Task<IActionResult> UploadBook(IFormFile pdfBook)
        {
            try
            {
                return Ok(await _fileServices.UploadBook(pdfBook));
            }
            catch 
            {
                throw;
            }
        }
    }
}
