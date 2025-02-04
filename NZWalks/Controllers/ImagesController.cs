using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.DTO;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        [HttpPost]
        [Route("Upload")]
        public IActionResult Upload([FromForm] ImageUploadDTO request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                return Ok("Uploaded");
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadDTO request)
        {
            var allowedExtentions = new string[] { ".jpg", ".jpeg" };

            if(!allowedExtentions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupoorted File");
            }

            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "Please add less than 10 MB");
            }
        }

    }
}
