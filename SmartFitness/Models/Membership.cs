using System;
using System.Collections.Generic;

namespace SmartFitness.Models;

public partial class Membership
{
    public int MembershipId { get; set; }

    public string MembershipType { get; set; }

    public int Duration { get; set; }

    public decimal Price { get; set; }
}
