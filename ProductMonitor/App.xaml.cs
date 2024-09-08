using ProductMonitor.UserControls;
using ProductMonitor.ViewModels;
using ProductMonitor.Views;
using ProductMonitor.Windows;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ProductMonitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
            //return Container.Resolve<SettingWin>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MonitorUC, MonitorUCViewModel>( );
            containerRegistry.RegisterForNavigation<WorkShopDetailUC,WorkShopDetailViewModel>( );
            //Test为自定义的ViewModel类


        }
    }

}
