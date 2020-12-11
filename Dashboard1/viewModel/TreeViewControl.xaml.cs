using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Dashboard1;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls.Primitives;

namespace Dashboard1.viewModel
{
    /// <summary>
    /// TreeViewControl.xaml 的交互逻辑
    /// </summary>
    public partial class TreeViewControl : UserControl
    {
        private  ProductContext _treeViewContext = new ProductContext();
        public CollectionViewSource testViewSource;
        private CollectionViewSource menuViewSource;
        public Menu Menu;
        private TreeViewItem selectedItem;
        private Test copyItem;
        private TextBox reNameTextBox;

        public MouseButtonEventHandler selectedItem_DoubleClick { get; set; }

        public TreeViewControl()
        {
            
            InitializeComponent();
            testViewSource =
                (CollectionViewSource)FindResource(nameof(testViewSource));
            menuViewSource =
                (CollectionViewSource)FindResource(nameof(menuViewSource));
        }


        public ProductContext MyProperty
        {
            get { return (ProductContext)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(ProductContext), typeof(TreeViewControl), new FrameworkPropertyMetadata(new ProductContext()));


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _treeViewContext = MyProperty;
            // this is for demo purposes only, to make it easier
            // to get up and running
            //_treeViewContext.Database.EnsureCreated();

            // load the entities into EF Core
            //_treeViewContext.Tests.Load();
            ObservableCollection<Test> a = new ObservableCollection<Test>();
            List<Test> b = (List<Test>)_treeViewContext.Tests.Where(t => t.ParentTestId.Equals(0)).ToList();
            foreach (Test test in b)
            {
                a.Add(test);
            }
            testViewSource.Source = a;
            menuViewSource.Source = _treeViewContext.Menu.Where(t => t.MenuId.Equals(1)).ToList();
            //testViewSource.Source =  _treeViewContext.Tests.Local.ToObservableCollection();
        }
        private void ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            Test SelectedItem = departmentTree.SelectedItem as Test;
            ////获取在TreeView.ItemTemplate中定义的TextBox控件
            //SelectedItem.FullName = "True";
            ////_treeViewContext.SaveChanges();
            //testViewSource.DeferRefresh();
            reNameTextBox = FindVisualChild<TextBox>(selectedItem);
            reNameTextBox.Visibility = Visibility.Visible;
            reNameTextBox.SelectAll();
            reNameTextBox.Focus();
            reNameTextBox.Background= System.Windows.Media.Brushes.White;
            //MenuItem a  = ((System.Windows.Controls.MenuItem)e.OriginalSource).DataContext as MenuItem;
            //Test b = ((System.Windows.Controls.ContextMenu)e.Source).DataContext as Test;
            //TreeViewItem t=departmentTree.SelectedItem as TreeViewItem;
            //TreeViewItem item = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            //item.Focus();
            //if (item != null)
            //{
            //    //item.ContextMenu = youjian();///自己写一个contextmenu
            //}
        }
        static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
                source = VisualTreeHelper.GetParent(source);

