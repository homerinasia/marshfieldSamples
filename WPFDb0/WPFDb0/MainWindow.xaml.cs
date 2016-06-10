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


namespace WPFDb0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        pubsModel db;
        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            popDG(comboBox1.SelectedValue.ToString().Trim());
        }

        private void popDDL()
        {
            var items = db.titles.Select(t => t.type).Distinct();
            comboBox1.ItemsSource = items.ToList();
        }

        private void loaded(object sender, RoutedEventArgs e)
        {
            db = new pubsModel();
            popDDL();
        }

        private void popDG(string type)
        {
            var items = db.titles.Where(t => t.type == type);
            dgrid.ItemsSource = items.ToList();
        }
    }
}
