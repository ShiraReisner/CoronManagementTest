using System;
using System.Collections.Generic;

namespace CoronaManagement.Models;

public partial class PersonalDetail
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PatientIdentity { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int NumOfBuilding { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Phone { get; set; } = null!;

    public string MobilePhone { get; set; } = null!;

    public int PersonId { get; set; }

    public virtual ICollection<CoronaDetail> CoronaDetails { get; set; } = new List<CoronaDetail>();

    public virtual ICollection<Vaccination> Vaccinations { get; set; } = new List<Vaccination>();
}
