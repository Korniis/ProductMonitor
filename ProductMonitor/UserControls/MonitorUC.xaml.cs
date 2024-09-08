using ProductMonitor.Views;
using ProductMonitor.Windows;
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

namespace ProductMonitor.UserControls
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class MonitorUC : UserControl
    {
        public MonitorUC()
        {
            InitializeComponent();
        }

        private void Btn_Setting_Click(object sender, RoutedEventArgs e)
        {
            Window currentWindow = Window.GetWindow(this);
            SettingWin settingWin = new SettingWin() { Owner=currentWindow };

            settingWin.ShowDialog();

        }
    }
}
