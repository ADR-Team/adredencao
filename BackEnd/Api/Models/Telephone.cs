﻿using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Telephone
{
    public int Id { get; set; }

    public string Telephone1 { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
