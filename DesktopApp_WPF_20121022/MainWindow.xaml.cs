using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DesktopApp_WPF_20121022
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        //Window初期化処理
        public MainWindow()
        {
            InitializeComponent();
        }
        //フォーム初期化時処理
        private void Window_Initialized(object sender, EventArgs e)
        {
            Comment_Ballon_1.Visibility = Visibility.Hidden; //吹き出しの非表示(初期値)
        }
        //コンテキストメニュー【閉じる】選択時処理
        private void MenuItemClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //イメージ移動処理
        private void image1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
            Comment_Ballon_1.Visibility = Visibility.Visible;
        }
        //コンテキストメニュー【常に表示】選択時処理
        private void MenuItemAlwaysDisplay_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = !this.Topmost; //常に表示の切り替え
            MenuItemAlwaysDisplay.IsChecked = !MenuItemAlwaysDisplay.IsChecked;
        }
    }
}
