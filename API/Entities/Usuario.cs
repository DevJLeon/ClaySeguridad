using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public virtual ICollection<Rol> IdRolFks { get; set; } = new List<Rol>();
}
