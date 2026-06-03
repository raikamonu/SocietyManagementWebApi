using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "SessionTypeId is required")]
        public int? SessionTypeId { get; set; }
        public string? SessionTypeName { get; set; }
        public int? IsActive { get; set; }

        public int? IsDelete { get; set; }
    }
}
