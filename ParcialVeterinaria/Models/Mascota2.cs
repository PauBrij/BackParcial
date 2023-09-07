using System;
using System.Collections.Generic;

namespace ParcialVeterinaria.Models;

public partial class Mascota2
{
    public int IdMascota { get; set; }

    public int? Cedula { get; set; }

    public string? Raza { get; set; }

    public string? Tipo { get; set; }

    public int? IdAlimento { get; set; }

    public string? Peso { get; set; }

    public string? Edad { get; set; }

    public string? Genero { get; set; }
}
