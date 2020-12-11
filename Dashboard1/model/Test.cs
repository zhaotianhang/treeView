using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using LiveCharts;
using LiveCharts.Wpf;

namespace Dashboard1
{
    public class Test
    {
        public int TestId { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public int CateId { get; set; }
        public int level { get; set; }
        public JsonObject Data { get; set; }
        public int ParentTestId { get; set; }
        public virtual Menu Menu { get; set; }
        
        [ForeignKey("ParentTestId")]
        public virtual ICollection<Test>
    ChirdrenTests
        { get; private set; } =
    new ObservableCollection<Test>();
        public virtual ICollection<Category>
        Categorys
        { get; private set; } =
    new ObservableCollection<Category>();

        public SeriesCollection getSeries()
        {
            var Series = new SeriesCollection();
            foreach (Category category in Categorys)
            {
                var lineSeries = new LineSeries();
                lineSeries.Title = category.Name;
                var chartValues = new ChartValues<double>();
                foreach (Product product in category.Products)
                {
                    chartValues.Add(product.Value);
                }
                lineSeries.Values = chartValues;
                Series.Add(lineSeries);
            }
            return Series;
        }
    }
}
