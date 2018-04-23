using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WpfApplication49
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SelectionHelper = new TileSelectionHelper(tileLayoutControl1);
            ObservableCollection<string> list = new ObservableCollection<string>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i.ToString());

            }
            tileLayoutControl1.ItemsSource = list;
            tileLayoutControl1.Focus();
        }


        TileSelectionHelper SelectionHelper;
    
    }
}
