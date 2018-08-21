using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    public class ProjectList
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public ProjectList(string name, string date)
        {
            this.Name = name;
            this.Date = date;
        }
    }
}
