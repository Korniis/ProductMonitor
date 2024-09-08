using HandyControl.Controls;
using HandyControl.Data;
using Prism.Navigation.Regions;
using ProductMonitor.Extensions;
using ProductMonitor.Models;
using ProductMonitor.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace ProductMonitor.ViewModels
{
    public class MonitorUCViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
      //  private readonly IRegion region;
        public MonitorUCViewModel(IRegionManager regionManager)
        {
            //注入区
            this.regionManager = regionManager;
           // this.region = regionManager.Regions[PrismManager.MainViewRegionName];
            //初始区
            InitTimer();
            CreateEnvironmentList();
            CreateAlarmList();
            CreateDeviceList();
            CreateRaderList();
            CreateStuffOutWorkList();
            CreateWorkShopList();



            // 方法区

            ShowDetailCommand = new DelegateCommand(ShowDetail);
        }
        #region 时间日期

        /// <summary>
        /// 时间
        /// </summary>
        private string timeNow = string.Empty;

        public string TimeNow
        {
            get { return timeNow; }
            set { SetProperty(ref timeNow, value); }
        }
        private string dayNow = string.Empty;
        /// <summary>
        /// 星期
        /// </summary>
        public string DayNow
        {
            get { return dayNow; }
            set { SetProperty(ref dayNow, value); }
        }
        private string dateNow = string.Empty;
        /// <summary>
        /// 月日
        /// </summary>
        public string DateNow
        {
            get { return dateNow; }
            set { SetProperty(ref dateNow, value); }
        }
        /// <summary>
        /// 初始化计数器
        /// </summary>
        private void InitTimer()
        {
            DispatcherTimer _timer = new DispatcherTimer();
            _timer.Interval = System.TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_tick;
            _timer.Start();

        }
        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Timer_tick(object? sender, EventArgs e)
        {
            DateNow = DateTime.Now.ToString("yyyy/MM/dd");
            TimeNow = DateTime.Now.ToString("HH:mm:ss");
            DayNow = DateTime.Now.ToString("dddd");
        }
        #endregion

        #region 一行计数
        /// <summary>
        /// 机器计数
        /// </summary>
        private string machineCount = "6982";

        public string MachineCount
        {
            get { return machineCount; }
            set { SetProperty(ref machineCount, value); }
        }
        /// <summary>
        /// 生产计数
        /// </summary>
        private string productCount = "6767";

        public string ProductCount
        {
            get { return productCount; }
            set { SetProperty(ref productCount, value); }
        }
        /// <summary>
        /// 坏件计数
        /// </summary>
        private string badCount = "67927";

        public string BadCount
        {
            get { return badCount; }
            set { SetProperty(ref badCount, value); }
        }
        #endregion

        #region 左侧环境数据
        private ObservableCollection<EnvironmentModel> environmentList;
        public ObservableCollection<EnvironmentModel> EnvironmentList
        {

            get { return environmentList; }
            set { SetProperty(ref environmentList, value); }

        }
        private void CreateEnvironmentList()
        {
            EnvironmentList = new ObservableCollection<EnvironmentModel>();
            EnvironmentList.Add(new EnvironmentModel { EnItName = "光照(Lux)", EnItValue = 123 });
            EnvironmentList.Add(new EnvironmentModel { EnItName = "噪音(db)", EnItValue = 55 });
            EnvironmentList.Add(new EnvironmentModel { EnItName = "温度(℃)", EnItValue = 80 });
            EnvironmentList.Add(new EnvironmentModel { EnItName = "湿度(%)", EnItValue = 43 });
            EnvironmentList.Add(new EnvironmentModel { EnItName = "PM2.5(m³)", EnItValue = 20 });
            EnvironmentList.Add(new EnvironmentModel { EnItName = "硫化氢(PPM)", EnItValue = 15 });
            EnvironmentList.Add(new EnvironmentModel { EnItName = "氮气(PPM)", EnItValue = 18 });




        }
        #endregion

        #region 中间警报
        private ObservableCollection<AlarmModel> alarmList;
        public ObservableCollection<AlarmModel> AlarmList
        {

            get { return alarmList; }
            set
            {
                SetProperty(ref alarmList, value);
            }
        }

        private void CreateAlarmList()
        {
            AlarmList = new ObservableCollection<AlarmModel>();
            AlarmList.Add(new AlarmModel { Num = "01", Msg = "设备温度过高", Time = Convert.ToDateTime("2023-11-23 18:34:56"), Duration = 7 });
            AlarmList.Add(new AlarmModel { Num = "02", Msg = "车间温度过高", Time = Convert.ToDateTime("2043-11-23 18:36:56"), Duration = 10 });
            AlarmList.Add(new AlarmModel { Num = "03", Msg = "设备转速过快", Time = Convert.ToDateTime("2043-11-23 15:34:56"), Duration = 12 });
            AlarmList.Add(new AlarmModel { Num = "03", Msg = "设备转速过快", Time = Convert.ToDateTime("2043-11-23 15:34:56"), Duration = 12 });
            AlarmList.Add(new AlarmModel { Num = "03", Msg = "设备转速过快", Time = Convert.ToDateTime("2043-11-23 15:34:56"), Duration = 12 });
            AlarmList.Add(new AlarmModel { Num = "04", Msg = "设备气压偏低", Time = Convert.ToDateTime("2243-05-23 18:34:56"), Duration = 90 });
            AlarmList.Add(new AlarmModel { Num = "04", Msg = "设备气压偏低", Time = Convert.ToDateTime("2243-05-23 18:34:56"), Duration = 90 });

        }


        #endregion

        #region 初始化设备监控
        private ObservableCollection<DeviceModel> deviceList;

        public ObservableCollection<DeviceModel> DeviceList
        {
            get { return deviceList; }
            set { SetProperty(ref deviceList, value); }
        }

        private void CreateDeviceList()
        {
            DeviceList = new();
            DeviceList.Add(new DeviceModel { DeviceItem = "电能(Kw.h)", Value = 60.8 });
            DeviceList.Add(new DeviceModel { DeviceItem = "电压(V)", Value = 390 });
            DeviceList.Add(new DeviceModel { DeviceItem = "电流(A)", Value = 5 });
            DeviceList.Add(new DeviceModel { DeviceItem = "压差(kpa)", Value = 13 });
            DeviceList.Add(new DeviceModel { DeviceItem = "温度(℃)", Value = 36 });
            DeviceList.Add(new DeviceModel { DeviceItem = "振动(mm/s)", Value = 4.1 });
            DeviceList.Add(new DeviceModel { DeviceItem = "转速(r/min)", Value = 2600 });
            DeviceList.Add(new DeviceModel { DeviceItem = "气压(kpa)", Value = 0.5 });
        }
        #endregion

        #region 雷达

        private ObservableCollection<RaderModel> raderList;

        public ObservableCollection<RaderModel> RaderList
        {
            get { return raderList; }
            set { SetProperty(ref raderList, value); }
        }
        private void CreateRaderList()
        {
            RaderList = new ObservableCollection<RaderModel>();
            RaderList.Add(new RaderModel { ItemName = "排烟风机", Value = 90 });
            RaderList.Add(new RaderModel { ItemName = "客梯", Value = 30.00 });
            RaderList.Add(new RaderModel { ItemName = "供水机", Value = 34.89 });
            RaderList.Add(new RaderModel { ItemName = "喷淋水泵", Value = 69.59 });
            RaderList.Add(new RaderModel { ItemName = "稳压设备", Value = 20 });

        }



        #endregion

        #region 初始化人员缺岗信息

        private List<StuffOutWorkModel> stuffOutWorkList;


        public List<StuffOutWorkModel> StuffOutWorkList
        {
            get { return stuffOutWorkList; }
            set { SetProperty(ref stuffOutWorkList, value); }
        }


        private void CreateStuffOutWorkList()
        {
            StuffOutWorkList = new List<StuffOutWorkModel>();

            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "wwe", Position = "技术员", OutWorkCount = 123 });
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "sajh", Position = "操作员", OutWorkCount = 23 });
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "vghh", Position = "技术员", OutWorkCount = 134 });
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "klds", Position = "统计员", OutWorkCount = 143 });
            StuffOutWorkList.Add(new StuffOutWorkModel { StuffName = "tierv", Position = "技术员", OutWorkCount = 12 });
        }

        #endregion

        #region 初始化车间列表 
        private List<WorkShopModel> workShopList;


        public List<WorkShopModel> WorkShopList
        {
            get { return workShopList; }
            set { SetProperty(ref workShopList, value); }
        }
        private void CreateWorkShopList()
        {
            WorkShopList = new List<WorkShopModel>();
            WorkShopList.Add(new WorkShopModel { WorkShopName = "贴片车间", WorkingCount = 32, WaitCount = 8, WrongCount = 4, StopCount = 0 });
            WorkShopList.Add(new WorkShopModel { WorkShopName = "封装车间", WorkingCount = 20, WaitCount = 8, WrongCount = 4, StopCount = 0 });
            WorkShopList.Add(new WorkShopModel { WorkShopName = "焊接车间", WorkingCount = 68, WaitCount = 8, WrongCount = 4, StopCount = 0 });
            WorkShopList.Add(new WorkShopModel { WorkShopName = "贴片车间", WorkingCount = 68, WaitCount = 8, WrongCount = 4, StopCount = 0 });
        }
        #endregion

        public DelegateCommand ShowDetailCommand { get; private set; }

        private void ShowDetail()
        {
            WorkShopDetailUC workShopDetailUC = new WorkShopDetailUC();

           /*  if (region != null)
            {
                // 查找 TransitioningContentControl
                      var contentControl = region.Views.OfType<TransitioningContentControl>().FirstOrDefault();

                       if (contentControl != null)
                       {
                           // 修改 TransitionMode
                           contentControl.TransitionMode = TransitionMode.Bottom2TopWithFade; // 这里可以是你想设置的模式
                       }
                   }*/
                // ThicknessAnimation thicknessAnimation = new ThicknessAnimation( new Thickness(0, 50, 0, -50),);
                regionManager.RequestNavigate(PrismManager.MainViewRegionName, nameof(WorkShopDetailUC));

            }
            /* public DelegateCommand ShowBackCommand { get; private set; }

             private void ShowBack()
             {
                 WorkShopDetailUC workShopDetailUC = new WorkShopDetailUC();
                 // ThicknessAnimation thicknessAnimation = new ThicknessAnimation( new Thickness(0, 50, 0, -50),);
                 regionManager.RequestNavigate(PrismManager.MainViewRegionName, nameof(MonitorUC));

             }*/




        
        }




    }
