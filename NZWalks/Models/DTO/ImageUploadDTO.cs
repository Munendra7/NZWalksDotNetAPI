using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models.DTO
{
    public class ImageUploadDTO
    {
        [Required]
        public required IFormFile File { get; set; }

        [Required]
        public required string FileName { get; set; }

        public string? FileDescription { get; set; }
    }
}
