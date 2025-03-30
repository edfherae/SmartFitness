using System;
using System.Collections.Generic;

namespace SmartFitness.Models;

public partial class ScheduleWeekday
{
    public int ScheduleWeekdayId { get; set; }

    public string ScheduleWeekdayType { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
