using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    public class LogItems
    { 
        public string Name { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
        public LogItems(string name, string date, string image)
        {
            this.Name = name;
            this.Date = date;
            this.Image = image;
        }
    }
}
