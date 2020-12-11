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

namespace Dashboard1
{
    /// <summary>
    /// TargetPage.xaml 的交互逻辑
    /// </summary>
    public partial class TargetPage : UserControl
    {
        public string imagePath;
        public TargetPage(string path)
        {
            InitializeComponent();
            imagePath = path;
           
        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            if(imagePath!=null)
            imageshow.Source = new BitmapImage(new Uri(imagePath));
        }
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
    }
}
