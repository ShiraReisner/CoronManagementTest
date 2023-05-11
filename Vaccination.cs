using System;
using System.Collections.Generic;

namespace CoronaManagement.Models;

public partial class Vaccination
{
    public int VaccinationId { get; set; }

    public string Manufacturer { get; set; } = null!;

    public DateTime Date { get; set; }

    public int PatientId { get; set; }

    public virtual PersonalDetail Patient { get; set; } = null!;
}
