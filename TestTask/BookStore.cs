using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestTask
{
    class BookStore
    {
        public BookStore()
        {
            using (StreamReader stream = new StreamReader("books.json"))
            {
                Books = JsonConvert.DeserializeObject<ObservableCollection<Book>>(stream.ReadToEnd());
            }
        }
        
        public ObservableCollection<Book> Books { get; set; }

        public void Sort(string propertyName)
        {
            Books = new ObservableCollection<Book>(Books.OrderBy(x =>
            typeof(Book).GetProperties().Where(x => x.Name == propertyName).Single().GetValue(x)));
        }

        public void Buy(int index)
        {
            Books.RemoveAt(index);
        }

    }
}
