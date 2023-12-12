using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Tipocontacto
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Contactopersona> Contactopersonas { get; set; } = new List<Contactopersona>();
}
