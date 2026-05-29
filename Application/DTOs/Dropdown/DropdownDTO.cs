using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class DropdownDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
