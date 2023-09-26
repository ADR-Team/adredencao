using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DateHour { get; set; }

    public int? ChurcheId { get; set; }

    public virtual ICollection<AddressEvent> AddressEvents { get; set; } = new List<AddressEvent>();

    public virtual Church? Churche { get; set; }
}
