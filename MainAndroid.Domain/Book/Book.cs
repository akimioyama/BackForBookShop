using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAndroid.Domain.Book
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string publisher { get; set; }
        public string year { get; set; }
        public string pages { get; set; }
        public string img_url { get; set; }

        //public Book(int id, string name, string author, string description,
        //    string price, string publisher, string year, string pages, string img_url)
        //{
        //    this.id = id;
        //    this.name = name;
        //    this.author = author;
        //    this.description = description;
        //    this.price = price;
        //    this.publisher = publisher;
        //    this.year = year;
        //    this.pages = pages;
        //    this.img_url = img_url;
        //}
    }
}
