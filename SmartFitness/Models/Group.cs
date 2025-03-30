using System;
using System.Collections.Generic;

namespace SmartFitness.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; }

    public string Description { get; set; }

    public int ScheduleWeekday { get; set; }

    public TimeOnly ScheduleTime { get; set; }

    public int Trainer { get; set; }

    public int? FreeSeats { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ScheduleWeekday ScheduleWeekdayNavigation { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Trainer TrainerNavigation { get; set; }
}
