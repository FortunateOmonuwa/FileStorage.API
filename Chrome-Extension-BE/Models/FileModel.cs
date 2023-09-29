using System.ComponentModel.DataAnnotations;

namespace Chrome_Extension_BE.Models
{
    public class FileModel
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        public string Name { get; set; } = string.Empty;
        [DataType(DataType.Url)]
        public string FilePath { get; set; } = string.Empty;
        public string FileExtension {  get; set; } = string.Empty;
        [Range(0, 50L * 1024 * 1024, ErrorMessage = "File size is too large. The maximum allowed size is 50 MB.")]
        public string FileSize {  get; set; } = string.Empty;

        public string Url {  get; set; } = string.Empty;
        public DateTime UploadDate { get; set; }
        public string UniqueFileName { get; set; } = string.Empty;
    }
}
