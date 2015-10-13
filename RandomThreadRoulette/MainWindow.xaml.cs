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
using RandomRouletteLibrary;
using System.Threading;
using System.Windows.Threading;
using RandomThreadRoulette.Infrastructure;
using RandomThreadRoulette.Controls;

namespace RandomThreadRoulette
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameServiceClient _service = new GameServiceClient();
        private User user;
        private DataRoulette dataRoulette;
        private int count = 0;

        private ThreadRoulette thread1;
        private ThreadRoulette thread2;
        private ThreadRoulette thread3;
        public MainWindow()
        {
            InitializeComponent();

            Loaded += delegate { Load(); };
        }

        private void Load()
        {
            user = User.CurrentUser;

            dataRoulette = new DataRoulette();
            txtPoints.Text = "Points: " + user.CurrentPoints.ToString();

            txtUser.Text = user.NickName + " Level: " + user.Level;
        }

        private void MainWindowRoulette_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            StartThreads();

            // Count user games. Value: 5 
            Interlocked.Increment(ref User.UserCurrentStarts);

            if (User.UserCurrentStarts == User.StartsPerGame)
                MyMessageBox.Show("Game info", "Current points: " + user.CurrentPoints, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void StartThreads()
        {
            ThreadRoulette.StartTimer();

            if (user.CurrentPoints >= 30)
            {
                ThreadRoulette.StopTimer();

                // Create new thread 
                Thread fruitThreads = new Thread(new ThreadStart(() =>
                {
                    // Create our context, and install it:
                    SynchronizationContext.SetSynchronizationContext(
                        new DispatcherSynchronizationContext(
                            Dispatcher.CurrentDispatcher));

                    Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);

                    // The main work 
                    thread1 = new ThreadRoulette("Thread roulette 1");
                    thread2 = new ThreadRoulette("Thread roulette 2");
                    thread3 = new ThreadRoulette("Thread roulette 3");

                    // Если потоки не синхронизировать то все значения будут одинаковы!!!
                    thread1.Thrd.Join();
                    thread2.Thrd.Join();
                    thread3.Thrd.Join();

                    // The main work 

                    // Start the Dispatcher Processing
                    System.Windows.Threading.Dispatcher.Run();
                }));

                fruitThreads.Start();

                fruitThreads.Join();

                control1.DataContext = thread1.RoulutteData;
                control2.DataContext = thread2.RoulutteData;
                control3.DataContext = thread3.RoulutteData;

                txtTimer.Text = "The system is thinking: " + ThreadRoulette.TimeElapsed.ToString() + " sec";

                SayResults();

                if (user.CurrentPoints >= 1000)
                    SayWin();
            }
            else
            {
                MessageBox.Show("Get a credit");
                return;
            }

            //ThreadRoulette.StartTimer();

            //if (user.CurrentPoints >= 30)
            //{
            //    user.CurrentPoints = user.CurrentPoints - 50;
            //    thread1 = new ThreadRoulette("Thread roulette 1");
            //    thread2 = new ThreadRoulette("Thread roulette 2");
            //    thread3 = new ThreadRoulette("Thread roulette 3");

            //    // Если потоки не синхронизировать то все значения будут одинаковы!!!
            //    thread1.Thrd.Join();
            //    thread2.Thrd.Join();
            //    thread3.Thrd.Join();

            //    control1.DataContext = thread1.RoulutteData;
            //    control2.DataContext = thread2.RoulutteData;
            //    control3.DataContext = thread3.RoulutteData;

            //    txtTimer.Text = "The system is thinking: " + ThreadRoulette.TimeElapsed.ToString() + " sec";

            //    SayResults();
                
            //    if (user.CurrentPoints >= 1000)
            //        SayWin();
            //}
            //else
            //{
            //    MessageBox.Show("Get a credit");
            //    return;            
            //}
            //ThreadRoulette.StopTimer();

        }

        private void SayResults()
        {
            int res = 0;
            res = dataRoulette.CompareResult(thread1.RoulutteData, thread2.RoulutteData, thread3.RoulutteData);
            user.CurrentPoints += res;

            txtNumb.Text = "You win money: " + res.ToString();
            txtPoints.Text = "Points: " + user.CurrentPoints;

            // Match the all results and cacl them
            txtResNumbers.Text = "Numbers: " + MyNumber.CurrentResult;
            txtResImages.Text = "Images: " + MyImage.CurrentResult;
            txtRes.Text = "Sum res: " +
                            MyNumber.SumDivByTwo(thread1.RoulutteData.Number, thread2.RoulutteData.Number, thread3.RoulutteData.Number)
                          + " + " + MyNumber.CurrentResult + " + " + MyImage.CurrentResult + " = "
                          + (MyImage.CurrentResult + MyNumber.CurrentResult + 
                          MyNumber.SumDivByTwo(thread1.RoulutteData.Number, thread2.RoulutteData.Number, thread3.RoulutteData.Number));

            ChangeColorPanel(MainResultPanel);
        }

        private void SayWin()
        {
            imageWin.Visibility = System.Windows.Visibility.Visible;
        }

        private void ChangeColorPanel(Panel panel)
        {
            count++;
            bool isTrue = count % 2 == 0;

            panel.Background = Brushes.LightGreen;

            if (isTrue) panel.Background = Brushes.AliceBlue;           
        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            Task<bool> res = _service.SendPoints(user.CurrentPoints, user.NickName);

            new RandomThreadRoulette.View.MenuWindow().Show();
            this.Close();
        }       
    }
}
