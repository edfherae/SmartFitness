using System;
using System.Collections.Generic;

namespace SmartFitness.Models;

public partial class Trainer
{
    public int TrainerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Specialization { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
	public override string ToString()
	{
        return $"{FirstName} {LastName}, {Specialization}";
	}
	public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
