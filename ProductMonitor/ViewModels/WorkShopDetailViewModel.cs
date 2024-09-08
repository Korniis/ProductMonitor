using HandyControl.Controls;
using HandyControl.Data;
using Prism.Navigation.Regions;
using ProductMonitor.Extensions;
using ProductMonitor.Models;
using ProductMonitor.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.ViewModels
{
    public class WorkShopDetailViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private IRegion region;
        public WorkShopDetailViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            ShowBackCommand = new DelegateCommand(ShowBack);
            region = regionManager.Regions[PrismManager.MainViewRegionName];
            this.region = region;


            CreateMachineList();
        }

        public DelegateCommand ShowBackCommand { get; private set; }

        private void ShowBack()
        {
            /*
                        if (region != null)
                        {
                            // 查找 TransitioningContentControl
                            var contentControl = region.Views.OfType<TransitioningContentControl>().FirstOrDefault();

                            if (contentControl != null)
                            {
                                // 修改 TransitionMode
                                contentControl.TransitionMode = TransitionMode.Left2RightWithFade; // 这里可以是你想设置的模式
                            }
                        }*/

            // 导航到指定视图
            regionManager.RequestNavigate(PrismManager.MainViewRegionName, nameof(MonitorUC));

        }

        private List<MachineModel> _MachineList;

        /// <summary>
        /// 机台集合属性
        /// </summary>
        public List<MachineModel> MachineList
        {
            get { return _MachineList; }
            set
            {
                SetProperty(ref _MachineList, value);

            }
        }

        #region 初始化机台列表
        private void CreateMachineList()
        {
            MachineList = new List<MachineModel>();
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int plan = random.Next(100, 1000);//计划量 随机数
                int finished = random.Next(0, plan);//已完成量
                MachineList.Add(new MachineModel
                {
                    MachineName = "焊接机-" + (i + 1),
                    FinishedCount = finished,
                    PlanCount = plan,
                    Status = "作业中",
                    OrderNo = "H202212345678"
                });
            }
        }
        #endregion
    }
}
