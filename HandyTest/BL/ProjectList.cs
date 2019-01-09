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
        public string CurrentDate { get; set; }
        public ProjectList(string name, string date, string currentDate)
        {
            this.Name = name;
            this.Date = date;
            this.CurrentDate = currentDate;
        }
    }
}
