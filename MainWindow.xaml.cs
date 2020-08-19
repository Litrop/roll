using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace roll
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Random random = new Random();

        private Boolean isRolling = false;

        public Boolean IsRolling
        {
            get
            {
                return isRolling;
            }
            set
            {
                isRolling = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RollButtonText"));
            }
        }

        public string RollButtonText
        {
            get
            {
                if (isRolling)
                {
                    return "Stop rolling";
                }
                else
                {
                    return "Start rolling";
                }
            }
        }

        private int endNumber = 99;

        public int EndNumber
        {
            get
            {
                return endNumber;
            }
            set
            {
                endNumber = value;
            }
        }

        private int randomNumber;

        public int RandomNumber
        {
            get
            {
                return randomNumber;
            }
            set
            {
                randomNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RandomNumber"));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleRoll(object sender, RoutedEventArgs args)
        {
            IsRolling = !IsRolling;
            Task.Run(Rolling);
        }

        private async void Rolling()
        {
            while (isRolling)
            {
                RandomNumber = random.Next(1, endNumber + 1);
                await Task.Delay(100);
            }
        }
    }
}
