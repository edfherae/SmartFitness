//using FitnessApp;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Design;
using SmartFitness.Models;

namespace SmartFitness
{
	public partial class MainWindow : Window
	{
		int year, month;
		private string connectionString;
		public ObservableCollection<Service> Services { get; set; }  
		public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
		private Service _selectedService;
		private DbSmartFitness1Context DbContext { get; } = new DbSmartFitness1Context();
		private Client temp_client; //такого быть не должно, по-хорошему, привязать бы как-то к табу

		public MainWindow()
		{
			InitializeComponent();

			GridView gvPersonal = new GridView();
			this.listViewPersonal.View = gvPersonal;
			gvPersonal.Columns.Add(new GridViewColumn() { Header = "Имя", Width = 100, DisplayMemberBinding = new Binding("FirstName") });
			gvPersonal.Columns.Add(new GridViewColumn() { Header = "Фамилия", Width = 100, DisplayMemberBinding = new Binding("LastName") });
			gvPersonal.Columns.Add(new GridViewColumn() { Header = "Специализация", Width = 200, DisplayMemberBinding = new Binding("Specialization") });
			gvPersonal.Columns.Add(new GridViewColumn() { Header = "Почта", Width = 140, DisplayMemberBinding = new Binding("Email") });
			gvPersonal.Columns.Add(new GridViewColumn() { Header = "Телефон", Width = 140, DisplayMemberBinding = new Binding("Phone") });
			this.listViewPersonal.ItemsSource = DbContext.Trainers.ToList();

	 		//listBoxClientInfo.Items.Add(new SmartFitness.Models.Client() { FirstName = "1", LastName = "2"});
			//listBoxClientInfo.Items.Add(new SmartFitness.Models.Client() { FirstName = "3", LastName = "4"});

			listViewClients.ItemsSource = DbContext.Clients.ToList();

			//BindingExpression be = textBoxClientId.GetBindingExpression(TextBox.TextProperty);
			//be?.UpdateTarget();

			//GridView gvClients = new();
			//this.listViewClients.View = gvClients;
			//gvClients.Columns.Add(new GridViewColumn() { Header = "Имя", Width = 100, //DisplayMemberBinding = new Binding("FirstName") });
			//gvClients.Columns.Add(new GridViewColumn() { Header = "Фамилия", Width = 100, DisplayMemberBinding = new Binding("LastName") });
			////this.listViewClients.ItemsSource = DbContext.Clients.ToList();
			//listViewClients.items

			year = Convert.ToInt32(DateTime.Now.Year); month = Convert.ToInt32(DateTime.Now.Month);
			LoadCalendar(month, year);

			//connectionString = ConfigurationManager.ConnectionStrings["DB_Smart_Fitness_1"].ConnectionString; // своя база
			//connection = new SqlConnection(connectionString);
			#region Услуги

			// Добавление услуг
			//Services = new ObservableCollection<Service>();
			//LoadDataFromDatabaseServices();
			//DataContext = this;
			//ServicesDataGrid.ItemsSource = Services;

			//Services.Add(new Service { Услуги = "Для Детей", Рублей = 1200, Срок = "1 месяц" });
			//Services.Add(new Service { Услуги = "Молодёж", Рублей = 2000, Срок = "1 месяц" });
			//Services.Add(new Service { Услуги = "Обычный", Рублей = 2350, Срок = "1 месяц" });
			//Services.Add(new Service { Услуги = "PRO", Рублей = 21000, Срок = "1 год" });

			//DataContext = this;
			//ServicesDataGrid.ItemsSource = Services;
			#endregion
			#region Клиенты

			//LoadClientDataFromDatabase();
			//DataGridClients.ItemsSource = Clients;

			#endregion
		}
		private void LoadDataFromDatabaseServices()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = "SELECT membership_id, membership_type, duration, price FROM Memberships"; // Измените, если нужно

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Service service = new Service();
								service.Id = Convert.ToInt32(reader["membership_id"]);
								service.Услуги = reader["membership_type"] as string; 
								service.Срок = Convert.ToInt32(reader["duration"]); 
								service.Рублей = Convert.ToDecimal(reader["price"]);

