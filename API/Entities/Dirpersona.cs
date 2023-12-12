using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Dirpersona
{
    public int Id { get; set; }

    public string Direccion { get; set; }

    public int? IdPersona { get; set; }

    public int? IdTdireccion { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; }

    public virtual Tipodireccion IdTdireccionNavigation { get; set; }
}
