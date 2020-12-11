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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using Dashboard1.viewModel;
namespace Dashboard1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private byte[] imageTmpByte;
        private static bool _hackyIsFirstWindow = true;
        public bool ShowDismissButton { get; private set; }
        public bool ShowDismissButton1 { get; private set; }
        private static WindowStyle _windowStyle;
        private static ResizeMode _windowResizeMode;
        private static WindowState _windowState;
        public MainWindowViewModel mainWindowViewModel { get; set; }
        private readonly ProductContext _context =
    new ProductContext();
        public ProductContext shareContext { get; set; }
        public MainWindow()
        {
            shareContext = _context;
            InitializeComponent();
            if (_hackyIsFirstWindow)
            {
                mainWindowViewModel = MainWindowViewModel.CreateWithSamples();
            }
            //     DataContext = MainWindowViewModel.CreateWithSamples();
            DataContext = this;
            _hackyIsFirstWindow = false;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier
            // to get up and running
            _context.Database.EnsureCreated();
            // bind to the source
            treeViewMenu.selectedItem_DoubleClick = selectedItem_DoubleClick;
        }
        private void selectedItem_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (TreeViewItem)sender;
            selectedItem.MouseDoubleClick -= selectedItem_DoubleClick;
            var selectedItemModel = (Test)selectedItem.DataContext;
            var name = selectedItemModel.Name;
            var key= selectedItemModel.GetHashCode();

            if (selectedItemModel.level==0)
            {
                var newPage = new TargetPage(selectedItemModel.FullName);
                ((MainWindow)DataContext).mainWindowViewModel.TabContents.Add(new TabContent(name, newPage));
            }
            else
            {
                var newPage = new DataPage((ObservableCollection<Category>)selectedItemModel.Categorys, selectedItemModel.getSeries, Button_Click);
                ((MainWindow)DataContext).mainWindowViewModel.TabContents.Add(new TabContent(name, newPage));
            }
            
            //((MainWindowViewModel)DataContext).TabContents.
        }
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            _context.SaveChanges();
        }
        private void GridBarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
            //if (e.ClickCount == 2)
            //{
            //    if (WindowState != WindowState.Normal)
            //    {
            //        WindowState = WindowState.Normal;

            //    }
            //    else
            //    {
            //        WindowState = WindowState.Maximized;
            //    }
            //}
            //else
            //{
                
            //    Point _mousePoint = Mouse.GetPosition(e.Source as FrameworkElement);
            //    Point pointToWindow = (e.Source as FrameworkElement).PointToScreen(_mousePoint);
            //    double oldWith = Width;
            //    if (0 != (pointToWindow.Y - _mousePoint.Y) || 0 != (pointToWindow.X - _mousePoint.X))
            //    {
            //        WindowState = WindowState.Normal;
            //    }
            //    WindowState = WindowState.Normal;
            //    double newWith = Width;
            //    Top = pointToWindow.Y- _mousePoint.Y;
            //    Left = pointToWindow.X - _mousePoint.X* newWith/oldWith;
            //    DragMove();
            //}
        }

        private void Full_Screen(object sender, RoutedEventArgs e)
        {

            _windowStyle = WindowStyle;
            WindowStyle = WindowStyle.None;
            _windowResizeMode = ResizeMode;
            ResizeMode = ResizeMode.NoResize;
            _windowState = WindowState;
            WindowState = WindowState.Maximized;
            Fullscreen.Visibility = Visibility.Hidden;
            FullscreenExit.Visibility = Visibility.Visible;
        }
        private void Full_Screen_Exit(object sender, RoutedEventArgs e)
        {
            WindowStyle = _windowStyle;
            ResizeMode = _windowResizeMode;
            WindowState = _windowState;
            Fullscreen.Visibility = Visibility.Visible;
            FullscreenExit.Visibility = Visibility.Hidden;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // clean up database connections
            _context.Dispose();
            base.OnClosing(e);
        }
        private void btnSelectUrl_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//默认的打开路径
            op.RestoreDirectory = true;
            //op.Filter = " 网页文件(*.htm)|*.htm|*.html|(*.html)|文本文件(*.txt)|*.txt|所有文件(*.*)|*.* ";
            op.Filter = "图像文件(*.bmp,*.jpg,*.png)| *.bmp; *.jpg; *.png| 所有文件(*.*) | *.*";
            if ((bool)op.ShowDialog())
            {
                if (op.OpenFile() != null)
                {
                    Stream openfile = op.OpenFile();
                    int length = (int)openfile.Length;
                    imageTmpByte = new byte[length];
                    openfile.Read(imageTmpByte, 0, length);
                }
                if (op.FileName != null && op.FileName != "")
                {
                    pathBar.Content = op.FileName;
                    pathBar.Visibility = Visibility.Visible;
                }
            }
            //string path = op.FileName;
            

           
           // LuJingZhuanHuanWenJianLiu(path);
        }
        #region 文件流转换路径
        private string WenJianLiuZhuanHuanLuJing(byte[] byteTuPian)
        {
            try
            {
                string strSaveLuJing = AppDomain.CurrentDomain.BaseDirectory+ "image\\";
                if (!Directory.Exists(strSaveLuJing))
                {
                    Directory.CreateDirectory(strSaveLuJing);
                }
                //拼接日期
                string strWenJianQianZhui = DateTime.Now.Year.ToString()
                                          + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()
                                          + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString()
                                          + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                string strWenJianName = string.Empty;
                //遍历二进制的数组的数组
                string strRiQiWenJian = strWenJianQianZhui + ".png";
                //获取基目录，它由程序集冲突解决程序用来探测程序集。
                string strBaoCunLuJing = System.AppDomain.CurrentDomain.BaseDirectory;
                //拼接路径
                strBaoCunLuJing = strBaoCunLuJing + "image\\" + strRiQiWenJian;
                FileInfo fi = new System.IO.FileInfo(strBaoCunLuJing);
                FileStream fs;
                fs = fi.OpenWrite();
                //将字节块写入文件流。(数组，开始字节索引，长度)
                fs.Write(byteTuPian, 0, byteTuPian.Length);
                //关闭当前流并释放与之关联的所有资源
                fs.Close();
                strWenJianName = strRiQiWenJian;

                return strWenJianName;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region 路径转换文件流
        private string LuJingZhuanHuanWenJianLiu(string strLuJing)
        {
            try
            {
                string strPhotoLuJing = "";
                if (strLuJing != "")
                {
                    //得到服务端所在位置的应用程序集
                    string strSaveLuJing = AppDomain.CurrentDomain.BaseDirectory;
                    //获取图片路径
                    strPhotoLuJing = strSaveLuJing + "image\\" + strLuJing;
                }
                return strPhotoLuJing;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void pathBar_DeleteClick(object sender, RoutedEventArgs e)
        {
            tmpImageClear();
        }
        private void tmpImageClear()
        {
            pathBar.Content = "";
            pathBar.Visibility = Visibility.Hidden;
            imageTmpByte = null;
        }
        private void newTarget_Click(object sender, RoutedEventArgs e)
        {
            if ( pathBar.Content != null && pathBar.Content.ToString() != "")
            {
                //var a = LuJingZhuanHuanWenJianLiu(pathBar.Content.ToString());
                if (imageTmpByte!=null)
                {
                    string name = WenJianLiuZhuanHuanLuJing(imageTmpByte);
                    addNewTarget(FruitTextBox.Text.ToString(), LuJingZhuanHuanWenJianLiu(name));
                }
            }
        }

        private void DialogHost_DialogOpened(object sender, MaterialDesignThemes.Wpf.DialogOpenedEventArgs eventArgs)
        {
            tmpImageClear();
        }
        private void addNewTarget(string name,string path)
        {
            var AddItem = _context.Tests.CreateProxy();
            AddItem.CateId = 0;
            AddItem.level = 0;
            AddItem.ParentTestId = 0;
            AddItem.Name = name;
            AddItem.FullName = path;
            _context.Tests.Add(AddItem);
            _context.SaveChanges();
            ObservableCollection<Test> a = new ObservableCollection<Test>();
            
            List<Test> b = (List<Test>)_context.Tests.Where(t => t.ParentTestId.Equals(0)).ToList();
            foreach (Test test in b)
            {
                a.Add(test);
            }
            treeViewMenu.testViewSource.Source = a;
        }
    }

    internal class ConsumoViewModel
    {
        public List<Consumo> Consumo { get; private set; }

        public ConsumoViewModel(Consumo consumo)
        {
            Consumo = new List<Consumo>();
            Consumo.Add(consumo);
        }
    }

    internal class Consumo
    {
        public string Titulo { get; private set; }
        public int Porcentagem { get; private set; }

        public Consumo()
        {
            Titulo = "Consumo Atual";
            Porcentagem = CalcularPorcentagem();
        }

        private int CalcularPorcentagem()
        {
            return 80; //Calculo da porcentagem de consumo
        }
    }
    public class MyVirtualizingStackPanel : VirtualizingStackPanel
    {
        /// <summary>
        /// Publically expose BringIndexIntoView.
        /// </summary>
        public void BringIntoView(int index)
        {

            this.BringIndexIntoView(index);
        }
    }
}
