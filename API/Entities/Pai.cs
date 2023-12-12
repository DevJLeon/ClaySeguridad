using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Pai
{
    public int Id { get; set; }

    public string NombrePais { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
