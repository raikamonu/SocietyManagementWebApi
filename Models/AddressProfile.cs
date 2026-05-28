using System;
using System.Collections.Generic;

namespace Model;

public partial class AddressProfile
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public int? TypeId { get; set; }

    public int? LocationId { get; set; }

    public string? Pincode { get; set; }

    public string? Landmark { get; set; }

    public virtual Entity? Entity { get; set; }

    public virtual Location? Location { get; set; }

    public virtual MasterTypeDetail? Type { get; set; }
}
