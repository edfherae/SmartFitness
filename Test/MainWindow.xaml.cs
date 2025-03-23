using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int year, month; 
        public MainWindow()
        {
            InitializeComponent();
            year  = Convert.ToInt32(DateTime.Now.Year); month = Convert.ToInt32(DateTime.Now.Month);
            LoadCalendar(month, year);
        }

        private void PersonelButton_Click(object sender, RoutedEventArgs e)
        {

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
                    CalendarDay day = new CalendarDay(days + "");
                    ScheduleGrid.Children.Add(day);
                    Grid.SetRow(day, r); Grid.SetColumn(day, c);
                    --days;
                    if (days <= 0) return;

                }
        } 
        #endregion
    }
}
