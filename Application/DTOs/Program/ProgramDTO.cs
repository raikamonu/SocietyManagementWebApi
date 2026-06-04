using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class ProgramDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? SessionId { get; set; }
        public int? LocationId { get; set; }

        public int? DistrictId { get; set; }
        public int? StateId { get; set; }
        public int? IsActive { get; set; }
        public int? IsDelete { get; set; }

    }
}
