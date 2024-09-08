using Prism.Common;
using ProductMonitor.Extensions;
using ProductMonitor.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProductMonitor.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion(PrismManager.MainViewRegionName, typeof(MonitorUC));
            this.regionManager = regionManager;
            ShowDetailCommand = new DelegateCommand(ShowDetail);
            // Optionally set the initial view to be displayed

        }

        private UserControl monitor;

        public UserControl Monitor
        {
            get { return monitor; }
            set { SetProperty(ref monitor, value); } // 使用 SetProperty 来触发属性改变通知
        }


        private string _title = "Productor";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand ShowDetailCommand { get; private set; }

        private void ShowDetail()
        {
            WorkShopDetailUC workShopDetailUC = new WorkShopDetailUC();

            // ThicknessAnimation thicknessAnimation = new ThicknessAnimation( new Thickness(0, 50, 0, -50),);
            regionManager.RequestNavigate(PrismManager.MainViewRegionName, nameof(WorkShopDetailUC));

        }
    




    }


}
