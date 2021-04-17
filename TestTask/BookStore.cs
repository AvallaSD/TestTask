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
                Books = JsonConvert.DeserializeObject(stream.ReadToEnd()) as ObservableCollection<Book>;
            }
        }
        
        public ObservableCollection<Book> Books { get; set; }

        public void Sort()
        {

        }

        public void Buy()
        {

        }

    }
}
