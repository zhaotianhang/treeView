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
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using LiveCharts;
using LiveCharts.Wpf;
namespace Dashboard1
{
    
    /// <summary>
    /// DataPage.xaml 的交互逻辑
    /// </summary>
    public partial class DataPage : UserControl
    {
        private CollectionViewSource categoryViewSource;
        private CollectionViewSource seriesViewSource;
        public RoutedEventHandler Button_Click;
        public SeriesCollection series { get; set; }
        private Func<SeriesCollection> seriesFunc;
        public Func<double,string> yFormatter { get; set; }
        public string[] labels { get; set; }
        public SeriesCollection testSeriesCollection { get; set; }
        public DataPage(ObservableCollection<Category> dataSource, Func<SeriesCollection> seriesFunc, RoutedEventHandler button_Click)
        {
            InitializeComponent();
            categoryViewSource =
    (CollectionViewSource)FindResource(nameof(categoryViewSource));
            categoryViewSource.Source =dataSource;

            this.seriesFunc = seriesFunc;
            Button_Click = button_Click;

            labels = new[] {"V","B","C","W" };
            yFormatter = value => value.ToString("c");

            //test
            testSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double> { 3, 5, 7, 4 }
                },
                 new ColumnSeries
                {
                    Values = new ChartValues<decimal> { 5, 6, 2, 7 }
                }
            };
            testSeriesCollection.Add(new LineSeries
            {
                Values = new ChartValues<double> { 6, 3, 2, 5 }
            });

            DataContext = this;
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            cartesianChart.Series = seriesFunc();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            // this forces the grid to refresh to latest values
            Button_Click(sender, e);
            categoryDataGrid.Items.Refresh();
            productsDataGrid.Items.Refresh();
            cartesianChart.Series = seriesFunc();
        }
    }
}
