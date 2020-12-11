using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace Dashboard1
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MenuItem>
            MenuItems
        { get; private set; } =
            new ObservableCollection<MenuItem>();
    }
}
