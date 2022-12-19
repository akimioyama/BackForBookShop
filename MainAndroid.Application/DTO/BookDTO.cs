using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAndroid.Application.DTO
{
    public class BookDTO
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
    }
}
