﻿using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Tipopersona
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
