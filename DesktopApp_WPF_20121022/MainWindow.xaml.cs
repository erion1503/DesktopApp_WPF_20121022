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
using System.Windows.Threading; // タイマー処理

namespace DesktopApp_WPF_20121022
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        //バルーンテキスト用変数
        private string bollonText;

        //Window初期化処理
        public MainWindow()
        {
            InitializeComponent();

            // タイマー処理
            DispatcherTimer dispacherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            dispacherTimer.Interval = new TimeSpan(0, 0, 1);
            dispacherTimer.Tick += (sender, e) => // λ式 旧->// dispacherTimer.Tick += new EventHandler(dispacherTimer_Tick);
                {
                    this.Date_LBL_1.Content = DateTime.Now.ToString("yyyy/MM/dd");
                    this.Timer_LBL_1.Content = DateTime.Now.ToString("HH:mm:ss");
                    if (DateTime.Now.Second == 00)
                    {
                        Comment_Ballon_1.Visibility = Visibility.Visible;
                        BLLN_TXTBLK_1.Visibility = Visibility.Visible;
                        bollonText = "今、" + DateTime.Now.Hour + "時だよ。\n    お兄ちゃん。";
                        BLLN_TXTBLK_1.Text = bollonText;
                    }
                };
            dispacherTimer.Start();
        }
        //フォーム初期化時処理
        private void Window_Initialized(object sender, EventArgs e)
        {
            Comment_Ballon_1.Visibility = Visibility.Hidden; //吹き出しの非表示(初期値)
            BLLN_TXTBLK_1.Visibility = Visibility.Hidden; //吹き出し文字の非表示(初期値)
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
            BLLN_TXTBLK_1.Visibility = Visibility.Visible;
            bollonText = "今日はどうしたの？\nお兄ちゃん。";
            BLLN_TXTBLK_1.Text = bollonText;
        }
        //コンテキストメニュー【常に表示】選択時処理
        private void MenuItemAlwaysDisplay_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = !this.Topmost; //常に表示の切り替え
            MenuItemAlwaysDisplay.IsChecked = !MenuItemAlwaysDisplay.IsChecked;
        }
        //マウス離れた時の処理
        private void image1_MouseLeave(object sender, MouseEventArgs e)
        {
            Comment_Ballon_1.Visibility = Visibility.Hidden; //吹き出しの非表示(初期値)
            BLLN_TXTBLK_1.Visibility = Visibility.Hidden; //吹き出しの非表示(初期値)
        }
        //マウス離れた時の処理
        private void MainWindow_1_MouseLeave(object sender, MouseEventArgs e)
        {
            Comment_Ballon_1.Visibility = Visibility.Hidden; //吹き出しの非表示(初期値)
            BLLN_TXTBLK_1.Visibility = Visibility.Hidden; //吹き出しの非表示(初期値)
        }
        //バルーンクリック時処理
        private void Comment_Ballon_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        //バルーンテキストクリック時処理
        private void BLLN_TXTBLK_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
