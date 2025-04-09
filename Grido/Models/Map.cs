using System;
using System.Collections.Generic;

namespace Grido.Models;

public partial class Map
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public string? Title { get; set; }

    public int Height { get; set; }

    public int Width { get; set; }

    public string Structure { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
