using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class AddressEvent
{
    public int Id { get; set; }

    public string Street { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string District { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string? AddOnAddress { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public int EventId { get; set; }

    public virtual Event Event { get; set; } = null!;
}
