using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dragablz;
using System.Collections.ObjectModel;
namespace Dashboard1
{
    public class MainWindowViewModel
    {
        private readonly IInterTabClient _interTabClient;
        private readonly ObservableCollection<TabContent> _tabContents = new ObservableCollection<TabContent>();

        public MainWindowViewModel()
        {
            _interTabClient = new DefaultInterTabClient();
        }

        public static MainWindowViewModel CreateWithSamples()
        {
            var result = new MainWindowViewModel();

            result.TabContents.Add(new TabContent("主页", new IndexPage()));
            result.TabContents.Add(new TabContent("设置", new IndexPage()));
            //result.TabContents.Add(new TabContent("Introduction", new IntroductionPage()));

            return result;
        }

        public ObservableCollection<TabContent> TabContents
        {
            get { return _tabContents; }
        }

        public IInterTabClient InterTabClient
        {
            get { return _interTabClient; }
        }

        public static Func<object> NewItemFactory
        {
            get { return () => new TabContent("主页", new IndexPage()); }
        }
    }
}
