using Microsoft.Identity.Client;

namespace Application.DTOs
{
    public class MasterTypeDTO
    { 
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public int? IsActive { get; set; }
    }
}
