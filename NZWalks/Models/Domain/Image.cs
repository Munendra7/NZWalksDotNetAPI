using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.Models.Domain
{
    public class Image
    {
        public Guid Id { get; set; }

        [NotMapped]
        public required IFormFile File { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public string? FileExtension { get; set; }

        public long FileSizeInBytes { get; set; }

        public required string FilePath { get; set; }
    }
}
