using System;
using System.Collections.Generic;

namespace CoronaManagement.Models;

public partial class CoronaDetail
{
    public int PatientId { get; set; }

    public DateTime PositiveDate { get; set; }

    public DateTime NegativeDate { get; set; }

    public int CoronaDetailsId { get; set; }

    public virtual PersonalDetail Patient { get; set; } = null!;
}
