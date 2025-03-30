using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartFitness.Models;

public partial class Client : INotifyPropertyChanged
{
	private bool hasChanged;
	[NotMapped]
    public bool HasChanged 
	{
		get => hasChanged;
		set { hasChanged = value; OnPropertyChanged(nameof(HasChanged)); }
	}
    public int clientId;
    public int ClientId 
    { 
        get => clientId; 
        set { clientId = value; OnPropertyChanged(nameof(ClientId)); HasChanged = true; } 
    }

    public string firstName;
    public string FirstName 
    { 
        get => firstName; 
        set { firstName = value; OnPropertyChanged(nameof(FirstName)); HasChanged = true; } 
    }

	public string lastName;
    public string LastName 
    { 
        get => lastName; 
        set { lastName = value; OnPropertyChanged(nameof(LastName)); HasChanged = true; } 
    }

	public string email;
	public string Email
	{
		get => email;
		set { email = value; OnPropertyChanged(nameof(Email)); HasChanged = true; }
	}
	public string phone;
	public string Phone
	{
		get => phone;
		set { phone = value; OnPropertyChanged(nameof(Phone)); HasChanged = true; }
	}
	public DateOnly birthDate;
	public DateOnly BirthDate
	{
		get => birthDate;
		set { birthDate = value; OnPropertyChanged(nameof(BirthDate)); HasChanged = true; }
	}
	public DateOnly startDate;
	public DateOnly StartDate
	{
		get => startDate;
		set { startDate = value; OnPropertyChanged(nameof(StartDate)); HasChanged = true; }
	}
	public int group;
	public int Group
	{
		get => group;
		set { group = value; OnPropertyChanged(nameof(Group)); HasChanged = true; }
	}
	public int? Unassigned { get; set; }

    public virtual Group GroupNavigation { get; set; }
    public event PropertyChangedEventHandler PropertyChanged;
	public Client() { }
	public Client(Client other)
	{
		clientId = other.ClientId;
		firstName = other.FirstName;
		lastName = other.LastName;
		email = other.Email;
		phone = other.Phone;
		birthDate = other.BirthDate;
		startDate = other.StartDate;
		group = other.Group;
		Unassigned = other.Unassigned;
	}
    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
	public override string ToString()
	{
        return $"{LastName} {FirstName}";
	}
}
