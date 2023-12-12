using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Estado
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
}
