using System;
using System.Collections.Generic;

namespace Grido.Models;

public partial class User
{
    public int Id { get; set; }

    public int IdRole { get; set; }

    public string Login { get; set; } = null!;

    public string? Nickname { get; set; }

    public string Password { get; set; } = null!;

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Map> Maps { get; set; } = new List<Map>();
}
