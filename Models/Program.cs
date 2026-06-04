using System;
using System.Collections.Generic;

namespace Model;

public partial class Program
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? LocationId { get; set; }

    public int? SessionId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? Date { get; set; }

    public int IsActive { get; set; }
    public int IsDelete { get; set; }

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual Location? Location { get; set; }

    public virtual Session? Session { get; set; }
}