            return source;
        }
        private void renametextbox_LostFous(object sender, RoutedEventArgs e)
        { 
            reNameTextBox.Visibility = Visibility.Collapsed;
            _treeViewContext.SaveChanges();
        }
        private void item_SelectedItemChanged(object sender, RoutedEventArgs e)
        {
            
            if (selectedItem!=null)
            {
                if (selectedItem == e.OriginalSource as TreeViewItem)
                {
                    return;
                }
                var textBlock = FindVisualChild<TextBlock>(selectedItem);
                textBlock.Foreground = System.Windows.Media.Brushes.Black;
                var packIcon = FindVisualChild<MaterialDesignThemes.Wpf.PackIcon>(selectedItem);
                packIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF993636"));
            }

            selectedItem = e.OriginalSource as TreeViewItem;
            selectedItem.Focus();
            var textBlock1 = FindVisualChild<TextBlock>(selectedItem);
            if (textBlock1 == null)
                return;
            textBlock1.Foreground = System.Windows.Media.Brushes.Black;
            var packIcon1 = FindVisualChild<MaterialDesignThemes.Wpf.PackIcon>(selectedItem);
            packIcon1.Foreground = System.Windows.Media.Brushes.IndianRed;
            //ItemContainerGeneratorStatusChanged(sender, e);
        }

        private void AddItem(int parentId,int type)
        {

        }
        private void deleteItem(int id, int type)
        {

        }
        private T FindVisualChild<T>(Visual visual) where T : Visual
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                Visual child = (Visual)VisualTreeHelper.GetChild(visual, i);
                if (child != null)
                {
                    T correctlyTyped = child as T;
                    if (correctlyTyped != null)
                    {
                        return correctlyTyped;
                    }

                    T descendent = FindVisualChild<T>(child);
                    if (descendent != null)
                    {
                        return descendent;
                    }
                }
            }

            return null;
        }
        private void departmentTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Test SelectedItem = departmentTree.SelectedItem as Test;
            switch (SelectedItem.CateId)
            {
                case 0:
                    departmentTree.ContextMenu = this.Resources["ContextMenu"] as System.Windows.Controls.ContextMenu;
                   break;
                case 1:
                    departmentTree.ContextMenu = this.Resources["ContextMenu1"] as System.Windows.Controls.ContextMenu;
                    break;
            }
        }

        private void renametextbox_LostFous(object sender, KeyboardFocusChangedEventArgs e)
        {
            reNameTextBox.Visibility = Visibility.Collapsed;
            _treeViewContext.SaveChanges();
        }

        private void renametextbox_LostFous(object sender, MouseEventArgs e)
        {
            reNameTextBox.Visibility = Visibility.Collapsed;
            _treeViewContext.SaveChanges();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)

            {
                reNameTextBox.Visibility = Visibility.Collapsed;
                _treeViewContext.SaveChanges();
            }
        }

        private void MenuReName_Click(object sender, RoutedEventArgs e)
        {
            Test SelectedItem = departmentTree.SelectedItem as Test;
            reNameTextBox = FindVisualChild<TextBox>(selectedItem);
            reNameTextBox.Visibility = Visibility.Visible;
            reNameTextBox.SelectAll();
            reNameTextBox.Focus();
            reNameTextBox.Background = System.Windows.Media.Brushes.White;
        }
        private void Command_Delete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Test SelectedItem = departmentTree.SelectedItem as Test;
            e.CanExecute = SelectedItem != null;
            e.Handled = true;
        }

        private void Command_Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Test SelectedItem = departmentTree.SelectedItem as Test;
            if (selectedItem == null) return;
            //Test _selectParentItem= _treeViewContext.Tests.Where(t => t.TestId.Equals(SelectedItem.ParentTestId)).Single();

            TreeViewItem _selectParentItem = GetParentObjectEx<TreeViewItem>(selectedItem) as TreeViewItem;
            ((ObservableCollection<Test>)_selectParentItem.ItemsSource).Remove(SelectedItem);
            _treeViewContext.SaveChanges();
        }
        private void Command_Copy_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Test SelectedItem = departmentTree.SelectedItem as Test;
            e.CanExecute = SelectedItem != null;
            e.Handled = true;
        }

        private void Command_Copy_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Test SelectedItem = departmentTree.SelectedItem as Test;
            if (selectedItem == null) return;
            copyItem = SelectedItem;
        }
        private void Command_Paste_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Test SelectedItem = departmentTree.SelectedItem as Test;
            e.CanExecute = SelectedItem != null && SelectedItem.CateId == 0;
            e.Handled = true;
        }

        private void Command_Paste_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Test SelectedItem = departmentTree.SelectedItem as Test;
            if (selectedItem == null) return;
            //Test _selectParentItem= _treeViewContext.Tests.Where(t => t.TestId.Equals(SelectedItem.ParentTestId)).Single();
            var newCopyItem = new Test();
           // newCopyItem =  ;
            ((ObservableCollection<Test>)selectedItem.ItemsSource).Add(copyItem);
            _treeViewContext.SaveChanges();
        }
        private Test set_id(Test item)
        {
            //item.TestId= DatabaseGenerated(DatabaseGeneratedOption.Identity);

            return item;
        }
        public TreeViewItem GetParentObjectEx<TreeViewItem>(DependencyObject obj) where TreeViewItem : FrameworkElement
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);
            while (parent != null)
            {
                if (parent is TreeViewItem)
                {
                    return (TreeViewItem)parent;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }

        private void MenuAddTask_Click(object sender, RoutedEventArgs e)
        {
            if (selectedItem == null) return;
            Test SelectedItem = departmentTree.SelectedItem as Test;
            var AddItem = _treeViewContext.Tests.CreateProxy();
            AddItem.CateId = 1;
            AddItem.level = SelectedItem.level+1;
            SelectedItem.ChirdrenTests.Add(AddItem);
            _treeViewContext.SaveChanges();
            selectedItem.Items.Refresh();

            TreeViewItem cur1 = GetTreeViewItem(selectedItem, AddItem);
            cur1.Loaded += new_TreeEvent;
        }

        private void MenuAddProject_Click(object sender, RoutedEventArgs e)
        {
            if (selectedItem == null) return;
            Test SelectedItem = departmentTree.SelectedItem as Test;
            var AddItem = _treeViewContext.Tests.CreateProxy();
            AddItem.CateId = 0;
            AddItem.level = SelectedItem.level + 1;
            SelectedItem.ChirdrenTests.Add(AddItem);
            _treeViewContext.SaveChanges();
            selectedItem.Items.Refresh();

            TreeViewItem cur1 = GetTreeViewItem(selectedItem, AddItem);
            cur1.Loaded += new_TreeEvent;
        }
        private TreeViewItem GetTreeViewItem(ItemsControl container, object item)
        {
            if (container != null)
            {
                if (container.DataContext == item)
                {
                    return container as TreeViewItem;
                }

                // Expand the current container
                if (container is TreeViewItem && !((TreeViewItem)container).IsExpanded)
                {
                    container.SetValue(TreeViewItem.IsExpandedProperty, true);
                }

                // Try to generate the ItemsPresenter and the ItemsPanel.
                // by calling ApplyTemplate.  Note that in the
                // virtualizing case even if the item is marked
                // expanded we still need to do this step in order to
                // regenerate the visuals because they may have been virtualized away.

                container.ApplyTemplate();
                ItemsPresenter itemsPresenter =
                    (ItemsPresenter)container.Template.FindName("ItemsHost", container);
                if (itemsPresenter != null)
                {
                    itemsPresenter.ApplyTemplate();
                }
                else
                {
                    // The Tree template has not named the ItemsPresenter,
                    // so walk the descendents and find the child.
                    itemsPresenter = FindVisualChild<ItemsPresenter>(container);
                    if (itemsPresenter == null)
                    {
                        container.UpdateLayout();

                        itemsPresenter = FindVisualChild<ItemsPresenter>(container);
                    }
                }

                Panel itemsHostPanel = (Panel)VisualTreeHelper.GetChild(itemsPresenter, 0);

                // Ensure that the generator for this panel has been created.
                UIElementCollection children = itemsHostPanel.Children;

                MyVirtualizingStackPanel virtualizingPanel =
                    itemsHostPanel as MyVirtualizingStackPanel;

                for (int i = 0, count = container.Items.Count; i < count; i++)
                {
                    TreeViewItem subContainer;
                    if (virtualizingPanel != null)
                    {
                        // Bring the item into view so
                        // that the container will be generated.
                        virtualizingPanel.BringIntoView(i);

                        subContainer =
                            (TreeViewItem)container.ItemContainerGenerator.
                            ContainerFromIndex(i);
                    }
                    else
                    {
                        subContainer =
                            (TreeViewItem)container.ItemContainerGenerator.
                            ContainerFromIndex(i);

                        // Bring the item into view to maintain the
                        // same behavior as with a virtualizing panel.
                        subContainer.BringIntoView();
                    }

                    if (subContainer != null)
                    {
                        // Search the next level for the object.
                        TreeViewItem resultContainer = GetTreeViewItem(subContainer, item);
                        if (resultContainer != null)
                        {
                            return resultContainer;
                        }
                        else
                        {
                            // The object is not under this TreeViewItem
                            // so collapse it.
                            subContainer.IsExpanded = false;
                        }
                    }
                }
            }

            return null;
        }
        private void new_TreeEvent(object sender, EventArgs e)
        {
            //selectedItem.Items.Refresh();
            //selectedItem.ApplyTemplate();
            //selectedItem.UpdateLayout();
           // selectedItem.Items.MoveCurrentToLast();
            //var AddItem = selectedItem.Items.CurrentItem;
            //var element = (TreeViewItem)selectedItem.ItemContainerGenerator.
            //                ContainerFromIndex(selectedItem.Items.CurrentPosition);
            var element = (TreeViewItem)sender;
            //TreeViewItem cur1 = GetTreeViewItem(selectedItem, AddItem);
            element.Loaded -= new_TreeEvent;
            element.SetValue(TreeViewItem.IsSelectedProperty, true);
            reNameTextBox = FindVisualChild<TextBox>(element);

            reNameTextBox.Visibility = Visibility.Visible;
            reNameTextBox.Focus();
            reNameTextBox.Background = System.Windows.Media.Brushes.White;
            reNameTextBox.SelectAll();
        }

        private void TreeItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2){
                selectedItem.MouseDoubleClick += selectedItem_DoubleClick;
            }
        }
    }

}
