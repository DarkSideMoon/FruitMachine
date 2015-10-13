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
using System.Windows.Media.Animation;

namespace RandomThreadRoulette.View
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private BitmapImage _userLevelImage;
        private User _userCurr;
        private GameServiceClient _service = new GameServiceClient();

        // Animation
        private static string[] TransitionEffects = new[] { "Fade" };
        private string TransitionType;
        private int EffectIndex = 0;

        public MenuWindow()
        {
            InitializeComponent();
            Loaded += delegate { Load(); };
        }

        private void Load()
        {
            _userCurr = User.CurrentUser;
        }

        private void mainBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        #region Button events
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            _service.Save(_userCurr.NickName, _userCurr.CurrentPoints, _userCurr.Debt, _userCurr.Status, _userCurr.Level);
            Environment.Exit(0);
        }

        private void btnRulesGame_Click(object sender, RoutedEventArgs e)
        {
            listAchievements.ItemsSource = null;
            listAchievements.Visibility = System.Windows.Visibility.Collapsed;
            txtRules.Visibility = System.Windows.Visibility.Visible;
            SlideLoad(txtRules);
            
            Task<string> rules = _service.Rules();
            txtRules.Text = rules.Result;
        }

        private void btnSingleGame_Click(object sender, RoutedEventArgs e)
        {
            myUser.Visibility = System.Windows.Visibility.Visible;
            SlideLoad(myUser);

            _userLevelImage = _service.LevelImage(_userCurr.Level);
            _userCurr.LevelImage = _userLevelImage;
            myUser.DataContext = _userCurr;
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void btnGetCredit_Click(object sender, RoutedEventArgs e)
        {
            User us = new User();
            User.CurrentUser.GetCredit();

            SlideLoad(myUser);
            myUser.DataContext = us;
            myUser.DataContext = User.CurrentUser;
        }

        private void btnGetAchievements_Click(object sender, RoutedEventArgs e)
        {
            txtRules.Visibility = System.Windows.Visibility.Collapsed;
            listAchievements.Visibility = System.Windows.Visibility.Visible;

            _userLevelImage = _service.LevelImage(_userCurr.Level);
            _userCurr.LevelImage = _userLevelImage;
            SlideLoad(listAchievements);

            List<Achievement> resAchivements = _service.GetAchieve(_userCurr.NickName);
            listAchievements.ItemsSource = resAchivements;
        }
        #endregion

        #region Animation Method
        private void SlideLoad(FrameworkElement element)
        {
            try
            {
                TransitionType = TransitionEffects[EffectIndex].ToString();
                Storyboard StboardFadeOut = (Resources[string.Format("{0}Out", TransitionType.ToString())] as Storyboard).Clone();
                StboardFadeOut.Begin(element);
                Storyboard StboardFadeIn = Resources[string.Format("{0}In", TransitionType.ToString())] as Storyboard;
                StboardFadeIn.Begin(element);
            }
            catch (Exception) { }
        }

        private void SlideUnLoad(FrameworkElement element)
        {
            try
            {
                TransitionType = TransitionEffects[EffectIndex].ToString();
                Storyboard StboardFadeIn = Resources[string.Format("{0}In", TransitionType.ToString())] as Storyboard;
                StboardFadeIn.Begin(element);
                Storyboard StboardFadeOut = (Resources[string.Format("{0}Out", TransitionType.ToString())] as Storyboard).Clone();
                StboardFadeOut.Begin(element);
            }
            catch (Exception) { }
        }
        #endregion
    }
}
