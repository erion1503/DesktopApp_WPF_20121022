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

using System.Windows.Threading;

namespace DesktopApp_WPF_20121022
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        #region "クラス内変数定義(dispacherTimes,dispacherCounter)"
        /// <summary>
        /// クラス内変数定義
        /// </summary>
        DispatcherTimer dispatcherTimerTimes;
        DispatcherTimer dispatcherTimerCounter;
        #endregion

        #region "Window初期化処理(フォーム内継続処理記述)"
        /// <summary>
        /// Window初期化処理 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //時刻表示処理（タイマー）
            dispatcherTimerTimes = new DispatcherTimer(DispatcherPriority.Normal);
            dispatcherTimerTimes.Interval = new TimeSpan(0,0,1);
            dispatcherTimerTimes.Tick += (send, ev)=>
            {
                LabelTimer.Content = DateTime.Now.ToString();
            };
            dispatcherTimerTimes.Start();

            //時間経過処理（カウンター）
            dispatcherTimerCounter = new DispatcherTimer(DispatcherPriority.Normal);
        }
        #endregion

        #region "フォーム初期化時処理"
        /// <summary>
        /// フォーム初期化時処理
        /// </summary>
        /// <param name="send">オブジェクト</param>
        /// <param name="ev">引数</param>
        private void WindowMain_Initialized(object sender, EventArgs e)
        {
            ImageBallon.Visibility = Visibility.Hidden; //吹き出しの非表示(初期値)
            TextBlockMain.Visibility = Visibility.Hidden; //吹き出し文字非表示（初期値）
        }
        #endregion

        #region "コンテキストメニュー【閉じる】処理"
        //コンテキストメニュー【閉じる】処理
        private void MenuItemClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region "イメージ移動処理"
        /// <summary>
        /// イメージ移動処理
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベント引数</param>
        private void ImageMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();

            //吹き出し表示処理
            TextBlockMain.Text = GetText(); //吹き出し文字取得処理
            ImageBallon.Visibility = Visibility.Visible;
            TextBlockMain.Visibility = Visibility.Visible;
            dispatcherTimerCounter.Interval = new TimeSpan(0,0,5); //時間間隔（時,分,秒）

            //吹き出し表示時間計算処理
            dispatcherTimerCounter.Tick += (ss, ee) =>
            {
                ImageBallon.Visibility = Visibility.Hidden;
                TextBlockMain.Visibility = Visibility.Hidden;
            };
            dispatcherTimerCounter.Start();
        }
        #endregion

        #region "コンテキストメニュー【常に表示】選択時処理"
        /// <summary>
        /// コンテキストメニュー【常に表示】選択時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAlwaysDisplay_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = !this.Topmost; //常に表示の切り替え
            MenuItemAlwaysDisplay.IsChecked = !MenuItemAlwaysDisplay.IsChecked;
        }
        #endregion


        //TODO テキストメッセージの作成
        #region "テキストメッセージの作成処理"
        /// <summary>
        /// テキストメッセージの作成処理
        /// </summary>
        /// <returns></returns>
        private string GetText()
        {
            string strText;
            strText = "Hello, have a nice day.";
            return strText;
        }
        #endregion

        #region "画面ロード時処理"
        /// <summary>
        /// 画面ロード時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowMain_Loaded(object sender, RoutedEventArgs e)
        {
            LabelTimer.Content = "00:00:00";
        }
        #endregion

        /// <summary>
        /// value changed処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SliderImageSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //イメージサイズ変更
            ImageMain.Width = 200 + SliderImageSize.Value * 50;
            ImageMain.Height = 200 + SliderImageSize.Value * 50;

            //オフセット変更

        }

        //TODO タイマー処理の作成

        
    }
}
