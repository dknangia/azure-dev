using HealthCheckAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace HealthCheckAPI.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : Controller
    {
        private readonly FileExtensionContentTypeProvider _contentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider contentTypeProvider)
        {
            _contentTypeProvider = contentTypeProvider;
        }

        [HttpGet("{fileId}")]
        public ActionResult Index(int fileId)
        {
            var pathToFile = "Fido-2023-03-13.pdf";
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);

            if (!_contentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
