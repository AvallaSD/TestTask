using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TestTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookStore store;
        public MainWindow()
        {
            InitializeComponent();
            store = new BookStore();
            listview.ItemsSource = store.Books;
            gridView.Columns.RemoveAt(0);
            foreach (var property in typeof(Book).GetProperties())
            {
                var currentHeader = new GridViewColumnHeader();
                currentHeader.Content = property.Name;
                currentHeader.Click += CurrentHeader_Click;
                gridView.Columns.Add(new GridViewColumn() { Header = currentHeader, 
                    DisplayMemberBinding = new Binding(property.Name),  });
            }
        }


        private void CurrentHeader_Click(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            store.Sort(headerClicked.Content.ToString());
            listview.ItemsSource = store.Books;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            store.Buy(listview.SelectedIndex);
            listview.ItemsSource = store.Books;
        }
    }
}
