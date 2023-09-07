using System;
using System.Collections.Generic;

namespace ParcialVeterinaria.Models;

public partial class Cliente2
{
    public int Cedula { get; set; }

    public string? IdMascota { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }
}
