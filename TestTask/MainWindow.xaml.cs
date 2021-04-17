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
            foreach (var property in typeof(Book).GetProperties())
            {
                gridView.Columns.Add(new GridViewColumn() { Header = property.Name, DisplayMemberBinding = new Binding(property.Name) });
            }
        }
    }
}
