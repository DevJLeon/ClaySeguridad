using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Rol
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public virtual ICollection<Usuario> IdUsuarioFks { get; set; } = new List<Usuario>();
}
