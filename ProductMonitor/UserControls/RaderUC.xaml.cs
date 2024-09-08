using ProductMonitor.Models;
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

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// RaderUC.xaml 的交互逻辑
    /// </summary>
    public partial class RaderUC : UserControl
    {
        public RaderUC()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;
        }



        public ObservableCollection<RaderModel> ItemsSource

        {
            get { return (ObservableCollection<RaderModel>)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<RaderModel>), typeof(RaderUC));
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Drag();
        }
        private void Drag()
        {
            if (ItemsSource == null || ItemsSource.Count == 0)
            {

                return;
            }
            mainCanvas.Children.Clear();
            P1.Points.Clear();
            P2.Points.Clear();
            P3.Points.Clear();
            P4.Points.Clear();
            P5.Points.Clear();
            double size = Math.Min(RenderSize.Width, RenderSize.Height);
            LayGrid.Height = size;
            LayGrid.Width = size;
            double raduis = (size / 2);
            double step = 360 / ItemsSource.Count;
            for (int i = 0; i < ItemsSource.Count; i++)
            {
                double x = (raduis - 20) * Math.Cos((step * i - 90) * Math.PI / 180);//x偏移量
                double y = (raduis - 20) * Math.Sin((step * i - 90) * Math.PI / 180);//y偏移量

                //X Y坐标
                P1.Points.Add(new Point(raduis + x, raduis + y));

                P2.Points.Add(new Point(raduis + x * 0.75, raduis + y * 0.75));

                P3.Points.Add(new Point(raduis + x * 0.5, raduis + y * 0.5));
                 
                P4.Points.Add(new Point(raduis + x * 0.25, raduis + y * 0.25));

                //数据多边形
                P5.Points.Add(new Point(raduis + x * ItemsSource[i].Value * 0.01, raduis + y * ItemsSource[i].Value * 0.01));

                TextBlock txt = new TextBlock();
                txt.Width = 60;
                txt.FontSize = 10;
                txt.TextAlignment = TextAlignment.Center;
                txt.Text = ItemsSource[i].ItemName;
                txt.Foreground = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
                txt.SetValue(Canvas.LeftProperty, raduis + (raduis - 10) * Math.Cos((step * i - 90) * Math.PI / 180) - 30);//设置左边间距
                txt.SetValue(Canvas.TopProperty, raduis + (raduis - 10) * Math.Sin((step * i - 90) * Math.PI / 180) - 7);//设置上边间距

                mainCanvas.Children.Add(txt);
            }


        }


    }
}
