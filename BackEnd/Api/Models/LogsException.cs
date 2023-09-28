using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class LogsException
{
    public int Id { get; set; }

    public string TitleException { get; set; } = null!;

    public string SummaryException { get; set; } = null!;

    public string CompleteException { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
