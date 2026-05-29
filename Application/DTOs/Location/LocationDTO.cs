using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Location
{
    internal class LocationDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? ParentId { get; set; }
        public int? TypeId { get; set; }
        public int IsActive { get; set; }



    }
}
