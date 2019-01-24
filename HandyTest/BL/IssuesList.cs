using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    public class IssuesList
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public IssuesList(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}
