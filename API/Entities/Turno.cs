using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Turno
{
    public int Id { get; set; }

    public string NombreTurno { get; set; }

    public DateTime? HoraTurnoInicio { get; set; }

    public DateTime? HoraTurnoFin { get; set; }

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
