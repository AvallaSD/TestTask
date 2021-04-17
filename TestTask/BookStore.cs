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
                var json = stream.ReadToEnd();
                Books = JsonConvert.DeserializeObject(stream.ReadToEnd()) as ObservableCollection<Book>;
            }
            using (StreamWriter stream = new StreamWriter("books.json"))
            {
                stream.Write(JsonConvert.SerializeObject(Books));
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
