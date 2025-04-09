using System;
using System.Collections.Generic;

namespace Grido.Models;

public partial class Object
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Key { get; set; }
}
