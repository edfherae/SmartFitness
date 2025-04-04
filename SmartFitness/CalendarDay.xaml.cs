using System;
using System.Collections.Generic;
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

namespace SmartFitness
{
    public partial class CalendarDay : UserControl
    {
        public CalendarDay(string today, string regime, string evento)
        {
            InitializeComponent();
            DayLabel.Content = today;
            WorkTimeLabel.Content = regime;
            EventLabel.Content = evento;
        }
    }
}
