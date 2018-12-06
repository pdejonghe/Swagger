using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SwaggerWebAPI.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; } = true;
    }
}
