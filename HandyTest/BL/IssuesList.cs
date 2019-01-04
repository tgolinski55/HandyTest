using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    class IssuesList
    {
        public string Name { get; set; }
        public IssuesList(string name)
        {
            this.Name = name;
        }
    }
}
