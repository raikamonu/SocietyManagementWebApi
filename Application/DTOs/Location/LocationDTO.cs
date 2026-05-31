using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }
        public int? ParentId { get; set; }
        public string? ParentName { get; set; }
        public int? TypeId { get; set; }
        public string? TypeName { get; set; }
        public int IsActive { get; set; }



    }
}
