using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFAppEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Timer timer = new Timer(1000);

        int count = 0;
        string buttonContent = "Click Me";
        string labelContent = "Click the button ... I dare you :)";

        public MainWindow()
        {
            InitializeComponent();
            timer.Elapsed += updateClickTimer;

            clickMeButton.Click += startClicktimer;
            clickMeButton.Click += myOwnClickFunc;
        }


        private void clickMeButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!timer.Enabled)
            {
                clickMeLabel.Content = "HEY! I didn't think you'd actually click it :(";
                clickMeButton.Content = "I've been clicked!";
                Console.WriteLine("UI Updated");
            }
            
        }

        private void myOwnClickFunc(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("BUTTON CLICKED");
        }

        private void startClicktimer(object sender, RoutedEventArgs e)
        {
            if (!timer.Enabled)
            {
                timer.Start();
            }
        }

        private void updateClickTimer(object sender, ElapsedEventArgs e)
        {
            count++;
            if (count == 3)
            {
                count = 0;
                // This delegates to work to the UI thread since we are updating UI elements here on another thread.
                App.Current.Dispatcher.Invoke(delegate
                {
                    updateTextAndReenable();
                });

                timer.Stop();
            }
        }

        private void updateTextAndReenable()
        {
            clickMeButton.Content = buttonContent;
            clickMeLabel.Content = labelContent;
            Console.WriteLine("UI Updated");
        }
    }
}
