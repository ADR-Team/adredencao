using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class AddressChurch
{
    public int Id { get; set; }

    public string Street { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string District { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string? AddOnAddress { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public int ChurcheId { get; set; }

    public virtual Church Churche { get; set; } = null!;
}
