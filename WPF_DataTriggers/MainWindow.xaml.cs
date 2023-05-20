using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WPF_DataTriggers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            listBox.DisplayMemberPath = nameof(Country.FullInfo);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                (listBox.SelectedItem as Country).Name = "New name";
                (listBox.SelectedItem as Country).ShortName = "BLA";
            }
        }
    }
    class Countries : ObservableCollection<Country>
    {
        public Countries()
        {
            this.Add(new Country("Ukraine", "UA"));
            this.Add(new Country("United Kingdom", "UK"));
            this.Add(new Country("United States of America", "USA"));
            this.Add(new Country("Italy", "ITL"));
        }
    }

    public class Country : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string name;
        private string shortName;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullInfo));
            }
        }
        public string ShortName
        {
            get { return shortName; }
            set
            {
                shortName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullInfo));
            }
        }

        public Country()
        {

        }

        public Country(string name, string shortName)
        {
            Name = name;
            ShortName = shortName;
        }

        public string FullInfo => $"{Name} {ShortName}";
        public override string ToString() => $"{Name} {ShortName}";
    }
}
