using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard1.viewModel
{
    class TreeNode
    {
        public int NodeId { get; set; }
        public string name { get; set; }
        public string fullName { get; set; }
        public ObservableCollection<TreeNode> chirdren =new ObservableCollection<TreeNode>();
        public void  a() {
        }
    }
    class Tree {
        
        public Tree()
        {
        }
    }
}
