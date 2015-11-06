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
using System.Windows.Shapes;
using RandomRouletteLibrary;
using RandomThreadRoulette.Infrastructure;
using System.ServiceModel;
using System.Net;
using System.IO;

using System.Net.Http;
using RandomThreadRoulette.Controls;
using System.Threading;
using System.Windows.Threading;

namespace RandomThreadRoulette.View
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {        
        private User us;
        public StartWindow()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, RoutedEventArgs  e)
        {
            GameServiceClient service = new GameServiceClient();
            Task<bool> isAlive = service.IsAlive();

            if (!isAlive.Result)
            {
                MyMessageBox.Show("Error!", "Can not connect to the server. Start up server", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

            string userName = txtNickName.Text;

            //Thread userLoadThread = new Thread(new ParameterizedThreadStart(delegate
            //    {
            //        us = service.LoadUserInfo(userName);
            //    }));

            //Task myTask = new Task((Action)delegate { us = service.LoadUserInfo(userName); });

            //userLoadThread.Join();



            Thread userLoadThread = new Thread(new ThreadStart(() =>
            {
                // Create our context, and install it:
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(
                        Dispatcher.CurrentDispatcher));

                Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);

                us = service.LoadUserInfo(userName);

                // Start the Dispatcher Processing
                System.Windows.Threading.Dispatcher.Run();
            }));
            // Setup and start thread as before
            userLoadThread.Start();

            userLoadThread.Join();

            User.CurrentUser = us;

            new MenuWindow().Show();
            this.Close();
        }

        private void borderDragMove_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