								Services.Add(service);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show($"Error loading {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private void LoadClientDataFromDatabase()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					string query = "SELECT first_name, last_name, email, phone, birth_date, start_date, [group], unassigned FROM Clients";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								// Объявляем переменную client внутри цикла
								//Client client = new Client();
								//client.Name = reader["first_name"] as string;
								//client.LastName = reader["last_name"] as string;
								//client.email = reader["email"] as string;
								//client.Номер = reader["phone"] as string;
								//client.birth_date = reader["birth_date"] as DateTime?; // Используем DateTime? для обработки null
								//client.start_date = reader["start_date"] as DateTime?; // Используем DateTime? для обработки null
								//client.Группа = Convert.ToInt32(reader["group"]);
								//client.Pезерв = Convert.ToInt32(reader["unassigned"]);
								//Clients.Add(client);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show($"Error loading client {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void PersonelButton_Click(object sender, RoutedEventArgs e)
		{

		}
		private void PurchaseServiceButton_Click(object sender, RoutedEventArgs e)
		{
			// Получаем первого клиента из списка (если он есть)
			//Client selectedClient = Clients.FirstOrDefault();

			// Проверяем, что клиент найден (список не пуст)
			//if (selectedClient == null)
			//{
			//	System.Windows.MessageBox.Show("В базе данных нет клиентов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			//	return;
			//}

			//// Проверяем, что услуга выбрана
			//if (_selectedService == null)
			//{
			//	System.Windows.MessageBox.Show("Пожалуйста, выберите услугу из списка.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			//	return;
			//}

			// Строим сообщение для MessageBox с подтверждением покупки
			//string message = $"Вы уверены, что хотите купить услугу '{_selectedService.Услуги}' для клиента '{selectedClient.Name} {selectedClient.LastName}'?";

			// Показываем MessageBox с вопросом о подтверждении
			//MessageBoxResult result = System.Windows.MessageBox.Show(message, "Подтверждение покупки", MessageBoxButton.YesNo, MessageBoxImage.Question);

			//// Если пользователь подтвердил покупку
			//if (result == MessageBoxResult.Yes)
			//{
			//	// Обновляем поле unassingned для выбранного клиента в базе данных
			//	////////////////////////////////////////////////////////////////////// Доработать!
			//	//UpdateUnassignedForClient(selectedClient, _selectedService);
			//}
		}

		// Метод для обновления поля unassingned для клиента в базе данных
		private void UpdateUnassignedForClient(Client client, Service service)
		{
			try
			{
				// Используем блок using для автоматического закрытия соединения после завершения работы
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					// Открываем соединение с базой данных
					connection.Open();

					// SQL-запрос для обновления поля unassingned
					string query = "UPDATE Clients SET unassingned = ISNULL(unassingned + ', ', '') + @ServiceName WHERE first_name = @FirstName AND last_name = @LastName";

					// Используем блок using для автоматического освобождения ресурсов команды SQL
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						// Задаем параметры запроса (для защиты от SQL-инъекций)
						//command.Parameters.AddWithValue("@ServiceName", service.Услуги);
						//command.Parameters.AddWithValue("@FirstName", client.Name);
						//command.Parameters.AddWithValue("@LastName", client.LastName);

						// Выполняем запрос
						command.ExecuteNonQuery();
					}

					// Обновляем коллекцию Clients, чтобы DataGrid обновился
					LoadClientDataFromDatabase();
				}
			}
			catch (Exception ex)
			{
				// Обрабатываем ошибки и выводим сообщение пользователю
				System.Windows.MessageBox.Show($"Ошибка при обновлении unassingned: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
    
		// Выбор услуги
		private Service SelectService()
		{
			string message = "Введите название услуги:";
			
			string result = Microsoft.VisualBasic.Interaction.InputBox(message, "Выбор услуги", "");
			
			foreach (Service service in Services)
			{
				if (result == service.Услуги)
				{
					return service;
				}
			}
			
			return null;
		}
		private void ServicesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// Получаем выбранную услугу из DataGrid
			_selectedService = ServicesDataGrid.SelectedItem as Service;

			// Если услуга выбрана, активируем кнопку "Purchase Service"
			PurchaseService.IsEnabled = _selectedService != null;
		}

		#region CalendarStuff
		private void NextMonthButton_Click(object sender, RoutedEventArgs e)
		{
			if (month + 1 == 13) { month = 1; ++year; }
			else ++month;
			LoadCalendar(month, year);
		}

		private void PastMonthButton_Click(object sender, RoutedEventArgs e)
		{
			if (month - 1 == 0) { month = 12; --year; }
			else --month;
			LoadCalendar(month, year);
		}

		private void listViewClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (listViewClients.SelectedIndex != -1) 
			{ 
				temp_client = new((Client)listViewClients.SelectedItem);
				temp_client.HasChanged = false;
				gridClientInfo.DataContext = temp_client; 
				ButtonSaveClient.IsEnabled = false;
			}
		}

		private void gridClientInfo_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			//отследить изменение копии, после врубить кнопку сохранения
		}

		private void Log_in_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			SmartFitnessLogin smart = new SmartFitnessLogin();
			smart.Show();
		}

		private void LoadCalendar(int month, int year)
		{
			ScheduleGrid.Children.Clear();
			string monthname = new DateTimeFormatInfo().GetMonthName(month);  // name of month 
			MonthYearLabel.Content = monthname + ", " + year;

			int days = DateTime.DaysInMonth(year, month); // days in month
			DateTime endday = new DateTime(year, month, days);

			int weekday = Convert.ToInt32(endday.DayOfWeek);
			weekday = (weekday == 0 ? 6 : weekday - 1);

			for (int r = 5; r >= 0; --r)
				for (int c = 6; c >= 0; --c)
				{
					if (r == 5 & c > weekday) continue;
					CalendarDay day = new CalendarDay(days + "", "00:00 - 00:00");
					ScheduleGrid.Children.Add(day);
					Grid.SetRow(day, r); Grid.SetColumn(day, c);
					--days;
					if (days <= 0) return;

				}
		}
		#endregion
	}
}
