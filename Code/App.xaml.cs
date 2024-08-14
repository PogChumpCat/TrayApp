using AutostartManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TrayApp.Code.Classes;
using WinFormsApp = System.Windows.Forms.Application;

namespace TrayApp.Code
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        static readonly bool registerShortcutForAllUser = false;
        readonly AutostartManager autostartManager = new AutostartManager(WinFormsApp.ProductName, WinFormsApp.ExecutablePath, registerShortcutForAllUser);
        private readonly BackgroundWorker _worker = new BackgroundWorker();
        private readonly Tray tray = new Tray();


        protected override void OnStartup(StartupEventArgs e)
        {
            _worker.DoWork += DoBackgroundWork;
            _worker.RunWorkerAsync();

            //if (tray.autoStart & !autostartManager.IsAutostartEnabled())
            //{
            //    autostartManager.EnableAutostart();
            //}
            //autostartManager.DisableAutostart();

        }

        private void DoBackgroundWork(object sender, DoWorkEventArgs e)
        {


        }
    }

}
