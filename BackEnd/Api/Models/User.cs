using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string NameComplete { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Rg { get; set; } = null!;

    public short Gender { get; set; }

    public string NameMother { get; set; } = null!;

    public string? NameFather { get; set; }

    public string? Profession { get; set; }

    public bool? Employed { get; set; }

    public short? Education { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public DateOnly? DateOfBaptism { get; set; }

    public DateOnly? DateOfUnion { get; set; }

    public short MaritalStatus { get; set; }

    public short IsALeader { get; set; }

    public short Situation { get; set; }

    public int RoleId { get; set; }

    public int EcclesiasticalPositionId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual EcclesiasticalPosition EcclesiasticalPosition { get; set; } = null!;

    public virtual ICollection<LogsDelete> LogsDeletes { get; set; } = new List<LogsDelete>();

    public virtual ICollection<LogsException> LogsExceptions { get; set; } = new List<LogsException>();

    public virtual ICollection<LogsInsert> LogsInserts { get; set; } = new List<LogsInsert>();

    public virtual ICollection<LogsUpdate> LogsUpdates { get; set; } = new List<LogsUpdate>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Telephone> Telephones { get; set; } = new List<Telephone>();
}
