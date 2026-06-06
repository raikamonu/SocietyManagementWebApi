using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class MasterTypeDTO
    { 
        public int? Id { get; set; }
        public decimal? Srno { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public int? IsActive { get; set; }

    }





    public class VMasterTypeDTO
    {
        public int Id { get; set; }
        public decimal? Srno { get;  set; }
        public string? Name { get; set; }
        public string? ParentName { get; set; }
        public int? IsActive { get; set; }
    }
}
