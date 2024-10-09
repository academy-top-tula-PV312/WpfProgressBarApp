using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfProgressBarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker worker;
        int progressMin;
        int progressMax;

        public MainWindow()
        {
            InitializeComponent();

            worker = new BackgroundWorker();
            worker.DoWork += DoWork;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;

            progressMin = (int)progress.Minimum;
            progressMax = (int)progress.Maximum;

            datePicker.BlackoutDates.Add(
                new CalendarDateRange
                (new DateTime(2024, 10, 5), new DateTime(2024, 10, 15))
                );
            datePicker.BlackoutDates.Add(
                new CalendarDateRange
                (new DateTime(2024, 10, 25), new DateTime(2024, 10, 30))
                );
            calendar.DisplayDateStart = new DateTime(2024, 5, 1);
            calendar.DisplayDateEnd = new DateTime(2024, 11, 30);

            

        }

        private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                  worker.RunWorkerAsync();
        }

        void DoWork(object sender, DoWorkEventArgs e)
        {
            for (var i = progressMin; i <= progressMax; i++)
            {
                Thread.Sleep(30);
                if(sender is BackgroundWorker worker)
                    worker.ReportProgress((int)i);
                
            }
        }
    }
}