using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Church
{
    public int Id { get; set; }

    public string Churche { get; set; } = null!;

    public virtual ICollection<AddressChurch> AddressChurches { get; set; } = new List<AddressChurch>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
