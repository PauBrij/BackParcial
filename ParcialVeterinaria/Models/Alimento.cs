using System;
using System.Collections.Generic;

namespace ParcialVeterinaria.Models;

public partial class Alimento
{
    public int IdAlimento { get; set; }

    public string? TipoDeAlimento { get; set; }

    public string? EtapaDeCrecimiento { get; set; }

    public string? TipoDeAnimal { get; set; }
}
