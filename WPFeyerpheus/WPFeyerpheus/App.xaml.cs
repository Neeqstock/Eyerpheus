using Eyerpheus.Chests;
using Eyerpheus.Controllers.Eyetracker;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFeyerpheus
{
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            WpfEyeXChest.getChest().getEyeXHost().Start();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            WpfEyeXChest.getChest().getEyeXHost().Dispose();
        }


    }
}
