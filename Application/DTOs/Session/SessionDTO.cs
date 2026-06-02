using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? SessionTypeId { get; set; }
        public string? SessionTypeName { get; set; }
        public int? IsActive { get; set; }

        public int? IsDelete { get; set; }
    }
}
