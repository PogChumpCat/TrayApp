using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TrayApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly BackgroundWorker _worker = new BackgroundWorker();
        protected override void OnStartup(StartupEventArgs e)
        {
            _worker.DoWork += DoBackgroundWork;
            _worker.RunWorkerAsync();

        }

        private void DoBackgroundWork(object sender, DoWorkEventArgs e)
        {


        }
    }

}
