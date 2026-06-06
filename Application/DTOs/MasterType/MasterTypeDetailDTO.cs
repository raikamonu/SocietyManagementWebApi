using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class MasterTypeDetailDTO
    {
        public int? Id { get; set; }
        public decimal? Srno { get; set; }

        public string? Code { get; set; }


        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        public int? ParentId { get; set; }

        public int? MasterTypeId { get; set; }
        public string? MasterTypeName { get; set; }
        public string? ParentName { get; set; }

        public int? IsActive { get; set; }

    }
}
