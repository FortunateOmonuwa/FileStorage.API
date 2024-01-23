using System.ComponentModel.DataAnnotations;

namespace FileStorage.API.Models
{
    public class Role
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
