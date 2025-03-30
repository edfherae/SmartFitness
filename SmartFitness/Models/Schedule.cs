using System;
using System.Collections.Generic;

namespace SmartFitness.Models;

public partial class Schedule
{
    public int Group { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public bool Spent { get; set; }

    public virtual Group GroupNavigation { get; set; }
}
