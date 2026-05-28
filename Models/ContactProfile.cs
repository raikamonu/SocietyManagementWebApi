using System;
using System.Collections.Generic;

namespace Model;

public partial class ContactProfile
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public int? TypeId { get; set; }

    public string? Mobileno { get; set; }

    public string? Whatsappno { get; set; }

    public string? EmailId { get; set; }

    public virtual Entity? Entity { get; set; }

    public virtual MasterTypeDetail? Type { get; set; }
}
