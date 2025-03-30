using System.ComponentModel;

namespace SmartFitness
{
	public class Service : INotifyPropertyChanged
	{
		private int idex;
		private string _trainerName;
		private decimal _price;
		private int _discount;

		public int Id
		{
			get { return idex; }
			set {
					if (idex != value)
					{
						idex = value;
					OnPropertyChanged(nameof(idex));
					} 
				}
		}
		public string Услуги
		{
			get { return _trainerName; }
			set
			{
				if (_trainerName != value)
				{
					_trainerName = value;
					OnPropertyChanged(nameof(Услуги));
				}
			}
		}
		public int Срок
		{
			get { return _discount; }
			set
			{
				if (_discount != value)
				{
					_discount = value;
					OnPropertyChanged(nameof(Срок));
				}
			}
		}
		public decimal Рублей
		{
			get { return _price; }
			set
			{
				if (_price != value)
				{
					_price = value;
					OnPropertyChanged(nameof(Рублей));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}