namespace Application.DTOs
{
    public class MasterTypeDetailDTO
    {
        public int? Id { get; set; }

        public string? Code { get; set; }

        public string? Name { get; set; }

        public int? ParentId { get; set; }

        public int? MasterTypeId { get; set; }

        public int? IsActive { get; set; }

    }
}
